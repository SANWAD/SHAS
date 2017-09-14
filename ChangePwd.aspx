<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" Title="Change Password" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="panel panel-default">
<%--<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>--%>
        <div class="panel-heading">
            <h class="text-muted text-center">Change Password</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">       
            <div class="form-group">
                <asp:HiddenField ID="lblinw_no" runat="server" />
            </div>
             <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:99%"> 
                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="User"></asp:Label> 
            <asp:DropDownList ID="ddlUser" runat="server" class="form-control"  
                    AutoPostBack="true"></asp:DropDownList>
              </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqInwTo" controltovalidate="ddlUser" ErrorMessage="Select User" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table> 
            </div>                   
            <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label> 
            <asp:TextBox ID="txtOldPwd" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div> 
             <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label> 
            <asp:TextBox ID="txtNewPwd" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
            <asp:Label ID="Label7" runat="server" Text="Confirm Password"></asp:Label> 
            <asp:TextBox ID="txtConPwd" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>           
            <%-- <div class="form-group">
             <table style="width:100%">
            <tr>
            <td style="width:99%"> 
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text="Update Password"></asp:Label>
              <asp:TextBox ID="txtinwfrom" runat="server" class="form-control"></asp:TextBox>
                </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqFrom" controltovalidate="txtinwfrom" ErrorMessage="Required Update Password" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table>                    
            </div>--%>                   
            <div class="btn-toolbar list-toolbar">
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" class="btn btn-primary" Text ="Save"/>
                <asp:Button ID="btnCanel" runat="server" class="btn btn-primary" Text="Cancel" onclick="btnCanel_Click" CausesValidation="false" />
            </div>
            <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
            </div> 
       </div>
        </div> 
       <%-- </ContentTemplate> 
</asp:UpdatePanel>--%>
        </div>
</asp:Content>

