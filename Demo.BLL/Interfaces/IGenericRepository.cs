using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T Item);
        void Update(T Item);
        void Delete(T Item);
        //IEnumerable<T> SearchWithName(string Name);
        

    }
}
