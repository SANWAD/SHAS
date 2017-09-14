<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="HM_Comp_Add_Grid.aspx.cs" Inherits="HM_Comp_Add_Grid" Title="Hearing Aid Company Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:updatepanel id="UpdatePanel1" runat="server">
   <ContentTemplate>
   <div class="panel panel-default">
    <div class ="panel-heading" >
    <h class="text-muted text-center" >Hearing Aid Company Master</h>
    </div>
    <div class="panel-body">
    <div class="form-group">
    <table style="width:100%">
    <tr>
    <td><asp:Button ID="btnADD" runat="server" Text="NEW" onclick="btnADD_Click" class="btn btn-primary"/></td>
    <td align="right"><asp:Button ID="btnAdSearch" runat="server" Text="Advance Search" onclick="btnAdSearch_Click" class="btn btn-primary"/></td>
    </tr>
    </table> 
    </div> 
    <div class="form-group">
    <asp:Panel ID="Panel1" runat="server" Visible="False"  BorderColor="Black" BorderWidth="0" style="width:100%"> 
        <table style="width:100%">
        <tr><td colspan="8" align="center"><asp:Label ID="lblMsg" runat="server" Text="Date is Optional & Description i.e  HAid Code / HAid Company Name " style="font-family:Times New Roman;" Font-Bold="true" ForeColor="red" ></asp:Label></td></tr>
        <tr>
       <td style="width:30%">    
        <div>
         <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>                               
            <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtFr_Dt"  CssClass="ajax__calendar">
            </AjaxToolkit:CalendarExtender>  
        </div>
        </td>
       <td style="width:2%">
            <div>
               <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />  
            </div>                              
        </td>  
       <td style="width:30%">
        <div>
          <asp:Label ID="lblTo_Dt" runat="server" Text="To Date"></asp:Label>                             
           <asp:TextBox ID="txtTo_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
            <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtTo_Dt"  CssClass="ajax__calendar">
            </AjaxToolkit:CalendarExtender>       
         </div>
        </td>
       <td style="width:2%">    
            <div>
             <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />    
            </div>
        </td>
       <td style="width:30%">
        <div>
          <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>  
        </div>
        <div>    
           <asp:TextBox ID="txtDesc" runat="server" class="form-control"></asp:TextBox> 
       </div>
       </td>   
       <td valign="bottom">
       <div> </div>
       <div>                    
           <asp:Button ID="btnSerch" runat="server" Text="Search" class="btn btn-primary" 
               onclick="btnSerch_Click"/>  
        </div>      
        </td>
        </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="true"  
                CellPadding="3" class="table table-bordered table-striped" style="width:100%" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" 
                onrowdatabound="GridView1_RowDataBound">    
        </asp:GridView>
        </asp:Panel>   
    </div>
    </div>
</div> 
   </ContentTemplate> 
</asp:updatepanel>    
</asp:Content>

