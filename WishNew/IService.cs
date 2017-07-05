using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WishNew
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Xml)]
        Product[] GetProducts();
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Xml)]
        void InsertNewProduct(Product newProduct);
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Xml)]
        void tryAdding100Elements(Product[] listOfProducts);
        [WebGet(UriTemplate = "/Products", ResponseFormat = WebMessageFormat.Xml)]
        void deleteElement(Product product);

    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProdNo { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string MadeOf { get; set; }

    }
}
