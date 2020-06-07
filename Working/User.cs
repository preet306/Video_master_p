using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_master_p.Working
{
   public class User: DBClass
    {

        public Boolean insertUser(String Name,String Email,String Contact,String Adr) {
            if (!Name.Equals("") && !Email.Equals("") && !Contact.Equals("") && !Adr.Equals(""))
            {
                String sql_query = "insert into tbl_User values('"+Name+ "','" + Email+ "','" + Contact + "','" + Adr + "')";
                Sql_DML(sql_query);
                MessageBox.Show("User is regitered in the Project ");
                return true;
            }
            else {
                MessageBox.Show("Must fill all the details");
                return false;
            }
        }


        public Boolean DeleteUser(int UserID)
        {
            if (UserID>0)
            {
                DataTable obj = new DataTable();
                obj = Sql_searchOperation("select * from tbl_Booking where User_ID="+UserID+" and ReturnDate='Book'");
                if (obj.Rows.Count == 0)
                {
                    String sql_query = "delete from tbl_User where User_ID=" + UserID + "";
                    Sql_DML(sql_query);
                    MessageBox.Show("User is deleted from the Project ");
                    return true;
                }
                else {
                    MessageBox.Show("First return the Booked Video ");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Must Select the User ");
                return false;
            }
        }

        public Boolean EditUser(int UserID,String Name, String Email, String Contact, String Adr)
        {
            if (!Name.Equals("") && !Email.Equals("") && !Contact.Equals("") && !Adr.Equals(""))
            {
                String sql_query = "update tbl_User set Name='" + Name + "',Email='" + Email + "',Contact='" + Contact + "',Address='" + Adr + "' where User_ID=" + UserID + "";
                Sql_DML(sql_query);
                MessageBox.Show("User Record is Edit in the Project ");
                return true;
            }
            else
            {
                MessageBox.Show("Must fill all the details");
                return false;
            }
        }


        public void DisplayUser(DataGridView dgv) {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from tbl_User");
            dgv.DataSource = obj;
        }

        //get the top ranked video from the database 
        public Boolean TopUser()
        {
            DataTable tblData = new DataTable();
            tblData = Sql_searchOperation("select * from tbl_User");
            int x = 0, y = 0, cunt = 0;
            String Name = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tbl = new DataTable();
                tbl = Sql_searchOperation("select * from tbl_Booking where User_ID=" + Convert.ToInt32(tblData.Rows[x]["User_ID"].ToString()) + "");

                if (tbl.Rows.Count > cunt)
                {
                    Name = tblData.Rows[x]["Name"].ToString();
                    cunt = tbl.Rows.Count;
                }

            }
            MessageBox.Show("Best User of the Project is " + Name);
            return true;
        }
    }
}
