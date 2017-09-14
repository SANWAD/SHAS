<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="HrAidRepair.aspx.cs" Inherits="HrAidRepair" Title="Hearing Aid Repair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
 <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Repair</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
             <asp:HiddenField ID="lbljob_id" runat="server" />
            </div>
            <div class="form-group">
            <table style="width: 100%;">
            <tr>
            <td style="width: 98%;">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Patient Name"></asp:Label> 
             <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" ></asp:TextBox>
             <div id="divwidth" style="display: list-item">
                 </div>
                 <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" UseContextKey="true" CompletionListElementID="divwidth">
                 </AjaxToolkit:AutoCompleteExtender>                   
             </td>
            <td style="width: 2%;">
            <asp:HiddenField ID="lblptnt_id" runat="server" />
            <asp:RequiredFieldValidator runat="server" id="reqQty" controltovalidate="txtptnt_nm" ErrorMessage="Required Patent Name" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr>
            </table>
            </div>  
            <div class="form-group">
               <asp:Label ID="Label5" runat="server" Text="Visual Report"></asp:Label>
               <asp:TextBox ID="txtvisu_rpt" runat="server" class="form-control" TextMode="MultiLine" ></asp:TextBox>
            </div>    
            <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Hearing Aid For Repair"></asp:Label>  
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>                   
            <asp:DropDownList id="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>                    
            <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList> 
            <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>                    
            <asp:HiddenField ID="lblmach_id" runat="server" />
            <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>
            </ContentTemplate> 
            </asp:UpdatePanel> 
            </div> 
            <div class="form-group">
            <table style="width: 100%;">
            <tr>
            <td style="width: 99%;">
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="Ear Site"></asp:Label>
               <asp:RadioButtonList ID="rbte_site" runat="server" RepeatDirection="Horizontal" style="width:100%">
                    <asp:ListItem>Right</asp:ListItem>
                    <asp:ListItem>Left</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:RadioButtonList>
                 </td>
            <td style="width: 1%;">
            <asp:RequiredFieldValidator runat="server" id="reqSite" controltovalidate="rbte_site" ErrorMessage="Select Ear Site" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr>
            </table>
               </div>           
               <div class="form-group">
               <asp:Label ID="Label14" runat="server">Repair To</asp:Label>
               <asp:RadioButtonList ID="rbtrep_to" runat="server" RepeatDirection="Horizontal" style="width:100%">
                    <asp:ListItem>In House</asp:ListItem>
                    <asp:ListItem>To Company</asp:ListItem>
                </asp:RadioButtonList>
               </div>                                          
              </div>              
        <div class="col-sm-push-0 col-md-5">
                    <div class="form-group">
                    </div> 
                     <div class="form-group">
                           <asp:Label ID="Label8" runat="server" Text="Expense Charge"></asp:Label>
                           <asp:TextBox ID="txtexpchg" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0"></asp:TextBox>
                        </div>  
                            <div class="form-group">
                               <asp:Label ID="Label9" runat="server" Text="Advanced Paid"></asp:Label>
                               <asp:TextBox ID="txtadv_paid" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);">0</asp:TextBox>
                            </div> 
                             <div class="form-group">                    
                                <table  class="table" style="width:100%">
                                        <tr>
                                          <td style="width:99%">
                                            <asp:Label ID="Label10" runat="server" Text="Expected Date For Hearing Aid Receiving"></asp:Label>
                                            <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" TargetControlID="txtdate" Format="dd/MM/yyyy" CssClass="ajax__calendar" >
                                            </AjaxToolkit:CalendarExtender>
                                         </td>
                                         <td style="width:1%">
                                            <div>
                                                <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                                         </td>
                                        </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label11" runat="server" Text="Hearing Accessories"></asp:Label>
                                 <asp:TextBox ID="txtaccess" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                           </div>
                            <div class="form-group">
                           <asp:Label ID="Label13" runat="server" Text="Hearing Aid Receive from Company"></asp:Label>
                            <asp:CheckBox ID="chkRap_ret" runat="server" Text="Machine Return From Company" class="form-control"/>
                           </div>
                            <div class="form-group">                               
                                <asp:Label ID="Label12" runat="server" Text="Receive Machine"></asp:Label>
                                 <asp:CheckBox ID="chkPtnt_Rcv" runat="server" Text="Machine Receive By Patient" class="form-control" />
                           </div>
                    <div class="btn-toolbar list-toolbar" >                    
                        <%--<asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>--%>
                        
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"></asp:Button>
                        
                        <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" onclick="btnPrint_Click"></asp:Button> 
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




