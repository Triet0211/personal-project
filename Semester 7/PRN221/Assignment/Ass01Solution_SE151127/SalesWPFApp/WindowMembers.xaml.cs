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
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        public IMemberRepository MemberRepository { get; set; }
        public Member LoginMember { get; set; }
        public Cart Cart { get; set; }
        public WindowMembers()
        {
            InitializeComponent();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin { };
            windowLogin.Show();
            this.Hide();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            WindowProfile windowProfile = new WindowProfile(LoginMember, true)
            {
                Title = "Update New Member"
            };
            windowProfile.ShowDialog();
        }

        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts windowProducts = new WindowProducts()
            {
                LoginMember = LoginMember
            };
            windowProducts.Closed += (s, args) => this.Close();
            windowProducts.Show();
            Hide();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders(LoginMember);
            windowOrders.Closed += (s, args) => this.Close();
            windowOrders.Show();
            Hide();
        }
    }
}