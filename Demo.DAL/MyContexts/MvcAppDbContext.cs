using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.MyContexts
{
    public class MvcAppDbContext : IdentityDbContext<ApplicationUser>
    {

        public MvcAppDbContext(DbContextOptions<MvcAppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer(
        //        "Server = . ; Database = MvcProjectDb ; Trusted_connection = True ; Trust Server Certificate = True");



        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }
        //public DbSet<IdentityUser>Users { get; set; }//=> in IdentityDbContext 
        //public DbSet<IdentityRole>Roles { get; set; }//=> in IdentityDbContext 


    }
}
