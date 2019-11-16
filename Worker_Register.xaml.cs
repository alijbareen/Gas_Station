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
    /// Interaction logic for Worker_Register.xaml
    /// </summary>
    public partial class Worker_Register : Window
    {
        Service service;
        public Worker_Register(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        public Worker_Register(Service service, string worker_id, string worker_name, string worker_pass) : this(service)
        {
          
            this.service = service;
            txtUser.Text = worker_name;
            pswd.Text = worker_pass;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (service.checklogin(txtUser.Text, pswd.Text))
            {
                MessageBox.Show("משתמש קיים");
            }
            else
            {
                DB_connector.AddNewWorker(txtUser.Text, pswd.Text);
                MessageBox.Show("Success!");
                Window w2 = new View_Workers(service);
                w2.Show();
                this.Close();
            }
        }
    }
}
