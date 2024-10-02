using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key] // Marking this property as the primary key
        public Guid Id { get; set; }= Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; } =DateTime.Now;
        public string? LastUpdatedBy { get; set; }
    }
}
