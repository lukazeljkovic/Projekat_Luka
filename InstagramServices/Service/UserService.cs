using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstagramServices.Service
{
   public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var result = users.ToListAsync();


            return await Task.Run(() =>  result );
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return  user;

        }

        public async Task Add(User user)
        {
            await _userRepository.Add(user);
            
        }

        public async Task Remove(int id)
        {
            await _userRepository.Remove(id);
                    
        }

        public async Task Edit(User user)
        {
            await _userRepository.Edit(user);
        }
    }
}
