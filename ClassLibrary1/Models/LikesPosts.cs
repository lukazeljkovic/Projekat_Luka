using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class LikesPosts : BaseModel
    {
        public Post Post { get; set; }

        public User User { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]       
        public int PostId { get; set; }
    }
}
