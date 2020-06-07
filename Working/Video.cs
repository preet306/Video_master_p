using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_master_p.Working
{
    public class Video: DBClass
    {
        public Boolean InsertVideo(String Name,String Ratting,String Released, String Copies,String Plot,String genre) {
            if (!Name.Equals("") && !Ratting.Equals("") && !Released.Equals("") && !Copies.Equals("") && !Plot.Equals("") && !genre.Equals("")) {
                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;
                int cost = 0;

                int diffYear = Currentyear - Convert.ToInt32(Released);
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                else if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                String Insert = "insert into tbl_Video values('"+Name+"','"+Ratting+"','"+Released+"','"+Copies+"','"+cost.ToString()+"','"+Plot+"','"+genre+"')";
                Sql_DML(Insert);
                MessageBox.Show("Video is record in the project ");
                return true;
            }
            else {
                MessageBox.Show("must fill all details ");
                return false;
            }
            
        }

        public Boolean deleteVideo(int Video_ID) {
            if (Video_ID>0) {
                DataTable obj = new DataTable();
                obj = Sql_searchOperation("select * from tbl_Booking where Video_ID=" + Video_ID + " and ReturnDate='Book'");
                if (obj.Rows.Count == 0)
                {
                    String delete = "delete from tbl_Video where Video_ID=" + Video_ID + "";
                    Sql_DML(delete);
                    MessageBox.Show("Video is deleted ");
                    return true;
                }
                else
                {
                    MessageBox.Show("this video  already booked ");
                    return false;
                }

                
            }
            else {
                MessageBox.Show("Must select the video to delete ");
                return false;
            }
        }



        public Boolean EditVideo(int Video_ID, String Name, String Ratting, String Released, String Copies, String Plot, String genre) {
            if (!Name.Equals("") && !Ratting.Equals("") && !Released.Equals("") && !Copies.Equals("") && !Plot.Equals("") && !genre.Equals(""))
            {
                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;
                int cost = 0;

                int diffYear = Currentyear - Convert.ToInt32(Released);
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                else if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                String Insert = "Update tbl_Video set Name='" + Name + "',Ratting='" + Ratting + "',Released='" + Released + "',Copies='" + Copies + "',Charges='" + cost.ToString() + "',Plot='" + Plot + "',Genre='" + genre + "' where Video_ID=" + Video_ID + "";
                Sql_DML(Insert);
                MessageBox.Show("Video is edited  in the project ");
                return true;
            }
            else
            {
                MessageBox.Show("Must fill all details ");
                return false;
            }

        }
        public void DisplayVideo(DataGridView dgv)
        {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from tbl_Video");
            dgv.DataSource = obj;
        }


        //get the top ranked video from the database 
        public Boolean TopVideo() {
            DataTable tblData = new DataTable();
            tblData =Sql_searchOperation("select * from tbl_Video");
            int x = 0, y = 0, cunt = 0;
            String Name = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tbl = new DataTable();
                tbl = Sql_searchOperation("select * from tbl_Booking where Video_ID=" + Convert.ToInt32(tblData.Rows[x]["Video_ID"].ToString()) + "");

                if (tbl.Rows.Count > cunt)
                {
                    Name = tblData.Rows[x]["Name"].ToString();
                    cunt = tbl.Rows.Count;
                }

            }
            MessageBox.Show("Best Video of the Project is " + Name);
            return true;
        }
    }
}
