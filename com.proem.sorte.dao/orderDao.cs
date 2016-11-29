using Branch;
using log4net;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using sorteSystem.com.proem.sorte.util;
using SorteSystem.com.proem.sorte.domain;
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
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(orderDao));

        /// <summary>
        /// 从线上服务器获取所有的用户
        /// </summary>
        /// <returns></returns>
        public List<ZcProcessOrder> FindAll(string branchId)
        {
            List<ZcProcessOrder> list = new List<ZcProcessOrder>();
            OracleConnection conn = null;
            OracleDataReader reader = null;
            OracleCommand command = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                string sql = "select * from zc_order_process where branchid='" + branchId + "'";
                command.CommandText = sql;
                command.Connection = conn;
                reader = command.ExecuteReader();
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
                log.Error("获取待分拣商品信息失败", ex);
            }
            finally
            {
                if(reader != null){
                    reader.Close();
                }
                command.Dispose();
                if(conn != null){
                    conn.Close();
                }
            }
            return list;
        }


        public List<ZcProcessOrderItem> getItemByid(string orderId)
        {
            List<ZcProcessOrderItem> list = new List<ZcProcessOrderItem>();
            OracleConnection conn = null;
            OracleDataReader reader = null;
            OracleCommand command = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                string sql = "select id,CREATETIME, UPDATETIME,ADDON,AMOUNT,bn,cost,G_PRICE,GOODS_STATE,ITEM_TYPE,name,NUMS, "
                    +" obj_id,order_id,PRICE,PRODUCT_ID,score,SENDNUM, TYPE_ID, WEIGHT, GOODSFILE_ID,PROVIDER_ID,groupFlag from zc_order_process_item where order_id='" + orderId + "'";
                command.CommandText = sql;
                command.Connection = conn;
                reader = command.ExecuteReader();
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
                    user.groupFlag = reader.IsDBNull(22) ? default(int) : reader.GetInt32(22);
                    list.Add(user);
                }
            }
            catch (Exception ex)
            {
                log.Error("根据订单号获取详细信息"+ex.Message, ex);
            }
            finally
            {
                if(reader!= null){
                    reader.Close();
                }
                command.Dispose();
                if(conn!= null){
                    conn.Close();
                }
            }
            return list;
        }

        //更新
        public void UpdateStatus(object id)
        {
            string sql = "update ZC_SORTE set AUDITS_TATUS = '4', updateTime=:updateTime  where id = '"+id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleTransaction tran = null;
            try
            {
                conn = OracleUtil.OpenConn();
                tran = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.Add(":updateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                log.Error("跟新分拣单状态失败", ex);
                tran.Rollback();
            }
            finally
            {
                cmd.Dispose();
                if(tran != null){
                    tran.Dispose();
                }
                if(conn!= null){
                    conn.Close();
                }
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
                if(tran != null){
                    tran.Dispose();
                }
                if(conn != null){
                    conn.Close();
                }
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
                tran.Commit();
            }
            catch (Exception ex)
            {
                log.Error("删除分拣商品信息失败", ex);
                tran.Rollback();
            }
            finally
            {
                cmd.Dispose();
                if(tran != null){
                    tran.Dispose();
                }
                if(conn!= null){
                    conn.Close();
                }
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
                if(conn != null){
                    conn.Close();
                }
            }
        }

        //得到transit表中是否有order数据
        public int getTransitOrderCount(string id) {
            string sql = "select count(id) from zc_order_transit where id='"+id+"'";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            OracleDataReader reader = null;
            int count = -1;
            try
            {

                conn = OracleUtil.OpenConn();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    count = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                }
                return count;
            }
            catch (Exception ex)
            {
                log.Error("获取订单数据失败", ex);
            }
            finally
            {
                if(reader != null){
                    reader.Close();
                }
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
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
                cmd.Parameters.Add(":createTime", DateTime.Now);
                cmd.Parameters.Add(":updateTime", DateTime.Now);
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
                if(tran != null){
                    tran.Dispose();
                }
                if(conn != null){
                    conn.Close();
                }
            }
        }
        public string getBranchName(string street)
        {
            //获取数据库连接
            OracleConnection connection = OracleUtil.OpenConn();
            string queryString = "select a.branch_name from zc_branch_total a left join zc_zoning b on b.id = a.zoning_id where b.street= '" + street + "'";
            OracleCommand command = new OracleCommand(queryString);
            command.Connection = connection;
            OracleDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
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
                command.Dispose();
                if(reader != null){
                    reader.Close();
                }
                if(connection != null){
                    connection.Close();
                }
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
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                cmd.Dispose();
                if(conn != null){
                    conn.Close();
                }
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
                    if(tran != null ){
                        tran.Dispose();
                    }
                    if(conn!= null){
                        conn.Close();
                    }
                }
            }

        /// <summary>
        /// 库存减少
        /// </summary>
        /// <param name="obj"></param>
            public void updateStoreHouse(orderSorte obj)
            {
                ZcGoodsMasterDao zcGoodsMasterDao = new ZcGoodsMasterDao();
                string sql = "update zc_storehouse set updateTime=:updateTime,store = :store, storemoney = :money, include_tax_money = :include_tax_money ,weight=:weight where id = :id";
                OracleConnection conn = null;
                OracleTransaction tran = null;
                OracleCommand cmd = new OracleCommand();
                ZcGoodsMaster zcGoodsMaster = zcGoodsMasterDao.FindById(obj.goods_id);
                StoreHouse storeHouse = FindByGoodsFileId(obj.goods_id);
                if (storeHouse == null)
                {
                    AddStoreHouse(obj);
                    storeHouse = FindByGoodsFileId(obj.goods_id);
                }
                string oldNums = storeHouse.Store;
                float old = string.IsNullOrEmpty(oldNums) ? 0F : float.Parse(storeHouse.Store);
                storeHouse.Store = (old - float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)).ToString();
                ///成本计算改变
                if (float.Parse(storeHouse.Store) <= 0)
                {
                    if (float.Parse(storeHouse.StoreMoney) > 0)
                    {
                        float a = float.Parse(obj.weight) - old;
                        storeHouse.StoreMoney = ((0 - a * float.Parse(zcGoodsMaster.GoodsPurchasePrice))).ToString();
                        storeHouse.include_tax_money = (0 - a * float.Parse(zcGoodsMaster.GoodsPurchasePrice)).ToString();
                    }
                    else
                    { 
                        storeHouse.StoreMoney = (float.Parse(storeHouse.StoreMoney) - float.Parse(obj.weight) * float.Parse(zcGoodsMaster.GoodsPurchasePrice)).ToString();
                        storeHouse.include_tax_money = (float.Parse(storeHouse.StoreMoney) - float.Parse(obj.weight) * float.Parse(zcGoodsMaster.GoodsPurchasePrice)).ToString();
                    }
                }
                else
                {
                    if (float.Parse(storeHouse.StoreMoney) > 0)
                    {
                        storeHouse.StoreMoney = (!string.IsNullOrEmpty(oldNums) && !"0".Equals(oldNums)) ? ((old - float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)) * (float.Parse(String.IsNullOrEmpty(storeHouse.StoreMoney) ? "0" : storeHouse.StoreMoney) / old)).ToString() : "0";
                        storeHouse.include_tax_money = (!string.IsNullOrEmpty(oldNums) && !"0".Equals(oldNums)) ? ((old - float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)) * (float.Parse(String.IsNullOrEmpty(storeHouse.include_tax_money) ? "0" : storeHouse.include_tax_money) / old)).ToString() : "0";
                    }
                    else 
                    {
                        storeHouse.StoreMoney = ((float.Parse(storeHouse.StoreMoney) - float.Parse(zcGoodsMaster.GoodsPurchasePrice) * float.Parse(obj.weight))).ToString();
                        storeHouse.include_tax_money = (float.Parse(storeHouse.StoreMoney) - float.Parse(zcGoodsMaster.GoodsPurchasePrice) * float.Parse(obj.weight)).ToString();
                    }
                    
                }
                
                float oldWeight = string.IsNullOrEmpty(storeHouse.Weight) ? 0F : float.Parse(storeHouse.Weight);
                float newWeight = oldWeight - float.Parse(string.IsNullOrEmpty(obj.weight) ? "0" : obj.weight);
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":updateTime", DateTime.Now);
                    cmd.Parameters.Add(":store", storeHouse.Store);
                    cmd.Parameters.Add(":money", storeHouse.StoreMoney);
                    cmd.Parameters.Add(":include_tax_money", storeHouse.include_tax_money);
                    cmd.Parameters.Add(":weight", newWeight);
                    cmd.Parameters.Add(":id", storeHouse.Id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("更新库存信息失败", ex);
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

        /// <summary>
        /// 库存增加
        /// </summary>
        /// <param name="obj"></param>
            public void updateStoreHouseAdd(orderSorte obj)
            {
                ZcGoodsMasterDao dao = new ZcGoodsMasterDao();
                ZcGoodsMaster zcGoodsMaster = dao.FindById(obj.goods_id);
                string sql = "update zc_storehouse set updateTime=:updateTime,store = :store, storemoney = :money, include_tax_money = :include_tax_money ,weight=:weight where id = :id";
                OracleConnection conn = null;
                OracleTransaction tran = null;
                OracleCommand cmd = new OracleCommand();
                StoreHouse storeHouse = FindByGoodsFileId(obj.goods_id);
                float costPrice = getCostPriceByGoodsFileId(obj.goods_id);
                if (storeHouse == null)
                {
                    AddStoreHouse(obj);
                    storeHouse = FindByGoodsFileId(obj.goods_id);
                }
                string oldNums = storeHouse.Store;
                float old = string.IsNullOrEmpty(oldNums) ? 0F : float.Parse(storeHouse.Store);
                storeHouse.Store = (old + float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)).ToString();
                
                float money = float.Parse(obj.weight) * costPrice;

                storeHouse.StoreMoney = (float.Parse(storeHouse.StoreMoney) + money).ToString();
                storeHouse.include_tax_money = (float.Parse(storeHouse.include_tax_money) + money).ToString();
                
                //if (float.Parse(storeHouse.Store) <= 0)
                //{
                //    storeHouse.StoreMoney = "0";
                //    storeHouse.include_tax_money = "0";
                //}
                //else 
                //{
                //    storeHouse.StoreMoney = (!string.IsNullOrEmpty(oldNums) && !"0".Equals(oldNums)) ? ((old + float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)) * (float.Parse(String.IsNullOrEmpty(storeHouse.StoreMoney) ? "0" : storeHouse.StoreMoney) / old)).ToString() : "0";
                //    storeHouse.include_tax_money = (!string.IsNullOrEmpty(oldNums) && !"0".Equals(oldNums)) ? ((old + float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)) * (float.Parse(String.IsNullOrEmpty(storeHouse.include_tax_money) ? "0" : storeHouse.include_tax_money) / old)).ToString() : "0";
                //}
                
                float oldWeight = string.IsNullOrEmpty(storeHouse.Weight) ? 0F : float.Parse(storeHouse.Weight);
                float newWeight = oldWeight + float.Parse(string.IsNullOrEmpty(obj.weight) ? "0" : obj.weight);
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":updateTime", DateTime.Now);
                    cmd.Parameters.Add(":store", storeHouse.Store);
                    cmd.Parameters.Add(":money", storeHouse.StoreMoney);
                    cmd.Parameters.Add(":include_tax_money", storeHouse.include_tax_money);
                    cmd.Parameters.Add(":weight", newWeight);
                    cmd.Parameters.Add(":id", storeHouse.Id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("更新库存信息失败", ex);
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

            /// <summary>
            /// 扫码收银库存增加
            /// </summary>
            /// <param name="obj"></param>
            public void updateStoreHouseAddSorteWithOutOrder(orderSorte obj)
            {
                ZcGoodsMasterDao dao = new ZcGoodsMasterDao();
                ZcGoodsMaster zcGoodsMaster = dao.FindById(obj.goods_id);
                string sql = "update zc_storehouse set updateTime=:updateTime,store = :store, storemoney = :money, include_tax_money = :include_tax_money ,weight=:weight where id = :id";
                OracleConnection conn = null;
                OracleTransaction tran = null;
                OracleCommand cmd = new OracleCommand();
                StoreHouse storeHouse = FindByGoodsFileId(obj.goods_id);
                float costPrice = float.Parse(obj.costPrice);
                if (storeHouse == null)
                {
                    AddStoreHouse(obj);
                    storeHouse = FindByGoodsFileId(obj.goods_id);
                }
                string oldNums = storeHouse.Store;
                float old = string.IsNullOrEmpty(oldNums) ? 0F : float.Parse(storeHouse.Store);
                storeHouse.Store = (old + float.Parse(String.IsNullOrEmpty(obj.weight) ? "0" : obj.weight)).ToString();

                float money = float.Parse(obj.weight) * costPrice;

                storeHouse.StoreMoney = (float.Parse(storeHouse.StoreMoney) + money).ToString();
                storeHouse.include_tax_money = (float.Parse(storeHouse.include_tax_money) + money).ToString();


                float oldWeight = string.IsNullOrEmpty(storeHouse.Weight) ? 0F : float.Parse(storeHouse.Weight);
                float newWeight = oldWeight + float.Parse(string.IsNullOrEmpty(obj.weight) ? "0" : obj.weight);
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":updateTime", DateTime.Now);
                    cmd.Parameters.Add(":store", storeHouse.Store);
                    cmd.Parameters.Add(":money", storeHouse.StoreMoney);
                    cmd.Parameters.Add(":include_tax_money", storeHouse.include_tax_money);
                    cmd.Parameters.Add(":weight", newWeight);
                    cmd.Parameters.Add(":id", storeHouse.Id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("更新库存信息失败", ex);
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

            /// <summary>
            /// 获取成本金额
            /// </summary>
            /// <param name="goodsFileId"></param>
            /// <param name="flag">出入库标识   true入库  flase出库</param>
            /// <param name="changeNum"></param>
            /// <returns></returns>
            public float getCostPrice(string goodsFileId, bool flag, float changeNum) 
            {
                ZcGoodsMasterDao dao = new ZcGoodsMasterDao();
                ZcGoodsMaster zcGoodsMaster = dao.FindById(goodsFileId);
                float costPrice = 0;
                StoreHouse storeHouse = FindByGoodsFileId(goodsFileId);
                if(storeHouse == null ){
                    orderSorte obj = new orderSorte();
                    obj.goods_id = goodsFileId;
                    AddStoreHouse(obj);
                    storeHouse = FindByGoodsFileId(goodsFileId);
                }
                float storeMoney = float.Parse(storeHouse.StoreMoney);
                float store = float.Parse(storeHouse.Store);
                if (flag)
                {
                    //入库
                    if (store <= 0)
                    {
                        costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                    }
                    else 
                    {
                        costPrice = storeMoney / store;
                    }
                }
                else    //出库
                {
                    if (store - changeNum > 0)
                    {
                        if (storeMoney > 0)
                        {
                            costPrice = storeMoney / store;
                        }
                        else
                        {
                            costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                        }
                    }
                    else {
                        if (storeMoney > 0)
                        {
                            if(store == 0){
                                costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                            }
                            else if (changeNum == 0)
                            {
                                if (store > 0)
                                {
                                    costPrice = storeMoney / store;
                                }
                                else {
                                    costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                                }
                            }
                            else {
                                costPrice = (storeMoney + (changeNum - store) * float.Parse(zcGoodsMaster.GoodsPurchasePrice)) / changeNum;
                            }
                        }
                        else 
                        {
                            costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                        }
                    }
                }
                return costPrice;
            }

            /// <summary>
            /// 获取成本金额
            /// </summary>
            /// <param name="goodsFileId"></param>
            /// <param name="flag">出入库标识   true入库  flase出库</param>
            /// <param name="changeNum"></param>
            /// <returns></returns>
            public float getCostPrice(ZcGoodsMaster zcGoodsMaster, bool flag, float changeNum)
            {
                float costPrice = 0;
                StoreHouse storeHouse = FindByGoodsFileId(zcGoodsMaster.Id);
                if (storeHouse == null)
                {
                    orderSorte obj = new orderSorte();
                    obj.goods_id = zcGoodsMaster.Id;
                    AddStoreHouse(obj);
                    storeHouse = FindByGoodsFileId(zcGoodsMaster.Id);
                }
                float storeMoney = float.Parse(storeHouse.StoreMoney);
                float store = float.Parse(storeHouse.Store);
                if (flag)
                {
                    //入库
                    if (store <= 0)
                    {
                        costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice)/(1+zcGoodsMaster.InputTax);
                    }
                    else
                    {
                        costPrice = storeMoney / store;
                    }
                }
                else    //出库
                {
                    if (store - changeNum > 0)
                    {
                        if (storeMoney > 0)
                        {
                            costPrice = storeMoney / store;
                        }
                        else
                        {
                            costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice)/(1+zcGoodsMaster.OutTax);
                        }
                    }
                    else
                    {
                        if (storeMoney > 0)
                        {
                            if (store == 0)
                            {
                                costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice) / (1 + zcGoodsMaster.OutTax);
                            }
                            else if (changeNum == 0)
                            {
                                if (store > 0)
                                {
                                    costPrice = storeMoney / store;
                                }
                                else
                                {
                                    costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice) / (1 + zcGoodsMaster.OutTax);
                                }
                            }
                            else
                            {
                                costPrice = (storeMoney + (changeNum - store) * float.Parse(zcGoodsMaster.GoodsPurchasePrice) / (1 + zcGoodsMaster.OutTax)) / changeNum;
                            }
                        }
                        else
                        {
                            costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice) / (1 + zcGoodsMaster.OutTax);
                        }
                    }
                }
                return costPrice;
            }
            
            public float getCostPriceByGoodsFileId(string goodsId) 
            {
                float costPrice = 0;
                DateTime dd = DateTime.Now.AddDays(-1);
                string startTime = dd.ToString("yyyy-MM-dd 00:00：00");
                string endTime = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                string sql = "select (a.COSTINGMONEY/a.PRODUCTWEIGHT) as costPrice from zc_zccostrecord_items a "
                + "left join zc_goods_master b on b.id=a.productgoods "
                + "left join zc_goods_master c on c.id=a.materialgoods where 1=1 and b.id ='" + goodsId + "' "
                + " and a.createTime >=to_date('"+startTime+"', 'yyyy-MM-dd HH24:mi:ss') and a.createTime <= to_date('"+endTime+"', 'yyyy-MM-dd HH24:mi:ss')";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            ZcGoodsMasterDao dao = new ZcGoodsMasterDao();
                            ZcGoodsMaster zcGoodsMaster = dao.FindById(goodsId);
                            costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                        }
                        else
                        {
                            costPrice = reader.GetFloat(0);
                        }

                    }
                    else
                    {
                        ZcGoodsMasterDao dao = new ZcGoodsMasterDao();
                        ZcGoodsMaster zcGoodsMaster = dao.FindById(goodsId);
                        costPrice = float.Parse(zcGoodsMaster.GoodsPurchasePrice);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("根据id获取成本单价失败", ex);
                }
                finally
                { 
                    if(reader != null){
                        reader.Close();
                    }
                    if(conn != null){
                        conn.Close();
                    }
                    cmd.Dispose();
                }
                return costPrice;
            }

            private void AddStoreHouse(orderSorte obj)
            {
                String sql = "insert into zc_storehouse (id,createTime,updateTime,status,store,storemoney,weight,branch_id, goodsfile_id) "
                    + " values (:id, :createTime, :updateTime, :status, :store, :storeMoney, :weight, :branch_id, :goodsfile_id)";
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
                    cmd.Parameters.Add(":status", "1");
                    cmd.Parameters.Add(":store", "0");
                    cmd.Parameters.Add(":storeMoney", "0");
                    cmd.Parameters.Add(":weight", "0");
                    cmd.Parameters.Add(":branch_id", ConstantUtil.BranchId);
                    cmd.Parameters.Add(":goodsfile_id", obj.goods_id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("新增" + obj.goods_id + "的库存信息", ex);
                }
                finally {
                    cmd.Dispose();
                    if(conn != null){
                        conn.Close();
                    }
                }
            }

            public StoreHouse FindByGoodsFileId(string goodsFileId) 
            {
                StoreHouse obj = null;
                string sql = "select id,store, storemoney,weight,include_tax_money  from zc_storehouse where branch_id = :branchId and goodsfile_id = :goodsFileId ";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":branchId", ConstantUtil.BranchId);
                    cmd.Parameters.Add(":goodsFileId", goodsFileId);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        obj = new StoreHouse();
                        obj.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        obj.Store = reader.IsDBNull(1) ? "0" : reader.GetString(1);
                        obj.StoreMoney = reader.IsDBNull(2) ? "0" : reader.GetString(2);
                        obj.Weight = reader.IsDBNull(3) ? "0" : reader.GetString(3);
                        obj.include_tax_money = reader.IsDBNull(4) ? "0" : reader.GetString(4);
                        obj.GoodsFileId = goodsFileId;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("根据商品id查询商品信息", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if(reader != null){
                        reader.Close();
                    }
                    if(conn != null){
                        conn.Close();
                    }
                }
                return obj;
            }

            public void deleteAllSorteStatus()
            {
                string sql = "delete from zc_sorte_status where 1=1";
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
                    log.Error("删除分拣工位信息表", ex);
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

            public orderSorte FindOrderSorteBy(string orderSorteId)
            {
                orderSorte obj = new orderSorte();
                string sql = "select id, CREATETIME, UPDATETIME, ADDRESS, GOODS_ID, GOODS_NAME, ORDERSNUM, SORTENUM,sorteId, WEIGHT, isWeight, bar_code, isReturn, costPrice, isPrint , money,costPrice, rate  from zc_orders_sorte where id ='"+orderSorteId+"'";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        obj.id = orderSorteId;
                        obj.createTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                        obj.updateTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(2);
                        obj.address = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        obj.goods_id = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        obj.goods_name = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        obj.orderNum = reader.IsDBNull(6) ? "0" : reader.GetString(6);
                        obj.sorteNum = reader.IsDBNull(7) ? "0" : reader.GetString(7);
                        obj.sorteId = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        obj.weight = reader.IsDBNull(9) ? "0" : reader.GetString(9);
                        obj.isWeight = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        obj.bar_code = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        obj.isReturn = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        obj.costPrice = reader.IsDBNull(13) ? "0" : reader.GetString(13);
                        obj.isPrint = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        obj.money = reader.IsDBNull(15) ? "0" : reader.GetString(15);
                        obj.costPrice = reader.IsDBNull(16) ? "0" : reader.GetString(16);
                        obj.rate = reader.IsDBNull(17) ? "0" : reader.GetString(17);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取收银信息失败", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if(conn != null){
                        conn.Close();
                    }
                }
                return obj;
            }

            /// <summary>
            /// 根据street获取分拣信息
            /// </summary>
            /// <param name="street"></param>
            /// <returns></returns>
            public List<orderSorte> getByStreet(string street)
            {
                string startTime = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
                string endTime = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                List<orderSorte> list = new List<orderSorte>();
                string sql = "select id, createTime, address, goods_id, sorteNum, weight, money,costPrice, rate from zc_orders_sorte where 1=1 and address = '"+street+"' and sorteId is not null and isReturn != '1' "
                    + " and createTime >=to_date('"+startTime+"', 'yyyy-MM-dd HH24:mi:ss')  and  createTime <= to_date('"+endTime+"', 'yyyy-MM-dd HH24:mi:ss')";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    while(reader.Read()){
                        orderSorte obj = new orderSorte();
                        obj.id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        obj.createTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                        obj.address = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        obj.goods_id = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        obj.sorteNum = reader.IsDBNull(4) ? "0" : reader.GetString(4);
                        obj.weight = reader.IsDBNull(5) ? "0" : reader.GetString(5);
                        obj.money = reader.IsDBNull(6) ? "0" : reader.GetString(6);
                        obj.costPrice = reader.IsDBNull(7) ? "0" : reader.GetString(7);
                        obj.rate = reader.IsDBNull(8) ? "0" : reader.GetString(8);
                        list.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("查询分拣信息失败", ex);
                }
                finally 
                {
                    if(reader != null){
                        reader.Close();
                    }
                    if(conn != null){
                        conn.Close();
                    }
                    cmd.Dispose();
                }
                return list;
            }

            public string getCashierByBranchId(string branchId)
            {
                string str = "";
                String sql = "select CASH_REGISTER from zc_branch_total where id='"+branchId+"'";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if(reader.Read()){
                        str = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("根据id或者分店收银机标识", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if(reader != null){
                        reader.Close();
                    }
                    if(conn != null){
                        conn.Close();
                    }
                }
                return str;
            }

            public void AddtransitItem(ZcProcessOrderItem obj)
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
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
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

            public int getDispatchingCount()
            {
                int count = 0;
                string sql = "select count(1) from ZC_DISPATCHING_WAREHOUSE ";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    reader = cmd.ExecuteReader();
                    if(reader.Read()){
                        count = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取配送出库单数量失败", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return count;
            }

            public int getBranchInCount(string streetId)
            {
                int count = 0;
                string sql = "select count(1) from ZC_branch_in where inodd like 'BI"+streetId+"%'";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        count = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取配送出库单数量失败", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return count;
            }

            public int getSorteCount()
            {
                int count = 0;
                string sql = "select count(1) from zc_sorte ";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        count = reader.IsDBNull(0) ? default(int) : reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取分拣单数量失败", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return count;
            }

            public void addSorte(Sorte sorte)
            {
                string sql = "insert into zc_sorte (id, createTime, updateTime,AUDITS_TATUS, code,make_time, SORTING_METHOD, GROUPFLAG) "
                    + " values (:id, :createTime, :updateTime, :AUDITS_TATUS, :code, :make_time, :SORTING_METHOD, :GROUPFLAG)";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction tran = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(":id", sorte.Id);
                    cmd.Parameters.Add(":createTime", sorte.createTime);
                    cmd.Parameters.Add(":updateTime", sorte.updateTime);
                    cmd.Parameters.Add(":AUDITS_TATUS", sorte.auditStatus);
                    cmd.Parameters.Add(":code", sorte.code);
                    cmd.Parameters.Add(":make_time", sorte.makeTime);
                    cmd.Parameters.Add(":SORTING_METHOD", sorte.sortingMethod);
                    cmd.Parameters.Add(":GROUPFLAG", sorte.groupFlag);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("插入分拣单失败", ex);
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

            public void addSorteItem(SorteItem sorteItem)
            {
                string sql = "insert into zc_sorte_item (id, createTime, updateTime,areaId, sortStatus,branch_total_id, sorte_id) "
                    + " values (:id, :createTime, :updateTime, :areaId, :sortStatus, :branch_total_id, :sorte_id)";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction tran = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.Add(":id", sorteItem.id);
                    cmd.Parameters.Add(":createTime", sorteItem.createTime);
                    cmd.Parameters.Add(":updateTime", sorteItem.updateTime);
                    cmd.Parameters.Add(":areaId", sorteItem.areaId);
                    cmd.Parameters.Add(":sortStatus", sorteItem.sortStatus);
                    cmd.Parameters.Add(":branch_total_id", sorteItem.branch_total_id);
                    cmd.Parameters.Add(":sorte_id", sorteItem.sorte_id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("插入分拣单明细失败", ex);
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

            public void updateIsPrint(string p)
            {
                string sql = "update zc_orders_sorte set isPrint = '1' where id='"+p+"'";
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
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("修改分拣信息打印状态失败", ex);
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
            /// 添加日志信息
            /// </summary>
            /// <param name="desp">日志描述</param>
            /// <param name="moduleName">模块</param>
            public void insertLog(string desp, string moduleName) {
                string sql = "insert into zc_log (id,CREATETIME,UPDATETIME, DESCRIPTION, IPADDRESS, MODULENAME, USER_ID) values (:id,:CREATETIME,:UPDATETIME, :DESCRIPTION, :IPADDRESS, :MODULENAME, :USER_ID)";
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
                    cmd.Parameters.Add(":CREATETIME", DateTime.Now);
                    cmd.Parameters.Add(":UPDATETIME", DateTime.Now);
                    cmd.Parameters.Add(":DESCRIPTION", ConstantUtil.LoginUserName+desp);
                    cmd.Parameters.Add(":IPADDRESS", ConstantUtil.LocalIp);
                    cmd.Parameters.Add(":MODULENAME", moduleName);
                    cmd.Parameters.Add(":USER_ID", ConstantUtil.LoginUserId);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("增加日志信息失败！", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if(tran != null){
                        tran.Dispose();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }

            public void addBranchSettlementItem(BranchSettlementItem obj)
            {
                string sql = "insert into Zc_branch_settlement_item (id, createTime, updateTime, payableMoney, actualMoney, discountMoney, favorableMoney, paidMoney, tax, codeType, billDate, agreedTime, unpaidMoney, code, money, branchCode) "
                    + " values (:id, :createTime, :updateTime, :payableMoney, :actualMoney, :discountMoney, :favorableMoney, :paidMoney, :tax, :codeType, :billDate, :agreedTime, :unpaidMoney, :code, :money, :branchCode)";
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
                    cmd.Parameters.Add(":payableMoney", obj.payableMoney);
                    cmd.Parameters.Add(":actualMoney", obj.actualMoney);
                    cmd.Parameters.Add(":discountMoney", obj.discountMoney);
                    cmd.Parameters.Add(":favorableMoney", obj.favorableMoney);
                    cmd.Parameters.Add(":paidMoney", obj.paidMoney);
                    cmd.Parameters.Add(":tax", obj.tax);
                    cmd.Parameters.Add(":codeType", obj.codeType);
                    cmd.Parameters.Add(":billDate", obj.billDate);
                    cmd.Parameters.Add(":agreedTime", obj.agreedTime);
                    cmd.Parameters.Add(":unpaidMoney", obj.unpaidMoney);
                    cmd.Parameters.Add(":code", obj.code);
                    cmd.Parameters.Add(":money", obj.money);
                    cmd.Parameters.Add(":branchCode", obj.branchCode);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("新增缴款单失败", ex);
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

            public long FindSaveInCount()
            {
                long count = 0;
                string sql = "select count(1) from zc_saveIn_Warehouse ";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if(reader.Read()){
                        count = reader.GetInt64(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取入库单的数量", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if(reader != null){
                        reader.Dispose();
                    }
                    if(conn != null){
                        conn.Close();
                    }
                }
                return count;
            }

            public string FindIdByStreet(string returnStreet)
            {
                string id = "";
                string sql = "select id from zc_branch_total where branch_code = '"+returnStreet+"'";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id = reader.GetString(0);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取亭点id", ex);
                }
                finally
                {
                    cmd.Dispose();
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return id;
            }

            public void addSaveIn(SaveIn obj)
            {
                string sql = "insert into zc_saveIn_Warehouse (id, CREATETIME, UPDATETIME,CHECK_DATE, CHECKMAN, MONEY, NUMS, odd, STATUE, street, weight, BRANCH_ID, createMan, storehouse_id) values "
                    + " (:id, :CREATETIME, :UPDATETIME, :CHECK_DATE, :CHECKMAN, :MONEY, :NUMS, :odd, :STATUE, :street, :weight, :BRANCH_ID, :createMan, :storehouse_id)";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction tran = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(":id", obj.id);
                    cmd.Parameters.Add(":CREATETIME", obj.createTime);
                    cmd.Parameters.Add(":UPDATETIME", obj.updateTime);
                    cmd.Parameters.Add(":CHECK_DATE", obj.check_date);
                    cmd.Parameters.Add(":CHECKMAN", obj.checkMan);
                    cmd.Parameters.Add(":MONEY", obj.money);
                    cmd.Parameters.Add(":NUMS", obj.nums);
                    cmd.Parameters.Add("::odd", obj.odd);
                    cmd.Parameters.Add(":STATUE", obj.statue);
                    cmd.Parameters.Add(":street", obj.street);
                    cmd.Parameters.Add(":WEIGHT", obj.weight);
                    cmd.Parameters.Add(":BRANCH_ID", obj.branch_id);
                    cmd.Parameters.Add(":createMan", obj.createMan);
                    cmd.Parameters.Add(":storehouse_id", obj.storehouse_id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("插入入库单", ex);
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

            public void addSaveInItem(List<SaveInItem> list)
            {
                string sql = "insert into zc_saveIn_Warehouse_item (id, CREATETIME, UPDATETIME, MONEY, NUMS, SAVEIN_ID, WEIGHT, GOODSFILE_ID, rate, rateMoney, costPrice ) values "
                    + " (:id, :CREATETIME, :UPDATETIME, :MONEY, :NUMS, :SAVEIN_ID, :WEIGHT, :GOODSFILE_ID, :rate, :rateMoney, :costPrice )";
                OracleConnection conn = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction tran = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    for (int i = 0; i < list.Count; i++ )
                    {
                        SaveInItem obj = list[i];
                        cmd.Parameters.Add(":id", obj.id);
                        cmd.Parameters.Add(":CREATETIME", obj.createTime);
                        cmd.Parameters.Add(":UPDATETIME", obj.updateTime);
                        cmd.Parameters.Add(":MONEY", obj.money);
                        cmd.Parameters.Add(":NUMS", obj.nums);
                        cmd.Parameters.Add(":SAVEIN_ID", obj.saveIn_id);
                        cmd.Parameters.Add(":WEIGHT", obj.weight);
                        cmd.Parameters.Add(":GOODSFILE_ID", obj.goodsFile_id);
                        cmd.Parameters.Add(":rate", obj.rate);
                        cmd.Parameters.Add(":rateMoney", obj.rateMoney);
                        cmd.Parameters.Add(":costPrice", obj.costPrice);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("插入入库单明细", ex);
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

            public void deleteSaveInItem(string returnStreet, orderSorte obj)
            {
                string startTime = DateTime.Now.ToString("yyyy-MM-dd 00:00:01");
                string endTime = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                string sql = "select a.id as itemId, a.MONEY, a.nums, a.WEIGHT, b.id, b.money as totalMoney, b.NUMS as totalNums, b.WEIGHT as totalWeight "
                    +" from ZC_SAVEIN_WAREHOUSE_ITEM a left join ZC_SAVEIN_WAREHOUSE b on a.SAVEIN_ID = b.id "
                    +" where 1=1 and b.street = '"+returnStreet+"' and a.GOODSFILE_ID = '"+obj.goods_id+"' "
                    +" and b.CREATETIME >=TO_DATE('"+startTime+"', 'yyyy-MM-dd HH24:mi:ss') "
                    + " and b.CREATETIME <=TO_DATE('" + endTime + "', 'yyyy-MM-dd HH24:mi:ss') "
                    + " and a.money >= '"+(-float.Parse(obj.money))+"'";
                OracleConnection conn = null;
                OracleTransaction tran = null;
                OracleCommand cmd = new OracleCommand();
                OracleDataReader reader = null;
                try
                {
                    conn = OracleUtil.OpenConn();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    if(reader.Read()){
                        string itemId = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        float money = float.Parse(reader.IsDBNull(1) ? "0" : reader.GetString(1));
                        float nums = float.Parse(reader.IsDBNull(2) ? "0" : reader.GetString(2));
                        float weight = float.Parse(reader.IsDBNull(3) ? "0" : reader.GetString(3));
                        string id = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        float totalmoney = float.Parse(reader.IsDBNull(5) ? "0" : reader.GetString(5));
                        float totalnums = float.Parse(reader.IsDBNull(6) ? "0" : reader.GetString(6));
                        float totalweight = float.Parse(reader.IsDBNull(7) ? "0" : reader.GetString(7));
                        string sql1 = "";
                        string sql2 = "";
                        if (money + float.Parse(obj.money) > 0)
                        {
                            sql1 = "update ZC_SAVEIN_WAREHOUSE_ITEM set money = '"+(money+float.Parse(obj.money))+"', nums = '"+(nums + float.Parse(obj.sorteNum))+"', weight = '"+(weight - float.Parse(obj.weight))+"' where id = '"+itemId+"' ";
                            sql2 = "update ZC_SAVEIN_WAREHOUSE set money = '" + (totalmoney + float.Parse(obj.money)) + "', nums = '" + (totalnums + float.Parse(obj.sorteNum)) + "', weight = '" + (totalweight - float.Parse(obj.weight)) + "' where id = '" + id + "' ";
                        }
                        else 
                        {
                            //数量相同
                            if (totalmoney - money > 0)
                            {
                                sql1 = "delete from  ZC_SAVEIN_WAREHOUSE_ITEM  where id = '" + itemId + "' ";
                                sql2 = "update ZC_SAVEIN_WAREHOUSE set money = '" + (totalmoney + float.Parse(obj.money)) + "', nums = '" + (totalnums + float.Parse(obj.sorteNum)) + "', weight = '" + (totalweight - float.Parse(obj.weight)) + "' where id = '" + id + "' ";
                            }
                            else 
                            {
                                //当前删除的商品时唯一的退货商品
                                sql1 = "delete from  ZC_SAVEIN_WAREHOUSE_ITEM  where id = '" + itemId + "' ";
                                sql2 = "delete from ZC_SAVEIN_WAREHOUSE where id = '"+id+"'";
                            }
                        }
                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    log.Error("删除退货商品,入库单修改", ex);
                }
                finally
                { 
                    if(tran != null){
                        tran.Dispose();
                    }
                    if(reader != null){
                        reader.Close();
                    }
                    cmd.Dispose();
                    if(conn != null){
                        conn.Close();
                    }
                }
            }

    }

    
}

