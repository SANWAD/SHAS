<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Main Grid_Page_Grid.aspx.cs" Inherits="Main_Grid" Title="Main Grid Page" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<asp:updatepanel id="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <div class="panel panel-default">
   <div class="panel-body">
<asp:Panel ID="Panel1" runat="server"  ScrollBars="Auto">
<table style="width:100%">
<tr><td colspan="4" align="left"  >    
    <asp:Button ID="btnExcel" runat="server" onclick="btnExcel_Click" Text="Export To Excel" class="btn btn-primary"/>
    <asp:Button ID="btnPdf" runat="server"  Text="Export To PDF" onclick="btnPdf_Click" class="btn btn-primary"/>
   <%-- <asp:DropDownList ID="DropDownList1" runat="server" Width="150px"  AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Excel"></asp:ListItem>
    <asp:ListItem Text="Pdf" ></asp:ListItem>
    <asp:ListItem Text="Word"></asp:ListItem>
    </asp:DropDownList>--%>
    </td>
    <%--<td colspan="4" align="right"><asp:Button ID="btnAdSearch" runat="server" Text="Advance Search" onclick="btnAdSearch_Click" class="btn btn-primary"/></td>--%>
    </tr>
    <tr><td colspan="4" align="Center">
        <asp:Label ID="lblHead" runat="server" Text="" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>
        </td></tr>
<tr>
<td colspan="6">    
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="true" CellPadding="3" class="table table-bordered table-striped" onrowdatabound="GridView1_RowDataBound" onselectedindexchanged="GridView1_SelectedIndexChanged">    
     </asp:GridView>  
    <asp:Label ID="lblPittyCash" visible="False" runat="server"></asp:Label>
    <asp:TextBox ID="txtTotal" runat="server" Visible="false"></asp:TextBox>    
</td> 
</tr> 
</table>
</asp:Panel> 
</div>     
</div>  
    <%--</ContentTemplate> 
</asp:updatepanel> --%>    
</asp:Content>

