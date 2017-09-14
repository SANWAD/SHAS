<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="HAStockTransfer.aspx.cs" Inherits="HAStockTransfer" Title="Hearing Aid Stock Transfer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
   function askConfirm() {
       var DropdownList = document.getElementById('<%=ddl_comp.ClientID %>');
        var SelectedIndex = DropdownList.selectedIndex;
        var SelectedValue = DropdownList.value;
        var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;        
        if (SelectedText == "Select")
        alert("Please Select Accessories")
        return true;
    }
    function fill() {
        var txt8 = document.getElementById('<%=txtmachprice.ClientID %>').value;
        var txt9 = document.getElementById('<%=txtQty.ClientID %>').value;
        var Result=parseInt(txt8) * parseInt(txt9);
        if (!isNaN(Result)) {
            document.getElementById('<%=txtrecamt.ClientID %>').value = Result;
        }
    }
//    function checkPrintReq() {
//        var confirm_value = document.createElement("INPUT");
//        confirm_value.type = "hidden";
//        confirm_value.name = "confirm_value";
//        if (confirm("Print Is Required?")) {
//            confirm_value.value = "Yes";
//        }
//        else {
//            confirm_value.value = "No";
//        }
//        document.forms[0].appendChild(confirm_value);
//     }
    </script>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
   <ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Stock Transfer</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group"> 
                     <asp:HiddenField ID="lbl_ac_id" runat="server" />      
                </div>
                <div class="form-group" >
        <asp:Label ID="Label18" runat="server" Text="Name Of Hearing Aid"></asp:Label> 
        <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
        <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>
        <asp:HiddenField ID="lbl_mach_id_rt" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" class="form-control"></asp:Label>
        <%--<asp:Label ID="lblSale_price" runat="server" Text="0" class="form-control"></asp:Label>--%>
        <asp:HiddenField ID="lblSale_price" runat="server" />       
        </div>        
                <div class="form-group">
                <asp:Label ID="Label12" runat="server">Price</asp:Label>                
                <asp:Textbox ID="txtmachprice" runat="server" class="form-control" 
                        onkeydown="return isNumeric(event.keyCode);"></asp:Textbox> 
                </div> 
                <div class="form-group">     
                <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblDoc_Date" runat="server" Text="Transfer Date"></asp:Label>
              <asp:TextBox ID="txtDoc_Date" runat="server" class="form-control" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft"  OnClientDateSelectionChanged="checkDate" TargetControlID="txtDoc_Date" Format="dd/MM/yyyy" CssClass="ajax__calendar">
               </AjaxToolkit:CalendarExtender>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="calImage" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>         
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">  
                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>     
                 <asp:Label ID="Label2" runat="server" Text="Hearing Aid Transfer To Center"></asp:Label>
                <asp:DropDownList ID ="ddlCent_Nm" runat ="server" class="form-control"></asp:DropDownList>
                 </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqCenter" controltovalidate="ddlCent_Nm" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>
                </table> 
                </div>
                 <div class="form-group">
                  <table style="width:100%">
                <tr>
                <td style="width:99%">  
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>     
                <asp:Label ID="Label4" runat="server" Text="Hearing Aid Transfer Quantity"></asp:Label>
                <asp:TextBox ID="txtQty" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="return askConfirm(),fill()" AutoPostBack="true" ontextchanged="txtQty_TextChanged"></asp:TextBox>
                 </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtQty" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>
                </table>
                <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
                     <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Typed Quantity is Greater than Stock Quantity" Visible="False"></asp:Label>
                </div>
                <div class="form-group">
                <asp:Label ID="Label5" runat="server" >Total</asp:Label>
                <asp:Textbox ID="txtrecamt" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:Textbox> 
                </div> 
                <div class="btn-toolbar list-toolbar">               
                <asp:Button ID="btn_save" runat="server" Text="Save" class="btn btn-primary" onclick="btn_save_Click" Enabled="False" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" onclientclick="return askConfirm()"  CausesValidation="false" onclick="btnCancel_Click"/>                   
                </div>
                <div class="form-group"> 
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                </div> 
            </div>
        </div>
    </div>     
    </ContentTemplate> 
</asp:UpdatePanel>

</asp:Content>

