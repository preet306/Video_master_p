using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_master_p.Working;

namespace Video_master_p
{
    public partial class Form1 : Form
    {
        //user detail intance 
        User instance_User = new User();
        Video Instance_Video = new Video();
        Booking instance_Booking = new Booking();

        private int Booking_ID = 0;
        private int details = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void add_cust_Click(object sender, EventArgs e)
        {
            if (instance_User.insertUser(custmer_textbx.Text,custmr_email.Text,custmr_phone.Text,custmr_address.Text)) {
                custmer_textbx.Text="";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";


            }
            
        }

        private void update_cust_Click(object sender, EventArgs e)
        {
            if (instance_User.EditUser(Convert.ToInt32(cust_id.Text.ToString()),custmer_textbx.Text, custmr_email.Text, custmr_phone.Text, custmr_address.Text))
            {
                custmer_textbx.Text = "";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";
                cust_id.Text = "";

            }

        }

        private void del_cust_Click(object sender, EventArgs e)
        {
            if (instance_User.DeleteUser(Convert.ToInt32(cust_id.Text.ToString()))) {
                custmer_textbx.Text = "";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";
                cust_id.Text = "";

            }

        }

        private void add_videos_Click(object sender, EventArgs e)
        {
            if (Instance_Video.InsertVideo(video_name.Text,video_ratting.Text,video_real.Text,video_tot.Text,video_plot.Text,video_genre.Text)) {

                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";

            }
        }

        private void update_videos_Click(object sender, EventArgs e)
        {
            if (Instance_Video.EditVideo(Convert.ToInt32(video_id.Text.ToString()),video_name.Text, video_ratting.Text, video_real.Text, video_tot.Text, video_plot.Text, video_genre.Text))
            {

                video_id.Text = "";
                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";

            }


        }

        private void del_videos_Click(object sender, EventArgs e)
        {
            if (Instance_Video.deleteVideo(Convert.ToInt32(video_id.Text.ToString()))) {
                video_id.Text = "";
                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";
            }
        }

        private void return_video_Click(object sender, EventArgs e)
        {
            if (instance_Booking.ReturnInsert(Booking_ID,cust_id.Text, video_id.Text, DtpIssue.Text,dtpReturn.Text)) {

                video_id.Text = "";
                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";
                custmer_textbx.Text = "";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";
                cust_id.Text = "";
            }

        }

        private void rec_customer_Click(object sender, EventArgs e)
        {
            details=1;
            instance_User.DisplayUser(Record);
        }

        private void issue_video_Click(object sender, EventArgs e)
        {
            if (instance_Booking.BookingInsert(cust_id.Text,video_id.Text,DtpIssue.Text)) {
                video_id.Text = "";
                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";
                custmer_textbx.Text = "";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";
                cust_id.Text = "";


            }

        }

        private void del_video_Click(object sender, EventArgs e)
        {
            if (instance_Booking.DeleteBooking(Booking_ID)){
                video_id.Text = "";
                video_name.Text = "";
                video_ratting.Text = "";
                video_real.Text = "";
                video_tot.Text = "";
                video_plot.Text = "";
                video_genre.Text = "";
                custmer_textbx.Text = "";
                custmr_email.Text = "";
                custmr_phone.Text = "";
                custmr_address.Text = "";
                cust_id.Text = "";
                Booking_ID = 0;
            }
        }

        private void rec_video_Click(object sender, EventArgs e)
        {
            details = 2;
            Instance_Video.DisplayVideo(Record);
        }

        private void rec_rental_Click(object sender, EventArgs e)
        {
            details = 3;
            instance_Booking.DisplayBooking(Record);
        }

        private void Record_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //view the user details
            if (details == 1)
            {
                cust_id.Text = Record.CurrentRow.Cells[0].Value.ToString();
                custmer_textbx.Text = Record.CurrentRow.Cells[1].Value.ToString();
                custmr_email.Text = Record.CurrentRow.Cells[2].Value.ToString();
                custmr_phone.Text = Record.CurrentRow.Cells[3].Value.ToString();
                custmr_address.Text = Record.CurrentRow.Cells[4].Value.ToString();

            }


            else if (details == 2)
            {
                //view the video details 
                video_id.Text = Record.CurrentRow.Cells[0].Value.ToString();
                video_name.Text = Record.CurrentRow.Cells[1].Value.ToString();
                video_ratting.Text = Record.CurrentRow.Cells[2].Value.ToString();
                video_real.Text = Record.CurrentRow.Cells[3].Value.ToString();
                video_tot.Text = Record.CurrentRow.Cells[4].Value.ToString();
                video_plot.Text = Record.CurrentRow.Cells[6].Value.ToString();
                video_genre.Text = Record.CurrentRow.Cells[7].Value.ToString();

            }
            else if (details == 3)
            {
                Booking_ID = Convert.ToInt32(Record.CurrentRow.Cells[0].Value.ToString());
                cust_id.Text = Record.CurrentRow.Cells[1].Value.ToString();
                video_id.Text = Record.CurrentRow.Cells[2].Value.ToString();
                DtpIssue.Text = Record.CurrentRow.Cells[3].Value.ToString();

            }
            else {
                MessageBox.Show("Must choose an option to view the record ");
            }

            details = 0;
        }

        private void cust_best_Click(object sender, EventArgs e)
        {
            instance_User.TopUser();
        }

        private void movie_best_Click(object sender, EventArgs e)
        {
            Instance_Video.TopVideo();
        }
    }
}
