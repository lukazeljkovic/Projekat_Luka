using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task Add(User entity);
        Task Remove(int id);
        Task Edit(User entity);
    }
}
