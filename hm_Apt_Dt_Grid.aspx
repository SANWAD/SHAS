<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Apt_Dt_Grid.aspx.cs" Inherits="hm_Apt_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="table-bordered">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="apt_id" class="table table-bordered table-striped">                    
                    <Columns>
                        <asp:CommandField HeaderText="Select" ShowHeader="True" 
                            ShowSelectButton="True" />
                    <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />
                    <asp:BoundField DataField="ptnt_mob" HeaderText="Mobile No" SortExpression="ptnt_mob" />                    
                    <asp:BoundField DataField="apt_date" HeaderText="Appointment Date" SortExpression="apt_date" />    
                    <asp:BoundField DataField="apt_time" HeaderText="Time" SortExpression="apt_time" />                                      
                    <asp:BoundField DataField="Ptntype" HeaderText="Patient Type" SortExpression="Ptntype" />
                    <asp:BoundField DataField="ISAptCancel" HeaderText="Status" SortExpression="ISAptCancel" />                    
                    </Columns>
                </asp:GridView>
 </div> 
</asp:Content>

