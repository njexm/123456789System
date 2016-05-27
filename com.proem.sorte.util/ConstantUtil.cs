using sorteSystem.com.proem.sorte.window;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorteSystem.com.proem.sorte.util
{
    class ConstantUtil
    {
        public static Dictionary<object, object> socketList =new Dictionary<object,object>();
        public static sorteGoodList main;
        public static string street;
        public static DataSet Branchds;
        public static int index;
        public static sorteList sortelist;
        public static int redStatus;
        public static string ip1 = "";
        public static string ip2 = "";

        /// <summary>
        /// 宜鲜美加工配送库
        /// </summary>
        public static string BranchId = "596BA834-0618-4902-BCDF-2A70499C43B5";

        /// <summary>
        /// 分拣单id
        /// </summary>
        public static string sorte_id;

        /// <summary>
        /// 工位ip
        /// </summary>
        public static List<string> ipList = new List<string>();

        /// <summary>
        /// 用户权限
        /// </summary>
        public static string UserRole;
        
        public static string AMDIN_ROLE = "ADMIN001";
    }
}
