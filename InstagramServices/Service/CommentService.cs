using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using System.Linq;

namespace InstagramServices.Service
{
    public class CommentService : ICommentService
    {
        public IGenericRepository<Comment> _commentRepository;
        public IGenericRepository<User> _userRepository;

        static CommentService() => MappsterService.CommentMapper();

        public CommentService(IGenericRepository<Comment> commentRepository, IGenericRepository<User> userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<List<CommentDto>> GetAll()
        {
            var comments = await _commentRepository.GetAll();
            var listComments = comments.Include(x => x.User);
            var dtoComments = listComments.Select(Mapster.TypeAdapter.Adapt<CommentDto>);

            var result = dtoComments.ToList();

            return await Task.Run(() => result);
        }

        public async Task<CommentDto> GetById(int id)
        {
            var comment = await _commentRepository.GetById(id);

            var result =  new CommentDto
            {
                Content = comment.Content,
                DateCreated = comment.DateCreated,
                Id = comment.Id,
                isDeleted = comment.isDeleted,
                UserId = comment.User != null ? comment.User.Id : 0
            };

            return await Task.Run(() => result);
        }

        public async Task Add(CommentDto commentDto)
        {
            var user = await _userRepository.GetById(commentDto.UserId);
            var commentMapped = TypeAdapter.Adapt<CommentDto, Comment>(commentDto);
            commentMapped.User = user;
            await _commentRepository.Add(commentMapped);
        }

        public async Task Remove(int id)
        {
             await _commentRepository.Remove(id);
        }

        public async Task Edit (CommentDto commentDto)
        {
            User user = await _userRepository.GetById(commentDto.UserId);
            Comment comment = new Comment
            {
                User = user,
                Content = commentDto.Content,
                DateCreated = commentDto.DateCreated,
                Id = commentDto.Id,
                isDeleted = commentDto.isDeleted,
            };

            await _commentRepository.Edit(comment);
        }
    }
}
