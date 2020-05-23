using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ContactListApplication
{

    public partial class ModifyContact : System.Web.UI.Page
    {
        static string contID;
        static bool properAddressSearch = false;
        static bool properPhoneSearch = false;
        static bool properDateSearch = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblErrDateMod.Visible = false;
                if (!IsPostBack)
                {

                    contID = Request.QueryString["Parameter"].ToString();

                    Fill_Details(contID);
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Go To View Contact Page to Modify a Contact');</script>");
                lblFNameMod.Visible = false;
                lblMNameMod.Visible = false;
                lblLNameMod.Visible = false;
                txtLNameMod.Visible = false;
                txtFNameMod.Visible = false;
                txtMNameMod.Visible = false;
                btnSaveContactMod.Visible = false;
            }
        }
        protected void Fill_Details(String contID)
        {
            try
            {   
                string name;
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);
                SqlCommand cmd01 = new SqlCommand();
                cmd01.CommandText = @"select Fname from CONTACT where Contact_id= '" + contID + "'";
                cmd01.CommandType = CommandType.Text;
                cmd01.Connection = con;
                con.Open();
                name = (string)cmd01.ExecuteScalar();
                txtFNameMod.Text = name;

                SqlCommand cmd02 = new SqlCommand();
                cmd02.CommandText = @"select Mname from CONTACT where Contact_id= '" + contID + "'";
                cmd02.CommandType = CommandType.Text;
                cmd02.Connection = con;
                name = (string)cmd02.ExecuteScalar();
                txtMNameMod.Text = name;

                SqlCommand cmd03 = new SqlCommand();
                cmd03.CommandText = @"select Lname from CONTACT where Contact_id= '" + contID + "'";
                cmd03.CommandType = CommandType.Text;
                cmd03.Connection = con;
                name = (string)cmd03.ExecuteScalar();
                txtLNameMod.Text = name;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = @"select Address_id,Address_Type,Address,City,State,Zip from ADDRESS where Contact_id= '" + contID + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                lvAddressSearch.DataSource = ds1.Tables[0];
                lvAddressSearch.DataBind();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = @"select Phone_id,Phone_Type,Area_code,Number from PHONE where Contact_id= '" + contID + "'";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                lvPhoneSearch.DataSource = ds2.Tables[0];
                lvPhoneSearch.DataBind();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandText = @"select Date_id,Date_Type,Date from DATE where Contact_id= '" + contID + "'";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;

                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);

                lvDateSearch.DataSource = ds3.Tables[0];
                lvDateSearch.DataBind();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillAddressSearch()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Address_Id, Address_type, Address,City,State,Zip from ADDRESS where contact_id='"+contID+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvAddressSearch.DataSource = ds.Tables[0];
                lvAddressSearch.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillPhoneSearch()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Phone_Id, Phone_type, Area_code,Number from PHONE where contact_id='" + contID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvPhoneSearch.DataSource = ds.Tables[0];
                lvPhoneSearch.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillDateSearch()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Date_id, Date_type, Date from DATE where contact_id='" + contID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvDateSearch.DataSource = ds.Tables[0];
                lvDateSearch.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lvAddressSearch_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtStreetAddrLVSearch = (TextBox)e.Item.FindControl("txtStreetAddrLVSearch");
                TextBox txtCityLVSearch = (TextBox)e.Item.FindControl("txtCityAddrLVSearch");
                TextBox txtStateLVSearch = (TextBox)e.Item.FindControl("txtStateAddrLVSearch");
                TextBox txtZipLVSearch = (TextBox)e.Item.FindControl("txtZipAddrLVSearch");

                DropDownList dllAddressTypeLVSearch = (DropDownList)e.Item.FindControl("ddlAddressTypeLVSearch");

                if (txtStreetAddrLVSearch.Text == "" || txtCityLVSearch.Text == "" || txtStateLVSearch.Text == "" || txtZipLVSearch.Text == "" || dllAddressTypeLVSearch.SelectedValue == "-1")
                {
                    properAddressSearch = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing');", true);
                }
                else
                {
                    properAddressSearch = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

                    SqlConnection con = new SqlConnection(strConnection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"insert into ADDRESS(Contact_id,Address_Type,Address,City,State,Zip) values('" + contID + "','" + dllAddressTypeLVSearch.SelectedItem + "','" + txtStreetAddrLVSearch.Text + "','" + txtCityLVSearch.Text + "','" + txtStateLVSearch.Text + "','" + txtZipLVSearch.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtStreetAddrLVSearch.Text = "";
                    txtCityLVSearch.Text = "";
                    txtStateLVSearch.Text = "";
                    txtZipLVSearch.Text = "";
                    dllAddressTypeLVSearch.SelectedValue = "-1";

                    FillAddressSearch();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvAddressSearch_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string addrID = "";

                Label lbl = (lvAddressSearch.Items[e.ItemIndex].FindControl("AddressIDLabelSearch")) as Label;

                if (lbl != null)
                {
                    addrID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from ADDRESS where Address_Id= '" + addrID + "' and Contact_id='" + contID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillAddressSearch();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvAddressSearch_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvAddressSearch.EditIndex = e.NewEditIndex;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Address_id,Address_Type,Address,City,State,Zip from ADDRESS where Contact_id='" + contID + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvAddressSearch.DataSource = ds1.Tables[0];
            lvAddressSearch.DataBind();

        }

        protected void lvAddressSearch_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string AddrId = "", AddrType = "", Address = "", State = "", City = "", Zip = "";

            Label lbl = (lvAddressSearch.Items[e.ItemIndex].FindControl("AddressIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                AddrId = lbl.Text;
            }

            TextBox txt = (lvAddressSearch.Items[e.ItemIndex].FindControl("txtStreetAddressEditLVSearch")) as TextBox;

            if (txt != null)
            {
                Address = txt.Text;
            }

            txt = (lvAddressSearch.Items[e.ItemIndex].FindControl("txtCityEditLVSearch")) as TextBox;

            if (txt != null)
            {
                City = txt.Text;
            }

            txt = (lvAddressSearch.Items[e.ItemIndex].FindControl("txtStateAddrEditLVSearch")) as TextBox;

            if (txt != null)
            {
                State = txt.Text;
            }

            txt = (lvAddressSearch.Items[e.ItemIndex].FindControl("txtZipEditLVSearch")) as TextBox;

            if (txt != null)
            {
                Zip = txt.Text;
            }

            DropDownList dllAddressTypeLVSearch = (lvAddressSearch.Items[e.ItemIndex].FindControl("ddlAddressTypeEditLVSearch")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"UPDATE ADDRESS SET Address_Type='" + dllAddressTypeLVSearch.SelectedItem + "', Address='" + Address + "', City='" + City + "',State='" + State + "',Zip='" + Zip + "' where Address_id='" + AddrId + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            lvAddressSearch.EditIndex = -1;

            FillAddressSearch();

        }

        protected void lvAddressSearch_ItemCancelling(object sender,ListViewCancelEventArgs e)
        {
            lvAddressSearch.EditIndex = -1;
            FillAddressSearch();
        }
        protected void lvPhoneSearch_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtAreaCodeLVSearch = (TextBox)e.Item.FindControl("txtAreaCodeLVSearch");
                TextBox txtPhoneNumberLVSearch = (TextBox)e.Item.FindControl("txtPhoneNumberLVSearch");
                DropDownList ddlPhoneTypeLVSearch = (DropDownList)e.Item.FindControl("ddlPhoneTypeLVSearch");

                if (txtAreaCodeLVSearch.Text == "" || txtPhoneNumberLVSearch.Text == "" || ddlPhoneTypeLVSearch.SelectedValue == "-1")
                {
                    properPhoneSearch = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing');", true);
                }
                else
                {
                    properPhoneSearch = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

                    SqlConnection con = new SqlConnection(strConnection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"insert into PHONE(Contact_id,Phone_type,Area_Code,Number) values('" + contID + "','" + ddlPhoneTypeLVSearch.SelectedItem + "','" + txtAreaCodeLVSearch.Text + "','" + txtPhoneNumberLVSearch.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtAreaCodeLVSearch.Text = "";
                    txtPhoneNumberLVSearch.Text = "";
                    ddlPhoneTypeLVSearch.SelectedValue = "-1";

                    FillPhoneSearch();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvPhoneSearch_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string phoneID = "";

                Label lbl = (lvPhoneSearch.Items[e.ItemIndex].FindControl("PhoneIDLabelSearch")) as Label;

                if (lbl != null)
                {
                    phoneID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from PHONE where Phone_Id= '" + phoneID + "' and contact_id='" + contID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillPhoneSearch();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvPhoneSearch_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvPhoneSearch.EditIndex = e.NewEditIndex;
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Phone_id,Phone_Type,Area_code,Number from PHONE where Contact_id='" + contID + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvPhoneSearch.DataSource = ds1.Tables[0];
            lvPhoneSearch.DataBind();
        }

        protected void lvPhoneSearch_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string PhoneId = "", AreaCd = "", Numb = "";

            Label lbl = (lvPhoneSearch.Items[e.ItemIndex].FindControl("PhoneIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                PhoneId = lbl.Text;
            }

            TextBox txt = (lvPhoneSearch.Items[e.ItemIndex].FindControl("txtAreaCodeEditLVSearch")) as TextBox;

            if (txt != null)
            {
                AreaCd = txt.Text;
            }

            txt = (lvPhoneSearch.Items[e.ItemIndex].FindControl("txtPhoneNumberEditLVSearch")) as TextBox;

            if (txt != null)
            {
                Numb = txt.Text;
            }

            DropDownList dllPhoneTypeLVSearch = (lvPhoneSearch.Items[e.ItemIndex].FindControl("ddlPhoneTypeEditLVSearch")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"UPDATE PHONE SET Phone_Type='" + dllPhoneTypeLVSearch.SelectedItem + "', Area_code='" + AreaCd + "', Number='" + Numb + "' where Phone_id='" + PhoneId + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            lvPhoneSearch.EditIndex = -1;

            FillPhoneSearch();

        }

        protected void lvPhoneSearch_ItemCancelling(object sender, ListViewCancelEventArgs e)
        {
            lvPhoneSearch.EditIndex = -1;
            FillPhoneSearch();
        }

        protected void lvDateSearch_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtDateLVSearch = (TextBox)e.Item.FindControl("txtDateLVSearch");
                DropDownList ddlDateTypeLVSearch = (DropDownList)e.Item.FindControl("ddlDateTypeLVSearch");
                if (txtDateLVSearch.Text == "" || ddlDateTypeLVSearch.SelectedValue == "-1")
                {
                    properDateSearch = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing');", true);
                }
                else
                {
                    properDateSearch = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strConnection);

                    SqlCommand cmd0 = new SqlCommand();
                    cmd0.CommandText = @"select date from Date where date_type='BirthDay' and contact_id='"+contID+"'";
                    cmd0.Connection = con;
                    con.Open();
                    object obj = cmd0.ExecuteScalar();
                    DateTime bday;

                    if (obj != null && ddlDateTypeLVSearch.SelectedItem.Text.Equals("Anniversary"))
                    {
                        bday = (DateTime)obj;
                        int idiff = DateTime.Compare(bday, DateTime.Parse(txtDateLVSearch.Text));
                        if (idiff > 0)
                        {
                            lblErrDateMod.Visible = true;
                            properDateSearch = false;
                            lblErrDateMod.Text = "Anniversary Date should be after Birth Date";
                        }
                    }

                    SqlCommand cmd01 = new SqlCommand();
                    cmd01.CommandText = @"select date from Date where date_type='Anniversary' and contact_id='" + contID + "'";
                    cmd01.Connection = con;
                    object obj1 = cmd01.ExecuteScalar();
                    DateTime aday;

                    if (obj1 != null && ddlDateTypeLVSearch.SelectedItem.Text.Equals("BirthDay"))
                    {
                        aday = (DateTime)obj1;
                        int idiff = DateTime.Compare(aday, DateTime.Parse(txtDateLVSearch.Text));
                        if (idiff < 0)
                        {
                            lblErrDateMod.Visible = true;
                            properDateSearch = false;
                            lblErrDateMod.Text = "BirthDay should be less than Anniversary Date";
                        }
                    }


                    SqlCommand cmd = new SqlCommand();
                    if (properDateSearch == true)
                    {
                        cmd.CommandText = @"insert into DATE(contact_id,Date_type,Date) values('" + contID + "','" + ddlDateTypeLVSearch.SelectedItem + "','" + txtDateLVSearch.Text + "')";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }                    
                    txtDateLVSearch.Text = "";
                    ddlDateTypeLVSearch.SelectedValue = "-1";

                    FillDateSearch();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvDateSearch_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string dateID = "";

                Label lbl = (lvDateSearch.Items[e.ItemIndex].FindControl("DateIDLabelSearch")) as Label;

                if (lbl != null)
                {
                    dateID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from DATE where date_id= '" + dateID + "' and contact_id='" + contID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillDateSearch();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvDateSearch_ItemEditing(object source, ListViewEditEventArgs e)
        {
            lvDateSearch.EditIndex = e.NewEditIndex;
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Date_id,Date_Type,Date from DATE where contact_id='" + contID + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvDateSearch.DataSource = ds1.Tables[0];
            lvDateSearch.DataBind();
        }

        protected void lvDateSearch_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string DateId = "", Date = "";

            Label lbl = (lvDateSearch.Items[e.ItemIndex].FindControl("DateIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                DateId = lbl.Text;
            }

            TextBox txt = (lvDateSearch.Items[e.ItemIndex].FindControl("txtDateEditLVSearch")) as TextBox;

            if (txt != null)
            {
                Date = txt.Text;
            }

            DropDownList ddlDateTypeEditLVSearch = (lvDateSearch.Items[e.ItemIndex].FindControl("ddlDateTypeEditLVSearch")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd0 = new SqlCommand();
            cmd0.CommandText = @"select date from DATE where date_type='BirthDay' and Contact_id='"+contID+"'";
            cmd0.Connection = con;
            con.Open();
            object obj = cmd0.ExecuteScalar();
            DateTime bday;

            if (obj != null && ddlDateTypeEditLVSearch.SelectedItem.Text.Equals("Anniversary"))
            {
                bday = (DateTime)obj;
                int idiff = DateTime.Compare(bday, DateTime.Parse(Date));
                if (idiff > 0)
                {
                    lblErrDateMod.Visible = true;
                    properDateSearch = false;
                    lblErrDateMod.Text = "BirthDay should be less than Anniversary Date";
                }
            }

            SqlCommand cmd01 = new SqlCommand();
            cmd01.CommandText = @"select date from Date where date_type='Anniversary' and contact_id='" + contID + "'";
            cmd01.Connection = con;
            object obj1 = cmd01.ExecuteScalar();
            DateTime aday;

            if (obj1 != null && ddlDateTypeEditLVSearch.SelectedItem.Text.Equals("BirthDay"))
            {
                aday = (DateTime)obj1;
                int idiff = DateTime.Compare(aday, DateTime.Parse(Date));
                if (idiff < 0)
                {
                    lblErrDateMod.Visible = true;
                    properDateSearch = false;
                    lblErrDateMod.Text = "BirthDay should be less than Anniversary Date";
                }
            }

            SqlCommand cmd1 = new SqlCommand();
            if (properDateSearch == true)
            {
                cmd1.CommandText = @"UPDATE DATE SET Date_Type='" + ddlDateTypeEditLVSearch.SelectedItem + "', Date='" + Date + "' where Date_id='" + DateId + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            
            lvDateSearch.EditIndex = -1;

            FillDateSearch();

        }

        protected void lvDateSearch_ItemCancelling(object sender, ListViewCancelEventArgs e)
        {
            lvDateSearch.EditIndex = -1;
            FillDateSearch();
        }

        protected void btnSaveContactMod_Click(object sender, EventArgs e)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"UPDATE CONTACT SET Fname='" + txtFNameMod.Text + "', Mname='" + txtMNameMod.Text + "',Lname='"+txtLNameMod.Text+"' where Contact_id='" + contID + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Changes Saved Successfully');</script>");
        }
    }
}