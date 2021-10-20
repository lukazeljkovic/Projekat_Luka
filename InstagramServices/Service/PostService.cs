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
    public class PostService : IPostService
    {
        private IGenericRepository<Post> _postRepository;
        private IGenericRepository<User> _userRepository;

        static void PostServiceMapper() => MappsterService.PostServiceMapper();

        public PostService(IGenericRepository<Post> postRepository, IGenericRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<List<PostDto>> GetAll()
        {
            var posts = await _postRepository.GetAll();
            var dtoPosts = posts.Select(post => new PostDto
            {
                Content = post.Content,
                DateCreated = post.DateCreated,
                Id = post.Id,
                isDeleted = post.isDeleted,
                UserId = post.User != null ? post.User.Id : 0
            });
            var result = await dtoPosts.ToListAsync();

            return await Task.Run(() => result);
        }

        public async Task<PostDto> GetById(int id)
        {
            var post = await _postRepository.GetById(id);

            var result = new PostDto
            {
                Content = post.Content,
                DateCreated = post.DateCreated,
                Id = post.Id,
                isDeleted = post.isDeleted,
                UserId = post.User != null ? post.User.Id : 0
            };

            return await Task.Run(() => result);
        }

        
        public async Task Add(PostDto postDto)
        {
            var user = await _userRepository.GetById(postDto.UserId);
            var postMapped = TypeAdapter.Adapt<PostDto,Post>(postDto);
            postMapped.User = user;            
            
            await _postRepository.Add(postMapped);
        }

        public async Task Remove(int id)
        {
             await _postRepository.Remove(id);
        }

        public async Task Edit(PostDto postDto)
        {
            User user = await _userRepository.GetById(postDto.UserId);
            Post post = new Post
            {
                User = user,
                Content = postDto.Content,
                DateCreated = postDto.DateCreated,
                Id = postDto.Id,
                isDeleted = postDto.isDeleted,
            };
            await _postRepository.Edit(post);
        }
    }
}
