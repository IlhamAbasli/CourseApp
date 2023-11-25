using Domain.Common;
using Domain.Models;
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

        public bool Delete(int id)
        {
            List<T> datas = AppDbContext<T>.Datas;
            bool result = false;
            foreach (var data in datas.ToList())
            {
                if (data.Id == id)
                {
                    datas.Remove(data);
                    result = true;
                }
            }
            return result;
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
