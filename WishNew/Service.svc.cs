using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using WishNew.Database;

namespace WishNew
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)]
    public class Service : IService
    {
        ProductRepository repo = new ProductRepository();

        public Product[] GetProductsMem()
        {
            return new Product[]
            {
                new Product() {ProdNo=0, Quantity=100, Name="Elephant sculpture", MadeOf="Balsa wood"},
                new Product() {ProdNo=1, Quantity=54, Name="Owl sculpture", MadeOf="Oak wood"}
            };
        }

        public Product[] GetProducts()
        {
            return repo.GetAll().ToArray();
        }

        public void InsertNewProduct(Product newProduct)
        {
            repo.insertNewElementToDB(newProduct);
        }

        public void tryAdding100Elements(Product[] listOfProducts)
        {
            repo.insertManyElements(listOfProducts);
        }

        public void deleteElement(Product product)
        {
            repo.deleteElement(product);
        }
    }
}
