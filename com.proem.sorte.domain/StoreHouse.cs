using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class StoreHouse
    {
        public string Id { get; set; }

        public string Store { get; set; }

        public string GoodsFileId { get; set; }

        public string StoreMoney { get; set; }

        public string Weight { get; set; }

        public string include_tax_money { get; set; }
    }
}
