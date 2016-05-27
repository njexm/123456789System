using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorteSystem.com.proem.sorte.dao
{
   public  class ZcProcessOrder
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
	 * 订单编号
	 */
       public string orderNum
       {
           get;
           set;
       }
        /**
         * 订单总额
         */
       public double orderTotalValue
       {
           get;
           set;
       }
        /**
         * 订单状态
         */
       public string orderStatus
       {
           get;
           set;
       }
        /**
         * 订单日期
         */
       public DateTime orderDate
       {
           get;
           set;
       }
        /**
         * 订单来源
         */
       public string orderCome
       {
           get;
           set;
       }
        /**
         * 收货人
         */
       public string consignee
       {
           get;
           set;
       }
        /**
         * 收货电话
         */
       public string cansignPhone
       {
           get;
           set;
       }
        /**
         * 收货地址
         */
       public string zcZoning
       {
           get;
           set;
       }
        /**
         * 订单金额
         */
       public double orderAmount
       {
           get;
           set;
       }
        /**
         * 优惠金额
         */
       public double orderReduceAmount
       {
           get;
           set;
       }
        /**
         * 有无赠品
         */
       public string isGift
       {
           get;
           set;
       }
        /**
         * 会员卡号
         */
       public string memberCardNumber
       {
           get;
           set;
       }
        /**
         * 商品数量
         */
       public int goodsNum
       {
           get;
           set;
       }
        /**
         * 拉取标志
         */
       public string pullFlag
       {
           get;
           set;
       }
        /**
         */
       public string associator
       {
           get;
           set;
       }
        /**
         * 对应亭点ID
         */
       public string branchId
       {
           get;
           set;
       }
    }
}
