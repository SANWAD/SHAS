<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="DoctorMaster.aspx.cs" Inherits="DoctorMaster" Title="Doctor Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
 <form1>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Doctor Master</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="lbldoc_id" runat="server" />                    
                    <asp:Label ID="Label1" runat="server" Text="Doctor Code"></asp:Label> 
                    <asp:TextBox ID="txtDoc_Code" runat="server" class="form-control"></asp:TextBox>                       
                </div>
                <div class="form-group">                
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Doctor Name"><a href="DoctorMaster.aspx">DoctorMaster.aspx</a></asp:Label> 
                    <asp:TextBox ID="txtdocnm" runat="server" class="form-control" 
                        ontextchanged="txtdocnm_TextChanged" AutoPostBack="true" 
                        AutoCompleteType="FirstName" ></asp:TextBox>
                </td>
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqDnm" ControlToValidate="txtdocnm" runat="server" ErrorMessage="Required Doctor Name" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td> 
                </tr> 
                </table>      
                </div>
                <div>
                <asp:Label ID="lblMsg" runat="server" Text="Doctor Name Already Exists" 
                        ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtdocadd" runat="server" class="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Phone No"></asp:Label>
                    <asp:TextBox ID="txttelno" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                        <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                    <asp:TextBox ID="txtmobno" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);">
                    </asp:TextBox>
                </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="ReqMob" ControlToValidate="txtmobno" runat="server" ErrorMessage="Required Mobile Number" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>                
                </td> 
                </tr> 
                </table>     
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Alternate No"></asp:Label>
                    <asp:TextBox ID="txtalttelno" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="eMail Id"></asp:Label>
                    <asp:TextBox ID="txtemailid" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="btn-toolbar list-toolbar">                
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" onkeydown="ValidateEmail(document.form1.txtemailid)"></asp:Button>                    
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" onclientclick="return askConfirm()" onclick="btnCancel_Click"/>                    
                </div>
                <div class="form-group">
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                </div> 
            </div>
        </div>
    </div>
    </form>
 </ContentTemplate> 
</asp:UpdatePanel>
</asp:Content>
