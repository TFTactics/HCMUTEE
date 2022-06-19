using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLBangTinTuyenSinh
    {
        /*public Table<TinTuyenSinh> LayBangTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.TinTuyenSinhs;
        }

        public bool ThemBangTin(string TieuDe, string NoiDung, string HeDaoTao, string TrangThai, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            TinTuyenSinh ts = new TinTuyenSinh();
            ts.TieuDe = TieuDe;
            ts.NoiDung = NoiDung;
            ts.HeDaoTao = HeDaoTao;
            ts.TrangThai = TrangThai;

            qlTS.TinTuyenSinhs.InsertOnSubmit(ts);
            qlTS.TinTuyenSinhs.Context.SubmitChanges();
            return true;
        }

        public bool XoaBangTin(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.TinTuyenSinhs
                          where tp.TieuDe == TieuDe
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaTin(ref string err, string TieuDe, string NoiDung, string HeDaoTao, string TrangThai)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.TinTuyenSinhs
                           where ts.TieuDe == TieuDe
                           select ts).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.NoiDung = NoiDung;
                tsQuery.HeDaoTao = HeDaoTao;
                tsQuery.TrangThai = TrangThai;
                qlTS.SubmitChanges();
            }
            return true;
        }*/
        DBMain db = null;
        public BLBangTinTuyenSinh()
        {
            db = new DBMain();
        }
        public DataSet LayBangTin()
        {
            return db.ExecuteQueryDataSet("select * from TinTuyenSinh", CommandType.Text);
        }
        public bool ThemBangTin(string TieuDe, string NoiDung, string HeDaoTao, string TrangThai, ref string err)
        {
            string sqlString = "Insert into TinTuyenSinh values (" + "N'" + TieuDe + "',N'" + NoiDung + "',N'" + HeDaoTao + "',N'" + TrangThai + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaBangTin(ref string err, string TieuDe)
        {
            string sqlString = "delete from TinTuyenSinh where TieuDe=N'" + TieuDe + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaTin(ref string err, string TieuDe, string NoiDung, string HeDaoTao, string TrangThai)
        {
            string sqlString = "Update TinTuyenSinh SET TieuDe=N'" + TieuDe +
                "',NoiDung=N'" + NoiDung + "',HeDaoTao=N'" + HeDaoTao + "',TrangThai=N'" + TrangThai
                + "'WHERE TieuDe = N'" + TieuDe + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public int DemSoTinTS()
        {
            return LayBangTin().Tables[0].Rows.Count;
        }
    }
}
