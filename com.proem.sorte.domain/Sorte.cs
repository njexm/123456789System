using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorteSystem.com.proem.sorte.domain
{
    public class Sorte
    {
        public string Id
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
	 * 分拣单号
	 */
        public string code
        {
            get;
            set;
        }
        /**	
         * 分拣方式
         */

        public string sortingMethod
        {
            get;
            set;
        }
        /**
         * 制单人
         */
        public string makeMen
        {
            get;
            set;
        }
        /**
         * 制单时间
         */
        public DateTime makeTime
        {
            get;
            set;
        }
        /**
         * 审核人
         */
        public string auditMen
        {
            get;
            set;
        }
        /**
         * 审核时间
         */
        public DateTime auditTime
        {
            get;
            set;
        }
        /**
         * 审核状态
         */
        public int auditStatus
        {
            get;
            set;
        }
        /**
         * 备注
         */
        public string remrks
        {
            get;
            set;
        }

        public int groupFlag { get; set; }
    }
}
