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
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public Member LoginAdmin { get; set; }
        public WindowAdmin()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin { };
            windowLogin.Show();
            this.Hide();
        }

        private void btnManageProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProductManagement windowProductManagement = new WindowProductManagement()
            {
                LoginAdmin = LoginAdmin
            };
            windowProductManagement.Closed += (s, args) => this.Close();
            this.Hide();
            windowProductManagement.Show();
        }

        private void btnManageUser_Click(object sender, RoutedEventArgs e)
        {
            WindowMemberManagement windowMemberManagement = new WindowMemberManagement()
            {
                LoginAdmin = LoginAdmin
            };
            windowMemberManagement.Closed += (s, args) => this.Close();
            this.Hide();
            windowMemberManagement.Show();
        }

        private void btnManageOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders(LoginAdmin);
            windowOrders.Closed += (s, args) => this.Close();
            windowOrders.Show();
            Hide();
        }
    }
}
