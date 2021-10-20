using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public interface IBaseModel
    {
        public int Id { get; set; }

        public bool isDeleted { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
