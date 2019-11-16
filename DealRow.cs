using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Station
{
    public class DealRow
    {
        private Deal m;

        public string deal_id { get; set; }
        public string deal_total { get; set; }
        public string deal_type { get; set; }
        public string deal_desc { get; set; }
        public string shift_id { get; set; }

        public DealRow(string deal_id, string deal_total, string deal_type, string deal_desc, string shift_id)
        {
            this.deal_id = deal_id;
            this.deal_total = deal_total;
            this.deal_type = deal_type;
            this.deal_desc = deal_desc;
            this.shift_id = shift_id;
        }

        public DealRow(Deal m)
        {
            this.deal_id = m.deal_id;
            this.deal_total = m.deal_total;
            this.deal_type = m.deal_type;
            this.deal_desc = m.deal_desc;
            this.shift_id = m.shift_id;
        }
    }
}
