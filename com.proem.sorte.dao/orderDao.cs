using Branch;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using sorteSystem.com.proem.sorte.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorteSystem.com.proem.sorte.dao
{
    class orderDao
    {
        /// <summary>
        /// 从线上服务器获取所有的用户
        /// </summary>
        /// <returns></returns>
        public List<ZcProcessOrder> FindAll(string branchId)
        {
            List<ZcProcessOrder> list = new List<ZcProcessOrder>();
            OracleConnection conn = null;
            try
            {
                conn = OracleUtil.OpenConn();
                string sql = "select * from zc_order_process where branchid='" + branchId + "'";
                OracleCommand command = new OracleCommand(sql);
                command.Connection = conn;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ZcProcessOrder user = new ZcProcessOrder();
                    user.id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    user.createTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                    user.updateTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(2);
                    user.branchId = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    user.cansignPhone = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    user.consignee = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    user.goodsNum = reader.IsDBNull(6) ? default(int) : reader.GetInt32(6);
                    user.isGift = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    user.memberCardNumber = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    user.orderAmount = reader.IsDBNull(9) ? default(double) : reader.GetDouble(9);
                    user.orderCome = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    user.orderDate = reader.IsDBNull(11) ? default(DateTime) : reader.GetDateTime(11);
                    user.orderNum = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    user.orderReduceAmount = reader.IsDBNull(13) ? default(double) : reader.GetDouble(13);
                    user.orderStatus = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                    user.orderTotalValue = reader.IsDBNull(15) ? default(double) : reader.GetDouble(15);
                    user.pullFlag = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                    user.associator = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                    user.zcZoning = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                    list.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                OracleUtil.CloseConn(conn);
            }
            return list;
        }


        public List<ZcProcessOrderItem> getItemByid(string orderId)
        {
            List<ZcProcessOrderItem> list = new List<ZcProcessOrderItem>();
            OracleConnection conn = null;
            try
            {
                conn = OracleUtil.OpenConn();
                string sql = "select * from zc_order_process_item where order_id='" + orderId + "'";
                OracleCommand command = new OracleCommand(sql);
                command.Connection = conn;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ZcProcessOrderItem user = new ZcProcessOrderItem();
                    user.id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    user.createTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                    user.updateTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(2);
                    user.addon = reader.IsDBNull(3) ? default(double) : reader.GetDouble(3);
                    user.amount = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    user.bn = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    user.cost = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    user.g_price = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    user.goodsState = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    user.item_type = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    user.name = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    user.nums = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                    user.obj_id = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    user.order_id = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                    user.price = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                    user.product_id = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                    user.score = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                    user.sendNum = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                    user.type_id = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                    user.weight = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                    user.goodsFile = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
                    user.providerInfo = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
                    list.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                OracleUtil.CloseConn(conn);
            }
            return list;
        }

        //更新
        public void UpdateStatus(object id)
        {
            string sql = "update ZC_SORTE set AUDITS_TATUS = '4' where id = '"+id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                    //cmd.Parameters.Add(":status", obj.OrderStatus);
                    //cmd.Parameters.Add(":id", obj.Id);
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
                tran.Dispose();
                OracleUtil.CloseConn(conn);
            }
        }

        //添加Items
        public void AddtransitItem(List<ZcProcessOrderItem> list)
        {
            string sql = "insert into ZC_ORDER_TRANSIT_ITEM  values "
                + " (:id ,:createTime, :updateTime, :ADDON , :AMOUNT, :BN, :COST, :G_PRICE, :GOODS_STATE, :ITEM_TYPE,:NAME, :NUMS, :OBJ_ID , :ORDER_ID, :PRICE, :PRODUCT_ID, :SCORE, :SENDNUM, :TYPE_ID, :WEIGHT, :GOODSFILE_ID, :PROVIDER_ID)";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                foreach (ZcProcessOrderItem obj in list)
                {
                    cmd.Parameters.Add(":id", obj.id);
                    cmd.Parameters.Add(":createTime", obj.createTime);
                    cmd.Parameters.Add(":updateTime", obj.updateTime);
                    cmd.Parameters.Add(":ADDON", obj.addon);
                    cmd.Parameters.Add(":AMOUNT", obj.amount);
                    cmd.Parameters.Add(":BN", obj.bn);
                    cmd.Parameters.Add(":COST", obj.cost);
                    cmd.Parameters.Add(":G_PRICE", obj.g_price);
                    cmd.Parameters.Add(":GOODS_STATE", obj.goodsState);
                    cmd.Parameters.Add(":ITEM_TYPE", obj.item_type);
                    cmd.Parameters.Add(":NAME", obj.name);
                    cmd.Parameters.Add(":NUMS", obj.nums);
                    cmd.Parameters.Add(":OBJ_ID", obj.obj_id);
                    cmd.Parameters.Add(":ORDER_ID", obj.order_id);
                    cmd.Parameters.Add(":PRICE", obj.price);
                    cmd.Parameters.Add(":PRODUCT_ID", obj.product_id);
                    cmd.Parameters.Add(":SCORE", obj.score);
                    cmd.Parameters.Add(":SENDNUM", obj.sendNum);
                    cmd.Parameters.Add(":TYPE_ID", obj.type_id);
                    cmd.Parameters.Add(":WEIGHT", obj.weight);
                    cmd.Parameters.Add(":GOODSFILE_ID", obj.goodsFile);
                    cmd.Parameters.Add(":PROVIDER_ID", obj.providerInfo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
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

        //删除Item
        public void deletePorcessItem(string id)
        {
            string sql = "delete  from zc_order_process_item where id='"+id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
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
                OracleUtil.CloseConn(conn);
            }
        }

        //删除processOrder
        public void deletePorcessOrder(string id)
        {
            string sql = "delete  from ZC_ORDER_PROCESS where id='" + id + "'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
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

        //得到transit表中是否有order数据
        public int getTransitOrderCount(string id) {
            string sql = "select count(id) from zc_order_transit where id='"+id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            int count = -1;
            try
            {

                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                 //cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                //tran.Commit();
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    count = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                }
                return count;
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
            return count;
        }


        //添加transitOrder数据
        public void AddtransitOrder(ZcProcessOrder obj)
        {
            string sql = "insert into ZC_ORDER_TRANSIT  values "
                + " (:id ,:createTime, :updateTime, :BRANCHID , :CANSIGNPHONE, :CONSIGNEE, :GOODSNUM, :ISGIFT, :MEMBERCARDNUMBER, :ORDERAMOUNT,:ORDERCOME, :ORDERDATE, :ORDERNUM , :ORDERREDUCEAMOUNT, :ORDERSTATUS, :ORDERTOTALVALUE, :PULLFLAG, :MEMBER_ID, :ZCZONING_ID)";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.Add(":id", obj.id);
                cmd.Parameters.Add(":createTime", obj.createTime);
                cmd.Parameters.Add(":updateTime", obj.updateTime);
                cmd.Parameters.Add(":BRANCHID", obj.branchId);
                cmd.Parameters.Add(":CANSIGNPHONE", obj.cansignPhone);
                cmd.Parameters.Add(":CONSIGNEE", obj.consignee);
                cmd.Parameters.Add(":GOODSNUM", obj.goodsNum);
                cmd.Parameters.Add(":ISGIFT", obj.isGift);
                cmd.Parameters.Add(":MEMBERCARDNUMBER", obj.memberCardNumber);
                cmd.Parameters.Add(":ORDERAMOUNT", obj.orderAmount);
                cmd.Parameters.Add(":ORDERCOME", obj.orderCome);
                cmd.Parameters.Add(":ORDERDATE", obj.orderDate);
                cmd.Parameters.Add(":ORDERNUM", obj.orderNum);
                cmd.Parameters.Add(":ORDERREDUCEAMOUNT", obj.orderReduceAmount);
                cmd.Parameters.Add(":ORDERSTATUS", obj.orderStatus);
                cmd.Parameters.Add(":ORDERTOTALVALUE", obj.orderTotalValue);
                cmd.Parameters.Add(":PULLFLAG", obj.pullFlag);
                cmd.Parameters.Add(":MEMBER_ID", obj.associator);
                cmd.Parameters.Add(":ZCZONING_ID", obj.zcZoning);
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
        public string getBranchName(string street)
        {
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.branch_name from zc_branch_total a left join zc_zoning b on b.id = a.zoning_id where b.street= '" + street + "'";
            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;
            try
            {
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string confirmPassword = string.Format("{0}", reader["branch_name"]);
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
            public void deleteSorteStatus(string ip) {
            string sql1 = "delete  from zc_sorte_status where ip ='"+ip+"'";
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

            public void insertSorteStatus(string street,string ip)
            {
                deleteSorteStatus(ip);
                string sql = "insert into zc_sorte_status  values "
                + " (:id ,:createTime, :updateTime, :street,:abip, :sorteId )";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction tran = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(":id", Guid.NewGuid().ToString());
                    cmd.Parameters.Add(":createTime", DateTime.Now);
                    cmd.Parameters.Add(":updateTime", DateTime.Now);
                    cmd.Parameters.Add(":street", street);
                    cmd.Parameters.Add(":abip", ip);
                    cmd.Parameters.Add(":sorteId", ConstantUtil.sorte_id);
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

            public void updateStoreHouse(ZcProcessOrderItem zcProcessOrderItem)
            {
                string sql = "update zc_storehouse set store = :store, storemoney = :money where id = :id";
                OracleConnection conn = null;
                OracleTransaction tran = null;
                OracleCommand cmd = new OracleCommand();
                try
                {
                    StoreHouse storeHouse = FindByGoodsFileId(zcProcessOrderItem.goodsFile);
                    float old = float.Parse(storeHouse.Store);
                    storeHouse.Store = (old - float.Parse(zcProcessOrderItem.nums)).ToString();
                    storeHouse.StoreMoney = ((old - float.Parse(zcProcessOrderItem.nums)) * (float.Parse(storeHouse.StoreMoney) / old)).ToString();
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":store", storeHouse.Store);
                    cmd.Parameters.Add(":money", storeHouse.StoreMoney);
                    cmd.Parameters.Add(":id", storeHouse.Id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if(tran!= null){
                        tran.Rollback();
                    }
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    OracleUtil.CloseConn(conn);
                }
            }

            public StoreHouse FindByGoodsFileId(string goodsFileId) 
            {
                StoreHouse obj = new StoreHouse();
                string sql = "select id,store, storemoney from zc_storehouse where branch_id = :branchId and goodsfile_id = :goodsFileId ";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":branchId", ConstantUtil.BranchId);
                    cmd.Parameters.Add(":goodsFileId", goodsFileId);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        obj.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        obj.Store = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        obj.StoreMoney = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        obj.GoodsFileId = goodsFileId;
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
    }

    
}
