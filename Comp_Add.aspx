<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Comp_Add.aspx.cs" Inherits="Comp_Add" Title="Own Speech & Hearing Clinic Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <div class="panel panel-default">
    <div class="panel-heading">
            <h class="text-muted text-center">Own Speech & Hearing Clinic Master</h>
        </div>
    <div class="panel-body">
    <div class="col-sm-push-0 col-md-5"> 
        <div class="form-group">
            <asp:HiddenField ID="lblComp_id" runat="server" /> 
        </div>
        <div class="form-group">
        <asp:Label ID="lblComp_Code" runat="server" Text="Code"></asp:Label>
        <asp:TextBox ID="txtComp_Code" runat="server" class="form-control" Enabled="false" ></asp:TextBox>
        </div> 
        <div class="form-group">
        <table style="width:100%">
                <tr>
         <td style="width:99%">               
                <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtComp_nm" runat="server" class="form-control" 
                    ontextchanged="txtComp_nm_TextChanged" AutoPostBack="true" ></asp:TextBox>
         </td> 
        <td style="width:1%">
        <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtComp_nm" runat="server" ErrorMessage="Required Company Name" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </td> 
        </tr> 
        </table>            
        </div>
        <div>
            <asp:Label ID="lblMsg" runat="server" Text="Company Name Already Exists" 
                ForeColor="Red" Visible="False"></asp:Label>
        </div>
     <div class="form-group">
    <table style="width:100%">
    <tr>
    <td style="width:99%">
            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtComp_Add" runat="server" AutoCompleteType="Notes" TextMode="MultiLine" class="form-control"></asp:TextBox>
    </td> 
    <td style="width:1%">
        <asp:RequiredFieldValidator ID="reqAdd" ControlToValidate="txtComp_Add" runat="server"  ErrorMessage="Required Company Address" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
    </td> 
    </tr> 
</table> 
    </div>
    </div> 
    <div class="col-sm-push-0 col-md-5">
    <div class="form-group">
    </div> 
    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Register No"></asp:Label>
        <asp:TextBox ID="txtReg_No" runat="server" AutoCompleteType="Notes" class="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
    <table style="width:100%">
                <tr>
                <td style="width:99%">
            <asp:Label ID="Label6" runat="server" Text="Phone No"></asp:Label>
        <asp:TextBox ID="txtPh_No" runat="server" AutoCompleteType="BusinessPhone" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
         </td> 
        <td style="width:1%">
        </td> 
        </tr> 
        </table> 
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
