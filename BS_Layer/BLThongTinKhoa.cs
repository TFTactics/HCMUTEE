using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinKhoa
    {
        /*public Table<ThongTinKhoa> LayThongTinKhoa()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinKhoas;
        }

        public bool ThemThongTinKhoa(string TenKhoa, string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinKhoa tt = new ThongTinKhoa();
            tt.TenKhoa = TenKhoa;
            tt.GioiThieu = GioiThieu;

            qlTS.ThongTinKhoas.InsertOnSubmit(tt);
            qlTS.ThongTinKhoas.Context.SubmitChanges();
            return true;
        }
        public bool XoaThongTinKhoa(ref string err, string TenKhoa)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinKhoas
                          where tp.TenKhoa == TenKhoa
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaThongTinKhoa(ref string err, string TenKhoa, string GT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinKhoas
                           where ts.TenKhoa == TenKhoa
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.GioiThieu = GT;
                qlTS.SubmitChanges();
            }
            return true;
        }*/

        DBMain db = null;
        public BLThongTinKhoa()
        {
            db=new DBMain();
        }
        public DataSet LayThongTinKhoa()
        {
            return db.ExecuteQueryDataSet("select * from ThongTinKhoa", CommandType.Text);
        }
        public bool ThemThongTinKhoa(string TenKhoa, string GioiThieu, ref string err)
        {
            string sqlString = "Insert into ThongTinKhoa values (" + "N'" + TenKhoa + "',N'" + GioiThieu + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaThongTinKhoa(ref string err, string TenKhoa)
        {
            string sqlString = "delete from ThongTinKhoa where TenKhoa=N'" + TenKhoa+ "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaThongTinKhoa(ref string err, string TenKhoa, string GT)
        {
            string sqlString = "UPDATE ThongTinKhoa SET GioiThieu=N'" + GT + "'WHERE TenKhoa=N'" +TenKhoa
                + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
