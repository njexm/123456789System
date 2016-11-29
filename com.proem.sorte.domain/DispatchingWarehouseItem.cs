using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class DispatchingWarehouseItem
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public string dispatchingWarehouseId { get; set; }

        public string goods_name { get; set; }

        public string serialNumber { get; set; }

        public string branch_total_id { get; set; }

        public DateTime cash_date { get; set; }

        public string weight { get; set; }

        public string goodsPrice { get; set; }

        public string money { get; set; }

        public string goods_specifications { get; set; }

        public string goodsFile_id { get; set; }

        public string nums { get; set; }

        /// <summary>
        /// 成本单价
        /// </summary>
        public string costPrice { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public string rate { get; set; }

        /// <summary>
        ///税额
        /// </summary>
        public string rateMoney { get; set; }
    }
}
