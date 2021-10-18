using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Add( T entity);
        Task Remove(int id);
        Task Edit(int id);
    }
}
