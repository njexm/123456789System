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
    public class BranchInDao
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(BranchInDao));

        /// <summary>
        /// 添加亭点入库单明细
        /// </summary>
        /// <param name="list"></param>
        public void addList(List<BranchInItem> list)
        {
            string sql = "insert into zc_branch_in_item (id, createTime, updateTime, branchIn_id, nums, weight, money, goodsFile_id, price) "
                + " values(:id, :createTime, :updateTime, :branchIn_id, :nums, :weight, :money, :goodsFile_id, :price)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                for (int i = 0; i < list.Count; i++)
                {
                    BranchInItem obj = list[i];
                    cmd.Parameters.Add(":id", obj.id);
                    cmd.Parameters.Add(":createTime", obj.createTime);
                    cmd.Parameters.Add(":updateTime", obj.updateTime);
                    cmd.Parameters.Add(":branchIn_id", obj.branchIn_id);
                    cmd.Parameters.Add(":nums", obj.nums);
                    cmd.Parameters.Add(":weight", obj.weight);
                    cmd.Parameters.Add(":money", obj.money);
                    cmd.Parameters.Add(":goodsFile_id", obj.goodsFile_id);
                    cmd.Parameters.Add(":price", obj.price);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("新增亭点入库单明细失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 添加亭点入库单
        /// </summary>
        /// <param name="obj"></param>
        public void addObj(BranchIn obj)
        {
            string sql = "insert into zc_branch_in (id, createTime, updateTime, inOdd, dispatching_id, nums, weight, money, branch_id, branch_from_id, user_id) "
                + " values (:id, :createTime, :updateTime, :inOdd, :dispatching_id, :nums, :weight, :money, :branch_id, :branch_from_id, :user_id)";
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
                cmd.Parameters.Add(":inOdd", obj.InOdd);
                cmd.Parameters.Add(":dispatching_id", obj.dispatching_id);
                cmd.Parameters.Add(":nums", obj.nums);
                cmd.Parameters.Add(":weight", obj.weight);
                cmd.Parameters.Add(":money", obj.money);
                cmd.Parameters.Add(":branch_id", obj.branch_id);
                cmd.Parameters.Add(":branch_from_id", obj.branch_from_id);
                cmd.Parameters.Add(":user_id", obj.user_id);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("新增亭点入库单失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }
    }
}
