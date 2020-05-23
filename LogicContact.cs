using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContactListApplication
{
    public class LogicContact
    {
        int CurrContactid;
        public void AddContactDetails(Contact C)
        {
            string cnstr = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("usp_AddContacts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Parameters.AddWithValue("@First_Name", C.First_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", C.Middle_Name);
            cmd.Parameters.AddWithValue("@Last_Name", C.Last_Name);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddAddress()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd0 = new SqlCommand();
            cmd0.CommandText = @"select top 1 Contact_id from Contact order by contact_id desc";
            cmd0.CommandType = CommandType.Text;
            cmd0.Connection = con;

            con.Open();
            CurrContactid = (int)cmd0.ExecuteScalar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"update AddressTemp set Contact_id='" + CurrContactid + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = @"insert into ADDRESS(Contact_id,Address_type,Address,City,State,Zip) select Contact_id,AddrType, StreetAddr, City, State, Zip from AddressTemp";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;

            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = @"Truncate table AddressTemp";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;

            cmd3.ExecuteNonQuery();

            con.Close();
        }

        public void AddPhone()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd0 = new SqlCommand();
            cmd0.CommandText = @"select top 1 Contact_id from Contact order by contact_id desc";
            cmd0.CommandType = CommandType.Text;
            cmd0.Connection = con;

            con.Open();
            CurrContactid = (int)cmd0.ExecuteScalar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"update PhoneTemp set Contact_id='" + CurrContactid + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = @"insert into PHONE(Contact_id,Phone_type,Area_code,Number) select Contact_id,PhoneType, AreaCode, PhoneNumber from PhoneTemp";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;

            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = @"Truncate table PhoneTemp";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;

            cmd3.ExecuteNonQuery();

            con.Close();

        }

        public void AddDate()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd0 = new SqlCommand();
            cmd0.CommandText = @"select top 1 Contact_id from Contact order by contact_id desc";
            cmd0.CommandType = CommandType.Text;
            cmd0.Connection = con;

            con.Open();
            CurrContactid = (int)cmd0.ExecuteScalar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"update DateTemp set Contact_id='" + CurrContactid + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = @"insert into DATE(Contact_id,Date_type,Date) select Contact_id,DateType, Date from DateTemp";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;

            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = @"Truncate table DateTemp";
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = con;

            cmd3.ExecuteNonQuery();

            con.Close();

        }
    }
}