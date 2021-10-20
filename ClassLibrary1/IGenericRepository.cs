using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface IGenericRepository <T> where T : class, IBaseModel
    {
        Task<T> GetById(int id);
        Task<IQueryable<T>> GetAll();
        Task Add(T entity);
        Task Remove(int id);
        Task Edit(T entity);
    }
}
