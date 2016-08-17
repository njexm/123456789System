﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    /// <summary>
    /// 亭点入库单明细
    /// </summary>
    public class BranchInItem
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public string branchIn_id { get; set; }

        public string nums { get; set; }

        public string weight { get; set; }

        public string money { get; set; }

        public string goodsFile_id { get; set; }

        /// <summary>
        /// 配送单价
        /// </summary>
        public string price { get; set; }
    }
}
