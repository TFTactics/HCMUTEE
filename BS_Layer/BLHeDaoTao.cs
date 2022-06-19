using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLHeDaoTao
    {
        /*public Table<HeDaoTao> LayHeDaoTao()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.HeDaoTaos;
        }

        public bool ThemHeDaoTao(string MaHDT, string TenHDT, string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            HeDaoTao hdt = new HeDaoTao();
            hdt.MaHeDaoTao = MaHDT;
            hdt.TenHeDaoTao = TenHDT;
            hdt.GioiThieu = GioiThieu

            qlTS.HeDaoTaos.InsertOnSubmit(tp);
            qlTS.HeDaoTaos.Context.SubmitChanges();
            return true;
        }

        public bool XoaHeDaoTao(ref string err, string MaHDT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tpQuery = from ts in qlTS.HeDaoTaos
                          where ts.MaHeDaoTao == MaHDT
                          select tp;
            qlTS.ThanhPhos.DeleteAllOnSubmit(tpQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaHeDaoTao(ref string err, string MaHDT, string TenHDT, string GT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tpQuery = (from tp in qlTS.HeDaoTaos
                           where tp.MaHeDaoTao == MaHDT
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenHeDaoTao = TenHDT;
                qlBH.SubmitChanges();
            }
            return true;
        }*/

        DBMain db = null;
        public BLHeDaoTao()
        {
            db=new DBMain();
        }
        public DataSet LayHeDaoTao()
        {
            return db.ExecuteQueryDataSet("select * from HeDaoTao", CommandType.Text);
        }
        public bool ThemHeDaoTao(string MaHDT, string TenHDT,string GioiThieu, ref string err)
        {
            string sqlString = "Insert into HeDaoTao values (" + "N'" + MaHDT + "',N'" + TenHDT + "',N'" + GioiThieu + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaHeDaoTao(ref string err, string MaHDT)
        {
            string sqlString = "delete from HeDaoTao where MaHeDaoTao=N'" + MaHDT + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaHeDaoTao(ref string err, string MaHDT, string TenHDT, string GT)
        {
            string sqlString = "UPDATE HeDaoTao SET TenHeDaoTao=N'" + TenHDT + "',GioiThieu=N'"
                + GT + "'WHERE MaHeDaoTao=N'" + MaHDT + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
