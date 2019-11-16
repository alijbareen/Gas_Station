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
    /// Interaction logic for Worker_logut.xaml
    /// </summary>
    public partial class Worker_logut : Window
    {
        private Service service;

        public Worker_logut()
        {
            InitializeComponent();
        }

        public Worker_logut(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB_connector.Update_Mish(service, mish1.Text, mish2.Text, mish3.Text, mish4.Text);
            service = null;
            Close();
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }

        private void Mish4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
