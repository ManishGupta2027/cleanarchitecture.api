using ProductApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Entities.Brands
{
    public class Brand : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Brand name cannot be empty.");
                _name = value;
            }
        }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
