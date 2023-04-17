using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_4_3
{
    internal class Apartment
    {
        private int apartmentNumber;
        private string address;
        public string ownerLastName;
        private ElectricityValues electricityRecords;
        public bool HasRecords;

        public Apartment(int apartmentNumber, string address, string ownerLastName)
        {
            this.apartmentNumber = apartmentNumber;
            this.address = address;
            this.ownerLastName = ownerLastName;
            this.electricityRecords = new ElectricityValues();
            this.HasRecords = false;
        }

        public void AddElectricityRecord(DateTime date, int value)
        {
            electricityRecords.AddValue(date, value);
            this.HasRecords = true;
        }

        public int ConsumedElectricity()
        {
            var min = electricityRecords.GetMinValues();
            var max = electricityRecords.GetMaxValues();
            return (int)(max.maxValue - min.minValue);
        }

        public override string ToString()
        {
            var min = electricityRecords.GetMinValues();
            var max = electricityRecords.GetMaxValues();

            //return $"{apartmentNumber}\t\t{ownerLastName}\t{min.minValue}\t\t{max.maxValue}\t\t{min.minDate:dd.MMMM.yy}\t\t{max.maxDate:dd.MMMM.yy}\n";
            return $"{apartmentNumber,-12}{ownerLastName,-15}{min.minValue,-15}{max.maxValue,-15}{min.minDate, -20:dd.MMMM.yy}{max.maxDate, -20:dd.MMMM.yy}{(DateTime.Today - max.maxDate).Days} Days\n";

        }

    }
}
