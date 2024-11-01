using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.MyContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>  where T : class
    {

        private readonly MvcAppDbContext _DbContext;
        public GenericRepository(MvcAppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public int Add(T Item)
        {
            _DbContext.Add(Item);
            return _DbContext.SaveChanges();
        }

        public int Delete(T Item)
        {
            _DbContext.Remove(Item);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        { 

            if(typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _DbContext.Employees.Include(E=>E.department).ToList();
            }

            return _DbContext.Set<T>().ToList();
        }
        public T GetById(int Id)
            => _DbContext.Set<T>().Find(Id);

        public int Update(T Item)
        {
            _DbContext.Update(Item);
            return _DbContext.SaveChanges();
        }

        //public IQueryable<T> SearchWithName(string SearchName) 
        //   => _DbContext.Set<T>().Where(I => I.Name.ToLower().Contains(SearchName.ToLower()));

    }
}
