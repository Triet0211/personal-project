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
    /// Interaction logic for WindowMemberManagement.xaml
    /// </summary>
    public partial class WindowMemberManagement : Window
    {
        public IMemberRepository MemberRepository;
        public Member LoginAdmin;
        public WindowMemberManagement()
        {
            MemberRepository = new MemberRepository();
            InitializeComponent();
            LoadMemberList();
        }
        void LoadMemberList()
        {
            var members = MemberRepository.GetMembers();
            try
            {
                dgMembers.ItemsSource = members;
                if (members.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        void LoadMemberList(IEnumerable<Member> members)
        {
            try
            {
                dgMembers.ItemsSource = members;
                if (members.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load member list");
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
            if ("".Equals(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Input is empty", "Member Management");
            }
            else
            {
                LoadMemberList(MemberRepository.GetMembersByEmail(txtEmail.Text.ToString()));
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowProfile windowProfile = new WindowProfile()
            {
                Title = "Create New Member",
                InsertOrUpdate = false
            };
            if (windowProfile.ShowDialog() == true)
            {
                LoadMemberList();
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberList(MemberRepository.SortMembers());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Member selected = (Member) dgMembers.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Has not selected a member yet. Try again!!!", "Member Management");
                return;
            }
            WindowProfile windowProfile = new WindowProfile(selected, true)
            {
                InsertOrUpdate = true,
                MemberInfo = selected,
                Title = "Update New Member"
            };
            if (windowProfile.ShowDialog() == true)
            {
                LoadMemberList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete selected user?", "Delete a member", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    Member selected = (Member)dgMembers.SelectedItem;
                    if (selected == null)
                    {
                        MessageBox.Show("Has not selected a member yet. Try again!!!", "Member Management");
                        return;
                    }
                    MemberRepository.DeleteMember(selected.MemberId);
                    LoadMemberList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }
    }
}