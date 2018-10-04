using Domain;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        Product GetByCode(string code);

        Product Add(Product entity);
       
        void Update(Product entity);

        void Delete(Product entity);
    }
}
