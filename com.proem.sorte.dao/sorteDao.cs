﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Branch;
using sorteSystem.com.proem.sorte.util;
using SorteSystem.com.proem.sorte.domain;

namespace SorteSystem.com.proem.sorte.dao
{
    class sorteDao
    {

        //添加分拣记录
        public List<string> AddtransitItem(List<orderSorte> list)
        {
            List<string> idStr = new List<string>();
            string sql1 = "insert into ZC_ORDERS_SORTE (id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, ORDERSNUM, SORTENUM, WEIGHT) values "
                + " (:id ,:createTime, :updateTime, :ADDRESS , :GOODS_ID, :GOODS_NAME, :ORDERSNUM, :SORTENUM, :weight)";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();

                cmd.Connection = conn;
                foreach (orderSorte obj in list)
                {
                    string id = obj.id;
                    if (id == null || "".Equals(id))
                    {
                        id = Guid.NewGuid().ToString();
                        idStr.Add(id);
                        cmd.CommandText = sql1;
                        cmd.Parameters.Add(":id", id);
                        cmd.Parameters.Add(":createTime", obj.createTime);
                        cmd.Parameters.Add(":updateTime", obj.updateTime);
                        cmd.Parameters.Add(":ADDRESS", obj.address);
                        cmd.Parameters.Add(":GOODS_ID", obj.goods_id);
                        cmd.Parameters.Add(":GOODS_NAME", obj.goods_name);
                        cmd.Parameters.Add(":ORDERSNUM", obj.orderNum);
                        cmd.Parameters.Add(":SORTENUM", obj.sorteNum);
                        cmd.Parameters.Add(":weight", obj.weight);
                    }
                    else
                    {
                        string sql2 = "update zc_orders_sorte a set a.sortenum = '" + obj.sorteNum + "' where a.id='" + obj.id + "'";
                        cmd.CommandText = sql2;
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                tran.Commit();
                return idStr;
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                cmd.Dispose();
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
            return null;
        }

        public string getIpName(string street)
        {
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select id from ZC_WORKSTATION where WORKIP='" + street + "'";
            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;
            try
            {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string confirmPassword = string.Format("{0}", reader["id"]);
                    return confirmPassword;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                OracleUtil.CloseConn(connection);
            }
            return null;
        }
        public void deleteSorteStatus(string ip)
        {
            string sql1 = "delete  from zc_sorte_status where ip ='" + ip + "'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql1;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                cmd.Dispose();
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }

        public void AddtransitItem(orderSorte obj)
        {
            List<string> idStr = new List<string>();
            string sql1 = "insert into ZC_ORDERS_SORTE (id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, ORDERSNUM, SORTENUM, WEIGHT, sorteId) values "
                + " (:id ,:createTime, :updateTime, :ADDRESS , :GOODS_ID, :GOODS_NAME, :ORDERSNUM, :SORTENUM , :weight, :sorteId)";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.CommandText = sql1;
                cmd.Parameters.Add(":id", obj.id);
                cmd.Parameters.Add(":createTime", obj.createTime);
                cmd.Parameters.Add(":updateTime", obj.updateTime);
                cmd.Parameters.Add(":ADDRESS", obj.address);
                cmd.Parameters.Add(":GOODS_ID", obj.goods_id);
                cmd.Parameters.Add(":GOODS_NAME", obj.goods_name);
                cmd.Parameters.Add(":ORDERSNUM", obj.orderNum);
                cmd.Parameters.Add(":SORTENUM", obj.sorteNum);
                cmd.Parameters.Add(":weight", obj.weight);
                cmd.Parameters.Add(":sorteId", ConstantUtil.sorte_id);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }

        public void DeleteBy(string id)
        {
            string sql = "delete from zc_orders_sorte where id = :id";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", id);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }

        public List<string> FindBy(string goodsId, string weight, string street)
        {
            List<string> list = new List<string>();
            string sql = "select id from zc_orders_sorte where goods_id = :goodsId and address = :street and weight= :weight";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":goodsId", goodsId);
                cmd.Parameters.Add(":street", street);
                cmd.Parameters.Add(":weight", weight);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    list.Add(id);
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
            return list;
        }

        public string getSorteId(string ip)
        {
            string sorteId = "";
            String sql = "select \"sorteId\" from zc_sorte_status where IP = :abIP";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":abIP", ip);
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    sorteId = reader.IsDBNull(0) ?  string.Empty : reader.GetString(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("根据ip查询sorteId失败" + e.Message);
            }
            return sorteId;
        }
    }
}
