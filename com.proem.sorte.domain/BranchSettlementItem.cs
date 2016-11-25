using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    /// <summary>
    /// 亭点缴款单
    /// </summary>
    public class BranchSettlementItem
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string money { get; set; }

        /// <summary>
        /// 配送出库单号
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 应付金额
        /// </summary>
        public string payableMoney { get; set; }

        /// <summary>
        /// 已付金额
        /// </summary>
        public string paidMoney { get; set; }

        /// <summary>
        /// 未付金额
        /// </summary>
        public string unpaidMoney { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public string actualMoney{get;set;}

        /// <summary>
        /// 优惠金额
        /// </summary>
        public string favorableMoney { get; set; }

        /// <summary>
        /// 已优惠金额
        /// </summary>
        public string discountMoney { get; set; }

        /// <summary>
        /// 约定付款时间
        /// </summary>
        public DateTime agreedTime { get; set; }

        /// <summary>
        /// 单据税额
        /// </summary>
        public string tax { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 缴款单主表Id
        /// </summary>
        public string branch_settlement_id { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime billDate { get; set; }

        /// <summary>
        /// 单据负责人
        /// </summary>
        public string dutyMan { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string codeType { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public string createMan { get; set; }

        /// <summary>
        /// 分店编号
        /// </summary>
        public string branchCode { get; set; }
    }
}
