using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Windows.Forms;
using log4net;

namespace Branch
{
    class OracleUtil
    {
        /// <summary>
        /// 日志
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(OracleUtil));

        /// <summary>
        /// open 一个 conn
        /// </summary>
        /// <returns></returns>
        public static OracleConnection OpenConn()
        {
            OracleConnection conn = null;
            try
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString);
                conn.Open();
            }
            catch (Exception ex) {
                log.Error("数据库连接失败" + ex.Message, ex);
                MessageBox.Show("数据库连接失败,请检查网络配置" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             return conn;
         }

        /// <summary>
        /// 关闭conn 释放资源
        /// </summary>
        /// 
        /// <param name="conn"></param>
        public static void CloseConn(OracleConnection conn)
         {
             if (conn == null) { return; }
             try
             {
                 if (conn.State != ConnectionState.Closed)
                 {
                     conn.Close();
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
             finally
             {
                 conn.Dispose();
             }
         }
        
    }
}
