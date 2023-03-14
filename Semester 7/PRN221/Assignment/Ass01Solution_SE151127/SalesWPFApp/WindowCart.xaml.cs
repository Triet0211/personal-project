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
    /// Interaction logic for WindowCart.xaml
    /// </summary>
    public partial class WindowCart : Window
    {
        public Member LoginMember { get; set; }
        public Cart Cart { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public WindowCart(Member loginMember, Cart cart)
        {
            InitializeComponent();
            LoginMember = loginMember;
            Cart = cart;
            CartRepository = new CartRepository();
            ProductRepository = new ProductRepository();
            OrderDetailRepository = new OrderDetailRepository();
            OrderRepository = new OrderRepository();
            LoadCartList();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void LoadCartList()
        {
            try
            {
                if (Cart != null)
                {
                    var productsInCart = Cart.ListProduct;

                    if (productsInCart != null && productsInCart.Count != 0)
                    {
                        dgCarts.ItemsSource = null;
                        dgCarts.ItemsSource = productsInCart;
                        lbFreight.Content = "Freight: " + Cart.Freight;
                        lbTotalPrice.Content = "Total Price: " + Cart.TotalPrice;
                        decimal total = Cart.Freight + Cart.TotalPrice;
                        lbTotal.Content = "Total: " + total;
                    }
                    else
                    {
                        btnRemove.IsEnabled = false;
                        btnUpdate.IsEnabled = false;
                        btnCheckout.IsEnabled = false;
                        lbTotal.Content = "";
                        lbTotalPrice.Content = "";
                        lbFreight.Content = "";
                        dgCarts.ItemsSource = null;
                        txtQuantity.Text = "";
                        txtQuantity.IsReadOnly = true;
                    }
                }
                else
                {
                    btnRemove.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                    btnCheckout.IsEnabled = false;
                    lbTotal.Content = "";
                    lbTotalPrice.Content = "";
                    lbFreight.Content = "";
                    dgCarts.ItemsSource = null;
                    txtQuantity.Text = "";
                    txtQuantity.IsReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Cart list");
            }
        }

        private void btnShopping_Click(object sender, RoutedEventArgs e) => Close();
        private void btnLougout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to logout (This cart will be deleted)?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
            {
                WindowLogin windowLogin = new WindowLogin { };
                windowLogin.Show();
                Hide();
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductInCart selected = (ProductInCart)dgCarts.SelectedItem;

                if (selected != null && !"".Equals(txtQuantity.Text))
                {
                    int quantity = int.Parse(txtQuantity.Text);
                    var product = ProductRepository.GetProductByID(selected.ProductId);
                    if (quantity > product.UnitsInStock)
                    {
                        MessageBox.Show("Your ordered quantity is more than Unit In Stock!!!", "Update product in cart");
                        return;
                    }
                    Cart tmp = Cart;
                    CartRepository.UpdateCart(ref tmp, product.ProductId, quantity);
                    Cart = tmp;
                    MessageBox.Show("Updated Successfully!!!", "Update product in cart");
                    LoadCartList();
                }
                else
                {
                    MessageBox.Show("Input is empty!!!", "Update product in cart");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product in cart");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductInCart selected = (ProductInCart)dgCarts.SelectedItem;

                if (selected != null)
                {
                    if (MessageBox.Show("Are you removing product " + selected.ProductName + " from cart?", "Remove product in cart", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var product = ProductRepository.GetProductByID(selected.ProductId);
                        Cart tmp = Cart;
                        CartRepository.RemoveFromCart(ref tmp, product.ProductId);
                        Cart = tmp;
                        LoadCartList();
                        MessageBox.Show("Removed Successfully!!!", "Remove product in cart");
                    }
                }
                else
                {
                    MessageBox.Show("Input is empty!!!", "Remove product in cart");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove product in cart");
            }
        }
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool check = true;
                foreach (var productInCart in Cart.ListProduct)
                {
                    var productInStore = ProductRepository.GetProductByID(productInCart.ProductId);
                    if (productInCart.Quantity > productInStore.UnitsInStock)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    IEnumerable<Order> listOrder = OrderRepository.GetOrdersByMemebrId(LoginMember.MemberId);
                    int newId = 1;
                    if (listOrder.ToArray().Length > 0)
                    {
                        newId = listOrder.Max(ord => ord.OrderId) + 1;
                    }

                    Order order = new Order
                    {
                        OrderId = newId,
                        MemberId = LoginMember.MemberId,
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now.AddDays(5),
                        ShippedDate = DateTime.Now.AddDays(5),
                        Freight = 0,
                    };
                    OrderRepository.InsertOrder(order);
                    foreach (var productInCart in Cart.ListProduct)
                    {
                        var productInStore = ProductRepository.GetProductByID(productInCart.ProductId);
                        productInStore.UnitsInStock = productInStore.UnitsInStock - productInCart.Quantity;
                        ProductRepository.UpdateProduct(productInStore);

                        OrderDetail currentDetail = new OrderDetail
                        {
                            OrderId = newId,
                            ProductId = productInCart.ProductId,
                            UnitPrice = productInStore.UnitPrice,
                            Quantity = productInCart.Quantity,
                            Discount = 0
                        };
                        OrderDetailRepository.AddDetail(currentDetail);
                    }
                    Cart tmp = Cart;
                    CartRepository.DeleteCart(ref tmp);
                    Cart = tmp;
                    MessageBox.Show("Ordered Successfully!!!", "Checkout");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Your ordered quantity exceeds quantity in stock!!!", "Checkout");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Checkout");
            }
        }
    }
}
