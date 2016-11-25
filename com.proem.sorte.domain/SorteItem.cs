using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class SorteItem
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public string areaId { get; set; }

        public string sortStatus { get; set; }

        public string address { get; set; }

        public string branch_total_id { get; set; }

        public string customer { get; set; }

        public string sorte_id { get; set; }

        public string remark { get; set; }
    }
}
