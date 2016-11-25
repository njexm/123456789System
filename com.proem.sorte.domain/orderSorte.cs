using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteSystem.com.proem.sorte.domain
{
    public class orderSorte
    {
        public string id { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        //亭点
        public string address { get; set; }
        //商品Id
        public string goods_id { get; set; }
        //商品名
        public string goods_name { get; set; }
        //订单份数
        public string orderNum { get; set; }
        //分拣份数
        public string sorteNum { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public string weight { get; set; }

        //金额
        public string money { get; set; }

        /// <summary>
        /// 是否称重商品
        /// 1是
        /// 0 否
        /// </summary>
        public string isWeight { get; set; }

        //条码
        public string bar_code { get; set; }

        /// <summary>
        /// 是否退货
        /// 1是
        /// 0否
        /// </summary>
        public string isReturn { get; set; }

        //分拣单id
        public string sorteId { get; set; }

        //成本价
        public string costPrice { get; set; }

        /// <summary>
        /// 是否打印
        /// 1是
        /// 0 否
        /// </summary>
        public string isPrint { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string goodsPrice { get; set; }
    }
}
