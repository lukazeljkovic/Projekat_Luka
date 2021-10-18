using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service.IService
{
   public interface ILikesPostsService
    {
        Task<LikesPosts> GetById(int id);
        Task<List<LikesPosts>> GetAll();
        Task Add(LikesPosts entity);
        Task Remove(int id);
        Task Edit(LikesPosts entity);
    }
}
