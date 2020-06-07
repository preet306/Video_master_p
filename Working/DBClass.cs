using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_master_p.Working
{
  public  class DBClass
    {

        //object of the sqlconnection class that is used to connect to with the sql server management 
        SqlConnection sqlcntn;

        //object of the sqlcommand class that is used to connect to with the sql server management 
        SqlCommand sqlcmd;

        //object of the sqlDataReader class that is used to connect to with the sql server management
        SqlDataReader sqlDataReader;


        //connection string of the class
        String location = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=Video_Project;Integrated Security=True";



        //to perform the dml operation like insert delete or update 
        public void Sql_DML(String query)
        {
            sqlcntn = new SqlConnection(location);
            sqlcntn.Open();
            sqlcmd = new SqlCommand(query, sqlcntn);
            sqlcmd.ExecuteNonQuery();
            sqlcntn.Close();
        }

        //get to carry the data from sql server data base and pass to data table 
        public DataTable Sql_searchOperation(String qry)
        {
            DataTable tbl = new DataTable();

            sqlcntn = new SqlConnection(location);

            sqlcntn.Open();

            sqlcmd = new SqlCommand(qry, sqlcntn);

            sqlDataReader = sqlcmd.ExecuteReader();

            tbl.Load(sqlDataReader);

            sqlcntn.Close();

            return tbl;
        }




    }
}
