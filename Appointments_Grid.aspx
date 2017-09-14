<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Appointments_Grid.aspx.cs" Inherits="Appointments_Grid" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
    function Collapse() {
        var btnAdSearch = document.getElementById('<%=btnAdSearch.ClientID %>').value;
        var Panel = document.getElementById('<%=Panel2.ClientID %>').value;
        if (btnAdSearch.Text == "Advance Search") {
            //panNonAfricaDropDown.style.visibility = "visible";
            Panel.style.visibility = "visible";
            //Panel.Visible = true;                        
            lblFr_dt.Visible = true;
            lblTo_Dt.Visible = true;
            btnAdSearch.Text = "Close";
        }
        else {
            Panel2.Visible = false;
            btnAdSearch.Text = "Advance Search";
        }
    }
</script>
 <script language="javascript" type="text/javascript">
     function toggle() {
         var ctrlID = document.getElementById('<%=Panel2.ClientID %>');
         if (ctrlID.style.visibility = "visible") {
             ctrlID.style.display = 'block';
            
         }
         else {
             ctrlID.style.display = 'none';
             
         }
     }
    </script>
  <asp:updatepanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
       <div class="panel panel-default">       
         <div class ="panel-heading" >
           <h class="text-muted text-center" >Appointment's</h>
</div>
<div class="panel-body">
<table style="width:100%"><tr><td style="width:50%"><asp:Button ID="btnPtn_New" 
        runat="server" Text="A New Patient Registration & Edit" class="btn btn-primary" 
        onclick="btnPtn_New_Click"/></td><td style="width:50%; text-align:right">
        <asp:Button ID="btnApt_Tel" runat="server" Text="Appointment (Telephonic - Regular)" 
            class="btn btn-primary" onclick="btnApt_Tel_Click"/></td> </tr> </table> 
<div class="form-group">
<table style="width:100%"><tr><td><asp:Button ID="btnADD" runat="server" Text="Appointment For Already Registered Patient" onclick="btnADD_Click" class="btn btn-primary"/></td><td align="right">
    <asp:Button ID="btnAptCan" runat="server" Text="Appointment Cancel" 
        class="btn btn-primary" onclick="btnAptCan_Click"/>&nbsp&nbsp<asp:Button ID="btnAdSearch" runat="server" Text="Advance Search" onclick="btnAdSearch_Click" class="btn btn-primary"/></td></tr></table> 
 </div> 
<div class="form-group">
<asp:Panel ID="Panel2" runat="server" Visible="False"  BorderColor="Black" BorderWidth="0" style="width:100%"> 
    <table style="width:100%">
    <tr>
   <td style="width:30%">    
    <div>
        <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>                             
            <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtFr_Dt" CssClass="ajax__calendar" Format="dd/MM/yyyy">
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
        <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtTo_Dt" CssClass="ajax__calendar" Format="dd/MM/yyyy">
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
       <asp:Label ID="lblDesc" runat="server" Text="Description" ></asp:Label>  
    </div>
    <div>    
      <asp:TextBox ID="txtDesc" runat="server" class="form-control"></asp:TextBox>   
   </div>
   </td>   
   <td valign="bottom">
   <div> </div>
   <div>                    
        <asp:Button ID="btnSerch" runat="server" Text="Search" class="btn btn-primary" onclick="btnSerch_Click"/> 
    </div>      
    </td>
    </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
    <asp:GridView ID="GridView1" runat="server"  CellPadding="3" class="table table-bordered table-striped"  style="width:100%" AutoGenerateSelectButton="True" onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="15" PersistedSelection="true" onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="True" >            
    </asp:GridView>
    </asp:Panel>
</div>
</div>
</div> 
    </ContentTemplate> 
  </asp:updatepanel>   
</asp:Content>

