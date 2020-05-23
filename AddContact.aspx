<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="ContactListApplication.AddContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-top: 0px;
        }
    </style>
    <style type="text/css">
        * { font-family: 'Times New Roman', sans-serif; font-size: 14px; }
        table.lamp { padding: 0px; border: 1px solid #d4d4d4; }
        table.lamp th { color: white; background-color: #666; padding: 10px; padding-left: 10px; text-align: left; }
        table.lamp td { padding: 4px; padding-left: 10px; background-color: #ffffff; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
</p>
<p>
    <asp:Label ID="lblFName" runat="server" Text="First Name :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name should not be empty" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="lblMidName" runat="server" Text="Middle Name :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="Middle Name should not be empty" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
    &nbsp;<asp:Label ID="lblLastName" runat="server" Text="Last Name :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server" CssClass="auto-style2"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name should not be empty" Font-Bold="True" Font-Size="Large" ForeColor="Red">*</asp:RequiredFieldValidator>
    </p>

    <asp:ListView ID="lvAddress" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvAddress_ItemInserting" OnItemDeleting="lvAddress_ItemDeleting" OnItemEditing="lvAddress_ItemEditing" OnItemUpdating="lvAddress_ItemUpdating" OnItemCanceling="lvAddress_ItemCancelling">
        <LayoutTemplate>
                <table class="lamp" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Address ID
                        </th>
                        <th>
                            Address Type
                        </th>
                        <th>
                            Street Address
                        </th>
                        <th>
                            City
                        </th>
                        <th>
                            State
                        </th>
                        <th>
                            Zip Code
                        </th>
                        <th>

                        </th>
                    </tr>
                    <tr id="itemplaceholder" runat="server">
                    </tr>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    
                    <td>
                        <asp:Label ID="AddressIDLabel" runat="server" Text='<%# Eval("Address_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="AddressTypeLabel" runat="server" Text='<%# Eval("AddrType") %>' />
                    </td>
                    <td>
                       <asp:Label ID="StreetAddrLabel" runat="server" Text='<%# Eval("StreetAddr") %>' />
                    </td>
                    <td>
                       <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                       <asp:Label ID="StateLabel" runat="server" Text='<%# Eval("State") %>' />
                    </td>
                    <td>
                       <asp:Label ID="ZipLabel" runat="server" Text='<%# Eval("Zip") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditAddr" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif" ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeleteAddr" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this address?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAddressTypeLV" runat="server">
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Address" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Work Address" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other Address" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAddressTypeLV" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Address Type." ErrorMessage="*"
                            ControlToValidate="ddlAddressTypeLV" ValidationGroup="vgAddress" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreetAddrLV" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStreetAddrLV" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Street Address." ErrorMessage="*" ControlToValidate="txtStreetAddrLV"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCityAddrLV" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtCityLV" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter City." ErrorMessage="*" ControlToValidate="txtCityAddrLV"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateAddrLV" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStateAddrLV" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter State." ErrorMessage="*" ControlToValidate="txtStateAddrLV"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipAddrLV" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtZip" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Zip Code." ErrorMessage="*" ControlToValidate="txtZipAddrLV"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td>
                        <asp:Button ID="btnSaveAddr" runat="server" CommandName="Insert"  Text="Save Address" ValidationGroup="vgAddress" ToolTip="Save Address and Add Another" CausesValidation="true"/>
                    </td>
                </tr>
       </InsertItemTemplate>
       <EditItemTemplate>
           <tr>
               <td>
                   <asp:Label ID="AddressIDLabelSearch2" runat="server" Text='<%# Eval("Address_id") %>' />
               </td>
                    <td>
                        <asp:DropDownList ID="ddlAddressTypeEditLV" runat="server" SelectedValue='<%# Bind("AddrType") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Address" Value="Home Address"></asp:ListItem>
                            <asp:ListItem Text="Work Address" Value="Work Address"></asp:ListItem>
                            <asp:ListItem Text="Other Address" Value="Other Address"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAddressTypeEdit" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Address Type." ErrorMessage="*"
                            ControlToValidate="ddlAddressTypeEditLV" ValidationGroup="vgAddressEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreetAddressEditLV" runat="server" Text='<%# Bind("StreetAddr") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStreetAddressEdit" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Street Address." ErrorMessage="*"
                            ControlToValidate="txtStreetAddressEditLV" ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCityEditLV" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtCity" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter City." ErrorMessage="*" ControlToValidate="txtCityEditLV"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateAddrEditLV" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStateAddrEdit" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter State." ErrorMessage="*" ControlToValidate="txtStateAddrEditLV"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipEditLV" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtZipEdit" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Zip Code." ErrorMessage="*" ControlToValidate="txtZipEditLV"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>            
              <td>
                  <asp:ImageButton ID="imgbUpdateAddr" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgAddressEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelAddr" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
              </td>
              </tr>
              </EditItemTemplate>
              <EmptyDataTemplate>
                  <tr>
                      <td>
                          No data was returned.
                      </td>
                  </tr>
               </EmptyDataTemplate>
    </asp:ListView>

    <asp:ListView ID="lvPhone" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvPhone_ItemInserting" OnItemDeleting="lvPhone_ItemDeleting" OnItemUpdating="lvPhone_ItemUpdating" OnItemEditing="lvPhone_ItemEditing" OnItemCanceling="lvPhone_ItemCancelling">
        <LayoutTemplate>
                <table class="lamp" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Phone ID
                        </th>
                        <th>
                            Phone Type
                        </th>
                        <th>
                            Area Code
                        </th>
                        <th>
                            Phone Number
                        </th>
                        <th>

                        </th>
                    </tr>
                    <tr id="itemplaceholder" runat="server">
                    </tr>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    
                    <td>
                        <asp:Label ID="PhoneIDLabel" runat="server" Text='<%# Eval("Phone_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="PhoneTypeLabel" runat="server" Text='<%# Eval("PhoneType") %>' />
                    </td>
                    <td>
                       <asp:Label ID="AreaCodeLabel" runat="server" Text='<%# Eval("AreaCode") %>' />
                    </td>
                    <td>
                       <asp:Label ID="PhoneNumLabel" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditPhone" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif"  ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeletePhone" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this phone?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPhoneTypeLV" runat="server">
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Phone" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Work Phone" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Cell Phone" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Fax" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlPhoneTypeLV" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Phone Type." ErrorMessage="*"
                            ControlToValidate="ddlPhoneTypeLV" ValidationGroup="vgPhone" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAreaCodeLV" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtAreaCodeLV" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Area Code." ErrorMessage="*"
                            ControlToValidate="txtAreaCodeLV" ValidationGroup="vgPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regExAreaCode" runat="server" ControlToValidate="txtAreaCodeLV" ErrorMessage="Area Code should contain only digits" ValidationExpression="\d+" ForeColor="Red" ValidationGroup="vgPhone">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumberLV" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPhoneNumberLV" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Phone Number." ErrorMessage="*" ControlToValidate="txtPhoneNumberLV"
                            ValidationGroup="vgPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpValPhoNumO" runat="server" ControlToValidate="txtPhoneNumberLV" ErrorMessage="Phone Number should be 10 digits" ValidationExpression="[0-9]{10}" ForeColor="Red" ValidationGroup="vgPhone">
                        </asp:RegularExpressionValidator>
                    </td>                   
                    <td>
                        <asp:Button ID="btnSavePhone" runat="server" CommandName="Insert" Text="Save Phone" ValidationGroup="vgPhone" ToolTip="Save Phone and Another" CausesValidation="true" />
                    </td>
                </tr>
       </InsertItemTemplate>
       <EditItemTemplate>
           <tr>
               <td>
                    <asp:Label ID="PhoneIDLabelSearch2" runat="server" Text='<%# Eval("Phone_id") %>' />
               </td>
                    <td>
                        <asp:DropDownList ID="ddlPhoneTypeEditLV" runat="server" SelectedValue='<%# Bind("PhoneType") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Phone" Value="Home Phone"></asp:ListItem>
                            <asp:ListItem Text="Work Phone" Value="Work Phone"></asp:ListItem>
                            <asp:ListItem Text="Cell Phone" Value="Cell Phone"></asp:ListItem>
                            <asp:ListItem Text="Fax" Value="Fax"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlPhoneTypeEdit" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Phone Type." ErrorMessage="*"
                            ControlToValidate="ddlPhoneTypeEditLV" ValidationGroup="vgPhoneEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAreaCodeEditLV" runat="server" Text='<%# Bind("AreaCode") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtAreaCodeEdit" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Area Code." ErrorMessage="*"
                            ControlToValidate="txtAreaCodeEditLV" ValidationGroup="vgPhoneEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regExAreaCodeEdit" runat="server" ControlToValidate="txtAreaCodeEditLV" ErrorMessage="Area Code should contain only digits" ValidationExpression="\d+" ForeColor="Red" ValidationGroup="vgPhoneEdit">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumberEditLV" runat="server" MaxLength="10" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPhoneNumberEdit" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Phone Number." ErrorMessage="*" ControlToValidate="txtPhoneNumberEditLV"
                            ValidationGroup="vgPhoneEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpValPhoNum" runat="server" ControlToValidate="txtPhoneNumberEditLV" ErrorMessage="Phone Number should be 10 digits" ValidationExpression="[0-9]{10}" ValidationGroup="vgPhoneEdit">
                        </asp:RegularExpressionValidator>
                    </td>           
              <td>
                  <asp:ImageButton ID="imgbUpdatePhone" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgPhoneEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelPhone" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
              </td>
              </tr>
              </EditItemTemplate>
              <EmptyDataTemplate>
                  <tr>
                      <td>
                          No data was returned.
                      </td>
                  </tr>
               </EmptyDataTemplate>
    </asp:ListView>

    <asp:ListView ID="lvDate" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvDate_ItemInserting" OnItemDeleting="lvDate_ItemDeleting" OnItemEditing="lvDate_ItemEditing" OnItemUpdating="lvDate_ItemUpdating" OnItemCanceling="lvDate_ItemCancelling">
        <LayoutTemplate>
                <table class="lamp" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Date ID
                        </th>
                        <th>
                            Date Type
                        </th>
                        <th>
                            Date
                        </th>
                        <th>

                        </th>
                    </tr>
                    <tr id="itemplaceholder" runat="server">
                    </tr>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
                <tr>
                    
                    <td>
                        <asp:Label ID="DateIDLabel" runat="server" Text='<%# Eval("Date_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="DateTypeLabel" runat="server" Text='<%# Eval("DateType") %>' />
                    </td>
                    <td>
                       <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditDate" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif"  ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeleteDate" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this Date?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDateTypeLV" runat="server">
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="BirthDay" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Anniversary" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlDateTypeLV" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Date Type." ErrorMessage="*"
                            ControlToValidate="ddlDateTypeLV" ValidationGroup="vgDate" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateLV" runat="server" Text='<%# String.Format("{0:MM/dd/yyyy}", Eval("FirstVisitDate")) %>' 
                             CssClass="form-control" TextMode="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_DateLV" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Date." ErrorMessage="*"
                            ControlToValidate="txtDateLV" ValidationGroup="vgDate" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>                 
                    <td>
                        <asp:Button ID="btnSaveDate" runat="server" CommandName="Insert" Text="Save Date" ValidationGroup="vgDate" ToolTip="Save Date and Add Another" CausesValidation="true"/>
                    </td>
                </tr>
       </InsertItemTemplate>
       <EditItemTemplate>
           <tr>
               <td>
                    <asp:Label ID="DateIDLabelSearch2" runat="server" Text='<%# Eval("Date_id") %>' />
               </td>
                    <td>
                        <asp:DropDownList ID="ddlDateTypeEditLV" runat="server" SelectedValue='<%# Bind("DateType") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="BirthDay" Value="BirthDay"></asp:ListItem>
                            <asp:ListItem Text="Anniversary" Value="Anniversary"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlDateTypeEdit" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Date Type." ErrorMessage="*"
                            ControlToValidate="ddlDateTypeEditLV" ValidationGroup="vgDateEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateEditLV" runat="server" Text='<%# String.Format("{0:MM/dd/yyyy}", Eval("Date")) %>' 
                             CssClass="form-control" TextMode="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtDateEdit" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Date" ErrorMessage="*"
                            ControlToValidate="txtDateEditLV" ValidationGroup="vgDateEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>                        
              <td>
                  <asp:ImageButton ID="imgbUpdateDate" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgDateEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelDate" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
              </td>
              </tr>
              </EditItemTemplate>
              <EmptyDataTemplate>
                  <tr>
                      <td>
                          No data was returned.
                      </td>
                  </tr>
               </EmptyDataTemplate>
    </asp:ListView>



    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblDateErrMsg" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </p>
    <p>
    &nbsp;<asp:Button ID="btnAdd_Contact" runat="server" OnClick="btnAdd_Contact_Click" Text="ADD CONTACT"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_Reset_Contact" runat="server" Text="RESET" OnClick="btn_Reset_Contact_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
