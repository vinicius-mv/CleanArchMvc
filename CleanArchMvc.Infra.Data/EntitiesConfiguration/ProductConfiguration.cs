using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10, 2);

            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

            builder.HasData(
                new Product(1, "Notebook: Leopard Print", "Composition Notebook - College Ruled 110 Pages - Large 8.5 x 11", 4.99m, 20, "notebook-leopard.jpg"),
                new Product(2, "Large Pencil Case", "Big Capacity Pencil Bag Large Storage Pouch 3 Compartments", 9.99m, 15, "large-pencil-case.jpg"),
                new Product(3, "Pentel Hi-Polymer Block Eraser", "Large, White, Pack of 4", 2.99m, 30, "pentel-pack4-eraser.jpg"),
                new Product(4, "Scientific Calculator", "Texas Instruments TI-30Xa", 8.94m, 10, "texas-scientific-calculator.jpg"));

        }
    }
}
