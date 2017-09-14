<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="lettermaster.aspx.cs" Inherits="transaction_lettermaster" Title="Letter Master" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default" >
        <div class="panel-heading" >
            <h class="text-muted text-center">Letter Master</h>
        </div>
        <div class="panel-body">
        <div class="form-group">
            <asp:HiddenField ID="lbllet_id" runat="server" />
        </div>
        <div class="form-group">
        <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                <asp:Label ID="Label2" runat="server" Text="Letter type"></asp:Label>
            <asp:TextBox ID="txtlet_type" runat="server" MaxLength="50" Class="form-control"></asp:TextBox>
            </td> 
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqLet_Type" controltovalidate="txtlet_type" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
            </td> 
            </tr> 
            </table> 
        </div>
        <div class="form-group">
        <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                <asp:Label ID="Label3" runat="server" Text="Letter Content"></asp:Label>
            <asp:TextBox ID="txtletdesc" runat="server" MaxLength="8000" TextMode="MultiLine" class="form-control" />
            </td> 
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqLet_Des" controltovalidate="txtletdesc" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/> 
            </td> 
            </tr> 
            </table> 
        </div>
        <div class="btn-toolbar list-toolbar">
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
            <ContentTemplate>
            <fieldset>             
            <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" class="btn btn-primary"/>
            <asp:Button ID="btnCancel" runat="server"  Text="Cancel" class="btn btn-primary" onclick="btnCancel_Click" onclientclick="return askConfirm()"/>
            </fieldset> 
            </ContentTemplate> 
        </asp:UpdatePanel>        
        </div>
        </div> 
    </div>
</asp:Content>
