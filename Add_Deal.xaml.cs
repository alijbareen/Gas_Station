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
    /// Interaction logic for Add_Deal.xaml
    /// </summary>
    public partial class Add_Deal : Window
    {
        public Service service;
        private string deal_idd;


        //public Shift shift;
        public Add_Deal()
        {
            InitializeComponent();
        }

        public Add_Deal(Service service,string deal6_id)
        {
            InitializeComponent();

            this.service = service;

            foreach (var m in service.shift.deal_list)
            {
                if (m.deal_id.Equals(deal6_id))
                {
                    deal_total.Text = m.deal_total;
                    //check again
                    deal_type.Text = m.deal_type;
                    deal_desc.Text = m.deal_desc;
                }

            }
            deal_idd = deal6_id;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string deal1_id;
            if (deal_idd == null) //add new deal
            {
                deal1_id = DateTime.Now.ToString("yyyyMMdd-HHMMss");
                Deal deal1 = new Deal(deal1_id, deal_total.Text, deal_type.Text, deal_desc.Text, service.shift.shift_id);
                service.shift.deal_list.Add(deal1);

                DB_connector.AddNewDeal(deal1); //insert the deal to database
                this.Close();
            }
            else //edit
            {
                deal1_id = deal_idd;
                Deal deal2 = new Deal(deal1_id, deal_total.Text, deal_type.Text, deal_desc.Text, service.shift.shift_id);

                foreach (var m in service.shift.deal_list)
                {
                    if (m.deal_id.Equals(deal_idd))
                    {
                        service.shift.deal_list.Remove(m);
                        DB_connector.UpdateDeal(deal2, deal_idd); //update deal in DB
                        //DB_connector.RemoveDeal(m);
                        break;
                    }
                    

                }

                service.shift.deal_list.Add(deal2);
                //DB_connector.AddNewDeal(deal2);
                
                this.Close();
            }

        }

        private void ComboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
