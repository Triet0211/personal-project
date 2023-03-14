using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        protected BaseEntity()
        {
        }

        protected BaseEntity(string id)
        {
            Id = id;
        }

        public bool IsDeleted { 
            get {
                if (DeletedAt == null)
                {
                    return false;
                }
                return true;
            } 
        }

    }
}
