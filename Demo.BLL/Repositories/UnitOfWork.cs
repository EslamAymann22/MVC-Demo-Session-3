using Demo.BLL.Interfaces;
using Demo.DAL.MyContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvcAppDbContext _DbContext;

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get ; set; }

        public UnitOfWork(MvcAppDbContext dbContext) {
            _DbContext = dbContext;

            EmployeeRepository = new EmployeeRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);

        }

        public int Complete()
        {
           return _DbContext.SaveChanges();
        }
    }
}
