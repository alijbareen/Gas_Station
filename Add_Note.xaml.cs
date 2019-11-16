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
    /// Interaction logic for Add_Note.xaml
    /// </summary>
    public partial class Add_Note : Window
    {
        private Service service;

        public Add_Note()
        {
            InitializeComponent();
        }

        public Add_Note(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string deal1_id = "note";    //deal id use guid
            Deal deal1 = new Deal(deal1_id, "0", "note", note.Text, service.shift.shift_id);
            service.shift.deal_list.Add(deal1);
            DB_connector.AddNewDeal(deal1);
            this.Close();

        }
    }
}
