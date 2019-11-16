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
    /// Interaction logic for View_Shifts1.xaml
    /// </summary>
    public partial class View_Shifts1 : Window
    {
        AllShiftsData VM;
        private Service service;

        public View_Shifts1()
        {
           
            service = new Service();
            service.Manager = true;
            VM = new AllShiftsData(service);
            this.DataContext = VM;
            InitializeComponent();

        }

        public View_Shifts1(Service service)
        {
            this.service = service;
            VM = new AllShiftsData(service);
            this.DataContext = VM;
            InitializeComponent();

        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedShift is null)
            {
                MessageBox.Show("Choose A Shift");
            }
            else
            {
                
                //enter worker page as admin
                Window w2 = new Worker_page1(service,VM.SelectedShift.shift_id);
                w2.Show();
                this.Close();
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridDeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedShift is null)
            {
                MessageBox.Show("Choose A Shift");
            }
            else
            {
                DB_connector.DeleteShift(VM.SelectedShift.shift_id);
              //remember to delete all deals also
                Window w2 = new View_Shifts1(service);
                w2.Show();
                this.Close();
            }
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
           this.VM.UpdateFilter();
           //VM.SearchTerm
           InitializeComponent();
        }

    }
}
