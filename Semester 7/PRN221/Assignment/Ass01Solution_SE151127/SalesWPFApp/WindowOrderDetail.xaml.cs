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
    /// Interaction logic for WindowOrderDetail.xaml
    /// </summary>
    public partial class WindowOrderDetail : Window
    {
        IOrderDetailRepository OrderDetailRepository;
        public Order OrderInfor { get; set; }

        public WindowOrderDetail(Order order)
        {
            OrderInfor = order;
            OrderDetailRepository = new OrderDetailRepository();
            InitializeComponent();
            LoadDetailList();
        }
        public void LoadDetailList()
        {
            IEnumerable<OrderDetail> listDetail = OrderDetailRepository.GetDetailsByOrderId(OrderInfor.OrderId);
            dgOrderDetails.ItemsSource = null;
            dgOrderDetails.ItemsSource = listDetail;
            decimal total = 0;
            foreach (var detail in listDetail)
            {
                total = total + detail.Quantity * detail.UnitPrice;
            }
            lbTotal.Content = "Total: " + total;
        }
    }
}
