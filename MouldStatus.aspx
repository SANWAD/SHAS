<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="MouldStatus.aspx.cs" Inherits="outward" Title="Mould Status" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">        
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Mould Status</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">  
            <div class="form-group">
                <asp:HiddenField ID="lblMou_no" runat="server" />
            </div>
             <div class="form-group">
           <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label1" runat="server"  Text="Patient Name"></asp:Label>  <asp:HiddenField ID="lblPtnt_id" runat="server" />                             
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
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Hearing Aid Name"></asp:Label>
                <asp:TextBox ID="txtHAidNm" runat="server" class="form-control"></asp:TextBox>
                </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqHAidNm" controltovalidate="txtHAidNm" ErrorMessage="Required Hearing Aid Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>    
             <div class="form-group">    
          <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblSent_Date" runat="server" Text="Mould Sent Date"></asp:Label>
              <asp:TextBox ID="txtSent_Date" runat="server" class="form-control" ></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" OnClientDateSelectionChanged="checkDate" TargetControlID="txtSent_Date" Format="dd/MM/yyyy"  TodaysDateFormat="dd/MM/yyyy" CssClass="ajax__calendar" >
               </AjaxToolkit:CalendarExtender>
               <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSent_Date" ErrorMessage="Can't Select Date which is greater than Todays Date"></asp:RangeValidator>--%>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="calImage" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>  
          </tr>  
          </table>
          </div>
           <div class="form-group">    
          <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblRec_Date" runat="server" Text="Mould Received Date"></asp:Label>
              <asp:TextBox ID="txtRec_Date" runat="server" class="form-control" ></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomLeft" TargetControlID="txtRec_Date" Format="dd/MM/yyyy"  CssClass="ajax__calendar" TodaysDateFormat="dd/MM/yyyy">
               </AjaxToolkit:CalendarExtender>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>  
          </tr>  
          </table>
          </div>
           <div class="form-group">    
          <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblFit_Date" runat="server" Text="H.Aid Fitting Date"></asp:Label>
              <asp:TextBox ID="txtFit_Date" runat="server" class="form-control"></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                    PopupPosition="BottomLeft" TargetControlID="txtFit_Date" Format="dd/MM/yyyy" 
                    CssClass="ajax__calendar" TodaysDateFormat="dd/MM/yyyy">
               </AjaxToolkit:CalendarExtender>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="Image2" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>  
          </tr>  
          </table>
          </div>
                            
                    
           
            <div class="btn-toolbar list-toolbar" >    
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
               <ContentTemplate>
                <fieldset>                     
                 <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  class="btn btn-primary"></asp:Button>                       
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCancel_Click" CausesValidation="false" ></asp:Button>
                </fieldset> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
            </div>
            <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
            </div> 
            </div>
        </div> 
        </div>
</asp:Content>

