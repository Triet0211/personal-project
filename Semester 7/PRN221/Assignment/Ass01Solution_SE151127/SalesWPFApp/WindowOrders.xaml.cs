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
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        public IEnumerable<Order> OrderList { get; set; }
        public Member LoginUser { get; set; }
        public IOrderDetailRepository OrderDetailRepository;
        public IOrderRepository OrderRepository;
        public WindowOrders(Member user)
        {
            OrderDetailRepository = new OrderDetailRepository();
            OrderRepository = new OrderRepository();
            LoginUser = user;
            InitializeComponent();
            LoadOrderList();
        }
        public void LoadOrderList()
        {
            if (LoginUser.MemberId == 0)
            {
                OrderList = OrderRepository.GetOrders();
            }
            else
            {
                OrderList = OrderRepository.GetOrdersByMemebrId(LoginUser.MemberId);
            }
            dgOrders.ItemsSource = null;
            dgOrders.ItemsSource = OrderList;
            if (OrderList == null || OrderList.Count() == 0)
            {
                btnViewDetail.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnViewDetail.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        private void btnLougout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin { };
            windowLogin.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (LoginUser.MemberId == 0)
            {
                WindowAdmin windowAdmin = new WindowAdmin()
                {
                    LoginAdmin = LoginUser
                };
                windowAdmin.Closed += (s, args) => this.Close();
                windowAdmin.Show();
                Hide();
            }
            else
            {
                WindowMembers windowMember = new WindowMembers()
                {
                    LoginMember = LoginUser
                };
                windowMember.Closed += (s, args) => this.Close();
                windowMember.Show();
                Hide();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = (Order)dgOrders.SelectedItem;
                if (order == null)
                {
                    MessageBox.Show("Select order to delete", "Delete order");
                    return;
                }
                if (MessageBox.Show("Do you want to delete this selected order?", "Delete Order", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    OrderDetailRepository.DeleteDetailByOrderId(order.OrderId);
                    OrderRepository.DeleteOrder(order.OrderId);
                    LoadOrderList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order selected = (Order)dgOrders.SelectedItem;
                if (selected == null)
                {
                    MessageBox.Show("Select order to view detail", "View order detail");
                    return;
                }
                WindowOrderDetail windowOrderDetail = new WindowOrderDetail(selected);
                windowOrderDetail.ShowDialog();
             }
            catch (Exception ex)
            {
                MessageBox.Show("Chosing blank row!!!", "View Order List");
            }

        }
    }
}