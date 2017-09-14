<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="BackUpDevice.aspx.cs" Inherits="BackUpDevice" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
    <div class="panel panel-default">
    <div class="panel-heading">
            <h class="text-muted text-center">Back Up Device</h>
        </div>
    <div class="panel-body">
    <div class="col-sm-push-0 col-md-5"> 
    <div class="form-group">
    <asp:Label ID="lblPath" runat="server" Text="Database Path" ></asp:Label>
        <asp:TextBox ID="txtPath" runat="server" class="form-control"  
            Text="D:\Delly BackUp\" ></asp:TextBox>
    </div> 
    <div class="form-group">
    <asp:Label ID="lblDbNm" runat="server" Text="Database Name"></asp:Label>
        <asp:TextBox ID="txtDbNm" runat="server" class="form-control" Text="Organiser-Full Database Backup"></asp:TextBox>
    </div> 
    <div class="form-group">
     <asp:Label ID="lblError" runat="server"></asp:Label>
    </div> 
     <div class="btn-toolbar list-toolbar">                   
    <asp:Button ID="btnBackUp" runat="server" Text="BackUp" class="btn btn-primary" onclick="btnBackUp_Click"/>
    <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" onclick="btnCan_Click" />        
    </div>
    </div> 
    </div> 
    </div> 
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

