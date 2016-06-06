using log4net;
using Oracle.ManagedDataAccess.Client;
using sorteSystem.com.proem.sorte.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Branch;

namespace sorteSystem.com.proem.sorte.dao
{
    public class ZcGoodsMasterDao
    {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog log = LogManager.GetLogger(typeof(ZcGoodsMasterDao));

        /// <summary>
        /// 根据货号获取商品信息
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        public ZcGoodsMaster FindBySerialNumber(string serial)
        {
            ZcGoodsMaster obj = null;
            string sql = "select ID,CREATETIME,UPDATETIME, DELFLAG, DISTRIBUTION_PRICE, EARLY_WARNING_DAYS, EARLY_WARNING_DAYS2, "
                    + " GOODSATTRIBUTE, GOODS_DISCOUNT_RATE, GOODS_PY_CODE, GOODS_CODE, GOODS_NAME, GOODS_ORIGIN, GOODS_PRICE, "
                    + " GOODS_PROPERTY, GOODS_PURCHASE_PRICE, GOODS_SPECIFICATIONS, GOODS_STATE, GOODS_TYPE, GOODS_UNIT, GROSS_MARGIN, "
                    + " INPUT_TAX, JOINT_RATE, LOWEST_PRICE, MANAGEMENT_INVENTORY, MEMBER_PRICE, MEMBER_PRICE2, MEMBER_PRICE3, MEMBER_PRICE4, MEMBER_PRICE5, "
                    + " OUT_TAX, POINT_OR_NOT, POINTS_VALUE, PROCUREMENT_STATUS, PRODUCTGOODSID, PURCHASE_SPECIFICATIONS, REMARK, SERIALNUMBER, STORE, VALIDITY_PERIOD, "
                    + " VALUATION_METHOD, WASTERATE, WHOLESALE_PRICE, WHOLESALE_PRICE2, WHOLESALE_PRICE3, WHOLESALE_PRICE4,WHOLESALE_PRICE5,WHOLESALE_PRICE6,WHOLESALE_PRICE7,WHOLESALE_PRICE8, "
                    + " ZCUSERINFO, GOODSFILE_USERID, GOODSTYPE_ID, GOODS_BRAND_ID, GOODS_CLASS_ID, GOODS_SUPPLIER_ID from zc_goods_master where serialNumber = :serial";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":serial", serial);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    obj = new ZcGoodsMaster();
                    obj.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    obj.CreateTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                    obj.UpdateTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(2);
                    obj.DelFlag = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    obj.DistributionPrice = reader.IsDBNull(4) ? default(float) : reader.GetFloat(4);
                    obj.EarlyWarningDays = reader.IsDBNull(5) ? default(float) : reader.GetFloat(5);
                    obj.EarlyWarningDays2 = reader.IsDBNull(6) ? default(float) : reader.GetFloat(6);
                    obj.GoodsAttribute = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    obj.GoodsDiscountRate = reader.IsDBNull(8) ? default(float) : reader.GetFloat(8);
                    obj.GoodsPyCode = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    obj.GoodsCode = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    obj.GoodsName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                    obj.GoodsOrigin = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    obj.GoodsPrice = reader.IsDBNull(13) ? default(float) : reader.GetFloat(13);
                    obj.GoodsProperty = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                    obj.GoodsPurchasePrice = reader.IsDBNull(15) ? string.Empty : reader.GetFloat(15).ToString();
                    obj.GoodsSpecifications = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                    obj.GoodsState = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                    obj.GoodsType = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                    obj.GoodsUnit = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                    obj.GrossMargin = reader.IsDBNull(20) ? default(float) : reader.GetFloat(20);
                    obj.InputTax = reader.IsDBNull(21) ? default(float) : reader.GetFloat(21);
                    obj.JoinRate = reader.IsDBNull(22) ? default(float) : reader.GetFloat(22);
                    obj.LowestPrice = reader.IsDBNull(23) ? default(float) : reader.GetFloat(23);
                    obj.ManagementInventory = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                    obj.MemberPrice = reader.IsDBNull(25) ? default(float) : reader.GetFloat(25);
                    obj.MemberPrice2 = reader.IsDBNull(26) ? default(float) : reader.GetFloat(26);
                    obj.MemberPrice3 = reader.IsDBNull(27) ? default(float) : reader.GetFloat(27);
                    obj.MemberPrice4 = reader.IsDBNull(28) ? default(float) : reader.GetFloat(28);
                    obj.MemberPrice5 = reader.IsDBNull(29) ? default(float) : reader.GetFloat(29);
                    obj.OutTax = reader.IsDBNull(30) ? default(float) : reader.GetFloat(30);
                    obj.PointOrNot = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
                    obj.PointsValue = reader.IsDBNull(32) ? default(float) : reader.GetFloat(32);
                    obj.ProcurementStatus = reader.IsDBNull(33) ? string.Empty : reader.GetString(33);
                    obj.ProductGoodsId = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
                    obj.PurchaseSpecifications = reader.IsDBNull(35) ? string.Empty : reader.GetString(35);
                    obj.Remark = reader.IsDBNull(36) ? string.Empty : reader.GetString(36);
                    obj.SerialNumber = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
                    obj.Store = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
                    obj.ValidityPeriod = reader.IsDBNull(39) ? default(float) : reader.GetFloat(39);
                    obj.ValucationMethod = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
                    obj.WasteRate = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
                    obj.WholeSalePrice = reader.IsDBNull(42) ? default(float) : reader.GetFloat(42);
                    obj.WholeSalePrice2 = reader.IsDBNull(43) ? default(float) : reader.GetFloat(43);
                    obj.WholeSalePrice3 = reader.IsDBNull(44) ? default(float) : reader.GetFloat(44);
                    obj.WholeSalePrice4 = reader.IsDBNull(45) ? default(float) : reader.GetFloat(45);
                    obj.WholeSalePrice5 = reader.IsDBNull(46) ? default(float) : reader.GetFloat(46);
                    obj.WholeSalePrice6 = reader.IsDBNull(47) ? default(float) : reader.GetFloat(47);
                    obj.WholeSalePrice7 = reader.IsDBNull(48) ? default(float) : reader.GetFloat(48);
                    obj.WholeSalePrice8 = reader.IsDBNull(49) ? default(float) : reader.GetFloat(49);
                    obj.ZcUserInfoId = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
                    obj.GoodsFileUserId = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);
                    obj.GoodsTypeId = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
                    obj.GoodsBrandId = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
                    obj.GoodsClassId = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
                    obj.GoodsSupplierId = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
                }
            }
            catch (Exception ex)
            {
                log.Error("根据货号获取商品信息失败", ex);
            }
            finally
            {
                OracleUtil.CloseConn(conn);
            }
            return obj;
        }


        /// <summary>
        /// 查看商品有没有对应的原材料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsWeightGoods(string id)
        {
            bool isWeightGoods = false;
            string sql = "select id from zc_goods_master where PRODUCTGOODSID = '" + id + "'";
            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = null;
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isWeightGoods = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("根据id查询原材料失败", ex);
            }
            finally
            {
                OracleUtil.CloseConn(conn);
            }
            return isWeightGoods;
        }

        public ZcGoodsMaster FindById(string goodsFileId)
        {
            ZcGoodsMaster obj = null;
            string sql = "select ID,CREATETIME,UPDATETIME, DELFLAG, DISTRIBUTION_PRICE, EARLY_WARNING_DAYS, EARLY_WARNING_DAYS2, "
                    + " GOODSATTRIBUTE, GOODS_DISCOUNT_RATE, GOODS_PY_CODE, GOODS_CODE, GOODS_NAME, GOODS_ORIGIN, GOODS_PRICE, "
                    + " GOODS_PROPERTY, GOODS_PURCHASE_PRICE, GOODS_SPECIFICATIONS, GOODS_STATE, GOODS_TYPE, GOODS_UNIT, GROSS_MARGIN, "
                    + " INPUT_TAX, JOINT_RATE, LOWEST_PRICE, MANAGEMENT_INVENTORY, MEMBER_PRICE, MEMBER_PRICE2, MEMBER_PRICE3, MEMBER_PRICE4, MEMBER_PRICE5, "
                    + " OUT_TAX, POINT_OR_NOT, POINTS_VALUE, PROCUREMENT_STATUS, PRODUCTGOODSID, PURCHASE_SPECIFICATIONS, REMARK, SERIALNUMBER, STORE, VALIDITY_PERIOD, "
                    + " VALUATION_METHOD, WASTERATE, WHOLESALE_PRICE, WHOLESALE_PRICE2, WHOLESALE_PRICE3, WHOLESALE_PRICE4,WHOLESALE_PRICE5,WHOLESALE_PRICE6,WHOLESALE_PRICE7,WHOLESALE_PRICE8, "
                    + " ZCUSERINFO, GOODSFILE_USERID, GOODSTYPE_ID, GOODS_BRAND_ID, GOODS_CLASS_ID, GOODS_SUPPLIER_ID from zc_goods_master where id = :serial";
            OracleConnection conn = null;
            OracleCommand cmd = new OracleCommand();
            try
            {
                conn = OracleUtil.OpenConn();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":serial", goodsFileId);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    obj = new ZcGoodsMaster();
                    obj.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    obj.CreateTime = reader.IsDBNull(1) ? default(DateTime) : reader.GetDateTime(1);
                    obj.UpdateTime = reader.IsDBNull(2) ? default(DateTime) : reader.GetDateTime(2);
                    obj.DelFlag = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    obj.DistributionPrice = reader.IsDBNull(4) ? default(float) : reader.GetFloat(4);
                    obj.EarlyWarningDays = reader.IsDBNull(5) ? default(float) : reader.GetFloat(5);
                    obj.EarlyWarningDays2 = reader.IsDBNull(6) ? default(float) : reader.GetFloat(6);
                    obj.GoodsAttribute = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    obj.GoodsDiscountRate = reader.IsDBNull(8) ? default(float) : reader.GetFloat(8);
                    obj.GoodsPyCode = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    obj.GoodsCode = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    obj.GoodsName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                    obj.GoodsOrigin = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    obj.GoodsPrice = reader.IsDBNull(13) ? default(float) : reader.GetFloat(13);
                    obj.GoodsProperty = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                    obj.GoodsPurchasePrice = reader.IsDBNull(15) ? string.Empty : reader.GetFloat(15).ToString();
                    obj.GoodsSpecifications = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                    obj.GoodsState = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                    obj.GoodsType = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                    obj.GoodsUnit = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                    obj.GrossMargin = reader.IsDBNull(20) ? default(float) : reader.GetFloat(20);
                    obj.InputTax = reader.IsDBNull(21) ? default(float) : reader.GetFloat(21);
                    obj.JoinRate = reader.IsDBNull(22) ? default(float) : reader.GetFloat(22);
                    obj.LowestPrice = reader.IsDBNull(23) ? default(float) : reader.GetFloat(23);
                    obj.ManagementInventory = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                    obj.MemberPrice = reader.IsDBNull(25) ? default(float) : reader.GetFloat(25);
                    obj.MemberPrice2 = reader.IsDBNull(26) ? default(float) : reader.GetFloat(26);
                    obj.MemberPrice3 = reader.IsDBNull(27) ? default(float) : reader.GetFloat(27);
                    obj.MemberPrice4 = reader.IsDBNull(28) ? default(float) : reader.GetFloat(28);
                    obj.MemberPrice5 = reader.IsDBNull(29) ? default(float) : reader.GetFloat(29);
                    obj.OutTax = reader.IsDBNull(30) ? default(float) : reader.GetFloat(30);
                    obj.PointOrNot = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
                    obj.PointsValue = reader.IsDBNull(32) ? default(float) : reader.GetFloat(32);
                    obj.ProcurementStatus = reader.IsDBNull(33) ? string.Empty : reader.GetString(33);
                    obj.ProductGoodsId = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
                    obj.PurchaseSpecifications = reader.IsDBNull(35) ? string.Empty : reader.GetString(35);
                    obj.Remark = reader.IsDBNull(36) ? string.Empty : reader.GetString(36);
                    obj.SerialNumber = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
                    obj.Store = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
                    obj.ValidityPeriod = reader.IsDBNull(39) ? default(float) : reader.GetFloat(39);
                    obj.ValucationMethod = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
                    obj.WasteRate = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
                    obj.WholeSalePrice = reader.IsDBNull(42) ? default(float) : reader.GetFloat(42);
                    obj.WholeSalePrice2 = reader.IsDBNull(43) ? default(float) : reader.GetFloat(43);
                    obj.WholeSalePrice3 = reader.IsDBNull(44) ? default(float) : reader.GetFloat(44);
                    obj.WholeSalePrice4 = reader.IsDBNull(45) ? default(float) : reader.GetFloat(45);
                    obj.WholeSalePrice5 = reader.IsDBNull(46) ? default(float) : reader.GetFloat(46);
                    obj.WholeSalePrice6 = reader.IsDBNull(47) ? default(float) : reader.GetFloat(47);
                    obj.WholeSalePrice7 = reader.IsDBNull(48) ? default(float) : reader.GetFloat(48);
                    obj.WholeSalePrice8 = reader.IsDBNull(49) ? default(float) : reader.GetFloat(49);
                    obj.ZcUserInfoId = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
                    obj.GoodsFileUserId = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);
                    obj.GoodsTypeId = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
                    obj.GoodsBrandId = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
                    obj.GoodsClassId = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
                    obj.GoodsSupplierId = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
                }
            }
            catch (Exception ex)
            {
                log.Error("根据id获取商品信息失败", ex);
            }
            finally
            {
                OracleUtil.CloseConn(conn);
            }
            return obj;
        }
    }
}
