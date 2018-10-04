using Data.Interfaces;
using Domain;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public Product Add(Product product)
        {
            return productRepository.Add(product);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public void Delete(Product product)
        {
            productRepository.Update(product);
        }
    }
}
