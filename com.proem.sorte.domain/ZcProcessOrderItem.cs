using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorteSystem.com.proem.sorte.domain
{
   public class ZcProcessOrderItem
    {
       public string id
       {
           get;
           set;
       }
       public DateTime createTime
           {
           get;
           set;
       }
       public DateTime updateTime
       {
           get;
           set;
       }
        /**
      * 订单ID
      */
       public string order_id
       {
           get;
           set;
       }
        /**
         * 订单明细对应商品对象ID
         */
       public string obj_id
       {
           get;
           set;
       }
        /**
         * 货品ID
         */
       public string product_id
       {
           get;
           set;
       }
        /**
         * 商品ID
         */
       public string goodsFile
       {
           get;
           set;
       }
        /**
         * 商品类型
         */
       public string type_id
       {
           get;
           set;
       }
        /**
         * 明细商品的品牌名
         */
       public string bn
       {
           get;
           set;
       }
        /**
         * 明细商品的名称
         */
       public string name
       {
           get;
           set;
       }
        /**
         * 明细商品的成本
         */
       public string cost
       {
           get;
           set;
       }
        /**
         * 明细商品的销售价
         */
       public string price
       {
           get;
           set;
       }
        /**
         * 明细商品的会员价
         */
       public string g_price
       {
           get;
           set;
       }
        /**
         * 明细商品的总额
         */
       public string amount
       {
           get;
           set;
       }
        /**
         * 明细商品积分
         */
       public string score
       {
           get;
           set;
       }
        /**
         * 明细商品重量
         */
       public string weight
       {
           get;
           set;
       }
        /**
         * 明细商品购买数量
         */
       public string nums
       {
           get;
           set;
       }
        /**
         * 明细商品发货数量
         */
       public string sendNum
       {
           get;
           set;
       }

        /**
         * 规格属性
         */
       public double addon
       {
           get;
           set;
       }
        /**
         * 商品类型
         */
       public string item_type
       {
           get;
           set;
       }

        /**
         * 供应商ID
         */
       public string providerInfo
       {
           get;
           set;
       }
        /**
         * 商品状态
         */
       public string goodsState
       {
           get;
           set;
       }
    }
}
