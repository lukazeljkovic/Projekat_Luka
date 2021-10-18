using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service
{
    public interface ICommentService
    {
        Task<CommentDto> GetById(int id);
        Task<List<CommentDto>> GetAll();
        Task Add(CommentDto entity);
        Task Remove(int id);
        Task Edit(CommentDto entity);
    }
}
