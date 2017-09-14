<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup ="true" CodeFile="SelectPatient_HearingRpt.aspx.cs" Inherits="SelectPatient_HearingRpt" Title="Patient Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:updatepanel id="UpdatePanel3" runat="server">
    <ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">Patient Data</div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
               <div class="form-group">
                    <asp:Label ID="label1" runat="server" Text="Select Option"></asp:Label>
                    <asp:RadioButtonList ID="rbtSelect" runat="server" RepeatDirection="Vertical" onselectedindexchanged="rbtSelect_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem >Patient--Hearing Aid Model,Company Search</asp:ListItem>
                        <%--<asp:ListItem >Hearing Aid Model-Patient Search</asp:ListItem>
                        <asp:ListItem >Hearing Aid Company-Patient Search</asp:ListItem>--%>
                        <asp:ListItem >Patient Data for due Amount</asp:ListItem>
                        <%--<asp:ListItem >NoOfPatientSelf and Doctor</asp:ListItem>--%>
                        <asp:ListItem >Referral Commission</asp:ListItem>
                        <asp:ListItem >No.Of Hearing Aid Sale</asp:ListItem>
                        <asp:ListItem >Patient All Data</asp:ListItem>        
                    </asp:RadioButtonList>
           </div>
               <div class="form-group">                  
                    <table style="width:100%">
                    <tr>
                    <td style="width:95%">               
<asp:Label ID="label2" runat="server" Text="Patent Name"></asp:Label>
<asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="Server">
  <ContentTemplate> 
  <div>  
        <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" 
          ></asp:TextBox> 
         <div id="divwidth" style="display:list-item">
         </div>
        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="divwidth">
        </AjaxToolkit:AutoCompleteExtender>        
        </div>
        </ContentTemplate> 
        </asp:UpdatePanel>                       
                     </td>
                    <td style="width:5%">
                    <asp:HiddenField ID="lblPtnt_Id" runat="server" />
                    </td>
                    </tr>
                    </table>
                    </div> 
               <div class="form-group">                   
                    <table style="width:100%">                  
                    <tr>
                    <td style="width:95%">
                    <asp:Label ID="lblMod" runat="server" Text="Hearing Aid Model Search"></asp:Label>
 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
  <ContentTemplate> 
  <div>  
        <asp:TextBox ID="txtModel" runat="server" class="form-control"></asp:TextBox> 
         <div id="div1" style="display:list-item">
         </div>
        <AjaxToolkit:AutoCompleteExtender ID="AutModel" runat="server" TargetControlID="txtModel" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="div1">
        </AjaxToolkit:AutoCompleteExtender>        
        </div>
        </ContentTemplate> 
        </asp:UpdatePanel>
                     </td>
                    <td>
                    <asp:HiddenField ID="lblMo_Id" runat="server" />
                    </td>
                    </tr>                    
                    </table>
               </div> 
               <div class="form-group">                   
                    <table style="width:100%">                  
                    <tr>
                    <td style="width:95%">
                    <asp:Label ID="lblComp" runat="server" Text="Hearing Aid Company Search"></asp:Label>
 <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="Server">
  <ContentTemplate> 
  <div>  
        <asp:TextBox ID="txtCom" runat="server" class="form-control"></asp:TextBox> 
         <div id="div2" style="display:list-item">
         </div>
        <AjaxToolkit:AutoCompleteExtender ID="AutCom" runat="server" TargetControlID="txtCom" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="div2">
        </AjaxToolkit:AutoCompleteExtender>        
        </div>
        </ContentTemplate> 
        </asp:UpdatePanel>                  
                     </td>
                    <td>
                    <asp:HiddenField ID="label7" runat="server" />
                    <asp:HiddenField ID="Label1s" runat="server" />
                    </td>
                    </tr>                    
                    </table>
               </div> 
               <div class="form-group">
               <table style="width:100%">
                    <tr>
                    <td style="width:30%">
                     <asp:Label ID="label8" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:10%">
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                            </td>
                    <td style="width:30%">
                     <asp:Label ID="label9" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="lblto_date" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="lblto_date_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="lblto_date" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:10%">
                            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
                            </td>                            
                            </tr></table>
                 </div>
                 <div class="btn-toolbar list-toolbar">
                        <button class="btn btn-primary"><i class="fa fa-save"></i>Save</button>
                        <button class="btn btn-primary" data-dismiss="modal">Cancel</button>
                    </div>  
               </div>
        </div> 
    </div>
    </ContentTemplate> 
</asp:updatepanel>     
</asp:Content>

