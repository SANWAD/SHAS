<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_rep_Dt_Grid.aspx.cs" Inherits="hm_rep_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="hr_job_id" class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />
        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
        <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />                        
        <asp:BoundField DataField="mach_desc" HeaderText="Machine Company Name" SortExpression="mach_desc" />
        <asp:BoundField DataField="hr_rep_to" HeaderText="Repair To" SortExpression="hr_rep_to" />
        <asp:BoundField DataField="hr_visual_rpt" HeaderText="Visual Report" SortExpression="hr_visual_rpt" />
        <asp:BoundField DataField="hr_exp_chg" HeaderText="Charge" SortExpression="hr_exp_chg" />
        <asp:BoundField DataField="hr_amt_paid" HeaderText="Paid" SortExpression="hr_amt_paid" />
        <asp:BoundField DataField="hr_exp_date" HeaderText="Machine Rtn Date" SortExpression="hr_exp_date" />
    </Columns>  
    </asp:GridView>
</asp:Content>

