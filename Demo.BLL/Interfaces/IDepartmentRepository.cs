﻿using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
       //IEnumerable<Department> GetAll();
       // Department GetById(int Id);
       // int Add(Department department);
       // int Update(Department department);
       // int Delete(Department department);

    }
}
