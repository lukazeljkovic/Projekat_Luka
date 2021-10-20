using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool isDeleted { get; set; }
    }
}
