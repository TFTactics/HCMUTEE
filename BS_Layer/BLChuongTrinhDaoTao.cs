using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLChuongTrinhDaoTao
    {
        /*public Table<ChuongTrinhDaoTao> LayChuongTrinhDaoTao()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ChuongTrinhDaoTaos;
        }

        public bool ThemChuongTrinhDaoTao(string TenCTDT, string NganhDaoTao, string HeDaoTao, string PDFDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ChuongTrinhDaoTao ct = new ChuongTrinhDaoTao();
            ct.TenChuongTrinh = TenCTDT;
            ct.NganhDaoTao = NganhDaoTao;
            ct.HeDaoTao = HeDaoTao;
            ct.PDFDaoTao = PDFDaoTao;
            ct.NoiDung = NoiDung;

            qlTS.ChuongTrinhDaoTaos.InsertOnSubmit(ct);
            qlTS.ChuongTrinhDaoTaos.Context.SubmitChanges();
            return true;
        }

        public bool XoaChuongTrinhDaoTao(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ct in qlTS.ChuongTrinhDaoTaos
                          where ct.TenChuongTrinh == TieuDe
                          select ct;

            qlTS.ChuongTrinhDaoTaos.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaChuongTrinh(ref string err, string TCT, string NDT, string HDT, string PDF, string ND)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ct in qlTS.ChuongTrinhDaoTaos
                           where ct.TenChuongTrinh == TCT
                           select ct).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.NganhDaoTao = NDT;
                tsQuery.HeDaoTao = HDT;
                tsQuery.PDFDaoTao = PDF;
                tsQuery.NoiDung = ND;
            }
        }*/

        DBMain db = null;
        public BLChuongTrinhDaoTao()
        {
            db = new DBMain();
        }
        public DataSet LayChuongTrinhDaoTao()
        {
            return db.ExecuteQueryDataSet("select * from ChuongTrinhDaoTao", CommandType.Text);
        }
        public bool ThemChuongTrinhDaoTao(string TenCTDT, string NganhDaoTao, string HeDaoTao, string PDFDaoTao, string NoiDung, ref string err)
        {
            string sqlString = "Insert into ChuongTrinhDaoTao values (" + "N'" + TenCTDT + "',N'" + NganhDaoTao + "',N'" + HeDaoTao + "',N'" + PDFDaoTao + "',N'" + NoiDung + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaChuongTrinhDaoTao(ref string err, string TieuDe)
        {
            string sqlString = "delete from ChuongTrinhDaoTao where NganhDaoTao=N'" + TieuDe + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaChuongTrinh(ref string err, string TCT, string NDT, string HDT, string PDF, string ND)
        {
            string sqlString = "UPDATE ChuongTrinhDaoTao SET TenChuongTrinh=N'" + TCT +
                "',NganhDaoTao=N'" + NDT + "',HeDaoTao=N'" + HDT + "',PDFDaoTao=N'" + PDF +
                "',NoiDung=N'" + ND + "'WHERE TenChuongTrinh = N'" + TCT + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataTable LayTenChuongTrinh()
        {
            string sqlString = "Select TenChuongTrinh from ChuongTrinhDaoTao";
            DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            return ds.Tables[0];
        }
        public int DemNganh(string x)
        {
            string sqlString = "select TenChuongTrinh from ChuongTrinhDaoTao where TenChuongTrinh=N'" + x + "'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0].Rows.Count;
        }
    }
}
