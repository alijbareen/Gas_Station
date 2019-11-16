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
    /// Interaction logic for Worker_page1.xaml
    /// </summary>
    public partial class Worker_page1 : Window
    {
        public Service service;
       // private string shift_id;

        public Worker_page1()
        {
            InitializeComponent();
        }

        public Worker_page1(Service service, string shift_id)
        {
            InitializeComponent();
            this.service = service;
            if (!service.Manager)
            {
                DB_connector.AddNewShiftToDB(service.shift);
            }
            else
            {
               this.service.shift = service.shift = DB_connector.Get_Shift_ByID(shift_id);
               this.service.shift.deal_list = DB_connector.Get_All_Shift_Deals(service.shift.shift_id);
               this.service.worker = service.shift.worker;
               
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Window win3 = new Add_Deal(service, null);
            win3.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
                Window win3 = new View_Deals1(service);
                win3.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window win3 = new Add_Note(service);
            win3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window win3 = new Worker_logut(service);
            win3.Show();
        }
    }
}
