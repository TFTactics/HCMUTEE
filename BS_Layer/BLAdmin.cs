using System.Data;
using UI.BD_Layer;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;  
using System.Data.Linq.Mapping;

namespace UI.BS_Layer
{
    class BLAdmin
    {
        public bool ThemUser(string User, string Pass1, string Pass2, ref string err)
        {
            if(Pass1 == Pass2)
            {
                MessageBox.Show("Done!!");
                QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
                Admin ad = new Admin();
                ad.Username = User;
                ad.Password = Pass1;

                qlTS.Admins.InsertOnSubmit(ad);
                qlTS.Admins.Context.SubmitChanges();
                return true;
            }
            else
                MessageBox.Show("Incorrect!");
            return false;
        }

        public bool CheckUser(string User, string Pass)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var adQuery = (from login in qlTS.Admins
                           where login.Username == User
                           select login).SingleOrDefault();
            if (adQuery.Password == Pass)
            {
                return true;
            }
            return false;
        }

        public bool Check(string User)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
           
            var adQuery = (from login in qlTS.Admins
                               where login.Username == User
                               select login).SingleOrDefault();
            if (adQuery == null)
                return false;
            else if(adQuery.Username == User)
            {
                return true;
            }
            return false;
        }


        /*DBMain db = null;
        public BLAdmin()
        {
            db = new DBMain();
        }
        public bool ThemUser(string User, string Pass1, string Pass2,  ref string err)
        {
            if (Pass1 == Pass2)
            {
                MessageBox.Show("Done!!");
                string sqlString = "insert into Admin values(N'" + User + "',N'" + Pass1 + "')";
                return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            }
            else
                MessageBox.Show("Incorrect!");
            return false;
        }

        public bool CheckUser(string User, string Pass)
        {
            string sqlString = "SELECT Password FROM Admin WHERE Username = N'" + User + "'AND Password =N'" +
                Pass + "'";
            if(db.ExecuteQueryDataSet(sqlString,CommandType.Text).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Check(string User)
        {
            string sqlString = "SELECT Username FROM Admin WHERE Username = N'" + User + "'";
            if (db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }*/
    }
}
