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
    class AllDealsData
    {
        private Service service;

        public AllDealsData(Service service)
        {
            this.service = service;
            service.shift.deal_list = DB_connector.Get_All_Shift_Deals(service.shift.shift_id);
            UpdateData();
        }



        public ObservableCollection<Deal> BoardlistsItems { get; set; }

        private ObservableCollection<DealRow> deals;
        public ObservableCollection<DealRow> Deals
        {
            get
            {
                return deals;
            }
            set
            {
                deals = value;
                UpdateFilter();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Deals"));
            }
        }

        private void UpdateFilter()
        {
            CollectionViewSource cvs = new CollectionViewSource() { Source = deals };
            ICollectionView cv = cvs.View;
            cv.Filter = o =>
            {
                DealRow p = o as DealRow;
                return (p.deal_id.ToString().ToUpper().Contains(SearchTerm.ToUpper()) || p.deal_type.ToString().ToUpper().Contains(searchTerm.ToUpper()));
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



        private DealRow selected;
        public DealRow Selected
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
            ObservableCollection<DealRow> rows = new ObservableCollection<DealRow>();
            foreach (var m in service.shift.deal_list)
            {
                rows.Add(new DealRow(m));

            }
            Deals = rows;
        }


        public DealRow SelectedDeal { get; set; }
        public string FilterText { get; set; }


        private string welcomeWorker { get; set; }





        public event PropertyChangedEventHandler PropertyChanged;








    }
}
