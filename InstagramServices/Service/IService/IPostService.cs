using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service
{
    public interface IPostService
    {
        Task<PostDto> GetById(int id);
        Task<List<PostDto>> GetAll();
        Task Add( PostDto entity);
        Task Remove(int id);
        Task Edit(PostDto entity);
    }
}
