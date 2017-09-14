<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Acc_Dt_Grid.aspx.cs" Inherits="Acc_Dt_Grid" Title="Untitled Page" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%">
<tr><td colspan="4" align="left"  >
    <asp:Button ID="btnADD" runat="server" Text="ADD" onclick="btnADD_Click"/>
    <asp:Button ID="btnExcel" runat="server" onclick="btnExcel_Click" 
        Text="Export To" />
    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px"  AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Excel"></asp:ListItem>
    <asp:ListItem Text="Pdf" ></asp:ListItem>
    <asp:ListItem Text="Word"></asp:ListItem>
    </asp:DropDownList>
    </td>
    <td colspan="4" align="right"><asp:Button ID="btnAdSearch" runat="server" Text="Advance Search" onclick="btnAdSearch_Click"/></td></tr>
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
     <td style="width: 20%;">      
                                <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>                             
                                    <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged"
                                        PopupPosition="BottomLeft" TargetControlID="txtFr_Dt" OnClientDateSelectionChanged="CheckDateEalier"
                                        CssClass="ajax__calendar">
                                    </AjaxToolkit:CalendarExtender>
                                </td>
     <td style="width: 10%;">
                                    <div>
                                        <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                                </td>
      
      
     <td style="width: 20%;">   
        <asp:Label ID="lblTo_Dt" runat="server" Text="To Date"></asp:Label>                           
        <asp:TextBox ID="txtTo_Dt" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
        <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged"
            PopupPosition="BottomLeft" TargetControlID="txtTo_Dt" OnClientDateSelectionChanged="CheckDateEalier"
            CssClass="ajax__calendar">
        </AjaxToolkit:CalendarExtender>
       </td>
     <td style="width: 10%;">
        <div>
            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
        </div>
     </td>  
    
    <table style="widows:100%">
    <tr>
    <td>  
    <div>    
        <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label> 
   </div>
   <div> 
        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
  </div>
  </td>
  <td>
        <div>                          
        <asp:Button ID="btnSerch" runat="server" Text="Serch" />
        </div>
       </td>   
    </tr>
    </table>
    </asp:Panel>  
</td>
</tr>
<tr>
<td colspan="8">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" DataKeyNames="acc_sale_id" 
        class="table table-bordered table-striped" onrowediting="GridView1_RowEditing" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
     <Columns>
       <%--  <asp:CommandField HeaderText="View" ShowHeader="True" ShowSelectButton="True" />
         <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />--%>
        <asp:BoundField DataField="ptnt_nm" HeaderText="Patient Name" SortExpression="ptnt_nm" />                        
        <asp:BoundField DataField="created_dt" HeaderText="Sale Date" SortExpression="created_dt" />
        <asp:BoundField DataField="acc_qty" HeaderText="Quantity" SortExpression="acc_qty" />
        <asp:BoundField DataField="acc_price" HeaderText="Price" SortExpression="acc_price" /> 
        <asp:BoundField DataField="tot_amt" HeaderText="Total" SortExpression="tot_amt" />                 
    </Columns> 
    </asp:GridView>
</td> 
</tr> 
</table>     
</asp:Content>

