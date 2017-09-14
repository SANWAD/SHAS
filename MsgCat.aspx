<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="MsgCat.aspx.cs" Inherits="MsgCat" Title="Massage Category" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<script runat="server">    
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Massage Category</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:HiddenField ID="lbl_Msg_id" runat="server"/>                       
                </div>                         
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Massage Description"></asp:Label>
                    <asp:TextBox ID="txt_MsgDesc" runat="server" class="form-control" 
                            AutoPostBack="true" ontextchanged="txt_MsgDesc_TextChanged" MaxLength="60" ></asp:TextBox>
                </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txt_MsgDesc" ErrorMessage="Required Massage Description" Text="*" SetFocusOnError="true" /> 
                </td>
                </tr>
                </table>
                </div> 
                  <div class="form-group">
                  <asp:Label ID="Label1" runat="server" Text="ISActive"></asp:Label>
                  <asp:CheckBox ID="ChkIsAct" runat="server" class="form-control" />
                  </div> 
                 <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Massage Description Already Exists" ForeColor="Red" Visible="false"></asp:Label>
                </div>             
                <div class="btn-toolbar list-toolbar"> 
                  <asp:Button ID="btn_save" runat="server" Text="SAVE" class="btn btn-primary" onclick="btn_save_Click"/>         
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
