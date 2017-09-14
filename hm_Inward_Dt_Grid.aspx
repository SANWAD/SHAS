<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Inward_Dt_Grid.aspx.cs" Inherits="hm_Inward_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" DataKeyNames="inw_no" 
        class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>        
        <asp:BoundField DataField="inw_to" HeaderText="Inward To" SortExpression="inw_to" />                        
        <asp:BoundField DataField="inw_from" HeaderText="Inward From" SortExpression="inw_from" />
        <asp:BoundField DataField="created_dt" HeaderText="Date" SortExpression="created_dt" />
        <asp:BoundField DataField="created_by" HeaderText="Created By" SortExpression="created_by" /> 
        <%--<asp:CommandField AccessibleHeaderText="Edit" ShowEditButton="True" HeaderText="Edit"/>--%>
        <asp:CommandField AccessibleHeaderText="View" ShowSelectButton="True" HeaderText="View" />        
    </Columns>  
    </asp:GridView>
</asp:Content>

