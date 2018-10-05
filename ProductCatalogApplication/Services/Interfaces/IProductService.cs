using Domain;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();

        IEnumerable<ProductDto> Search(string searchText);

        ProductDto GetById(int id);

        void Add(ProductDto product);

        void Update(ProductDto product);

        void Delete(int id);
    }
}
