using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class Comment : BaseModel
    {
        
        [Required]
        public string Content { get; set; }


        [Required]
        public User User { get; set; }

        [Required]
        public List<User> Likes { get; set; }

        [Required]
        public int NumOfLikes { get; set; }



    }
}
