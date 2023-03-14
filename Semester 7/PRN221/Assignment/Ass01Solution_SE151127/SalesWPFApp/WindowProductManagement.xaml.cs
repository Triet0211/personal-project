using BusinessObject;
using DataAccess.Repository;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProductManagement.xaml
    /// </summary>
    public partial class WindowProductManagement : Window 
    {
        public IProductRepository ProductRepository;
        public Member LoginAdmin;
        public WindowProductManagement()
        {
            ProductRepository = new ProductRepository();
            InitializeComponent();
            LoadProductList();
        }

        void LoadProductList()
        {
            var products = ProductRepository.GetProducts();
            try
            {
                dgProducts.ItemsSource = products;
                if (products.Count() == 0)
                {
                    btnDelete.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                }
                else
                {
                    btnDelete.IsEnabled = true;
                    btnUpdate.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }
        void LoadProductList(IEnumerable<Product> products)
        {
            try
            {
                dgProducts.ItemsSource = products;
                if (products.Count() == 0)
                {
                    btnDelete.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                }
                else
                {
                    btnDelete.IsEnabled = true;
                    btnUpdate.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            WindowAdmin windowAdmin = new WindowAdmin()
            {
                LoginAdmin = LoginAdmin
            };
            windowAdmin.Closed += (s, args) => this.Close();
            windowAdmin.Show();
            Hide();
        }
        private void btnLougout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin { };
            windowLogin.Show();
            this.Hide();
        }
        private void btnSearchByEmail_Click(object sender, RoutedEventArgs e)
        {
            if ("".Equals(txtName.Text.ToString()))
            {
                MessageBox.Show("Name input is empty", "Product Management");
            }
            else
            {
                LoadProductList(ProductRepository.GetProductsByName(txtName.Text.ToString()));
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowProductInformation windowProductInfor = new WindowProductInformation()
            {
                Title = "Create New Product",
                InsertOrUpdate = false
            };
            if (windowProductInfor.ShowDialog() == true)
            {
                LoadProductList();
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            LoadProductList(ProductRepository.SortByName());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Product selected = (Product)dgProducts.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Has not selected a product yet. Try again!!!", "Product Management");
                return;
            }
            WindowProductInformation windowProductInfor = new WindowProductInformation(selected, true)
            {
                InsertOrUpdate = true,
                ProductInfor = selected,
                Title = "Update New Product"
            };
            Console.WriteLine(windowProductInfor);
            if (windowProductInfor.ShowDialog() == true)
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete selected product?", "Delete a product", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    Product selected = (Product)dgProducts.SelectedItem;
                    if (selected == null)
                    {
                        MessageBox.Show("Has not selected a product yet. Try again!!!", "Product Management");
                        return;
                    }
                    ProductRepository.DeleteProduct(selected.ProductId);
                    LoadProductList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a product");
            }
        }
    }
}
