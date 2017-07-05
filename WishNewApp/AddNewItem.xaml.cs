using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WishNewApp
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Window
    {
        ServiceReference1.ServiceClient serviceReference;

        public AddNewItem()
        {
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void getServiceReference(ServiceReference1.ServiceClient reference)
        {
            serviceReference = reference;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get current elements
            ServiceReference1.ServiceClient ProxySOAP = new ServiceReference1.ServiceClient();
            ServiceReference1.Product[] listOfProducts = ProxySOAP.GetProducts();

            ServiceReference1.Product newProduct = new ServiceReference1.Product();
            //newProduct.ProdNo = listOfProducts[listOfProducts.Length - 1].ProdNo + 1;
            newProduct.ProdNo = Int32.Parse(productNoBox.Text);
            newProduct.Name = nameBox.Text;
            newProduct.MadeOf = madeOfBox.Text;
            newProduct.Quantity = Int32.Parse(quantityBox.Text);

            ProxySOAP.InsertNewProduct(newProduct);
        }
    }
}
