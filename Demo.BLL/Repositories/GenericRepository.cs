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
        public async Task AddAsync(T Item)
        {
            await _DbContext.AddAsync(Item);
        }

        public void Delete(T Item)
        {
            _DbContext.Remove(Item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        { 

            if(typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)await _DbContext.Employees.Include(E => E.department).ToListAsync();
            }

            return await _DbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int Id)
            => await _DbContext.Set<T>().FindAsync(Id);

        public void Update(T Item)
        {
            _DbContext.AddAsync(Item);
        }

        //public IQueryable<T> SearchWithName(string SearchName) 
        //   => _DbContext.Set<T>().Where(I => I.Name.ToLower().Contains(SearchName.ToLower()));

    }
}
