using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gas_Station
{
    public class AllWorkersData
    {

        private Service service;

        public AllWorkersData(Service service)
        {
            this.service = new Service();
            UpdateData();
        }

        public ObservableCollection<Worker> BoardlistsItems { get; set; }

        private ObservableCollection<WorkerRow> workers;
        public ObservableCollection<WorkerRow> Workers
        {
            get
            {
                return workers;
            }
            set
            {
                workers = value;
                UpdateFilter();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Workers"));
            }
        }

        private void UpdateFilter()
        {
            CollectionViewSource cvs = new CollectionViewSource() { Source = workers };
            ICollectionView cv = cvs.View;
            cv.Filter = o =>
            {
                WorkerRow p = o as WorkerRow;
                return (p.worker_name.ToString().ToUpper().Contains(SearchTerm.ToUpper()));// || p.BoardName.ToString().ToUpper().Contains(searchTerm.ToUpper()));
            };
            GridView = cv;
        }

        string searchTerm = "";
        public string SearchTerm
        {
            get
            {
                return searchTerm;
            }
            set
            {
                searchTerm = value;
                UpdateFilter();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SearchTerm"));
            }
        }



        private WorkerRow selected;
        public WorkerRow Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
        }



        private ICollectionView gridView;
        public ICollectionView GridView
        {
            get
            {
                return gridView;
            }
            set
            {
                gridView = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GridView"));
            }
        }



        private void UpdateData()
        {
            ObservableCollection<WorkerRow> rows = new ObservableCollection<WorkerRow>();
            List<Worker> list1= DB_connector.Get_All_Workers();
            foreach (var m in list1 )
            {
                rows.Add(new WorkerRow(m));
            }
            Workers = rows;
        }


        public WorkerRow SelectedWorker { get; set; }
        public string FilterText { get; set; }


        private string welcomeWorker { get; set; }





        public event PropertyChangedEventHandler PropertyChanged;

    }
}
