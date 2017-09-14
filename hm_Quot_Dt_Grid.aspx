<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="hm_Quot_Dt_Grid.aspx.cs" Inherits="hm_Quot_Dt_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%">
<tr><td colspan="4" align="left"  >
    <asp:Button ID="btnADD" runat="server" Text="ADD" onclick="btnADD_Click" class="btn btn-primary"/></td>
    <td colspan="4" align="right"><asp:Button ID="btnAdSearch" runat="server" Text="Advance Search" onclick="btnAdSearch_Click" class="btn btn-primary"/></td></tr>
<tr>
<td colspan="8">
<%--<div>
<div style="azimuth:left-side">
<input  id="button1" type="button" value="Close" onclick="Collapse()" />
</div>--%>
    <asp:Panel ID="Panel1" runat="server" Visible="False" BorderColor="Black" BorderWidth="1">
   <%--<div id="DivCollapse">--%>
    <table style="widows:100%">
    <tr>
    <td>
     <th style="width: 20%;">      
                                <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>                             
                                    <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged"
                                        PopupPosition="BottomLeft" TargetControlID="txtFr_Dt" OnClientDateSelectionChanged="CheckDateEalier"
                                        CssClass="ajax__calendar">
                                    </AjaxToolkit:CalendarExtender>
                                </th>
     <th style="width: 10%;">
                                    <div>
                                        <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                                </th>
    </td>  
    <td>  
     <th style="width: 20%;">   
        <asp:Label ID="lblTo_Dt" runat="server" Text="To Date"></asp:Label>                           
        <asp:TextBox ID="txtTo_Dt" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged"
            PopupPosition="BottomLeft" TargetControlID="txtTo_Dt" OnClientDateSelectionChanged="CheckDateEalier"
            CssClass="ajax__calendar">
        </AjaxToolkit:CalendarExtender>
       </th>
     <th style="width: 10%;">
        <div>
            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
        </div>
     </th>
    </td>
    <td>
     <th style="width: 20%;">   
        <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label> 
        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
        </th>
        <th style="width: 20%;">                          
        <asp:Button ID="btnSerch" runat="server" Text="Search" class="btn btn-primary"/>
       </th>
    </td>
    </tr>
    </table>
    </asp:Panel>
  <%-- </div>
   </div> --%>
</td>
</tr>
<tr>
<td colspan="8">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="quat_id" class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" onselectedindexchanged="GridView1_SelectedIndexChanged">
    <Columns>
        <%--<asp:BoundField DataField="" HeaderText="Type" SortExpression="" />   --%>        
        <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />                        
        <asp:BoundField DataField="ptnt_add" HeaderText="Add" SortExpression="ptnt_add" />
        <asp:BoundField DataField="ptnt_mob" HeaderText="Mobile No" SortExpression="ptnt_mob" />
        <asp:BoundField DataField="mach_desc" HeaderText="Machine Company Name" SortExpression="mach_desc" />
        <asp:BoundField DataField="quat_audio_ratio" HeaderText="Audio Ratio" SortExpression="quat_audio_ratio" />                        
        <asp:BoundField DataField="quat_ear_site" HeaderText="Site" SortExpression="quat_ear_site" />     
        <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" /> 
        <asp:BoundField DataField="vat" HeaderText="Vat" SortExpression="vat" />
        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />       
        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />                    
        <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />          
    </Columns>  
    </asp:GridView>
</td> 
</tr> 
</table> 
</asp:Content>

