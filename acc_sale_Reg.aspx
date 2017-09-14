<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="acc_sale_Reg.aspx.cs" Inherits="acc_sale_Reg" Title="Accessories Sale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 

    <script type="text/javascript">
   function askConfirm() {
        var DropdownList = document.getElementById('<%=ddlacc_desc.ClientID %>');
        var PtntName = document.getElementById('<%=txtptnt_nm.ClientID %>');
        var SelectedIndex = DropdownList.selectedIndex;
        var SelectedValue = DropdownList.value;
        var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;        
        if (SelectedText == "Select")
        alert("Please Select Accessories")
        return true;
    }
    function fill() {
        var txt8 = document.getElementById('<%=txtPrice.ClientID %>').value;
        var txt9 = document.getElementById('<%=txtqty.ClientID %>').value;
        var Result=parseInt(txt8) * parseInt(txt9);
        if (!isNaN(Result)) {
            document.getElementById('<%=txtrecamt.ClientID %>').value = Result;
        }
    }
    function checkPrintReq() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Print Is Required?")) {
            confirm_value.value = "Yes";
        }
        else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }
    </script>    
 
<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
  <ContentTemplate>      
    <div class="panel panel-default" >    
        <div class="panel-heading">
            <h class="text-muted text-center" ><asp:Label runat="server" ID ="lblHeading"></asp:Label>  </h>
        </div>        
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">              
           <div class="form-group">
           <asp:HiddenField ID="lblsale_id" runat="server"/> 
           </div>
           <div class="form-group">
           <asp:HiddenField ID="lblptnt_id" runat="server"/>                 
           </div>
           <div class="form-group">
               <asp:Label ID="lblRchk" runat="server"  Visible="false">Register or Unregister</asp:Label>
               <asp:RadioButtonList ID="optRchk" runat="server" AutoPostBack="False" RepeatDirection="Horizontal" style="width:100%" Visible="false">
                    <asp:ListItem Selected="True">Register</asp:ListItem>
                    <asp:ListItem>UnRegister</asp:ListItem>
               </asp:RadioButtonList>
           </div>
           <div class="form-group">
           <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label3" runat="server" ></asp:Label>                               
                <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" ></asp:TextBox> 
                
                 <div id="divwidth" style="display:list-item">
                 </div>
                 <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath ="~/WebService.asmx" MinimumPrefixLength ="1" EnableCaching="true" CompletionInterval="1000"  CompletionListElementID="divwidth" UseContextKey="true">
                 </AjaxToolkit:AutoCompleteExtender>
                </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqPtnt_nm" ControlToValidate="txtptnt_nm" runat="server" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
           </table>                
          </div> 
          <div class="form-group">    
          <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblDoc_Date" runat="server"></asp:Label>
              <asp:TextBox ID="txtDoc_Date" runat="server" class="form-control" ></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft"  OnClientDateSelectionChanged="checkDate" TargetControlID="txtDoc_Date" Format="dd/MM/yyyy" CssClass="ajax__calendar" TodaysDateFormat="dd/MM/yyyy">
               </AjaxToolkit:CalendarExtender>
               <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDoc_Date" ErrorMessage="Can't Select Date which is greater than Todays Date">
               </asp:RangeValidator>--%>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="calImage" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>  
          </tr>  
          </table>
          </div> 
       <div class="form-group">
           <table style="width:100%">
                <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label4" runat="server">Accessory Desc</asp:Label>
                    <asp:DropDownList ID="ddlacc_desc" runat="server" AutoPostBack="true" class="form-control" onselectedindexchanged="ddlacc_desc_SelectedIndexChanged"></asp:DropDownList>
                    </td> 
                    <td style="width:1%">
                    <asp:RequiredFieldValidator ID="reqAcc" ControlToValidate="ddlacc_desc" runat="server" ErrorMessage="Required Select Accessory " Text="*" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr> 
           </table> 
       </div>                    
           <div class="form-group">
                <asp:Label ID="Label12" runat="server"></asp:Label>                
                <asp:Textbox ID="txtPrice" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:Textbox> 
                </div> 
    </div>    
    <div class="col-sm-push-0 col-md-5">
             <div class="form-group">
             </div>     
              <div class="form-group">
              <table style="width:100%">
                <tr>
                <td style="width:99%">
                  <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
               <asp:Label ID="Label14" runat="server"></asp:Label>
                <asp:Textbox ID="txtqty" runat="server" class="form-control" 
                        onkeydown="return isNumeric(event.keyCode);" 
                        onkeyup="return askConfirm(),fill()" ontextchanged="txtqty_TextChanged" AutoPostBack="true"></asp:Textbox>
                </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqQty" ControlToValidate="txtqty" runat="server" ErrorMessage="Required Quantity" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td> 
                </tr> 
                </table> 
                <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                <asp:Label ID="Label5" runat="server" >Total</asp:Label>
                <asp:Textbox ID="txtrecamt" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:Textbox> 
                </div>    
                <div class="btn-toolbar list-toolbar">
                   <asp:Button  ID="btnsave" runat="server" OnClick="btnsave_Click" 
                        class="btn btn-primary" Text="Save" Enabled="False"></asp:Button>
                     <%--   OnClientClick="checkPrintReq()" --%>
                        
                   <asp:Button  ID="btnCancel" runat="server" data-dismiss="modal" class="btn btn-primary" Text="Cancel" onclick="btnCancel_Click" CausesValidation="false" ></asp:Button>
                   <asp:Button  ID="btnPrint" runat="server"  class="btn btn-primary" Text="Print" onclick="btnPrint_Click"></asp:Button>
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

