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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        IMemberRepository MemberRepository;
        public WindowLogin()
        {
            InitializeComponent();
            MemberRepository = new MemberRepository();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.ToString();
            string password = txtPassword.Password.ToString();
            Member user = null;
            try
            {
                user = MemberRepository.Login(email, password);
                if (user != null)
                {
                    if (user.MemberId == 0)
                    {
                        WindowAdmin windowAdmin = new WindowAdmin()
                        {
                            LoginAdmin = user
                        };
                        windowAdmin.Closed += (s, args) => this.Close();
                        windowAdmin.Show();
                        Hide();
                    }
                    else
                    {
                        WindowMembers windowMember = new WindowMembers()
                        {
                            LoginMember = user
                        };
                        windowMember.Closed += (s, args) => this.Close();
                        windowMember.Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Account Not Found!!!", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
