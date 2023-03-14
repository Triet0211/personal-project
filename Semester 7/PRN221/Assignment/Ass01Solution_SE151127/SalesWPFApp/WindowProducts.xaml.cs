using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        public IProductRepository ProductRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public Member LoginMember { get; set; }
        public Cart Cart { get; set; }
        public WindowProducts()
        {
            ProductRepository = new ProductRepository();
            CartRepository = new CartRepository();
            InitializeComponent();
            LoadProductList(ProductRepository.GetProducts());
        }
        private void btnLougout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin { };
            windowLogin.Show();
            this.Hide();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        void LoadProductList(IEnumerable<Product> products)
        {
            try
            {
                dgProducts.ItemsSource = products;
                dgProducts.EnableColumnVirtualization = false;
                if (products.Count() == 0)
                {
                    btnSearchByName.IsEnabled = false;
                    btnAddToCart.IsEnabled = false;
                    txtProductName.IsReadOnly = true;
                    txtProductNameToSearch.IsReadOnly = true;
                }
                else
                {
                    btnSearchByName.IsEnabled = true;
                    btnAddToCart.IsEnabled = true;
                    txtProductName.IsReadOnly = false;
                    txtProductNameToSearch.IsReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            WindowMembers windowMember = new WindowMembers()
            {
                LoginMember = LoginMember
            };
            windowMember.Closed += (s, args) => this.Close();
            windowMember.Show();
            Hide();
        }

        private void btnViewCart_Click(object sender, RoutedEventArgs e)
        {
            WindowCart windowCart = new WindowCart(LoginMember, Cart);
            if (windowCart.ShowDialog() == true)
            {
                MessageBox.Show("Checkout successfully!!!", "View Cart");
                WindowMembers windowMember = new WindowMembers
                {
                    MemberRepository = new MemberRepository(),
                    LoginMember = LoginMember
                };
                windowMember.Show();
                Hide();
            }
        }

        private void btnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            var name = txtProductNameToSearch.Text.ToString();
            if ("".Equals(name))
            {
                MessageBox.Show("Please input a name to search!!!", "Add to cart");
                return;
            }
            LoadProductList(ProductRepository.GetProductsByName(name));
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product selected = (Product)dgProducts.SelectedItem;
                if (selected == null)
                {
                    MessageBox.Show("Please choose a product to add!!!", "Add to cart");
                    return;
                }
                if (!"".Equals(txtProductName.Text) && !"".Equals(txtQuantity.Text))
                {
                    int quantity = int.Parse(txtQuantity.Text);
                    if (quantity == 0)
                    {
                        MessageBox.Show("Quantity can not be 0!", "Add to cart");
                        return;
                    }
                    var product = selected;
                    if (quantity > product.UnitsInStock)
                    {
                        MessageBox.Show("Your ordered quantity is more than Unit In Stock!!!", "Add to cart");
                        LoadProductList(ProductRepository.GetProducts());
                        return;
                    }
                    Cart tmp = Cart;
                    if (tmp == null)
                    {
                        tmp = new Cart
                        {
                            MemberId = LoginMember.MemberId
                        };
                    }
                    CartRepository.AddToCart(ref tmp, product.ProductId, quantity);
                    Cart = tmp;
                    txtQuantity.Text = "1";
                    MessageBox.Show("Added Successfully!!!", "Add to cart");
                }
                else
                {
                    MessageBox.Show("Input is empty!!!", "Add to cart");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add to cart");
            }
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                Product selected = (Product)dgProducts.SelectedItem;
                if (selected != null)
                {
                    txtProductName.Text = selected.ProductName;
                } else
                {
                    txtProductName.Text = "";
                }
        }
    }
}
