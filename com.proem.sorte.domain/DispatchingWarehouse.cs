﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class DispatchingWarehouse
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public string street { get; set; }

        public string branch_total_id { get; set; }

        public DateTime dispatcher_date { get; set; }

        public string nums { get; set; }

        public string weight { get; set; }

        public string money { get; set; }

        /// <summary>
        /// PSCHD yyyyMMddHHmmss
        /// </summary>
        public string dispatcherOdd { get; set; }

        public int statue { get; set; }

        public string checkMan { get; set; }

        public DateTime checkDate { get; set; }

        public string createMan { get; set; }

        public string remark { get; set; }

        public string branch_id { get; set; }

        /// <summary>
        /// 2
        /// </summary>
        public string type { get; set; }
    }
}
