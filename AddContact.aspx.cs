using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ContactListApplication
{
    public partial class AddContact : System.Web.UI.Page
    {
        static bool properAddress = true;
        static bool properPhone = true;
        static bool properDate = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            lblError.Visible = false;
            lblDateErrMsg.Visible = false;
            if (!IsPostBack)
            {
                string cnstr=ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(cnstr);
                SqlCommand cmd = new SqlCommand("usp_ResetFields", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                FillAddress();
                FillPhone();
                FillDate();           
            }
        }
        private void FillAddress()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Address_Id, AddrType, StreetAddr,City,State,Zip from AddressTemp";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvAddress.DataSource = ds.Tables[0];
                lvAddress.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillPhone()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

                //string strConnection = "data source=.;initial catalog=UTD; integrated security=SSPI";
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Phone_Id, PhoneType, AreaCode,PhoneNumber from PhoneTemp";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvPhone.DataSource = ds.Tables[0];
                lvPhone.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillDate()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select Date_Id, DateType, Date from DateTemp";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lvDate.DataSource = ds.Tables[0];
                lvDate.DataBind();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lvAddress_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtStreetAddrLV = (TextBox)e.Item.FindControl("txtStreetAddrLV");
                TextBox txtCityLV = (TextBox)e.Item.FindControl("txtCityAddrLV");
                TextBox txtStateLV = (TextBox)e.Item.FindControl("txtStateAddrLV");
                TextBox txtZipLV = (TextBox)e.Item.FindControl("txtZipAddrLV");

                DropDownList dllAddressTypeLV = (DropDownList)e.Item.FindControl("ddlAddressTypeLV");

                if (txtStreetAddrLV.Text == "" || txtCityLV.Text == "" || txtStateLV.Text == "" || txtZipLV.Text == "" || dllAddressTypeLV.SelectedValue == "-1")
                {
                    properAddress = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing');", true);
                }
                else
                {
                    properAddress = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

                    SqlConnection con = new SqlConnection(strConnection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"insert into AddressTemp(AddrType,StreetAddr,City,State,Zip) values('" + dllAddressTypeLV.SelectedItem + "','" + txtStreetAddrLV.Text + "','" + txtCityLV.Text + "','" + txtStateLV.Text + "','" + txtZipLV.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtStreetAddrLV.Text = "";
                    txtCityLV.Text = "";
                    txtStateLV.Text = "";
                    txtZipLV.Text = "";
                    dllAddressTypeLV.SelectedValue = "-1";

                    FillAddress();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvAddress_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string addrID = "";

                Label lbl = (lvAddress.Items[e.ItemIndex].FindControl("AddressIDLabel")) as Label;

                if (lbl != null)
                {
                    addrID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from AddressTemp where Address_Id= '" + addrID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillAddress();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvAddress_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvAddress.EditIndex = e.NewEditIndex;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Address_id,AddrType,StreetAddr,City,State,Zip from AddressTemp";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvAddress.DataSource = ds1.Tables[0];
            lvAddress.DataBind();

        }

        protected void lvAddress_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string AddrId = "", Address = "", State = "", City = "", Zip = "";

            Label lbl = (lvAddress.Items[e.ItemIndex].FindControl("AddressIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                AddrId = lbl.Text;
            }

            TextBox txt = (lvAddress.Items[e.ItemIndex].FindControl("txtStreetAddressEditLV")) as TextBox;

            if (txt != null)
            {
                Address = txt.Text;
            }

            txt = (lvAddress.Items[e.ItemIndex].FindControl("txtCityEditLV")) as TextBox;

            if (txt != null)
            {
                City = txt.Text;
            }

            txt = (lvAddress.Items[e.ItemIndex].FindControl("txtStateAddrEditLV")) as TextBox;

            if (txt != null)
            {
                State = txt.Text;
            }

            txt = (lvAddress.Items[e.ItemIndex].FindControl("txtZipEditLV")) as TextBox;

            if (txt != null)
            {
                Zip = txt.Text;
            }

            DropDownList dllAddressTypeLV = (lvAddress.Items[e.ItemIndex].FindControl("ddlAddressTypeEditLV")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"UPDATE AddressTemp SET AddrType='" + dllAddressTypeLV.SelectedItem + "', StreetAddr='" + Address + "', City='" + City + "',State='" + State + "',Zip='" + Zip + "' where Address_id='" + AddrId + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            lvAddress.EditIndex = -1;

            FillAddress();

        }

        protected void lvAddress_ItemCancelling(object sender,ListViewCancelEventArgs e)
        {
            lvAddress.EditIndex = -1;
            FillAddress();
        }

        protected void lvPhone_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtAreaCodeLV = (TextBox)e.Item.FindControl("txtAreaCodeLV");
                TextBox txtPhoneNumberLV = (TextBox)e.Item.FindControl("txtPhoneNumberLV");
                DropDownList dllPhoneTypeLV = (DropDownList)e.Item.FindControl("ddlPhoneTypeLV");

                if (txtAreaCodeLV.Text == "" || txtPhoneNumberLV.Text == "" || dllPhoneTypeLV.SelectedValue == "-1" || txtPhoneNumberLV.Text.Length<10 )
                {
                    properPhone = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing or Invalid');", true);
                }
                else
                {
                    properPhone = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

                    SqlConnection con = new SqlConnection(strConnection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"insert into PhoneTemp(PhoneType,AreaCode,PhoneNumber) values('" + dllPhoneTypeLV.SelectedItem + "','" + txtAreaCodeLV.Text + "','" + txtPhoneNumberLV.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtAreaCodeLV.Text = "";
                    txtPhoneNumberLV.Text = "";
                    dllPhoneTypeLV.SelectedValue = "-1";

                    FillPhone();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvPhone_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string phoneID = "";

                Label lbl = (lvPhone.Items[e.ItemIndex].FindControl("PhoneIDLabel")) as Label;

                if (lbl != null)
                {
                    phoneID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from PhoneTemp where Phone_Id= '" + phoneID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillPhone();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvPhone_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvPhone.EditIndex = e.NewEditIndex;
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Phone_id,PhoneType,AreaCode,PhoneNumber from PhoneTemp";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvPhone.DataSource = ds1.Tables[0];
            lvPhone.DataBind();
        }

        protected void lvPhone_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string PhoneId = "", AreaCd = "", Numb = "";

            Label lbl = (lvPhone.Items[e.ItemIndex].FindControl("PhoneIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                PhoneId = lbl.Text;
            }

            TextBox txt = (lvPhone.Items[e.ItemIndex].FindControl("txtAreaCodeEditLV")) as TextBox;

            if (txt != null)
            {
                AreaCd = txt.Text;
            }

            txt = (lvPhone.Items[e.ItemIndex].FindControl("txtPhoneNumberEditLV")) as TextBox;

            if (txt != null)
            {
                Numb = txt.Text;
            }

            DropDownList dllPhoneTypeLV = (lvPhone.Items[e.ItemIndex].FindControl("ddlPhoneTypeEditLV")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"UPDATE PhoneTemp SET PhoneType='" + dllPhoneTypeLV.SelectedItem + "', AreaCode='" + AreaCd + "', PhoneNumber='" + Numb + "' where Phone_id='" + PhoneId + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            lvPhone.EditIndex = -1;

            FillPhone();

        }

        protected void lvPhone_ItemCancelling(object sender, ListViewCancelEventArgs e)
        {
            lvPhone.EditIndex = -1;
            FillPhone();
        }

        protected void lvDate_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            try
            {
                TextBox txtDateLV = (TextBox)e.Item.FindControl("txtDateLV");
                DropDownList ddlDateTypeLV = (DropDownList)e.Item.FindControl("ddlDateTypeLV");
                if (txtDateLV.Text == "" || ddlDateTypeLV.SelectedValue == "-1")
                {
                    properDate = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "FailureMesg", "alert('One or More fields values are missing');", true);
                }
                else
                {
                    properDate = true;
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                    SqlConnection con = new SqlConnection(strConnection);
                    SqlCommand cmd0 = new SqlCommand();
                    cmd0.CommandText = @"select date from datetemp where dateType='BirthDay'";
                    cmd0.Connection = con;
                    con.Open();
                    object obj=cmd0.ExecuteScalar();
                    DateTime bday;
                    
                    if (obj != null && ddlDateTypeLV.SelectedItem.Text.Equals("Anniversary"))
                    {
                        bday = (DateTime)obj;
                        int idiff = DateTime.Compare(bday, DateTime.Parse(txtDateLV.Text));
                        if (idiff > 0)
                        {
                            lblDateErrMsg.Visible = true;
                            properDate = false;
                            txtDateLV.Text = "";
                            lblDateErrMsg.Text = "BirthDay should be less than Anniversary Date";
                        }
                    }

                    SqlCommand cmd01 = new SqlCommand();
                    cmd01.CommandText = @"select date from datetemp where dateType='Anniversary'";
                    cmd01.Connection = con;
                    object obj1 = cmd01.ExecuteScalar();
                    DateTime aday;

                    if (obj1 != null && ddlDateTypeLV.SelectedItem.Text.Equals("BirthDay"))
                    {
                        aday = (DateTime)obj1;
                        int idiff = DateTime.Compare(aday, DateTime.Parse(txtDateLV.Text));
                        if (idiff < 0)
                        {
                            lblDateErrMsg.Visible = true;
                            properDate = false;
                            txtDateLV.Text = "";
                            lblDateErrMsg.Text = "BirthDay should be less than Anniversary Date";
                        }
                    }

                    SqlCommand cmd = new SqlCommand();
                    if (properDate == true)
                    {
                        cmd.CommandText = @"insert into DateTemp(DateType,Date) values('" + ddlDateTypeLV.SelectedItem + "','" + txtDateLV.Text + "')";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }


                    txtDateLV.Text = "";
                    ddlDateTypeLV.SelectedValue = "-1";
                    FillDate();

                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvDate_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string dateID = "";

                Label lbl = (lvDate.Items[e.ItemIndex].FindControl("DateIDLabel")) as Label;

                if (lbl != null)
                {
                    dateID = lbl.Text;
                }
                string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnection);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete from DateTemp where Date_Id= '" + dateID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                FillDate();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void lvDate_ItemEditing(object source, ListViewEditEventArgs e)
        {
            lvDate.EditIndex = e.NewEditIndex;
            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = @"select Date_id,DateType,Date from DateTemp";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lvDate.DataSource = ds1.Tables[0];
            lvDate.DataBind();
        }

        protected void lvDate_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            string DateId = "", Date = "";

            Label lbl = (lvDate.Items[e.ItemIndex].FindControl("DateIDLabelSearch2")) as Label;

            if (lbl != null)
            {
                DateId = lbl.Text;
            }

            TextBox txt = (lvDate.Items[e.ItemIndex].FindControl("txtDateEditLV")) as TextBox;

            if (txt != null)
            {
                Date = txt.Text;
            }

            DropDownList ddlDateTypeEditLV = (lvDate.Items[e.ItemIndex].FindControl("ddlDateTypeEditLV")) as DropDownList;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd0 = new SqlCommand();
            cmd0.CommandText = @"select date from datetemp where dateType='BirthDay'";
            cmd0.Connection = con;
            con.Open();
            object obj = cmd0.ExecuteScalar();
            DateTime bday;

            if (obj != null && ddlDateTypeEditLV.SelectedItem.Text.Equals("Anniversary"))
            {
                bday = (DateTime)obj;
                int idiff = DateTime.Compare(bday, DateTime.Parse(Date));
                if (idiff > 0)
                {
                    lblDateErrMsg.Visible = true;
                    properDate = false;
                    lblDateErrMsg.Text = "BirthDay should be less than Anniversary Date";
                }
            }

            SqlCommand cmd01 = new SqlCommand();
            cmd01.CommandText = @"select date from datetemp where dateType='Anniversary'";
            cmd01.Connection = con;
            object obj1 = cmd01.ExecuteScalar();
            DateTime aday;

            if (obj1 != null && ddlDateTypeEditLV.SelectedItem.Text.Equals("BirthDay"))
            {
                aday = (DateTime)obj1;
                int idiff = DateTime.Compare(aday, DateTime.Parse(Date));
                if (idiff < 0)
                {
                    lblDateErrMsg.Visible = true;
                    properDate = false;
                    lblDateErrMsg.Text = "BirthDay should be less than Anniversary Date";
                }
            }

            SqlCommand cmd1 = new SqlCommand();
            if (properDate == true)
            {
                cmd1.CommandText = @"UPDATE DateTemp SET DateType='" + ddlDateTypeEditLV.SelectedItem + "', Date='" + Date + "' where Date_id='" + DateId + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            
            lvDate.EditIndex = -1;

            FillDate();

        }

        protected void lvDate_ItemCancelling(object sender, ListViewCancelEventArgs e)
        {
            lvDate.EditIndex = -1;
            FillDate();
        }

        public void clearAllFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            FillAddress();
            FillPhone();
            FillDate();
        }

        protected void btnAdd_Contact_Click(object sender, EventArgs e)
        {
            Contact C = new Contact();
            LogicContact lc = new LogicContact();
            C.First_Name = txtFirstName.Text;
            C.Last_Name = txtLastName.Text;
            C.Middle_Name = txtMiddleName.Text;

            if (Page.IsValid)
            {
                lc.AddContactDetails(C);
                lc.AddAddress();
                lc.AddPhone();
                lc.AddDate();
                clearAllFields();
                Response.Write("<script>alert('Contact Saved Successfully');</script>");
                
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "One or More fields is Empty";
            }

        }

        protected void btn_Reset_Contact_Click(object sender, EventArgs e)
        {
            
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";

            string cnstr = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("usp_ResetFields", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            FillAddress();
            FillPhone();
            FillDate();

        }
    }
}
 