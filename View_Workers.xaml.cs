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
    /// Interaction logic for View_Workers.xaml
    /// </summary>
    public partial class View_Workers : Window
    {
        private Service service;
        public AllWorkersData VM;
        public View_Workers()
        {
            InitializeComponent();
        }

        public View_Workers(Service service)
        {
            service = new Service();
            service.Manager = true;
            VM = new AllWorkersData(service);
            this.DataContext = VM;
            InitializeComponent();
            this.service = service;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window w2 = new Worker_Register(service);
            w2.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
            Window w2 = new Worker_Register(service,VM.SelectedWorker.worker_id, VM.SelectedWorker.worker_name, VM.SelectedWorker.worker_pass);
            w2.Show();
            this.Close();
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedWorker is null)
            {
                MessageBox.Show("Choose A Worker");
            }
            else
            {
                DB_connector.DeleteWorker(VM.SelectedWorker.worker_id);
                //remember to delete all shifts also
                Window w2 = new View_Workers(service);
                w2.Show();
                this.Close();
            }
        }

        private void GridWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
