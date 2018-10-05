using Data.Interfaces;
using Domain;
using Services.Dto;
using Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return from product in productRepository.GetAll()
                   select new ProductDto()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       Code = product.Code,
                       Price = product.Price,
                       Photo = product.Photo,
                       LastUpdated = product.LastUpdated
                   };
        }

        public IEnumerable<ProductDto> Search(string searchText)
        {
            return from product in productRepository.Search(searchText)
                   select new ProductDto()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       Code = product.Code,
                       Price = product.Price,
                       Photo = product.Photo,
                       LastUpdated = product.LastUpdated
                   };
        }

        public ProductDto GetById(int id)
        {
            var product = productRepository.GetById(id);

            if(product != null)
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Price = product.Price,
                    Photo = product.Photo,
                    LastUpdated = product.LastUpdated
                };

            }

            return null;
        }

        public void Add(ProductDto productDto)
        {
            if(productDto != null)
            {
                var product = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Code = productDto.Code,
                    Price = productDto.Price,
                    Photo = productDto.Photo
                };

                product.LastUpdated = DateTime.UtcNow;

                productRepository.Add(product);
            }
        }

        public void Update(ProductDto productDto)
        {
            if (productDto != null)
            {
                var product = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Code = productDto.Code,
                    Price = productDto.Price,
                    Photo = productDto.Photo
                };

                product.LastUpdated = DateTime.UtcNow;

                productRepository.Update(product);
            }
        }

        public void Delete(int id)
        {
            var productDto = GetById(id);

            if (productDto != null)
            {
                var product = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Code = productDto.Code,
                    Price = productDto.Price,
                    Photo = productDto.Photo
                };

                productRepository.Delete(product);
            }
        }

        private void Validate(ProductDto productDto)
        {
            var productCode = productRepository.GetByCode(productDto.Code);

            if(productCode != null)
            {
                throw new Exception("Product code should be unique");
            }

            if(productDto.Price <= 0)
            {
                throw new Exception("Price should be not less than 0");
            }

            if (productDto.Price > 999 && !productDto.IsPriceConfirmed)
            {
                throw new Exception("Price should be confirmed");
            }
        }
    }
}
