using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.MyContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository :   GenericRepository<Employee> , IEmployeeRepository
    {

        private readonly MvcAppDbContext _DbContext;
        public EmployeeRepository(MvcAppDbContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
        public IQueryable<Employee> FindWithAddress(string address)
            =>_DbContext.Employees.Where(E => E.Address == address);
        
        
      /*  public int Add(Employee employee)
        {
            _DbContext.Add(employee);
            return _DbContext.SaveChanges();
        }
        

        public int Delete(Employee employee)
        {
            _DbContext.Remove(employee);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
            => _DbContext.Employees.ToList();

        public Employee GetById(int Id)
            => _DbContext.Employees.Find(Id);

        public int Update(Employee employee)
        {
            _DbContext.Add(employee);
            return _DbContext.SaveChanges();
        }*/
    }
}
