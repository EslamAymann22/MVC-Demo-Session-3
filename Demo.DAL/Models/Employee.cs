using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Max is 10")]
        [MinLength(2,ErrorMessage ="Min is 2")]
        public string Name { get; set; }
        [Range(18 , 35 , ErrorMessage ="Age Must be between 18 and 35")]
        public int Age { get; set; }
        //[RegularExpression("")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool  IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone {  get; set; }

        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;


    }
}
