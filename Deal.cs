using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class Deal
    {
        public string deal_id { get; set; } // id should be the full date with hour and minute and day
        public string deal_total { get; set; }
        public string deal_type { get; set; }
        public string deal_desc { get; set; }
        public string shift_id { get; set; }


        public Deal(string deal_id, string deal_total, string deal_type, string deal_desc, string shift_id)
        {
            this.deal_id = deal_id;
            this.deal_total = deal_total;
            this.deal_type = deal_type;
            this.deal_desc = deal_desc;
            this.shift_id = shift_id;
        }

    }
}
