using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinNguoiDung
    {
        /*public Table<ThongTinNguoiDung> LayThongTinNguoiDung()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinNguoiDungs;
        }

        public bool ThemNguoiDung(string HoTen, string DienThoai, string Email, string LoaiNGuoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinNguoiDung tt = new ThongTinNguoiDung();
            tt.HoTen = HoTen;
            tt.DienThoai = DienThoai;
            tt.Email = Email;
            tt.LoaiNguoiDung = LoaiNGuoiDung;

            qlTS.ThongTinNguoiDungs.InsertOnSubmit(tt);
            qlTS.ThongTinNguoiDungs.Context.SubmitChanges();
        }

        public bool XoaNguoiDung(ref string err, string HoTen)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.ThongTinNguoiDungs
                          where ts.HoTen == HoTen
                          select ts;
            qlTS.ThongTinNguoiDungs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaThongTin(ref string err, string HoTen, string DienThoai, string Email, string LoaiNGuoiDung)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinNguoiDungs
                           where ts.Email == Email
                           select ts).SingleOrDefault();

            if(tsQuery != null)
            {
                tsQuery.HoTen = HoTen;
                tsQuery.DienThoai = DienThoai;
                tsQuery.Email = Email;
                tsQuery.LoaiNguoiDung = LoaiNGuoiDung;
            }
            return true;
        }*/

        DBMain db = null;
        public BLThongTinNguoiDung()
        {
            db=new DBMain();
        }
        public DataSet LayThongTinNguoiDung()
        {
            return db.ExecuteQueryDataSet("select * from ThongTinNguoiDung", CommandType.Text);
        }
        public bool ThemNguoiDung(string HoTen, string DienThoai,string Email, string LoaiNGuoiDung, ref string err)
        {
            string sqlString = "Insert into ThongTinNguoiDung values (" + "N'" + HoTen + "',N'" + DienThoai + "',N'" + Email + "',N'" + LoaiNGuoiDung + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNguoiDung(ref string err, string HoTen)
        {
            string sqlString = "delete from ThongTinNguoiDung where HoTen=N'" + HoTen+ "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaThongTin(ref string err, string HoTen, string DienThoai, string Email, string LoaiNGuoiDung)
        {
            string sqlString = "UPDATE ThongTinNguoiDung SET DienThoai=N'" + DienThoai + "',Email=N'"
                + Email + "',LoaiNguoiDung=N'" + LoaiNGuoiDung + "' Where HoTen=N'"+HoTen+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
