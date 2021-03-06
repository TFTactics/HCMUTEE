using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace UI.BS_Layer
{
    internal class BLLienHe
    {
        DBMain db = null;
        public BLLienHe()
        {
            db=new DBMain();
        }
        public DataSet LayLienHe()
        {
            return db.ExecuteQueryDataSet("select * from LienHe", CommandType.Text);
        }
        public bool ThemLienHe(string DiaDiem, string SoDT, string Email, string Fanpage, string PhongBanLH, string VanPhong, ref string err)
        {
            string sqlString = "insert into LienHe values(N'"+DiaDiem+"',N'"+SoDT+"',N'"+Email+"',N'"+Fanpage+"',N'"+PhongBanLH+"',N'"+VanPhong+"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool SuaLienHe(string DiaDiem, string SoDT,string Email, string Fanpage,string PhongBanLH, string VanPhong, ref string err)
        {
            string sqlString = "Update LienHe set DiaDiem=N'" + DiaDiem + "' , SoDienThoai=N'" + SoDT + "',Email=N'" + Email + "',Fanpage=N'" + Fanpage + "',PhongBanLienHe=N'" +PhongBanLH + "',VanPhong=N'" +VanPhong+"'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public void LayDuLieu(ref string DD, ref string SDT, ref string Email, ref string Fanpage, ref string TenPB, ref string VanPhong)
        {
            string err = "";
            DataSet ds = LayLienHe();
            DataTable dtGTC = new DataTable();
            dtGTC.Clear();
            dtGTC = ds.Tables[0];
            if (dtGTC.Rows.Count > 0)
            {
                DD = dtGTC.Rows[0][0].ToString();
                SDT = dtGTC.Rows[0][1].ToString();
                Email = dtGTC.Rows[0][2].ToString();
                Fanpage = dtGTC.Rows[0][3].ToString();
                TenPB = dtGTC.Rows[0][4].ToString();
                VanPhong = dtGTC.Rows[0][5].ToString();
            }
            else ThemLienHe(" ", " ", " ", " ", " ", " ", ref err);
        }
    }
}
