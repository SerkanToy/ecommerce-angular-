using ecommerce.api.Models.Domain.Abstractions;
using System;

namespace ecommerce.api.Models.Domain.Entities.Employees
{
    public class ProductJoinAttribut : Entity
    {
        public ProductJoinAttribut()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid AttributId { get; set; }
        public Attributs Attributs { get; set; }
    }
}
