<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Summary_Report_Grid.aspx.cs" Inherits="Summary_Report_Grid" Title="Summary Report of Boss" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:updatepanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
   <div class="panel panel-default">
    <div class ="panel-heading" >
    <h class="text-muted text-center" >Summary Report of Boss</h>
    </div>
    <div class="panel-body">

    <div class="form-group">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
         <div class="form-group"> 
          <table style="width:100%">
        <tr>   
         <td style="width:30%">
         <div>
                <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>  
                <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtFr_Dt" CssClass="ajax__calendar">
                </AjaxToolkit:CalendarExtender>
         </div>
         <td style="width:2%">
         <div>
             <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
         </div>
         </td> 
        </td>  
        <td style="width:30%">  
        <div>
            <asp:Label ID="lblTo_Dt" runat="server" Text="To Date"></asp:Label>                           
            <asp:TextBox ID="txtTo_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
            <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtTo_Dt" CssClass="ajax__calendar">
            </AjaxToolkit:CalendarExtender>
        </div>
        </td>
        <td>
            <div style="width:2%">
                <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
            </div>     
        </td>
        <td valign="bottom" > 
        <div></div>                         
           <div> <asp:Button ID="btnSerch" runat="server" Text="Search" 
                   class="btn btn-primary" onclick="btnSerch_Click"/></div>
        </td> 
        </tr> 
        </table> 
         </div> 
        <div class="form-group">    
    <h class="text-muted text-center" >Accessories Sale</h>
        <asp:GridView ID="GridView1" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true" AutoGenerateColumns="True" >            
        </asp:GridView>
        <h class="text-muted text-center" >Hearing Aid Sale</h>
        <asp:GridView ID="GridView2" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>
        
         <h class="text-muted text-center" >Hearing Aid Send for Repair</h>
        <asp:GridView ID="GridView3" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>
         <h class="text-muted text-center" >Petty Cash</h>
        <asp:GridView ID="GridView4" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>     
         <h class="text-muted text-center" >Inward</h>
        <asp:GridView ID="GridView5" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>
        <%--<h class="text-muted text-center">Hearing Aid Inward</h>--%>
        <asp:GridView ID="GridView6" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True"  Visible="false">            
        </asp:GridView>
        <h class="text-muted text-center" >Enquiry</h>
        <asp:GridView ID="GridView7" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>
        <h class="text-muted text-center" >Patient Register</h>
        <asp:GridView ID="GridView8" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%"  PageSize="15" PersistedSelection="true"  AutoGenerateColumns="True" >            
        </asp:GridView>
        </div>
        </asp:Panel>
    </div>
    </div>
</div> 
    </ContentTemplate> 
</asp:updatepanel> 
</asp:Content>

