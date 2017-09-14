<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="inward.aspx.cs" Inherits="inward" Title="Hearing Aid Inword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="panel panel-default">
<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Inword</h>
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
            <asp:Label ID="Label3" runat="server" Text="Inward Name(Documents)"></asp:Label>                    
             <asp:TextBox ID="txtinwto" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
              </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqInwTo" controltovalidate="txtinwto" ErrorMessage="Required Inword Name" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table> 
            </div>                   
             <div class="form-group">
             <table style="width:100%">
            <tr>
            <td style="width:99%"> 
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text="Inward From"></asp:Label>
              <asp:TextBox ID="txtinwfrom" runat="server" class="form-control" 
                    AutoCompleteType="Company"></asp:TextBox>
                </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqFrom" controltovalidate="txtinwfrom" ErrorMessage="Required Inward From" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table>                    
            </div>                   
            <div class="btn-toolbar list-toolbar">
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" class="btn btn-primary" Text ="Save"/>
                <asp:Button ID="btnCanel" runat="server" class="btn btn-primary" Text="Cancel" onclick="btnCanel_Click" CausesValidation="false" />
            </div>
            <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
            </div> 
       </div>
        </div> 
        </ContentTemplate> 
</asp:UpdatePanel>
        </div>
</asp:Content>

