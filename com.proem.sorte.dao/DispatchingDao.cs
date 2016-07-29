using Branch;
using log4net;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.dao
{
    public class DispatchingDao
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(DispatchingDao));

        public void addObj(DispatchingWarehouse obj) 
        {
            string sql = "insert into  zc_dispatching_Warehouse (id, createTime, updateTime, BRANCH_CODE, BRANCH_TOTAL_ID, DISPATCHER_DATE, DISPATCHER_MONEY, DISPATCHER_NUMS, DISPATCHER_WEIGHT, DISPATCHER_ODD, STATUE, "
                + " BRANCH_ID, dispatching_Type) values (:id, :createTime, :updateTime, :BRANCH_CODE, :BRANCH_TOTAL_ID, :DISPATCHER_DATE, :DISPATCHER_MONEY, :DISPATCHER_NUMS, :DISPATCHER_WEIGHT, :DISPATCHER_ODD, :STATUE,"
                + " :BRANCH_ID, :dispatching_Type)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", obj.id);
                cmd.Parameters.Add(":createTime", obj.createTime);
                cmd.Parameters.Add(":updateTime", obj.updateTime);
                cmd.Parameters.Add(":BRANCH_CODE", obj.street);
                cmd.Parameters.Add(":BRANCH_TOTAL_ID", obj.branch_total_id);
                cmd.Parameters.Add(":DISPATCHER_DATE", obj.dispatcher_date);
                cmd.Parameters.Add(":DISPATCHER_MONEY", obj.money);
                cmd.Parameters.Add(":DISPATCHER_NUMS", obj.nums);
                cmd.Parameters.Add(":DISPATCHER_WEIGHT", obj.weight);
                cmd.Parameters.Add(":DISPATCHER_ODD", obj.dispatcherOdd);
                cmd.Parameters.Add("::STATUE", obj.statue);
                cmd.Parameters.Add(":BRANCH_ID", obj.branch_id);
                cmd.Parameters.Add(":dispatching_Type", obj.type);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("添加zc_dispatching_Warehouse数据失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(tran != null){
                    tran.Dispose();
                }
                if(conn != null){
                    conn.Close();
                }
            }
        }

        public void addList(List<DispatchingWarehouseItem> list)
        {
            string sql = "insert into zc_dispatching_Warehouse_items (id, createTime, updateTime, CASH_DATE, DISPATCHINGWAREHOUSE_ID, GOODS_NAME, GOODS_PRICE, GOODS_SPECIFICATIONS, SERIALNUMBER, "
                + " TOTAL_MONEY, WEIGHT, BRANCH_TOTAL_ID, GOODSFILE_ID, NUMS) values (:id, :createTime, :updateTime, :CASH_DATE, :DISPATCHINGWAREHOUSE_ID, :GOODS_NAME, :GOODS_PRICE, :GOODS_SPECIFICATIONS, :SERIALNUMBER, "
                + ":TOTAL_MONEY, :WEIGHT, :BRANCH_TOTAL_ID, :GOODSFILE_ID, :NUMS)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                for (int i = 0; i < list.Count; i++ )
                {
                    DispatchingWarehouseItem obj = list[i];
                    cmd.Parameters.Add(":id", obj.id);
                    cmd.Parameters.Add(":createTime", obj.createTime);
                    cmd.Parameters.Add(":updateTime", obj.updateTime);
                    cmd.Parameters.Add(":CASH_DATE", obj.cash_date);
                    cmd.Parameters.Add(":DISPATCHINGWAREHOUSE_ID", obj.dispatchingWarehouseId);
                    cmd.Parameters.Add(":GOODS_NAME", obj.goods_name);
                    cmd.Parameters.Add(":GOODS_PRICE", obj.goodsPrice);
                    cmd.Parameters.Add(":GOODS_SPECIFICATIONS", obj.goods_specifications);
                    cmd.Parameters.Add(":SERIALNUMBER", obj.serialNumber);
                    cmd.Parameters.Add(":TOTAL_MONEY", obj.money);
                    cmd.Parameters.Add(":WEIGHT", obj.weight);
                    cmd.Parameters.Add(":BRANCH_TOTAL_ID", obj.branch_total_id);
                    cmd.Parameters.Add(":GOODSFILE_ID", obj.goodsFile_id);
                    cmd.Parameters.Add(":NUMS", obj.nums);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("添加zc_dispatching_Warehouse数据失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if (tran != null)
                {
                    tran.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
    }
}
