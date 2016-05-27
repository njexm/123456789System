using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorteSystem.com.proem.sorte.dao
{
    public class ProcessItemDao
    {

        public ProcessItem FindById(string id)
        {
            ProcessItem obj = new ProcessItem();
            string sql = "select * from zc_processgoods_items where id = :id";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", id);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    obj.Id = Convert.IsDBNull(reader["id"]) ? string.Empty : reader["id"].ToString();
                    obj.CreateTime = Convert.IsDBNull(reader["createtime"]) ? default(DateTime) : Convert.ToDateTime(reader["createtime"]);
                    obj.UpdateTime = Convert.IsDBNull(reader["updatetime"]) ? default(DateTime) : Convert.ToDateTime(reader["updatetime"]);
                    obj.DelFlag = Convert.IsDBNull(reader["delflag"]) ? string.Empty : reader["delflag"].ToString();
                    obj.GoodsName = Convert.IsDBNull(reader["goodsname"]) ? string.Empty : reader["goodsname"].ToString();
                    obj.GoodsNum = Convert.IsDBNull(reader["goodsnum"]) ? string.Empty : reader["goodsnum"].ToString();
                    obj.GoodsWeight = Convert.IsDBNull(reader["goodsweight"]) ? string.Empty : reader["goodsweight"].ToString();
                    obj.ProcessGoodsId = Convert.IsDBNull(reader["PROCESSGOODSID"]) ? string.Empty : reader["PROCESSGOODSID"].ToString();
                    obj.SerialNumber = Convert.IsDBNull(reader["SERIALNUMBER"]) ? string.Empty : reader["SERIALNUMBER"].ToString();
                    obj.Specifications = Convert.IsDBNull(reader["SPECIFICATIONS"]) ? string.Empty : reader["SPECIFICATIONS"].ToString();
                    obj.TypeFlag = Convert.IsDBNull(reader["TYPEFLAG"]) ? string.Empty : reader["TYPEFLAG"].ToString();
                    obj.Unit = Convert.IsDBNull(reader["UNIT"]) ? string.Empty : reader["UNIT"].ToString();
                    obj.UseNum = Convert.IsDBNull(reader["USENUM"]) ? string.Empty : reader["USENUM"].ToString();
                    obj.CptUserId = Convert.IsDBNull(reader["CTPUSER_ID"]) ? string.Empty : reader["CTPUSER_ID"].ToString();
                    obj.GoodsFileId = Convert.IsDBNull(reader["GOODSFILE_ID"]) ? string.Empty : reader["GOODSFILE_ID"].ToString();
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
            return obj;
        }

        public void UpdateItem(ProcessItem item)
        {
            string sql = "update zc_processgoods_items set goodsnum = :goodsnum , goodsweight = :weight, createTime = :createTime , updateTime = :updateTime where id = :id";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":goodsnum", item.GoodsNum);
                cmd.Parameters.Add(":weight", item.GoodsWeight);
                cmd.Parameters.Add(":createTime", item.CreateTime);
                cmd.Parameters.Add(":updateTime", item.UpdateTime);
                cmd.Parameters.Add(":id", item.Id);
                cmd.ExecuteNonQuery();
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

        public void AddProcessItem(ProcessItem item)
        {
            string sql = "insert into zc_processgoods_items (id, createTime, updateTime, goodsName, goodsNum, processgoodsid, serialnumber, specifications, typeflag, unit, goodsfile_id,goodsweight)"
                            + "values(:id, :createTime, :updateTime, :goodsName, :goodsNum, :processgoodsid, :serialnumber,:specifications, :typeflag, :goodsunit, :goodsfile_id, :goodsweight)";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", item.Id);
                cmd.Parameters.Add(":createTime", item.CreateTime);
                cmd.Parameters.Add(":updateTime", item.UpdateTime);
                cmd.Parameters.Add(":goodsName", item.GoodsName);
                cmd.Parameters.Add(":goodsNum", item.GoodsNum);
                cmd.Parameters.Add(":processgoodsid", item.ProcessGoodsId);
                cmd.Parameters.Add(":serialnumber", item.SerialNumber);
                cmd.Parameters.Add(":specifications", item.Specifications);
                cmd.Parameters.Add(":typeflag", item.TypeFlag);
                cmd.Parameters.Add(":goodsunit", item.Unit);
                cmd.Parameters.Add(":goodsfile_id", item.GoodsFileId);
                cmd.Parameters.Add(":goodsweight", item.GoodsWeight);
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

        public void DeleteById(string processItemId)
        {
            string sql = "delete from zc_processgoods_items where id = :id";
            OracleConnection conn = null;
            OracleTransaction tran = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":id", processItemId);
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
    }
}
