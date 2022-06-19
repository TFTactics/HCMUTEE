using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    class BLThongTinTruong
    {
        /*public Table<ThongTinChung> LayBangTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinChungs;
        }

        public bool SuaBangTin(string GioiThieuTruong, int SoGiaoSu,
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinChungs
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.GioiThieuTruong = GioiThieuTruong;
                tsQuery.SoGiaoSu = SoGiaoSu;
                tsQuery.SoPhoGiaoSu = PhoGS;
                tsQuery.SoNganhDaoTaoThacSi = NganhThac;
                tsQuery.SoNganhDaoTaoTienSi = NganhTien;
                tsQuery.SoNganhDaoTaoCuNhan = CuNhan;
                tsQuery.VideoGioiThieu = vid;

                qlTS.SubmitChanges();
            }
            return true;
        }*/

        DBMain db = null;
        public BLThongTinTruong()
        {
            db = new DBMain();
        }
        public DataSet LayBangTin()
        {
            return db.ExecuteQueryDataSet("select * from ThongTinChung", CommandType.Text);
        }
        public bool ThemBangTin(string GioiThieuTruong, int SoGiaoSu,
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            string sqlString = "insert into ThongTinChung values(N'" + GioiThieuTruong + "','" + SoGiaoSu + "','" + PhoGS + "','" + TSTS + "','" + NganhThac + "','" + NganhTien + "','" + CuNhan + "','" + vid + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaBangTin(string GioiThieuTruong, int SoGiaoSu, 
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            string sqlString = "UPDATE ThongTinChung SET " + "GioiThieuTruong = " +
                "N'" + GioiThieuTruong + "',SoGiaoSu=" +
                SoGiaoSu + ",SoPhoGiaoSu=" + PhoGS + ",SoThacSiTienSi=" + TSTS + 
                ",SoNganhDaoTaoTienSi=" + NganhThac + ",SoNganhDaoTaoThacSi=" + NganhTien + 
                ",SoNganhDaoTaoCuNhan=" + CuNhan + ",VideoGioiThieu= N'"
                + vid + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public void LayDuLieu(ref string GTC, ref int SGS, ref int PGS, ref int TSTS, ref int NTS, ref int NS, ref int CN, ref string vid)
        {
            string err = "";
            DataSet ds = LayBangTin();
            DataTable dtGTC = new DataTable();
            dtGTC = ds.Tables[0];
            if (dtGTC.Rows.Count > 0)
            {
                GTC = dtGTC.Rows[0][0].ToString();
                SGS = Convert.ToInt32(dtGTC.Rows[0][1].ToString());
                PGS = Convert.ToInt32(dtGTC.Rows[0][2].ToString());
                TSTS = Convert.ToInt32(dtGTC.Rows[0][3].ToString());
                NTS = Convert.ToInt32(dtGTC.Rows[0][4].ToString());
                NS = Convert.ToInt32(dtGTC.Rows[0][5].ToString());
                CN = Convert.ToInt32(dtGTC.Rows[0][6].ToString());
                vid = dtGTC.Rows[0][7].ToString();
            }
            else ThemBangTin(" ", 0, 0, 0, 0, 0, 0, " ", ref err);
        }
    }
}
