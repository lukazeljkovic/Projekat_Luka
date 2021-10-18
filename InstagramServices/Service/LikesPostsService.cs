using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServices.Service.IService
{
    public class LikesPostsService : ILikesPostsService
    {
        IGenericRepository<LikesPosts> _likesPostsRepository;
        IGenericRepository<Post> _postRepository;
        IGenericRepository<User> _userRepository;

        public LikesPostsService(IGenericRepository<LikesPosts> likesPostsRepository, IGenericRepository<User> userRepository, IGenericRepository<Post> postRepository)
        {
            _likesPostsRepository = likesPostsRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task Add(LikesPosts like)
        {
            
            
                var users = await _userRepository.GetAll();
                var user = users.Include(x => x.LikesPosts).ThenInclude(x => x.Post).FirstOrDefault(x => x.Id == like.UserId);
                user.LikesPosts.Add(like);
            try
            {
                await _userRepository.Edit(user);
            }
            catch (Exception e)
                {
                var a = 2;
            }
            // await _likesPostsRepository.Add(like);


            //List<LikesPosts> userLikes = c.LikesPosts;
            //userLikes.Add(like);


            //Post post =  await _postRepository.GetById(like.PostId);
            //List<LikesPosts> postLikes = post.LikesPosts;
            //postLikes.Add(like);



        }

        public async Task Edit(LikesPosts like)
        {
            await _likesPostsRepository.Edit(like);
        }

        public async Task<List<LikesPosts>> GetAll()
        {
            var users = _likesPostsRepository.GetAll();
            var result = await users;


            return await Task.Run(() => result.ToListAsync());
        }

        public Task<LikesPosts> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
