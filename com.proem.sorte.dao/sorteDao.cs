using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Branch;
using sorteSystem.com.proem.sorte.util;
using SorteSystem.com.proem.sorte.domain;
using log4net;

namespace SorteSystem.com.proem.sorte.dao
{
    class sorteDao
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(sorteDao));

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
                log.Error("新增分拣数据失败"+ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
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
                log.Error("查询工位id失败"+ex.Message,ex);
            }
            finally
            {
                if(connection != null){
                    connection.Close();
                }
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
                log.Error("删除分拣各工位信息表发生错误", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        public void AddtransitItem(orderSorte obj)
        {
            List<string> idStr = new List<string>();
            string sql1 = "insert into ZC_ORDERS_SORTE (id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, ORDERSNUM, SORTENUM, WEIGHT, sorteId, money,isWeight, bar_code, isReturn, goodsPrice, COSTPRICE, RATE) values "
                + " (:id ,:createTime, :updateTime, :ADDRESS , :GOODS_ID, :GOODS_NAME, :ORDERSNUM, :SORTENUM , :weight, :sorteId, :money, :isWeight, :bar_code, :isReturn, :goodsPrice, :COSTPRICE, :RATE)";
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
                cmd.Parameters.Add(":money", obj.money);
                cmd.Parameters.Add(":isWeight", obj.isWeight);
                cmd.Parameters.Add(":bar_code", obj.bar_code);
                cmd.Parameters.Add(":isReturn", obj.isReturn);
                cmd.Parameters.Add(":goodsPrice", obj.goodsPrice);
                cmd.Parameters.Add(":COSTPRICE", obj.costPrice);
                cmd.Parameters.Add(":RATE", obj.rate);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("新增分拣数据信息", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
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
                log.Error("删除分拣数据信息失败"+ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        public List<string> FindBy(string goodsId, string weight, string street)
        {
            List<string> list = new List<string>();
            string sql = "";
            if(string.IsNullOrEmpty(weight)){
                sql = "select id from zc_orders_sorte where goods_id = '" + goodsId + "' and address = '" + street + "' and weight is null and sorteId = '" + ConstantUtil.sorte_id + "'";
            }
            else
            {
                sql = "select id from zc_orders_sorte where goods_id = '" + goodsId + "' and address = '" + street + "' and weight= '" + weight + "' and sorteId = '" + ConstantUtil.sorte_id + "'";
            }
            
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    list.Add(id);
                }
            }
            catch (Exception ex)
            {
                log.Error("条件查询分拣数据信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn!= null){
                    conn.Close();
                }
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
                if (reader.Read())
                {
                    sorteId = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
            }
            catch (Exception e)
            {
                log.Error("根据ip查询sorteId失败" + e.Message, e);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
            return sorteId;
        }

        public void updateNums(float nums, string goodsFileId, float money, string orderSorteId)
        {
            string sql = "update ZC_ORDERS_SORTE set sorteNum = '" + nums + "' ,weight='" + nums + "', money = '" + money.ToString("0.0") + "' where id='" + orderSorteId + "' ";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("更新分拣数量失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        public void updateNums(string weight, string goodsFileId, float money, string orderSorteId)
        {
            string sql = "update ZC_ORDERS_SORTE set weight='" + weight + "', money = '" + money.ToString("0.0") + "' where id='" + orderSorteId + "' ";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("更新分拣重量失败", ex);
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

        public List<orderSorte> getSumBySorteId()
        {
            List<orderSorte> list = new List<orderSorte>();
            string sql = "select GOODS_ID,sum(sorteNum) as nums, sum(money) as money, sum(weight) as weight "
                +" from ZC_ORDERS_SORTE where SORTEID = '"+ConstantUtil.sorte_id+"' group by GOODS_ID, goods_name";
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = null;
            OracleDataReader reader = null;
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderSorte obj = new orderSorte();
                    obj.goods_id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    obj.sorteNum = reader.IsDBNull(1) ? string.Empty : reader.GetValue(1).ToString();
                    obj.money = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2).ToString();
                    obj.weight = reader.IsDBNull(3) ? string.Empty : reader.GetValue(3).ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                log.Error("获取分拣商品信息汇总"+ex.Message, ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
                if(reader != null){
                    reader.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// 新增退货信息
        /// </summary>
        /// <param name="obj"></param>
        public void addReturnGoods(orderSorte obj)
        {
            string sql = "insert into ZC_ORDERS_SORTE (id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, SORTENUM, WEIGHT, money,isWeight, bar_code, isReturn, goodsPrice, costPrice, rate, isPrint) values "
               + " (:id ,:createTime, :updateTime, :ADDRESS , :GOODS_ID, :GOODS_NAME, :SORTENUM , :weight, :money, :isWeight, :bar_code, :isReturn, :goodsPrice,  :costPrice, :rate, :isPrint)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.Add(":id", obj.id);
                cmd.Parameters.Add(":createTime", obj.createTime);
                cmd.Parameters.Add(":updateTime", obj.updateTime);
                cmd.Parameters.Add(":ADDRESS", obj.address);
                cmd.Parameters.Add(":GOODS_ID", obj.goods_id);
                cmd.Parameters.Add(":GOODS_NAME", obj.goods_name);
                cmd.Parameters.Add(":SORTENUM", obj.sorteNum);
                cmd.Parameters.Add(":weight", obj.weight);
                cmd.Parameters.Add(":money", obj.money);
                cmd.Parameters.Add(":isWeight", obj.isWeight);
                cmd.Parameters.Add(":bar_code", obj.bar_code);
                cmd.Parameters.Add(":isReturn", obj.isReturn);
                cmd.Parameters.Add(":goodsPrice", obj.goodsPrice);
                cmd.Parameters.Add(":costPrice", obj.costPrice);
                cmd.Parameters.Add(":rate", obj.rate);
                cmd.Parameters.Add(":isPrint", obj.isPrint);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("新增退货信息失败", ex);
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 扫码收银
        /// </summary>
        /// <param name="obj"></param>
        public void addSorteWithOutGoods(orderSorte obj)
        {
            string sql = "insert into ZC_ORDERS_SORTE (id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, SORTENUM, WEIGHT, money,isWeight, bar_code, isReturn, costPrice, isPrint, goodsPrice, rate) values "
               + " (:id ,:createTime, :updateTime, :ADDRESS , :GOODS_ID, :GOODS_NAME, :SORTENUM , :weight, :money, :isWeight, :bar_code, :isReturn, :costPrice, :isPrint, :goodsPrice, :rate)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.Add(":id", obj.id);
                cmd.Parameters.Add(":createTime", obj.createTime);
                cmd.Parameters.Add(":updateTime", obj.updateTime);
                cmd.Parameters.Add(":ADDRESS", obj.address);
                cmd.Parameters.Add(":GOODS_ID", obj.goods_id);
                cmd.Parameters.Add(":GOODS_NAME", obj.goods_name);
                cmd.Parameters.Add(":SORTENUM", obj.sorteNum);
                cmd.Parameters.Add(":weight", obj.weight);
                cmd.Parameters.Add(":money", obj.money);
                cmd.Parameters.Add(":isWeight", obj.isWeight);
                cmd.Parameters.Add(":bar_code", obj.bar_code);
                cmd.Parameters.Add(":isReturn", obj.isReturn);
                cmd.Parameters.Add(":costPrice", obj.costPrice);
                cmd.Parameters.Add(":isPrint", obj.isPrint);
                cmd.Parameters.Add(":goodsPrice", obj.goodsPrice);
                cmd.Parameters.Add(":rate", obj.rate);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                log.Error("新增扫码收银信息失败", ex);
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
    }
}
