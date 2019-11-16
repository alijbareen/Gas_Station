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
    public class AllShiftsData
    {
        private Service service;

        public AllShiftsData(Service service)
        {
            this.service = service;
            UpdateData();
        }


        public ObservableCollection<Shift> BoardlistsItems { get; set; }

        private ObservableCollection<ShiftRow> shifts;
        public ObservableCollection<ShiftRow> Shifts
        {
            get
            {
                return shifts;
            }
            set
            {
                shifts = value;
                UpdateFilter();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Shifts"));
            }
        }

        public void UpdateFilter()
        {
            CollectionViewSource cvs = new CollectionViewSource() { Source = shifts };
            ICollectionView cv = cvs.View;
            cv.Filter = o =>
            {
                ShiftRow p = o as ShiftRow;
                return (p.shift_id.ToString().ToUpper().Contains(SearchTerm.ToUpper()) || p.worker_id.ToString().ToUpper().Contains(searchTerm.ToUpper()));
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



        private ShiftRow selected;
        public ShiftRow Selected
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
            ObservableCollection<ShiftRow> rows = new ObservableCollection<ShiftRow>();

            List<Shift> All_shifts = DB_connector.Get_All_Shifts();
            foreach (var c in All_shifts)
            {

                rows.Add(new ShiftRow(c));    
            }
           Shifts = rows;

        }



        public ShiftRow SelectedShift { get; set; }
        public string FilterText { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

    }
}
