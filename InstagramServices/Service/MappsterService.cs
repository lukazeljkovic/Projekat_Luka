using Mapster;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramServices.Service
{
    public class MappsterService
    {
        public static void PostServiceMapper()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<PostDto, Post>();
        }

        public static void CommentMapper()
        {
            TypeAdapterConfig<Comment, CommentDto>.NewConfig()
                                                  .Map(dest => dest.UserId,
                                                       src => src.User.Id,
                                                       src => src.User != null);
        }
    }
}
