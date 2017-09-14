<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Ear_Mould_Dt_Grid.aspx.cs" Inherits="hm_Ear_Mould_Dt_Grid" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" DataKeyNames="mould_id" 
        class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />                        
        <asp:BoundField DataField="ptnt_add" HeaderText="Address" SortExpression="ptnt_add" />
        <asp:BoundField DataField="em_ear_site" HeaderText="Ear Site" SortExpression="em_ear_site" />
        <asp:BoundField DataField="ptnt_mob" HeaderText="Mob" SortExpression="ptnt_mob" /> 
        <asp:BoundField DataField="comment" HeaderText="Comment" SortExpression="comment" />
        <asp:BoundField DataField="em_price" HeaderText="Charge" SortExpression="em_price" />     
        <asp:BoundField DataField="em_rec_amt" HeaderText="Paid" SortExpression="em_rec_amt" /> 
        <asp:BoundField DataField="em_due_amt" HeaderText="Due Amt" SortExpression="em_due_amt" />
        <asp:BoundField DataField="em_return_dt" HeaderText="Mould Rtn Date" SortExpression="em_return_dt" /> 
        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
        <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />                
    </Columns>  
    </asp:GridView>
</asp:Content>

