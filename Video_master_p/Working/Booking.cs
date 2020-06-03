using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_master_p.Working
{
   public class Booking: DBClass
    {
        
        //this method is used to count he booked video 
        public int countBookedVideo(int Video_ID) {
            DataTable obj = new DataTable();
            obj =Sql_searchOperation( "select * from tbl_Booking where Video_ID="+Video_ID+" and ReturnDate='Book'");
            return obj.Rows.Count;
        }

        //this method is used to count he booked video 
        public int countBookedUser(int User_ID)
        {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from tbl_Booking where User_ID=" + User_ID + " and ReturnDate='Book'");
            return obj.Rows.Count;
        }



        //this method is used to count he booked video 
        public int VideoCopies(int Video_ID)
        {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from tbl_Video where Video_ID=" + Video_ID + "");
            return Convert.ToInt32(obj.Rows[0]["Copies"].ToString());
        }






        public Boolean BookingInsert(String User_ID,String Video_ID,String Issue) {
            if (!User_ID.Equals("") && !Video_ID.Equals(""))
            {
                if (countBookedVideo(Convert.ToInt32(Video_ID)) < VideoCopies(Convert.ToInt32(Video_ID)))
                {
                    if (countBookedUser(Convert.ToInt32(User_ID))<2) {

                        String booking = "insert into tbl_Booking values('" + User_ID + "','" + Video_ID + "','" + Issue + "','Book')";
                        Sql_DML(booking);
                        MessageBox.Show("Video is Booked by the User ");
                        return true;
                    } else {
                        MessageBox.Show("One User can book only two Video at a time ");
                        return false;
                    }



                   
                   
                }
                else {
                    MessageBox.Show("All Copiess are booked ");
                    return false;
                }


            }
            else {
                MessageBox.Show("Must select the video or user to Book ");
                return false;
            }
        }


        public Boolean DeleteBooking(int Booking_ID)
        {
            if (Booking_ID > 0)
            {
                String Delete = "delete from tbl_Booking where Booking_ID="+Booking_ID+"";
                Sql_DML(Delete);
                MessageBox.Show("Booked Video is deleted from the record");
                return true;
            }
            else {
                MessageBox.Show("select the video to delete ");
                return false;
            }

        }


        public int searchCost(int Video_ID) {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from  tbl_Video where Video_ID=" + Video_ID + "");
            return Convert.ToInt32(obj.Rows[0]["Charges"].ToString());
        }

        public Boolean ReturnInsert(int Booking_ID, string User_ID, String Video_ID, String Issue,String Return)
        {
            if (!User_ID.Equals("") && !Video_ID.Equals(""))
            {
                //get the difference between 
                //get the difference in days between 2 dates and get  the cost from the database 
                DateTime start = Convert.ToDateTime(Issue);
                DateTime endDate = Convert.ToDateTime(Return);

                String diff2 = (endDate - start).TotalDays.ToString();
                //convert the string value to double 
                double d = Convert.ToDouble(diff2);
                //pass the roud off value to calculate 
                double days = Math.Round(d);

                //get the cost of the video 
                DataTable tbl = new DataTable();
                if (d==0) {
                    days = 1;
                }

                int cost = searchCost(Convert.ToInt32(Video_ID));

                int payment = Convert.ToInt32(days) * cost;


                String booking = "update tbl_Booking set User_ID='" + User_ID + "',Video_ID='" + Video_ID + "',BookingDate='" + Issue + "',ReturnDate='"+Return+ "' where Booking_ID=" + Booking_ID + "";
                Sql_DML(booking);
                MessageBox.Show("your charges is $"+payment);

                return true;
            }
            else
            {
                MessageBox.Show("select the video and user to book the video ");
                return false;
            }
        }

        public void DisplayBooking(DataGridView dgv)
        {
            DataTable obj = new DataTable();
            obj = Sql_searchOperation("select * from tbl_Booking");
            dgv.DataSource = obj;
        }


    }
}
