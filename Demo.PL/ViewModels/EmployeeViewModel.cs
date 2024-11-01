using Demo.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Max is 10")]
        [MinLength(2, ErrorMessage = "Min is 2")]
        public string Name { get; set; }
        [Range(18, 35, ErrorMessage = "Age Must be between 18 and 35")]
        public int Age { get; set; }
        //[RegularExpression("")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public DateTime HireDate { get; set; }
        //public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("department")]
        public int? DepartmentId { get; set; }
        [InverseProperty("Employees")]
        public Department department { get; set; }

    }
}
