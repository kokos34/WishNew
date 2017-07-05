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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;

using System.Runtime.Serialization;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;

namespace WishNewApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        ServiceReference1.ServiceClient ProxySOAP;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private readonly Random random1 = new Random();
        

        public MainWindow()
        {
            InitializeComponent();
            refresh();
            
            

            /*Stopwatch watch = new Stopwatch();
            watch.Start();
            testAddingNElements(10);
            refresh();
            watch.Stop();
            Console.WriteLine("Time taken for 10 additional products to be added: " + watch.Elapsed.TotalSeconds.ToString());

            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            testAddingNElements(100);
            refresh();
            watch1.Stop();
            Console.WriteLine("Time taken for 100 more products to be added: " + watch1.Elapsed.TotalSeconds.ToString());

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            testAddingNElements(1000);
            refresh();
            watch2.Stop();
            Console.WriteLine("Time taken for 500 more products to be added: " + watch2.Elapsed.TotalSeconds.ToString());*/
        }

        private void btnSoapClicked(object sender, RoutedEventArgs s)
        {
            refresh();
        }

        private void addProductButtonClicked(object sender, RoutedEventArgs s)
        {
            AddNewItem window = new AddNewItem();
            window.getServiceReference(ProxySOAP);
            window.Closing += OnWindowClosing;
            window.Show();
        }

        private void refresh()
        {
            ProxySOAP = new ServiceReference1.ServiceClient();
            ProdSOAP.ItemsSource = ProxySOAP.GetProducts();            
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            refresh();
        }
        

        public void testAddingNElements(int N)
        {
            //ServiceReference1.ServiceClient ProxySOAP = new ServiceReference1.ServiceClient();
            ServiceReference1.Product[] listOfProducts = ProxySOAP.GetProducts();
            int lastProductNo = listOfProducts[listOfProducts.Length - 1].ProdNo;
            List<ServiceReference1.Product> list = new List<ServiceReference1.Product>();

            // Mapping to List<>
            for(int i = 0; i < listOfProducts.Length; i++)
            {
                list.Add(listOfProducts[i]);
            }

            // Adding 100 random points
            for(int i = 0; i < N; i++)
            {
                ServiceReference1.Product newProduct = new ServiceReference1.Product();

                int length = RandomNumber(4, 8);

                newProduct.Name = generateRandomName(length);
                newProduct.ProdNo = (lastProductNo + i);
                newProduct.Quantity = RandomNumber(5, 300);

                if ((i % 2 == 0) || (i % 3 == 0))
                    newProduct.MadeOf = "wood";
                else if (i % 5 == 0)
                    newProduct.MadeOf = "balsa";
                else
                    newProduct.MadeOf = "suar";

                list.Add(newProduct);
            }

            ServiceReference1.Product[] products = list.ToArray();
            
            ProxySOAP.tryAdding100Elements(products);
        }



        private string generateRandomName(int length)
        {
            lock (syncLock)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[length];

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random1.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                return finalString;
            }
            
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        private void Deleteelements_Click(object sender, RoutedEventArgs e)
        {
            int selectedRow = ProdSOAP.SelectedIndex;

            ServiceReference1.Product product = ProdSOAP.SelectedItem as ServiceReference1.Product;
            ProxySOAP.deleteElement(product);

            refresh();
        }
    }
}
