using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        Product Add(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}
