using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLDanhSachUngTuyen
    {
        /*public Table<DanhSachUngTuyen> LayDanhSachUngTuyen()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.DanhSachUngTuyens;
        }

        public bool ThemDanhSachUngTuyen(string HoTen, string Email, string SDT, int MaHoSo, int MaNguyenVong, string NganhUngTuyen, string TrangThai, string PhuongThuc, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            DanhSachUngTuyen ds = new DanhSachUngTuyen();
            ds.HoTen = HoTen;
            ds.Email = Email;
            ds.SDT = SDT;
            ds.MaHoSo = MaHoSo;
            ds.MaNguyenVong = MaNguyenVong;
            ds.NganhUngTuyen = NganhUngTuyen;
            ds.TrangThai = TrangThai;
            ds.PhuongThuc = PhuongThuc;

            qlTS.DanhSachUngTuyens.InsertOnSubmit(ds);
            qlTS.DanhSachUngTuyens.Context.SubmitChanges();
            return false;
        }

        public bool XoaDanhSachUngTuyen(ref string err, string email)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.DanhSachUngTuyens
                          where ts.Email == email
                          select tp;
            qlTS.DanhSachUngTuyens.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaDanhSachUngTuyen(ref string err, string Hoten, string email, string sdt, int MaHS, int MaNV, string TrangThai, string PT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.DanhSachUngTuyens
                           where ts.Email == email
                           select ts).SingleOrDefault();

            if(tsQuery != null)
            {
                tsQuery.HoTen = Hoten;
                tsQuery.Email = email;
                tsQuery.SDT = sdt;
                tsQuery.MaHoSo = MaHS;
                tsQuery.MaNguyenVong = MaNV;
                tsQuery.TrangThai = TrangThai;
                tsQuery.PhuongThuc = PT;
                qlTS.SubmitChanges();
            }
            return true;
        }*/
        
        DBMain db = null;
        public BLDanhSachUngTuyen()
        {
            db=new DBMain();
        }
        public DataSet LayDanhSachUngTuyen()
        {
            return db.ExecuteQueryDataSet("select * from DanhSachUngTuyen", CommandType.Text);
        }
        public bool ThemDanhSachUngTuyen(string HoTen, string Email,string SDT, int MaHoSo, int MaNguyenVong, string NganhUngTuyen, string TrangThai, string PhuongThuc, ref string err)
        {
            string sqlString = "Insert into DanhSachUngTuyen values (" + "N'" + HoTen + "',N'" + Email + "',N'" + SDT + "','" + MaHoSo + "','" + MaNguyenVong + "',N'" + NganhUngTuyen + "',N'" + TrangThai + "',N'" + PhuongThuc + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaDanhSachUngTuyen(ref string err, string email)
        {
            string sqlString = "delete from DanhSachUngTuyen where Email=N'" + email +"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaDanhSachUngTuyen(ref string err, string Hoten, string email, string sdt,int MaHS,int MaNV, string TrangThai, string PT)
        {
            string sqlString = "Update DanhSachUngTuyen SET HoTen=N'" + Hoten + 
                "',SDT=N'" + sdt +"',MaHoSo='"+MaHS+"',MaNguyenVong='"+MaNV+ "',TrangThai=N'" + TrangThai+"',PhuongThuc=N'"+PT
                + "'WHERE Email = N'" + email + "'" ;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public int DemSoTSTrungTuyen()
        {
            string sqlString = "Select TrangThai from DanhSachUngTuyen where TrangThai=N'" + "Trúng Tuyển" + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0].Rows.Count;
        }
        public int DemSoDonUT()
        {
            return LayDanhSachUngTuyen().Tables[0].Rows.Count;
        }
    }
}
