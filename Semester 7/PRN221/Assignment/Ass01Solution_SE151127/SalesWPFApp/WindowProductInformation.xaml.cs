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
using System.Text.RegularExpressions;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProductInformation.xaml
    /// </summary>
    public partial class WindowProductInformation : Window
    {
        public IProductRepository ProductRepository;
        public Product ProductInfor;
        public bool InsertOrUpdate;
        public WindowProductInformation()
        {
            ProductRepository = new ProductRepository();
            InitializeComponent();
            cbCategory.ItemsSource = ProductRepository.GetCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
        }

        public WindowProductInformation(Product product, bool updateFlag)
        {
            ProductRepository = new ProductRepository();
            InitializeComponent();
            cbCategory.ItemsSource = ProductRepository.GetCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
            ProductInfor = product;
            InsertOrUpdate = updateFlag;
            if (InsertOrUpdate) //update
            {
                txtProductId.Text = ProductInfor.ProductId.ToString();
                txtProductName.Text = ProductInfor.ProductName.ToString();
                txtUnitPrice.Text = ProductInfor.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfor.UnitsInStock.ToString();
                txtWeight.Text = ProductInfor.Weight.ToString();
                int indexCategory = Array.FindIndex(ProductRepository.GetCategories().ToArray(), c => c.CategoryId == ProductInfor.CategoryId);
                cbCategory.SelectedIndex = indexCategory;
                txtProductId.IsEnabled = false;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ProductId = 0;
                if (!"".Equals(txtProductId.Text))
                {
                    ProductId = int.Parse(txtProductId.Text);
                }

                var pro = new Product
                {
                    ProductId = ProductId,
                    ProductName = txtProductName.Text,
                    UnitPrice = Decimal.Parse(txtUnitPrice.Text.ToString()),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text.ToString()),
                    CategoryId = ((Category)cbCategory.SelectedItem).CategoryId,
                    Weight = txtWeight.Text
                };
                if (!InsertOrUpdate)//insert
                {
                    ProductRepository.InsertProduct(pro);
                }
                else //update
                {
                    ProductRepository.UpdateProduct(pro);
                }
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
