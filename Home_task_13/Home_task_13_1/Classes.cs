using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_13_1
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }


    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }


    public class Equipment
    {
        public int EquipmentId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public int QuantityAvailable { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<RentalItem> RentalItems { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }


    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }

    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public ICollection<RentalItem> RentalItems { get; set; }
    }

    public class RentalItem
    {
        public int RentalItemId { get; set; }
        public int RentalId { get; set; }
        public int EquipmentId { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalItemAmount { get; set; }

        public Rental Rental { get; set; }
        public Equipment Equipment { get; set; }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
    }

    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhoneNumber { get; set; }

        public ICollection<Supply> Supplies { get; set; }
    }

    public class Supply
    {
        public int SupplyId { get; set; }
        public int SupplierId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime SupplyDate { get; set; }
        public int QuantitySupplied { get; set; }

        public Supplier Supplier { get; set; }
        public Equipment Equipment { get; set; }
    }
}
