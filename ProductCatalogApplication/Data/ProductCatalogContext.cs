﻿
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
