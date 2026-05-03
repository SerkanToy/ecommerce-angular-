using ecommerce.api.Models.Domain.Abstractions;
using System;

namespace ecommerce.api.Models.Domain.Entities.Employees
{
    public class ProductJoinCategori: Entity
    {
        public ProductJoinCategori()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoriId { get; set; }
        public Categori Categori { get; set; }
    }
}
