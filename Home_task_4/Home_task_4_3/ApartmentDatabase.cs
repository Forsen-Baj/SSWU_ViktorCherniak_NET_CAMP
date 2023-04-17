using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_4_3
{
    public class ApartmentDatabase
    {
        private Dictionary<int, Apartment> _db;

        public ApartmentDatabase()
        {
            _db = new Dictionary<int, Apartment>();
        }

        public void AddElectricityRecord(string reading, int quarter)
        {
            if (reading == null)
                return;

            var parsedValues = reading.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int n = parsedValues.Length;
                int apartmentNumber = Int32.Parse(parsedValues[0]);
                string address = String.Join(" ", parsedValues, 1, n - 5);
                string lastName = parsedValues[n - 4];
                int firstReading = Int32.Parse(parsedValues[n - 3]);
                int lastReading = Int32.Parse(parsedValues[n - 2]);
                DateTime date = DateTime.Parse(parsedValues[n - 1]);

                if ((date.Month - 1) / 3 + 1 != quarter)
                    throw new Exception($"Date {date} is not withing quarter {quarter}");

                AddEntry(apartmentNumber, address, firstReading, lastReading, date, lastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}\nCan't read values from:\n[{reading}]\n");
            }
        }

        public string GetFullReport()
        {
            //string report = $"Apartment\tLast Name\tFirst Record\tLast Record\tFirst Record Date\tLast Record Date\n";
            string report = $"{"Apartment",-12}{"Last Name", -15}{"First Record", -15}{"Last Record",-15}{"First Record Date",-20}{"Last Record Date",-20}{"Days ago",-10}\n";

            foreach (var entry in _db)
                report += entry.Value.ToString();

            return report;
        }

        public string GetOneEntry(int number, bool header = false)
        {
            if (!_db.ContainsKey(number))
                return "No entry";

            if (!header)
                return _db[number].ToString();

            return $"{"Apartment",-12}{"Last Name",-15}{"First Record",-15}{"Last Record",-15}{"First Record Date",-20}{"Last Record Date",-20}\n" +
                    _db[number].ToString();
        }

        private void AddEntry(int apartmentNumber, string address, int firstReading, int lastReading, DateTime date, string lastName)
        {
            if (!_db.ContainsKey(apartmentNumber))
                _db[apartmentNumber] = new Apartment(apartmentNumber, address, lastName);

            _db[apartmentNumber].AddElectricityRecord(date, lastReading);

            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            _db[apartmentNumber].AddElectricityRecord(firstDayOfMonth, firstReading);
        }

        public string FindMaxElectricityUser(double cost)
        {
            if (cost <= 0)
            {
                return $"Invalid cost {cost}";
            }

            int max = 0, number = -1;
            foreach (var user in _db)
            {
                int consumed = user.Value.ConsumedElectricity();
                if (consumed > max)
                {
                    max = consumed;
                    number = user.Key;
                }
            }

            if (number == -1 || max == 0)
                return "DB doesn't have enough information to find max consumer";

            return $"User {_db[number].ownerLastName} consumed {max}kWh, expenses = {cost * max:F2}$";
        }

        public List<int> FindUsersWithZeroConsumption()
        {
            var users = new List<int>();

            foreach (var user in _db)
                if (user.Value.ConsumedElectricity() == 0)
                    users.Add(user.Key);

            return users;
        }

        public void GetDBFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            int quarter = 0;

            if (lines.Length < 2)
                return;
            try
            {
                quarter = Convert.ToInt32(lines[0].Split()[1]);

                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i];
                    AddElectricityRecord(line, quarter);
                }
            }
            catch (Exception)
            {
                throw new Exception("Can't read quarter");
            }
        }

        public void GetDBFromConsole()
        {
            string line = Console.ReadLine();

            try
            {
                var args = line.Split(" ");
                Console.WriteLine(args[0] + "\n" + args[1]);
                int n = Int32.Parse(args[0]);
                int quarter = Int32.Parse(args[1]);

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    AddElectricityRecord(input, quarter);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}\nInvalid input");
            }
        }

        public string HouseExpenses(double cost)
        {
            if (cost <= 0)
                return "Invalid cost";

            string report = $"{"Apartment",-15}{"Consumed",-15}{"Expenses",-15}\n";
            foreach (var user in _db)
            {
                var consumed = user.Value.ConsumedElectricity();
                report += $"{user.Key,-15}{consumed.ToString()+" kWh",-15}{consumed * cost:C}\n";
            }

            return report;
        }
    }
}
