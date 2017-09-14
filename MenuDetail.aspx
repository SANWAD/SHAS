<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="MenuDetail.aspx.cs" Inherits="MenuDetail" Title="User Mapping" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<script runat="server">    
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">User Mapping</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:HiddenField ID="lbl_ac_id" runat="server"/>                       
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">                
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="User"></asp:Label> 
                    <asp:DropDownList ID="ddlUser" runat="server" class="form-control"></asp:DropDownList>
                </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqUser" controltovalidate="ddlUser" ErrorMessage="Required to select User" Text="*"  SetFocusOnError="true"/>
                </td>
                </tr>
                </table>                
                </div>
               
                <div class="form-group">
                <%--<table style="width:100%">
                <tr>
                <td style="width:99%"> 
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>--%>
                        <asp:Label ID="lblMastMenu" runat="server" Text="Master Menu"></asp:Label>
                    <asp:CheckBox ID="chkMastMenu" runat="server" class="form-control"/>
               <%-- </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqMastMenu" controltovalidate="chkMastMenu" ErrorMessage="Required To Select Master Menu" Text="*" SetFocusOnError="true" /> 
                </td>
                </tr>
                </table>--%>
                </div> 
                 <div class="form-group">
                <%--<table style="width:100%">
                <tr>
                <td style="width:99%"> 
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>--%>
                        <asp:Label ID="lblMenu" runat="server" Text="Menu"></asp:Label>
                    <asp:CheckBox ID="chkMenu" runat="server" class="form-control"/>
               <%-- </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqMenu" controltovalidate="chkMenu" ErrorMessage="Required To Select Master Menu" Text="*" SetFocusOnError="true" /> 
                </td>
                </tr>
                </table>--%>
                </div>  
                 <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Center Name Already Exists" 
                        ForeColor="Red" Visible="false"></asp:Label>
                </div>             
                <div class="btn-toolbar list-toolbar">                
                 <asp:Button ID="btn_save" runat="server" Text="SAVE" OnClick="btn_save_Click" class="btn btn-primary"/>    
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" onclientclick="return askConfirm()" />
                </div>
                <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" EnableClientScript="true" />
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate> 
 </asp:UpdatePanel> 
</asp:Content>
