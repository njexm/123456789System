using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class SaveIn
    {
        public string id { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public DateTime check_date { get; set; }

        public string checkMan { get; set; }

        public string money { get; set; }

        public string nums { get; set; }

        public string order_type { get; set; }

        public string remark { get; set; }

        public string odd { get; set; }

        public int statue { get; set; }

        public string street { get; set; }

        public string weight { get; set; }

        /// <summary>
        /// 分店Id
        /// </summary>
        public string branch_id { get; set; }

        public string createMan { get; set; }

        public string storehouse_id { get; set; }

    }
}
