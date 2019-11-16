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
    /// Interaction logic for View_Deals1.xaml
    /// </summary>
    public partial class View_Deals1 : Window
    {
        private Service service;
        AllDealsData VM;

        public View_Deals1()
        {
            InitializeComponent();
        }

        public View_Deals1(Service service)
        {
            VM = new AllDealsData(service);
            this.DataContext = VM;
            InitializeComponent();
            this.service = service;
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedDeal is null)
            {
                MessageBox.Show("Choose A Deal");
            }
            else
            {
                Window w2 = new Add_Deal(service, (VM.SelectedDeal.deal_id));
                w2.Show();
                this.Close();

            }
        }

        private void GridDeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedDeal is null)
            {
                MessageBox.Show("Choose A Deal");
            }
            else
            {
                //DB_connector.RemoveDeal(VM.SelectedDeal.deal_id);
                foreach (var m in service.shift.deal_list)
                {
                    if (m.deal_id.Equals(VM.SelectedDeal.deal_id))
                    {
                        service.shift.deal_list.Remove(m);
                        //Delete deal in DB
                        DB_connector.DeleteDeal(m.deal_id);
                        break;
                    }
                }


                Window w2 = new View_Deals1(service);
                    w2.Show();
                    this.Close();               
            }
        }

        private void GridShifts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
