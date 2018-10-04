using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        //public IEnumerable<T> List(ISpecification<T> spec)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = spec.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = spec.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return secondaryResult
        //                    .Where(spec.Criteria)
        //                    .AsEnumerable();
        //}

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
