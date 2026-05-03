using ecommerce.api.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Employees
{
    public class Attributs : Entity
    {
        public Attributs()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductJoinAttribut> ProductJoinAttributs { get; set; }    
    }
}
