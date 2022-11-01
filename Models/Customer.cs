using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        public string Nickname {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
