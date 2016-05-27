using Branch;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.dao
{
    public class ProcessDao
    {


        public string FindGoodsNum(string p)
        {
            string num = "";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            string sql = "select goodstotalnum from zc_processgoods where id = :id";
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", p);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    num = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
            return num;
        }

        public void updateNum(string p, string goodsNum)
        {
            string sql = "update zc_processgoods set goodstotalnum = :num where id = :id";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":num", goodsNum);
                cmd.Parameters.Add(":id", p);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }
    }
}
