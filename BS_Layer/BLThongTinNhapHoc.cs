using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinNhapHoc
    {
       /* public Table<ThongTinNhapHoc> LayThongTinNhapHoc()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinNhapHocs;
        }

        public bool ThemThongTinNhapHoc(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinNhapHoc tt = new ThongTinNhapHoc();
            tt.NoiDungNhapHoc = NDNhapHoc;
            tt.BuocSo = BuocSo;
            tt.NoiDung = NoiDung;

            qlTS.ThongTinNhapHocs.InsertOnSubmit(tt);
            qlTS.ThongTinNhapHocs.Context.SubmitChanges();
            return true;
        }

        public bool XoaThongTin(ref string err, string NoiDungNhapHoc)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinNhapHocs
                          where tp.NoiDungNhapHoc == NoiDungNhapHoc
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaThongTin(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinNhapHocs
                           where ts.NoiDungNhapHoc == NDNhapHoc
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.NoiDungNhapHoc = NDNhapHoc;
                tsQuery.BuocSo = BuocSo;
                tsQuery.NoiDung = NoiDung;
                qlTS.SubmitChanges();
            }
            return true;
        }*/

        DBMain db = null;
        public BLThongTinNhapHoc()
        {
            db=new DBMain();
        }
        public DataSet LayThongTinNhapHoc()
        {
            return db.ExecuteQueryDataSet("select * from ThongTinNhapHoc", CommandType.Text);
        }
        public bool ThemThongTinNhapHoc(string NDNhapHoc, string BuocSo,string NoiDung, ref string err)
        {
            string sqlString = "Insert into ThongTinNhapHoc values (" + "N'" + NDNhapHoc + "',N'" + BuocSo + "',N'" + NoiDung + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaThongTin(ref string err, string NoiDungNhapHoc)
        {
            string sqlString = "delete from ThongTinNhapHoc where NoiDungNhapHoc=N'" + NoiDungNhapHoc + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaThongTin(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            string sqlString = "UPDATE ThongTinNhapHoc SET BuocSo=N'" + BuocSo + "',NoiDung=N'" 
                + NoiDung + "'WHERE NoiDungNhapHoc=N'" + NDNhapHoc + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
