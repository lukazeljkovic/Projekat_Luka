using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class CommentDto : BaseModel
    {
        [Required]
        public string Content { get; set; }


        [Required]
        public int UserId { get; set; }
    }
}
