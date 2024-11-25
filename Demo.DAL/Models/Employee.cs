using Demo.DAL.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    
        public int Age { get; set; }

        public string Address { get; set; }

        public decimal Salary { get; set; }

        public bool  IsActive { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }

        public string ImageName { get; set; }

        //public IFormFile Image { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("department")]
        public int? DepartmentId {get; set; }
        [InverseProperty("Employees")]
        public Department department { get; set; }

    }
}
