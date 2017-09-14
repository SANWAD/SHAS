<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Enquiry" Title="Patient Enquiry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
         function askConfirm() {

             var DropdownList = document.getElementById('<%=ddlpatien_for.ClientID %>');            
        var SelectedIndex = DropdownList.selectedIndex;
        var SelectedValue = DropdownList.value;
        var SelectedText = DropdownList.options[DropdownList.selectedIndex].text;        
        if (SelectedText == "Select")
            alert("Please Select Patient Type")
        return true;
        }
    </script>
<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
 <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Patient Enquiry</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
                    <div class="form-group">
                     <asp:HiddenField ID="lbleid" runat="server" />
                    </div>
                    <div class="form-group">
                    <asp:Label ID="lblEnqFor" runat="server" Text="Patient For"></asp:Label>
                     <asp:DropDownList runat="server" ID="ddlpatien_for"  class="form-control">
                     </asp:DropDownList>
                    </div>                    
                    <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblEnqNm" runat="server" Text="Patient Name"></asp:Label>
                     <asp:TextBox ID ="txtptnt_nm" runat="server" class="form-control"></asp:TextBox>
                     <asp:HiddenField ID="lblptnt_id" runat="server" />
                     <div id="divwidth" style="display:list-item">
                    </div>
                    <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                    </AjaxToolkit:AutoCompleteExtender> 
                     </td> 
                     <td style="width: 1%;">
                     <asp:RequiredFieldValidator runat="server" id="reqPNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true" EnableClientScript="true"/>
                     </td>
                     </tr> 
                     </table> 
                    </div>
                    <div class="form-group">                    
                    <asp:Label ID="lblEnqAge" runat="server" Text="Age"></asp:Label>
                     <asp:TextBox ID ="txtAge" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onchange="return askConfirm()"></asp:TextBox>
                    </div> 
                      <div class="form-group">
                     <table style="width:100%">
                               <tr>
                                    <td style="width:98%">
                                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        <asp:Label ID="lblEnqDt" runat="server" Text="Enquiry Date"></asp:Label>
                                        <asp:TextBox ID="txtDate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                        <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtDate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtDate" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                                        </AjaxToolkit:CalendarExtender>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Can't Select Date which is greater than Todays Date"></asp:RangeValidator> 
                                    </td>
                                    <td style="width:2%"> 
                                    <div>                          
                                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                                            <asp:RequiredFieldValidator runat="server" id="reqEnq_dt" controltovalidate="txtDate" ErrorMessage="Required Enquiry Date" Text="*"  SetFocusOnError="true"/>
                                    </div>
                                    </td>
                                </tr>                            
                        </table>
                    </div>
              </div> 
        <div class="col-sm-push-0 col-md-5">
                      <div class="form-group">
                      </div> 
                    <div class="form-group">
                    <asp:Label ID="lblEnqBY" runat="server" Text="Enquiry By"></asp:Label>
                     <asp:TextBox ID ="txtEnquiry_by" runat="server" class="form-control"></asp:TextBox>                     
                    </div>
                    <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile No"></asp:Label>
                     <asp:TextBox ID ="txtMob" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onchange="return askConfirm()"></asp:TextBox>
                     </td> 
                     <td style="width: 1%;">
                     <asp:RequiredFieldValidator runat="server" id="reqMob_No" controltovalidate="txtMob" ErrorMessage="Required Mobile No" Text="*"  SetFocusOnError="true" EnableClientScript="true"/>
                     </td>
                     </tr> 
                     </table> 
                    </div>
                    <div class="form-group">
                    <asp:Label ID="lblBrif" runat="server" Text="Brif Description"></asp:Label> 
                    <asp:TextBox runat="server" ID="txtBrif" TextMode="MultiLine" class="form-control"></asp:TextBox>
                    </div>
                     <div class="form-group">
                            <asp:Label ID="lblEnqCom" runat="server" Text="Enquiry Complete"></asp:Label>                                      
                            <asp:CheckBox ID="chkenq" runat="server"  />                                        
                    </div>
                     <div class="btn-toolbar list-toolbar">
                     <asp:Button runat="server" ID="btnSave" Text="SAVE" OnClick="btnSave_Click" class="btn btn-primary"/>
                        <asp:Button runat="server" ID="btnCancle" Text="Cancel" OnClick="btnCancle_Click" class="btn btn-primary" CausesValidation="false"/>                        
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



