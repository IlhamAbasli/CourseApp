using Domain.Common;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        T Edit(int id);
        bool Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
