using Home_task_13_1;
using static Home_task_13_1.RentalContext;


using (var dbContext = new RentalContext())
{

    dbContext.Database.EnsureCreated();
    var customerRepository = new Repository<Customer>(dbContext);
    var rentalRepository = new Repository<Rental>(dbContext);

    // Add a new customer and create a rental entry
    /*var customer = new Customer
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        PhoneNumber = "1234567890"
    };

    customerRepository.Add(customer);
    dbContext.SaveChanges();

    var rental = new Rental
    {
        CustomerId = customer.CustomerId,
        RentalDate = DateTime.Now,
        ReturnDate = DateTime.Now.AddDays(7),
        TotalAmount = 100.00m
    };

    rentalRepository.Add(rental);
    dbContext.SaveChanges();

    // Delete a customer by ID
    int customerIdToDelete = 1;
    var customerToDelete = customerRepository.GetById(customerIdToDelete);
    if (customerToDelete != null)
    {
        customerRepository.Delete(customerToDelete);
        dbContext.SaveChanges();
    }

    // Update a customer by ID
    int customerIdToUpdate = 2; 
    var customerToUpdate = customerRepository.GetById(customerIdToUpdate);
    if (customerToUpdate != null)
    {
        customerToUpdate.FirstName = "UpdatedFirstName";
        customerToUpdate.LastName = "UpdatedLastName";
        customerRepository.Update(customerToUpdate);
        dbContext.SaveChanges();
    }

    IEnumerable<Rental> rentals = rentalRepository.GetAll();


    // Display rental information
    foreach (var rentall in rentals)
    {
        Console.WriteLine($"Rental ID: {rentall.RentalId}");
        Console.WriteLine($"Customer ID: {rentall.CustomerId}");
        Console.WriteLine($"Rental Date: {rentall.RentalDate}");
        Console.WriteLine($"Return Date: {rentall.ReturnDate}");
        Console.WriteLine($"Total Amount: {rentall.TotalAmount}");
        Console.WriteLine();
    }*/

    // Delete rental

    int rentalIdToDelete = 5;
    var rentalToDelete = rentalRepository.GetById(rentalIdToDelete);
    if (rentalToDelete != null)
    {
        rentalRepository.Delete(rentalToDelete);
        dbContext.SaveChanges();
        Console.WriteLine("Rental deleted successfully.");
    }
    else
    {
        Console.WriteLine("Rental not found.");
    }
}