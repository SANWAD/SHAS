<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="outward.aspx.cs" Inherits="outward" Title="OutWord" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">        
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">OutWord</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">  
            <div class="form-group">
                <asp:HiddenField ID="lblout_no" runat="server" />
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text="Item Name"></asp:Label>
                 <asp:TextBox ID="txt_out_desc" runat="server" class="form-control"></asp:TextBox>
                 </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOut_desc" controltovalidate="txt_out_desc" ErrorMessage="Required OutWord Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="OutWard From"></asp:Label>
                <asp:TextBox ID="txtout_from" runat="server" class="form-control" 
                            AutoCompleteType="Company"></asp:TextBox>
                </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOut_From" controltovalidate="txtout_from" ErrorMessage="Required OutWord From" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>    
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
               <asp:Label ID="Label4" runat="server" Text="OutWard To"></asp:Label>
               <asp:TextBox ID="txtout_to" runat="server" class="form-control" 
                            AutoCompleteType="Company"></asp:TextBox>
               </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOut_To" controltovalidate="txtout_to" ErrorMessage="Required OutWord To" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
              <asp:Label ID="Label5" runat="server" Text="Courier Name / Machine Status"></asp:Label>
              <asp:TextBox ID="txtcour_nm" runat="server" class="form-control"></asp:TextBox>
              </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqCour_Nm" controltovalidate="txtcour_nm" ErrorMessage="Required Courier Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>                
        </div>
        <div class="col-sm-push-0 col-md-5"> 
            <div class="form-group">
            </div> 
            <div class="form-group">
              <asp:Label ID="Label6" runat="server" Text="Charges Paid"></asp:Label>
              <asp:TextBox ID="txtchg_paid" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:Label ID="Label7" runat="server" Text="Courier Receipt No"></asp:Label>
              <asp:TextBox ID="txtrec_no" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div style="height: 5Px;">
            </div>
            <div class="btn-toolbar list-toolbar" >    
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
               <ContentTemplate>
                <fieldset>                     
                 <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  class="btn btn-primary"></asp:Button>                       
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCancel_Click" CausesValidation="false" ></asp:Button>
                </fieldset> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
            </div>
            <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
            </div> 
        </div> 
        </div>
        </div> 
</asp:Content>

