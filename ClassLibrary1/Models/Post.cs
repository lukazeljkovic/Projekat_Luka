using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Post : BaseModel
    {
        [Required]
        public User User { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public List<LikesPosts> LikesPosts { get; set; }

        [Required]
        public int NumOfLikes { get; set; }
    }
}
