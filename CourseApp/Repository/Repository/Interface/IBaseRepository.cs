using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        List<T> Search(string searchText);
        List<T> Sorting(string sortText);
    }
}
