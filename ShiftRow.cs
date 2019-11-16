using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class ShiftRow
    {
        public string shift_id { get; set; }

        public string worker_id { get; set; }

        public string mish1 { get; set; }
        public string mish2 { get; set; }
        public string mish3 { get; set; }
        public string mish4 { get; set; }

        public ShiftRow(string shift_id, string worker_id, string mish1, string mish2, string mish3, string mish4)
        {
            this.shift_id = shift_id;
            this.worker_id = worker_id;
            this.mish1 = mish1;
            this.mish2 = mish2;
            this.mish3 = mish3;
            this.mish4 = mish4;


        }

        public ShiftRow(Shift c)
        {
            this.shift_id = c.shift_id;
            this.worker_id = c.worker_id;
            this.mish1 = c.mish1;
            this.mish2 = c.mish2;
            this.mish3 = c.mish3;
            this.mish4 = c.mish4;





        }
    }
}
