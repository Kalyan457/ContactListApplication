<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifyContact.aspx.cs" Inherits="ContactListApplication.ModifyContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        * { font-family: Arial, sans-serif; font-size: 12px; }
        table.lamp { padding: 0px; border: 1px solid #d4d4d4; }
        table.lamp th { color: white; background-color: #666; padding: 10px; padding-left: 10px; text-align: left; }
        table.lamp td { padding: 4px; padding-left: 10px; background-color: #ffffff; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblFNameMod" runat="server" Font-Bold="True" Text="First Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtFNameMod" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFNameMod" runat="server" ControlToValidate="txtFNameMod" ErrorMessage="First Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="lblMNameMod" runat="server" Font-Bold="True" Text="Middle Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtMNameMod" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfvMNameMod" runat="server" ControlToValidate="txtMNameMod" ErrorMessage="Middle Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="lblLNameMod" runat="server" Font-Bold="True" Text="Last Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtLNameMod" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLName" runat="server" ControlToValidate="txtLNameMod" ErrorMessage="Last Name is Required"></asp:RequiredFieldValidator>
    </p>
    <asp:ListView ID="lvAddressSearch" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvAddressSearch_ItemInserting" OnItemDeleting="lvAddressSearch_ItemDeleting" OnItemEditing="lvAddressSearch_ItemEditing" OnItemUpdating="lvAddressSearch_ItemUpdating" OnItemCanceling="lvAddressSearch_ItemCancelling">
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
                        <asp:Label ID="AddressIDLabelSearch" runat="server" Text='<%# Eval("Address_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="AddressTypeLabelSearch" runat="server" Text='<%# Eval("Address_Type") %>' />
                    </td>
                    <td>
                       <asp:Label ID="StreetAddrLabelSearch" runat="server" Text='<%# Eval("Address") %>' />
                    </td>
                    <td>
                       <asp:Label ID="CityLabelSearch" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                       <asp:Label ID="StateLabelSearch" runat="server" Text='<%# Eval("State") %>' />
                    </td>
                    <td>
                       <asp:Label ID="ZipLabelSearch" runat="server" Text='<%# Eval("Zip") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditAddrSearch" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif"  ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeleteAddrSearch" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this Address?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAddressTypeLVSearch" runat="server" SelectedValue='<%# Bind("Address_type") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Address" Value="Home Address"></asp:ListItem>
                            <asp:ListItem Text="Work Address" Value="Work Address"></asp:ListItem>
                            <asp:ListItem Text="Other Address" Value="Other Address"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAddressTypeLVSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Address Type." ErrorMessage="*"
                            ControlToValidate="ddlAddressTypeLVSearch" ValidationGroup="vgAddress" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreetAddrLVSearch" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStreetAddrLVSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Street Address." ErrorMessage="*" ControlToValidate="txtStreetAddrLVSearch"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCityAddrLVSearch" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtCityLVSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter City." ErrorMessage="*" ControlToValidate="txtCityAddrLVSearch"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateAddrLVSearch" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStateAddrLVSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter State." ErrorMessage="*" ControlToValidate="txtStateAddrLVSearch"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipAddrLVSearch" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtZipSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Zip Code." ErrorMessage="*" ControlToValidate="txtZipAddrLVSearch"
                            ValidationGroup="vgAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    
                    <td>
                        <asp:Button ID="btnSaveAddr" runat="server" CommandName="Insert" Text="Save Address" ValidationGroup="vgAddress" ToolTip="Save Address and Add Another" CausesValidation="true"/>
                    </td>
                </tr>
       </InsertItemTemplate>
       <EditItemTemplate>
           <tr>
               <td>
                   <asp:Label ID="AddressIDLabelSearch2" runat="server" Text='<%# Eval("Address_id") %>' />
               </td>
                    <td>
                        <asp:DropDownList ID="ddlAddressTypeEditLVSearch" runat="server" SelectedValue='<%# Bind("Address_type") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Address" Value="Home Address"></asp:ListItem>
                            <asp:ListItem Text="Work Address" Value="Work Address"></asp:ListItem>
                            <asp:ListItem Text="Other Address" Value="Other Address"></asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlAddressTypeEditSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Address Type." ErrorMessage="*"
                            ControlToValidate="ddlAddressTypeEditLVSearch" ValidationGroup="vgAddressEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreetAddressEditLVSearch" runat="server" Text='<%# Bind("Address") %>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStreetAddressEditSearch" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Street Address." ErrorMessage="*"
                            ControlToValidate="txtStreetAddressEditLVSearch" ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCityEditLVSearch" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtCityEditSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter City." ErrorMessage="*" ControlToValidate="txtCityEditLVSearch"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStateAddrEditLVSearch" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtStateAddrEditSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter State." ErrorMessage="*" ControlToValidate="txtStateAddrEditLVSearch"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipEditLVSearch" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtZipEditSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Zip Code." ErrorMessage="*" ControlToValidate="txtZipEditLVSearch"
                            ValidationGroup="vgAddressEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>            
              <td>
                  <asp:ImageButton ID="imgbUpdateAddrSearch" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgAddressEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelAddrSearch" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
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

    <br />

    <asp:ListView ID="lvPhoneSearch" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvPhoneSearch_ItemInserting" OnItemDeleting="lvPhoneSearch_ItemDeleting" OnItemEditing="lvPhoneSearch_ItemEditing" OnItemUpdating="lvPhoneSearch_ItemUpdating" OnItemCanceling="lvPhoneSearch_ItemCancelling">
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
                        <asp:Label ID="PhoneIDLabelSearch" runat="server" Text='<%# Eval("Phone_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="PhoneTypeLabelSearch" runat="server" Text='<%# Eval("Phone_Type") %>' />
                    </td>
                    <td>
                       <asp:Label ID="AreaCodeLabelSearch" runat="server" Text='<%# Eval("Area_Code") %>' />
                    </td>
                    <td>
                       <asp:Label ID="PhoneNumLabelSearch" runat="server" Text='<%# Eval("Number") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditPhoneSearch" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif"  ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeletePhoneSearch" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this phone?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPhoneTypeLVSearch" runat="server">
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Phone" Value="Home Phone"></asp:ListItem>
                            <asp:ListItem Text="Work Phone" Value="Work Phone"></asp:ListItem>
                            <asp:ListItem Text="Cell Phone" Value="Cell Phone"></asp:ListItem>
                            <asp:ListItem Text="Fax" Value="Fax"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlPhoneTypeLVSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Phone Type." ErrorMessage="*"
                            ControlToValidate="ddlPhoneTypeLVSearch" ValidationGroup="vgPhone" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAreaCodeLVSearch" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtAreaCodeLVSearch" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Area Code." ErrorMessage="*"
                            ControlToValidate="txtAreaCodeLVSearch" ValidationGroup="vgPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumberLVSearch" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPhoneNumberLVSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Phone Number." ErrorMessage="*" ControlToValidate="txtPhoneNumberLVSearch"
                            ValidationGroup="vgPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpValPhoNum" runat="server" ControlToValidate="txtPhoneNumberLVSearch" ErrorMessage="Phone Number should be 10 digits" ValidationExpression="[0-9]{10}" ForeColor="Red" ValidationGroup="vgPhone">
                        </asp:RegularExpressionValidator>
                    </td>                   
                    <td>
                        <asp:Button ID="btnSavePhone" runat="server" CommandName="Insert" Text="Save Phone" ValidationGroup="vgPhone" ToolTip="Save Phone and Another" CausesValidation="true"/>
                    </td>
                </tr>
       </InsertItemTemplate>
       <EditItemTemplate>
           <tr>
               <td>
                    <asp:Label ID="PhoneIDLabelSearch2" runat="server" Text='<%# Eval("Phone_id") %>' />
               </td>
                    <td>
                        <asp:DropDownList ID="ddlPhoneTypeEditLVSearch" runat="server" SelectedValue='<%# Bind("Phone_type") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Home Phone" Value="Home Phone"></asp:ListItem>
                            <asp:ListItem Text="Work Phone" Value="Work Phone"></asp:ListItem>
                            <asp:ListItem Text="Cell Phone" Value="Cell Phone"></asp:ListItem>
                            <asp:ListItem Text="Fax" Value="Fax"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlPhoneTypeEditSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Phone Type." ErrorMessage="*"
                            ControlToValidate="ddlPhoneTypeEditLVSearch" ValidationGroup="vgPhoneEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAreaCodeEditLVSearch" runat="server" Text='<%# Bind("Area_code") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtAreaCodeEditSearch" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Area Code." ErrorMessage="*"
                            ControlToValidate="txtAreaCodeEditLVSearch" ValidationGroup="vgPhoneEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumberEditLVSearch" runat="server" MaxLength="10" Text='<%# Bind("Number") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtPhoneNumberEditSearch" runat="server" ForeColor="Red" Font-Bold="true"
                            Font-Size="18px" ToolTip="Please enter Phone Number." ErrorMessage="*" ControlToValidate="txtPhoneNumberEditLVSearch"
                            ValidationGroup="vgPhoneEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpValPhoNum1" runat="server" ControlToValidate="txtPhoneNumberEditLVSearch" ErrorMessage="Phone Number should be 10 digits" ValidationExpression="[0-9]{10}" ValidationGroup="vgPhoneEdit">
                        </asp:RegularExpressionValidator>

                    </td>           
              <td>
                  <asp:ImageButton ID="imgbUpdatePhoneSearch" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgPhoneEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelPhoneSearch" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
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

    <br />

    <asp:ListView ID="lvDateSearch" runat="server" InsertItemPosition="LastItem" OnItemInserting="lvDateSearch_ItemInserting" OnItemDeleting="lvDateSearch_ItemDeleting" OnItemEditing="lvDateSearch_ItemEditing" OnItemUpdating="lvDateSearch_ItemUpdating" OnItemCanceling="lvDateSearch_ItemCancelling">
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
                        <asp:Label ID="DateIDLabelSearch" runat="server" Text='<%# Eval("Date_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="DateTypeLabelSearch" runat="server" Text='<%# Eval("Date_type") %>' />
                    </td>
                    <td>
                       <asp:Label ID="DateLabelSearch" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                       <asp:ImageButton ID="imgbEditDateSearch" runat="server" CommandName="Edit" Text="Edit" ImageUrl="edit_icon_mono.gif"  ToolTip="Edit"/>
                       <asp:ImageButton ID="imgbDeleteDateSearch" runat="server" CommandName="Delete" Text="Delete" ImageUrl="delete_icon_mono.gif" OnClientClick="return confirm('Are you sure you want to delete this Date?');" ToolTip="Delete"/>
                    </td>
                </tr>
         </ItemTemplate>
        <InsertItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDateTypeLVSearch" runat="server">
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="BirthDay" Value="BirthDay"></asp:ListItem>
                            <asp:ListItem Text="Anniversary" Value="Anniversary"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlDateTypeLVSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Date Type." ErrorMessage="*"
                            ControlToValidate="ddlDateTypeLVSearch" ValidationGroup="vgDate" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateLVSearch" runat="server" Text='<%# String.Format("{0:MM/dd/yyyy}", Eval("Date")) %>' 
                             CssClass="form-control" TextMode="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_DateLVSearch" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Date." ErrorMessage="*"
                            ControlToValidate="txtDateLVSearch" ValidationGroup="vgDate" Display="Dynamic"></asp:RequiredFieldValidator>
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
                        <asp:DropDownList ID="ddlDateTypeEditLVSearch" runat="server" SelectedValue='<%# Bind("Date_type") %>'>
                            <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="BirthDay" Value="BirthDay"></asp:ListItem>
                            <asp:ListItem Text="Anniversary" Value="Anniversary"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddlDateTypeEditSearch" runat="server" ForeColor="Red"
                            Font-Bold="true" Font-Size="18px" ToolTip="Please select Date Type." ErrorMessage="*"
                            ControlToValidate="ddlDateTypeEditLVSearch" ValidationGroup="vgDateEdit" Display="Dynamic"
                            InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDateEditLVSearch" runat="server" Text='<%# String.Format("{0:MM/dd/yyyy}", Eval("Date")) %>' 
                             CssClass="form-control" TextMode="date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtDateEditSearch" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="18px" ToolTip="Please enter Date" ErrorMessage="*"
                            ControlToValidate="txtDateEditLVSearch" ValidationGroup="vgDateEdit" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>                        
              <td>
                  <asp:ImageButton ID="imgbUpdateDateSearch" runat="server" CommandName="Update" Text="Update" ImageUrl="save_icon_mono.gif" CausesValidation="true" ValidationGroup="vgDateEdit" ToolTip="Update"/>
                  <asp:ImageButton ID="imgbCancelDateSearch" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="undo_icon_mono.gif" CausesValidation="false" ToolTip="Cancel"/>
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


    <br />
    <asp:Label ID="lblErrDateMod" runat="server" ForeColor="Red" Text="Label"></asp:Label>


    <br />
    <asp:Button ID="btnSaveContactMod" runat="server" OnClick="btnSaveContactMod_Click" Text="Save Changes" CausesValidation="true"/>


</asp:Content>
