using Domain.Common;
using Repository.Datas;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private static int _id = 1;
        public void Create(T entity)
        {
            entity.Id = _id++;
            AppDbContext<T>.Datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.Datas.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.Datas.ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.Datas.FirstOrDefault(x => x.Id == id);   
        }

    }
}
