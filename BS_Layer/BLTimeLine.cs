using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLTimeLine
    {
        /*public Table<TimeLine> LayTimeLine()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.TimeLines;
        }

        public bool ThemTimeLine(string TenSuKien, DateTime BatDau, DateTime KetThuc, string HeDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            TimeLine tl = new TimeLine();
            tl.TenSuKien = TenSuKien;
            tl.ThoiGianBatDau = BatDau;
            tl.ThoiGianKetThuc = KetThuc;
            tl.HeDaoTao = HeDaoTao;
            tl.NoiDung = NoiDung;

            qlTS.TimeLines.InsertOnSubmit(tl);
            qlTS.TimeLines.Context.SubmitChanges();
            return true;
        }

        public bool XoaBangTin(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.TimeLines
                          where ts.TenSuKien == TieuDe
                          select ts;

            qlTS.TimeLines.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaBangTin(ref string err, string TenSK, DateTime NgayDang, DateTime KetThuc, string HDT, string NoiDung)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.TimeLines
                           where ts.TenSuKien == TenSK
                           select ts).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.ThoiGianBatDau = NgayDang;
                tsQuery.ThoiGianKetThuc = KetThuc;
                tsQuery.HeDaoTao = HDT;
                tsQuery.NoiDung = NoiDung;
            }
            return true;
        }*/
        DBMain db = null;
        public BLTimeLine()
        {
            db = new DBMain();
        }
        public DataSet LayTimeLine()
        {
            return db.ExecuteQueryDataSet("select * from TimeLine", CommandType.Text);
        }
        public bool ThemTimeLine(string TenSuKien, DateTime BatDau, DateTime KetThuc, string HeDaoTao, string NoiDung, ref string err)
        {
            string sqlString = "Insert into TimeLine values (" + "N'" + TenSuKien + "',N'" + BatDau.ToString("yyyy-MM-dd") + "',N'" + KetThuc.ToString("yyyy-MM-dd") + "',N'" + HeDaoTao + "',N'" + NoiDung + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaBangTin(ref string err, string TieuDe)
        {
            string sqlString = "delete from TimeLine where TenSuKien=N'" + TieuDe + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaBangTin(ref string err, string TenSK, string NgayDang, string KetThuc, string HDT, string NoiDung)
        {
            string sqlString = "UPDATE TimeLine SET ThoiGianBatDau=N'" + Convert.ToDateTime(NgayDang).Date + "',ThoiGianKetThuc=N'"
                + Convert.ToDateTime(KetThuc).Date + "',HeDaoTao=N'" + HDT + "',NoiDung=N'" + NoiDung + "'WHERE TenSuKien=N'" + TenSK + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
