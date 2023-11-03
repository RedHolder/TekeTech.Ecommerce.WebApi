using System.ComponentModel.DataAnnotations;

namespace Customer.Api.Models
{
    public class CustomerInfo
    {
       
        [Key]
        public string CustomerID { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

    }
}
