<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Trial_Dt_Grid.aspx.cs" Inherits="hm_Trial_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" DataKeyNames="h_t_id" 
        class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />
        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
        <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />                        
        <asp:BoundField DataField="mach_desc" HeaderText="Machine Company Name" SortExpression="mach_desc" />
        <asp:BoundField DataField="h_h_m_price" HeaderText="Price" SortExpression="h_h_m_price" />
        <asp:BoundField DataField="acc_given" HeaderText="Accessosies" SortExpression="acc_given" />
        <asp:BoundField DataField="type_of_pay" HeaderText="Pay Type" SortExpression="type_of_pay" />
        <asp:BoundField DataField="Rtn_dt" HeaderText="Machine Rtn Date" SortExpression="Rtn_dt" />
    </Columns>  
    </asp:GridView>
</asp:Content>

