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

namespace Gas_Station
{
    /// <summary>
    /// Interaction logic for Login1.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        Service service;


        public Login1()
        {
            InitializeComponent();
            this.service = new Service();

            this.DataContext = this.service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            service = new Service();
            string shift_idd = DateTime.Now.ToString("yyyyMMdd-HHMMss");
            service.shift = new Shift(shift_idd, txtUser.Text);
            if (service.checklogin(txtUser.Text, pswd.Text))
            {
                service.worker = service.getworker(txtUser.Text);
                Window win2 = new Worker_page1(service,null);
                win2.Show();
                Close();

            }

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window win2 = new Manager_page1();
            win2.Show();
            Close();
        }
    }
}
