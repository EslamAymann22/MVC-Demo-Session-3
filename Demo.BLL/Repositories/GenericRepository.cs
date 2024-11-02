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
        public void Add(T Item)
        {
            _DbContext.Add(Item);
        }

        public void Delete(T Item)
        {
            _DbContext.Remove(Item);
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

        public void Update(T Item)
        {
            _DbContext.Update(Item);
        }

        //public IQueryable<T> SearchWithName(string SearchName) 
        //   => _DbContext.Set<T>().Where(I => I.Name.ToLower().Contains(SearchName.ToLower()));

    }
}
