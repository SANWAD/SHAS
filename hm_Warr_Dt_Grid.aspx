<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Warr_Dt_Grid.aspx.cs" Inherits="hm_Warr_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="mach_id" class="table table-bordered table-striped">                    
                    <Columns>
                    <asp:BoundField DataField="hm_sale_dt" HeaderText="Warranty Card Date" SortExpression="hm_sale_dt" />                        
                    <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />
                    <asp:BoundField DataField="ptnt_mob" HeaderText="Mobile No" InsertVisible="False" ReadOnly="True" SortExpression="ptnt_mob" />
                    <asp:BoundField DataField="ptnt_cont_no" HeaderText="Contact No" SortExpression="ptnt_cont_no" />                        
                    <asp:BoundField DataField="ptnt_add" HeaderText="Address" SortExpression="ptnt_add" />                        
                    <asp:BoundField DataField="warr_Period" HeaderText="Warranty Date" SortExpression="warr_Period" />                       
                    </Columns>                  
                </asp:GridView>
</asp:Content>

