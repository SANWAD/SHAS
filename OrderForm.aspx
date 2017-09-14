<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="OrderForm.aspx.cs" Inherits="outward" Title="Order By Mail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">        
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Order Form</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">  
            <div class="form-group">
                <asp:HiddenField ID="lblOrd_no" runat="server" />
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text="Name of Hearing Aid / Accessories"></asp:Label>
                 <asp:TextBox ID="txtOrder_desc" runat="server" class="form-control" Height="125px" TextMode="MultiLine"></asp:TextBox>
                 </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOrder_desc" controltovalidate="txtOrder_desc" ErrorMessage="Required OutWord Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Order From"></asp:Label>
                <asp:TextBox ID="txtOrder_from" runat="server" class="form-control"></asp:TextBox>
                </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOrder_From" controltovalidate="txtOrder_from" ErrorMessage="Required OutWord From" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>    
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
               <asp:Label ID="Label4" runat="server" Text="Order To"></asp:Label>
              <asp:DropDownList id="ddl_comp" runat="server" class="form-control"></asp:DropDownList>  
               </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqOrder_To" controltovalidate="ddl_comp" ErrorMessage="Required Order To" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
                            
                    
           
            <div class="btn-toolbar list-toolbar" >    
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
               <ContentTemplate>
                <fieldset>                     
                 <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>  
                 <asp:Button ID="btnExport" runat="server" Text="Export To Pdf" 
                        class="btn btn-primary" onclick="btnExport_Click" Visible="false" ></asp:Button>                     
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

