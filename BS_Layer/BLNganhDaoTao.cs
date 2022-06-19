using System.Data;
using System.Text.RegularExpressions;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLNganhDaoTao
    {
        public Table<ThongTinChuyenNganh> LayThongTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinChuyenNganhs;
        }

        public bool ThemNganhDaoTao(string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinChuyenNganh tt = new ThongTinChuyenNganh();
            tt.MaNganh = MaNganh;
            tt.TenNganh = TenN;
            tt.LoaiChuongTrinh = LoaiCT;
            tt.Khoa = Khoa;
            tt.ChiTieu = ChiTieu;
            tt.HocPhi = HocPhi;
            tt.MoTaNganh = MoTa;

            qlTS.ThongTinChuyenNganhs.InsertOnSubmit(tt);
            qlTS.ThongTinChuyenNganhs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNganh(ref string err, string MaNgang)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinChuyenNganhs
                          where tp.MaNganh == MaNgang
                          select tp;

            qlTS.ThongTinChuyenNganhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaNganh(ref string err, string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinChuyenNganhs
                           where ts.MaNganh == MaNganh
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.TenNganh = TenN;
                tsQuery.LoaiChuongTrinh = LoaiCT;
                tsQuery.Khoa = Khoa;
                tsQuery.ChiTieu = ChiTieu;
                tsQuery.HocPhi = HocPhi;
                tsQuery.MoTaNganh = MoTa;
                qlTS.SubmitChanges();
            }
            return true;
        }

        DBMain db = null;
        public BLNganhDaoTao()
        {
            db=new DBMain();
        }
        public DataSet LayThongTin()
        {
            return db.ExecuteQueryDataSet("select * from ThongTinChuyenNganh", CommandType.Text);
        }
        public bool ThemNganhDaoTao(string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa, ref string err)
        {
            string sqlString = "Insert into ThongTinChuyenNganh values (" + "N'" + MaNganh +"',N'"+TenN+ "',N'" + LoaiCT + "',N'" + Khoa + "','" + ChiTieu + "','" + HocPhi + "',N'" + MoTa + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNganh(ref string err, string MaNgang)
        {
            string sqlString = "delete from ThongTinChuyenNganh where MaNganh=N'" + MaNgang +"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaNganh(ref string err,string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu,int HocPhi, string MoTa)
        {
            string sqlString = "Update ThongTinChuyenNganh SET TenNganh = N'" + TenN + "',LoaiChuongTrinh =N'" + LoaiCT + "',Khoa=N'" + Khoa + "',ChiTieu='" + ChiTieu+"',HocPhi='"+HocPhi+"',MoTaNganh=N'"+MoTa
                + "'WHERE MaNganh = N'" + MaNganh + "'" ;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public DataSet SearchNganh(string value)
        {
            string sqlString;
            if (!IsNumber(value))
            {
                sqlString = "select * from ThongTinChuyenNganh where MaNganh like '%"
                    + value + "%' or TenNganh like '%" + value + "%' or LoaiChuongTrinh like '%" + value
                    + "%' or Khoa like '%" + value + "%' or  MoTaNganh like '%" + value + "%'";
                
            }
            else
            {
                sqlString = "select * from ThongTinChuyenNganh where MaNganh like '%"
                    + value + "%' or TenNganh like '%" + value + "%' or LoaiChuongTrinh like '%" + value
                    + "%' or Khoa like '%" + value + "%' or ChiTieu='" + value + "' or HocPhi ='"
                    + value + "' or MoTaNganh like '%" + value + "%'";
            }
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public DataSet LocLoaiCT(string value)
        {
            string sqlString = "select * from ThongTinChuyenNganh where LoaiChuongTrinh = '"+value+"'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public int DemSoNganh()
        {
            return LayThongTin().Tables[0].Rows.Count;
        }    
    }
}
