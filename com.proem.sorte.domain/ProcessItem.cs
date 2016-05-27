using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.domain
{
    public class ProcessItem
    {
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string GoodsName { get; set; }

        public string GoodsNum { get; set; }

        public string ProcessGoodsId { get; set; }

        public string SerialNumber { get; set; }

        public string Specifications { get; set; }

        public string TypeFlag { get; set; }

        public string Unit { get; set; }

        public string UseNum { get; set; }

        public string GoodsFileId { get; set; }

        public string CptUserId { get; set; }

        public string DelFlag { get; set; }

        public string GoodsWeight { get; set; }
    }
}
