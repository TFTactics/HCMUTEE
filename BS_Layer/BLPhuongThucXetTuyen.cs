using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLPhuongThucXetTuyen
    {
       /* public Table<PhuongThucXetTuyen> LayPhuongThucXetTuyen()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.PhuongThucXetTuyens;
        }

        public bool ThemPhuongThucXetTuyen(string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            PhuongThucXetTuyen xt = new PhuongThucXetTuyen();
            xt.TenPhuongThuc = TenPT;
            xt.MaPhuongThuc = MaPT;
            xt.HeDaoTao = HeDaoTao;
            xt.ThoiGianBatDau = TGBD;
            xt.ThoiGianKetThuc = TGKT;
            xt.HinhAnh = Anh;
            xt.NoiDung = NoiDung;
            xt.PhuongThucCha = PTCha;

            qlTS.PhuongThucXetTuyens.InsertOnSubmit(xt);
            qlTS.PhuongThucXetTuyens.Context.SubmitChanges();
            return true;
        }
        public bool XoaPhuongThucXetTuyen(ref string err, string MaPhuongThuc)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.PhuongThucXetTuyens
                          where tp.MaPhuongThuc == MaPhuongThuc
                          select tp;

            qlTS.PhuongThucXetTuyens.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaPhuongThuc(ref string err, string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.PhuongThucXetTuyens
                           where ts.MaPhuongThuc == MaPT
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.TenPhuongThuc = TenPT;
                tsQuery.MaPhuongThuc = MaPT;
                tsQuery.HeDaoTao = HeDaoTao;
                tsQuery.ThoiGianBatDau = TGBD;
                tsQuery.ThoiGianKetThuc = TGKT;
                tsQuery.HinhAnh = Anh;
                tsQuery.NoiDung = NoiDung;
                tsQuery.PhuongThucCha = PTCha;
                qlTS.SubmitChanges();
            }
            return true;
        }
*/
        DBMain db = null;
        public BLPhuongThucXetTuyen()
        {
            db=new DBMain();
        }
        public DataSet LayPhuongThucXetTuyen()
        {
            return db.ExecuteQueryDataSet("select * from PhuongThucXetTuyen", CommandType.Text);
        }
        public bool ThemPhuongThucXetTuyen(string TenPT, string MaPT, string HeDT, DateTime TGBD , DateTime TGKT, string Anh, string NoiDung, string PTCha,ref string err)
        {
            string sqlString = "Insert into PhuongThucXetTuyen values (" + "N'" + TenPT + "',N'" + MaPT + "',N'" + HeDT + "','" + TGBD.ToString("yyyy-MM-dd") + "','" + TGKT.ToString("yyyy-MM-dd") + "',N'" + Anh + "',N'" + NoiDung + "',N'" + PTCha + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaPhuongThucXetTuyen(ref string err, string MaPhuongThuc)
        {
            string sqlString = "delete from PhuongThucXetTuyen where MaPhuongThuc=N'" + MaPhuongThuc + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaPhuongThuc(ref string err, string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha)
        {
            string sqlString = "UPDATE PhuongThucXetTuyen SET TenPhuongThuc=N'"+TenPT+"',HeDaoTao=N'"+HeDT+"',ThoiGianBatDau=N'"+TGBD.Date
                +"',ThoiGianKetThuc = N'"+TGKT.Date+"',HinhAnh = N'"+Anh+"',NoiDung = N'"+NoiDung
                +"',PhuongThucCha = N'"+PTCha+"' WHERE MaPhuongThuc = N'"+MaPT+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
