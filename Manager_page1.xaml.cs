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
    /// Interaction logic for Manager_page1.xaml
    /// </summary>
    public partial class Manager_page1 : Window
    {
        Service service;
        


        public Manager_page1()
        {
            service = new Service();
            
            service.Manager = true;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Window win2 = new View_Shifts1(service);
            win2.Show();
            Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window win2 = new View_Workers(service);
            win2.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            service = null;
            Close();
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }
    }
}
