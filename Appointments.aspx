<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Appointments.aspx.cs" Inherits="Appointment" Title="Appointment's" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
     function askConfirm() {
         var DropdownList1 = document.getElementById('<%=ddltype.ClientID %>');
         var DropdownList2 = document.getElementById('<%=ddlapt_type.ClientID %>'); 
         var DropdownList = document.getElementById('<%=ddl_apt_time.ClientID %>');        
         var SelectedIndex = DropdownList.selectedIndex;
         var SelectedValue = DropdownList.value;
         var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;
         if (SelectedText == "Select")
             alert("Please Select Appointment Time")
         return true;
     }
     function checkPrintReq() {
         var confirm_value = document.createElement("INPUT");
         confirm_value.type = "hidden";
         confirm_value.name = "confirm_value";

         if (confirm("Go To Bill?")) {
             confirm_value.value = "Yes";
         }
         else {
             confirm_value.value = "No";
         }
         document.forms[0].appendChild(confirm_value);
     }
    
    </script>
<%--<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
       <ContentTemplate>--%>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Appointment's</h>
        </div>        
       
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="lblaptid" runat="server" />
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%"> 
                    <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
                   <asp:Label ID="Label5" runat="server" Text="Patient For"></asp:Label>
                    <asp:DropDownList ID="ddltype" runat="server" class="form-control">
                    </asp:DropDownList>  
                </td> 
                <td style="width:1%"> 
                <asp:RequiredFieldValidator runat="server" id="reqPtnt_For" controltovalidate="ddltype" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>  
                </table>                    
                </div>
                <div class="form-group">
                 <table style="width:100%">
                <tr>
                <td style="width:99%">
                     <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Appointment Type"></asp:Label>
                     <asp:DropDownList  ID="ddlapt_type" runat="server" class="form-control">
                            </asp:DropDownList>
                </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator runat="server" id="reqApt_Type" controltovalidate="ddlapt_type" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td> 
                </tr> 
                </table> 
                </div>
                <%--<div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Select Doctor"></asp:Label>
                     <asp:DropDownList  ID="ddlDoctor" runat="server" class="form-control"></asp:DropDownList>
                </div>  --%>  
                <div class="form-group">
                <asp:HiddenField ID="lblptnttype" runat="server" />
                </div>
                <div class="form-group">
                 <table style="width:100%">
                <tr>
                <td style="width:99%">                
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label14" runat="server" Text="Patient Name"></asp:Label>
                <asp:TextBox ID="ddl_ptnt_nm" runat="server" class="form-control" ></asp:TextBox>
                <div id="divwidth" style="display:list-item">
                </div>
                <AjaxToolkit:AutoCompleteExtender ID="AutoPtntNm" runat="server" TargetControlID="ddl_ptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                </AjaxToolkit:AutoCompleteExtender> 
                 </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator runat="server" id="reqPtnt_nm" controltovalidate="ddl_ptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td> 
                </tr> 
                </table>  
                </div>
                <div class="form-group">
                <asp:HiddenField ID="lblptnt_id" runat="server" />
                </div>               
                <div class="form-group">
                    <table style="width: 100%;">                       
                            <tr>
                                <td style="width: 98%;">
                                    <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text="Appointment Date"></asp:Label>
                                    <asp:TextBox ID="txtdate" runat="server" class="form-control"></asp:TextBox>
                                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" CssClass="ajax__calendar" OnClientDateSelectionChanged="CheckDateEalier" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" Enabled="true"  Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                    </AjaxToolkit:CalendarExtender>
                                </td>
                                <td style="width: 2%;">
                                    <div>
                                        <asp:Image ID="Image" runat="server" ImageUrl="~/images/calendar.png" />
                                       <asp:RequiredFieldValidator runat="server" id="reqDt" controltovalidate="txtdate" ErrorMessage="Required Appointment Date" Text="*"  EnableClientScript="true"/>
                                    </div>
                                </td>
                            </tr>
                    </table>
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="Time"></asp:Label>
                    <asp:DropDownList ID="ddl_apt_time" runat="server" class="form-control"></asp:DropDownList>
                </td>
                 <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqTime" controltovalidate="ddl_apt_time" ErrorMessage="Required Appointment Time" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                 </td>
                 </tr> 
                 </table> 
                </div>
                <div class="form-group">
                 <asp:Label ID="Label2" runat="server" Text="Cancel Appointment" Enabled="False"></asp:Label>
                    <asp:CheckBox ID="chkcan" runat="server" class="form-control" Enabled="False"/>
                </div> 
                <div class="btn-toolbar list-toolbar">
                 <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" class="btn btn-primary" onclientclick="return askConfirm()"></asp:Button>
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>
                 <asp:Button ID="btnBill" runat="server" Text="Go For BillPrint" class="btn btn-primary" onclick="btnBill_Click"></asp:Button>                 
                </div> 
                <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                </div>        
            </div>            
        </div>        
    </div>
   <%-- </ContentTemplate> 
      </asp:UpdatePanel> --%>
</asp:Content>
