using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactListApplication
{
    public partial class ViewContact : System.Web.UI.Page
    {
        static string queryText;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
               
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            queryText = txtSearch.Text;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Contact_id,Fname,Mname,Lname from CONTACT where contact_id in (
                                    select contact_id from CONTACT where FName like '%" + queryText + "%' or MName like '%" + queryText + "%' or LName like '%" + queryText + "%' union select contact_id from ADDRESS where Address like '%"+queryText+"%' or city like '%"+queryText+"%' or state like '%"+queryText+"%' or Zip like '%" + queryText + "%' union select contact_id from PHONE where Area_code like '%"+queryText+"%' or Number like '%"+queryText+"%')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvSearchContact.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count==0)
                {
                    Response.Write("<script>alert('No Matching Records Found');</script>");
                }
                else
                {
                    lvSearchContact.DataBind();
                }

                con.Close();

            }
            catch (Exception ex) { throw ex; }
        }

        public void FillSearch()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Contact_id,Fname,Mname,Lname from CONTACT where contact_id in (
                                    select contact_id from CONTACT where FName like '%" + queryText + "%' or MName like '%" + queryText + "%' or LName like '%" + queryText + "%' union select contact_id from ADDRESS where Address like '%" + queryText + "%' or city like '%" + queryText + "%' or state like '%" + queryText + "%' or Zip like '%" + queryText + "%' union select contact_id from PHONE where Area_code like '%" + queryText + "%' or Number like '%" + queryText + "%')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvSearchContact.DataSource = ds.Tables[0];
                lvSearchContact.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected void lvSearchContact_DeleteContact(object sender,ListViewDeleteEventArgs e)
        {
            try
            {
                string ContactID = "";

                Label lbl = (lvSearchContact.Items[e.ItemIndex].FindControl("ContactIDLabelSearch")) as Label;

                if (lbl != null)
                {
                    ContactID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from CONTACT where Contact_id= '" + ContactID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillSearch();

                Response.Write("<script>alert('Contact Deleted');</script>");
            }
            catch (Exception ex) { throw ex; }
        }
        
        protected void lvSearchContact_UpdateContact(object sender, ListViewUpdateEventArgs e)
        {
            string Contact_Id = "";

            Label lbl = (lvSearchContact.Items[e.ItemIndex].FindControl("ContactIDLabelSearch")) as Label;

            if (lbl != null)
            {
                Contact_Id = lbl.Text;
            }
            Response.Redirect("ModifyContact.aspx?Parameter=" + Contact_Id);
            Response.Redirect("ModifyContact.aspx");

        }
    }
}