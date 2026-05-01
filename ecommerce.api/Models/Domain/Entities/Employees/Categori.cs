using ecommerce.api.Models.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ecommerce.api.Models.Domain.Entities.Employees
{
    public class Categori: Entity
    {
        public Categori()
        {
            Id = Guid.CreateVersion7();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? icon { get; set; }
        public ICollection<ProductJoinCategori> ProductJoinCategori { get; set; }
    }
}
