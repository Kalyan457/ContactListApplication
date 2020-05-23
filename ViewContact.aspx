<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewContact.aspx.cs" Inherits="ContactListApplication.ViewContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-top: 0px;
        }
    </style>
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
        <asp:TextBox ID="txtSearch" runat="server" Width="575px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Width="170px" />
</p>
    <p>
    <br />
</p>
    <asp:ListView ID="lvSearchContact" runat="server" OnItemDeleting="lvSearchContact_DeleteContact" OnItemUpdating="lvSearchContact_UpdateContact">
        <LayoutTemplate>
                <table class="lamp" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Contact ID
                        </th>
                        <th>
                            First Name
                        </th>
                        <th>
                            Middle Name
                        </th>
                        <th>
                            Last Name
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
                        <asp:Label ID="ContactIDLabelSearch" runat="server" Text='<%# Eval("Contact_ID") %>' />
                    </td>
                    <td>
                       <asp:Label ID="ContactFNLabelSearch" runat="server" Text='<%# Eval("Fname") %>' />
                    </td>
                    <td>
                       <asp:Label ID="ContactMNLabelSearch" runat="server" Text='<%# Eval("Mname") %>' />
                    </td>
                    <td>
                       <asp:Label ID="ContactLNLabelSearch" runat="server" Text='<%# Eval("Lname") %>' />
                    </td>
                    <td>
                       <asp:Button ID="btnDeleteContact" runat="server" CommandName="Delete" Text="Delete Contact" />
                       <asp:Button ID="btnMoveToModifyPage" runat ="server" CommandName="Update" Text="Modify Contact" />
                    </td>
                </tr>
         </ItemTemplate>

        </asp:ListView>
        <br />
        
    <br />
    <br />

    <br />
    <br />
    <br />
</asp:Content>
