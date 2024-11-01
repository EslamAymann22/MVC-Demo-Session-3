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
        int Add(T Item);
        int Update(T Item);
        int Delete(T Item);
        //IEnumerable<T> SearchWithName(string Name);
        

    }
}
