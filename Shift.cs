using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class Shift
    {

        public string shift_id { get; set; }

        public string worker_id { get; set; }

        public string mish1 { get; set; }
        public string mish2 { get; set; }
        public string mish3 { get; set; }
        public string mish4 { get; set; }

        public Worker worker { get; set; }
        public List<Deal> deal_list { get; set; }

        public Shift(string shift_id, string worker_id)
        {
            this.shift_id = shift_id;
            this.worker_id = worker_id;
            this.deal_list = new List<Deal>();
            mish1 = "0";
            mish2 = "0";
            mish3 = "0";
            mish4 = "0";

        }

        public Shift(string shift_id, string worker_id, string mish1, string mish2, string mish3, string mish4)
        {
            this.shift_id = shift_id;
            this.worker_id = worker_id;
            this.mish1 = mish1;
            this.mish2 = mish2;
            this.mish3 = mish3;
            this.mish4 = mish4;


        }


        /* CODE IF NEEDED TO INITIALIZE THE WORKER
List<Worker> l1 = DB_connector.getworkers();
foreach (var m in l1)
{
    if (m.worker_id.Equals(worker_id))
    {
        worker = m;
    }
}
*/

    }
}
