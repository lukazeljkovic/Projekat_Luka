using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace Repository.Models
{
    public class User : BaseModel
    {
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<LikesPosts> LikesPosts { get; set; }

    }
}
