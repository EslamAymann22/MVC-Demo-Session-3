using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.MyContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public  class DepartmentRepository : IDepartmentRepository
    {
        private MvcAppDbContext _MyConn;

        public DepartmentRepository(MvcAppDbContext MyConn)
        {
            //MyConn = new MvcAppDbContext();
            _MyConn = MyConn;
        }
        public int Add(Department department)
        {
            _MyConn.Add(department);
            return _MyConn.SaveChanges();
        }

        public int Delete(Department department)
        {
            _MyConn.Remove(department);
            return _MyConn.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
            => _MyConn.Departments.ToList();

        public Department GetById(int Id)
        {
            //var res = _MyConn.Departments.Local.Where(D => D.Id == Id).FirstOrDefault();
            //if (res is null)
            //    res = _MyConn.Departments.Where(D => D.Id == Id).FirstOrDefault();
            //return res;
            return _MyConn.Departments.Find(Id);
        }
        public int Update(Department department)
        {
            _MyConn.Update(department);
            return _MyConn.SaveChanges();
        }
    }
}
