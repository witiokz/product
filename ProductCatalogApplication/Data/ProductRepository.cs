using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductCatalogContext dbContext;

        public ProductRepository(ProductCatalogContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Set<Product>();
        }

        public Product GetById(int id)
        {
            return dbContext.Set<Product>().Find(id);
        }

        public Product GetByCode(string code)
        {
            return dbContext.Set<Product>().FirstOrDefaultAsync(i => i.Code == code).Result;
        }

        public IEnumerable<Product> Search(string searchText)
        {
            return dbContext.Set<Product>().Where(i => i.Code == searchText || i.Name == searchText);
        }

        public Product Add(Product entity)
        {
            dbContext.Set<Product>().Add(entity);
            dbContext.SaveChanges();

            return entity;
        }

        public void Update(Product entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            dbContext.Set<Product>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
