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
    /// Interaction logic for WindowProfile.xaml
    /// </summary>
    public partial class WindowProfile : Window
    {
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member MemberInfo { get; set; }
        public WindowProfile()
        {
            MemberRepository = new MemberRepository();
            InitializeComponent();
        }

        public WindowProfile(Member mem, bool update)
        {
            MemberRepository = new MemberRepository();
            InitializeComponent();
            this.MemberInfo = mem;
            InsertOrUpdate = update;
            var tmp = mem;
            txtEmail.IsReadOnly = InsertOrUpdate;
            txtMemberId.IsReadOnly = InsertOrUpdate;
            if (InsertOrUpdate) //update mode
            {
                txtMemberId.Text = MemberInfo.MemberId.ToString();
                txtCompanyName.Text = MemberInfo.CompanyName;
                txtEmail.Text = MemberInfo.Email;
                txtPassword.Password = MemberInfo.Password;
                txtCity.Text = MemberInfo.City;
                txtCountry.Text = MemberInfo.Country;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int MemberId = 0;
                if (!"".Equals(txtMemberId.Text))
                {
                    MemberId = int.Parse(txtMemberId.Text);
                }

                var member = new Member
                {
                    MemberId = MemberId,
                    CompanyName = txtCompanyName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Password,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
                if (!InsertOrUpdate)//insert
                {
                    MemberRepository.InsertMember(member);
                }
                else //update
                {
                    MemberRepository.UpdateMember(member);
                }
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
