<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_Home_trial.aspx.cs" Inherits="h_Home_trial" Title="Hearing Aid Home Trial" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 

    <script type="text/javascript" >
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
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Home Trial</h>
        </div>        
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
                    <div class="form-group">
                        <asp:HiddenField ID="lbtrial_id" runat="server" />
                    </div>
                    <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Patient Name"></asp:Label> 
                     <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control"></asp:TextBox> 
                     <div id="divwidth" style="display: none">
                    </div>
                    <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="1000" CompletionSetCount="1" CompletionListElementID="divwidth" UseContextKey="true">
                    </AjaxToolkit:AutoCompleteExtender> 
                     </td>
                      <td style="width: 1%;">
                      <asp:HiddenField ID="lblptnt_id" runat="server" />
                      <asp:RequiredFieldValidator runat="server" id="reqPtntNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                      </td> 
                     </tr> 
                     </table>  
                    </div>
                    <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Ear Site" ></asp:Label>
                     <asp:RadioButtonList ID="rbte_site" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" onselectedindexchanged="rbte_site_SelectedIndexChanged" style="width:100%">
                                <asp:ListItem>Right</asp:ListItem>
                                <asp:ListItem>Left</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                                <%--<asp:ListItem>Bianaural Fitting</asp:ListItem>--%>
                     </asp:RadioButtonList>  
                     </td>
                      <td style="width: 1%;">
                      <asp:RequiredFieldValidator runat="server" id="reqSite" controltovalidate="rbte_site" ErrorMessage="Select Ear Site" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                      </td> 
                     </tr> 
                     </table>   
                    </div>   
                    <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Number Of Hg.Aids" Visible="false"></asp:Label>
                    <asp:RadioButtonList ID="rbtn_no_mach" runat="server" AutoPostBack="false" 
                            Font-Bold="true" RepeatDirection="Horizontal" style="width:100%" 
                            Visible="False">
                        <asp:ListItem>Single</asp:ListItem>
                        <asp:ListItem>Double</asp:ListItem>
                    </asp:RadioButtonList>
                    </div> 
                    <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Hearing Aid Id Right Ear"></asp:Label>
                    <asp:DropDownList id="ddl_comp" runat="server" AutoPostBack="True" 
                            class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>                    
                    <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" 
                            AutoPostBack="True" class="form-control" 
                            onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList> 
                    <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" 
                            AutoPostBack="True" class="form-control" 
                            onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>
                        <asp:HiddenField ID="lblmach_id" runat="server" />
                    </div>   
                    <div class="form-group">
                  <asp:Label ID="Label6" runat="server" Text="Hearing Aid Price"></asp:Label>
                   <asp:TextBox ID="txt_hn_price" runat="server" class="form-control"></asp:TextBox>  
                   <AjaxToolkit:AutoCompleteExtender ID="AutoPtntNm" runat="server" TargetControlID="txt_hn_price"
                                    FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx"
                                    MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="10" CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="divwidth">
                                </AjaxToolkit:AutoCompleteExtender>                                  
               </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Accessories Given"></asp:Label>
                     <asp:TextBox ID="txt_acc_given" runat="server" class="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </div>   
              </div>
         <div class="col-sm-push-0 col-md-5">
                   <div class="form-group">
                   </div> 
                    <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text="Mode of Payment"></asp:Label>
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged"  AutoPostBack="true" style="width:100%">
                                <asp:ListItem>CASH</asp:ListItem>
                                <asp:ListItem>CHEQUE</asp:ListItem>
                                <asp:ListItem>NO CHARGES</asp:ListItem>
                     </asp:RadioButtonList>
                     </td>
                      <td style="width: 1%;">
                      <asp:RequiredFieldValidator runat="server" id="reqChkdtl" controltovalidate="RadioButtonList1" ErrorMessage="Select Mode of Payment" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                      </td> 
                     </tr> 
                     </table> 
                    </div>   
                    <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="Cheque No"></asp:Label>
                     <asp:TextBox ID="txt_chq_no" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label15" runat="server" Text="Cheque Detail"></asp:Label>
                     <asp:TextBox ID="txt_chq_det" runat="server" class="form-control" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Cash"></asp:Label>
                     <asp:TextBox ID="txt_cash" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="Hearing Aid Return"></asp:Label>
                            <asp:CheckBox ID="chrtn" runat="server"  class="form-control" />                                        
                    </div>
                    <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:98%">
                            <asp:Label ID="Label13" runat="server" Text="Hearing Aid Return Date"></asp:Label>
                            <asp:TextBox ID="txtDate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtDate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtDate" CssClass="ajax__calendar" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                            </AjaxToolkit:CalendarExtender>
                     </td>
                    <td style="width:2%">
                        <div>
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                    </td>                    
                    </tr></table>
                    </div>
                    <div class="btn-toolbar list-toolbar" >
                    <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" class="btn btn-primary" OnClientClick="checkPrintReq()"/>
                    <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false"/> 
                    <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" 
                            onclick="btnPrint_Click" Enabled="False"/>                       
                    </div>
                   <div class="form-group">
                   <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                   </div>  
         </div> 
         </div>
         </ContentTemplate> 
 </asp:UpdatePanel>
       </div>
</asp:Content>

