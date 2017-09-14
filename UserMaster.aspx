<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="UserMaster.aspx.cs" Inherits="UserMaster" Title="User Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<script runat="server">    
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">User Master</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-5">
             <div class="form-group"> 
                <table style="width:100%">
                <tr>
                <td style="width:99%">  
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Center Name"></asp:Label>
                    <asp:DropDownList ID="ddlCent_Nm" runat="server" class="form-control"></asp:DropDownList>
                     </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqCenter" controltovalidate="ddlCent_Nm" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>
                </table> 
                </div>    
                <div class="form-group"> 
                <table style="width:100%">
                <tr>
                <td style="width:99%">   
                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text="User Type"></asp:Label>
                    <asp:DropDownList ID="ddlUser_type" runat="server" class="form-control"></asp:DropDownList>
                     </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqUser_type" controltovalidate="ddlUser_type" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>
                </table> 
                </div>  
            <div class="form-group">                 
                <asp:HiddenField ID="lbl_user_id" runat="server"/>                       
                </div>              
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label>
                    <asp:TextBox ID="txt_User_desc" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txt_User_desc" ErrorMessage="Required User Name"  Text="*" SetFocusOnError="true"/> 
                </td>
                </tr>
                </table>
                </div> 
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
                     <asp:TextBox ID="txtUserPwd" type="password" class="form-controlspan12 form-control" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqUserPwd" controltovalidate="txtUserPwd" ErrorMessage="Can't Blank Password" Text="*" SetFocusOnError="true"/> 
                </td>
                </tr>
                </table>
                </div>
                  <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="lblConPwd" runat="server" Text="Confirm Password"></asp:Label>
                 <asp:TextBox ID="txtConPwd" type="password" class="form-controlspan12 form-control" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqConpwd" controltovalidate="txtConPwd" ErrorMessage="Do Not Match Password" Text="*" SetFocusOnError="true"/> 
                </td>
                </tr>
                </table>
                </div>   
                </div>
                <div class="col-sm-push-0 col-md-5"> 
                <div class="form-group">
                </div> 
                <div class="form-group">
                <asp:Label ID="lblTel" runat="server" Text="Telephone Number"></asp:Label>
                <asp:TextBox ID="txtTelphone" runat="server" class="form-control"></asp:TextBox>
                </div> 
                <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" Text="E-mail Id"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                 <asp:Label ID="Label3" runat="server" Text="Shravan Mitra:"></asp:Label>
                <asp:RadioButtonList ID="rbtn_svn_mitr" runat="server" RepeatDirection="Horizontal" style="width:100%">
                        <asp:ListItem>YES</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:RadioButtonList>
                </div>  
                 <div class="form-group">
                 <asp:Label ID="Label11" runat="server" Text="User Is Active Or Not:"></asp:Label>
                     <asp:CheckBox ID="ChkIsActive" runat="server" class="form-control"/>
                </div>              
                <div class="btn-toolbar list-toolbar">                
                 <asp:Button ID="btn_save" runat="server" Text="SAVE" OnClick="btn_save_Click" class="btn btn-primary"/>    
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" />
                </div>
                <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                </div> 
            </div>
        </div>
    </div>
    </ContentTemplate> 
 </asp:UpdatePanel> 
</asp:Content>
