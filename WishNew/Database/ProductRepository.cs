using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishNew.Database
{
    public class ProductRepository
    {
        private ProductsClassesDataContext context = new ProductsClassesDataContext();

        public IEnumerable<WishNew.Product> GetAll()
        {
            var query =
                from obj in context.Products
                select new WishNew.Product()
                {
                    ProdNo = obj.ProdNo,
                    Quantity = obj.Quantity.Value,
                    Name = obj.Name,
                    MadeOf = obj.MadeOf

                };
            return query;
        }
        
        public void insertNewElementToDB(WishNew.Product newProduct)
        {
            Product product = new Product()
            {
                ProdNo = newProduct.ProdNo,
                Quantity = newProduct.Quantity,
                Name = newProduct.Name,
                MadeOf = newProduct.MadeOf
            };

            context.Products.InsertOnSubmit(product);
            context.SubmitChanges();
        }

        public void insertManyElements(WishNew.Product[] products)
        {
            foreach (WishNew.Product prod in products)
                insertNewElementToDB(prod);
        }

        public void deleteElement(WishNew.Product existingProduct)
        {
            Product dbProduct = new Product()
            {
                ProdNo = existingProduct.ProdNo,
                Name = existingProduct.Name,
                Quantity = existingProduct.Quantity,
                MadeOf = existingProduct.MadeOf
            };

            context.Products.Attach(dbProduct);
            context.Products.DeleteOnSubmit(dbProduct);
            context.SubmitChanges();
        }
    }
}