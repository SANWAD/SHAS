<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Apt_Tel.aspx.cs" Inherits="Apt_Tel" Title="Appointment(Telephonic)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="panel panel-default">
<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
        <div class="panel-heading">
            <h class="text-muted text-center">Appointment(Telephonic)</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">       
            <div class="form-group">
                <asp:HiddenField ID="lblApt_Tel_No" runat="server" />
            </div>
            <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:99%"> 
            <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Patient Name"></asp:Label>                    
            <asp:TextBox ID="txtPtnt_Nm" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqPtnt_Nm" controltovalidate="txtPtnt_Nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table> 
            </div>                   
            <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:99%"> 
            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Patient For"></asp:Label>
            <asp:DropDownList ID="ddltype" runat="server" class="form-control"></asp:DropDownList>
            </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqddltype" controltovalidate="ddltype" ErrorMessage="Required Select Appointment For" Text="*"  SetFocusOnError="true"/>
            </td>
            </tr> 
            </table>                    
            </div> 
             <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:99%">
            <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label10" runat="server" text="Mobile No"></asp:Label> 
            <asp:TextBox ID="txtmobno" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" MaxLength="12"></asp:TextBox>
            </td>
            <td style="width:1%">
            <asp:RequiredFieldValidator runat="server" id="reqMob" controltovalidate="txtmobno" ErrorMessage="Required Mobile No" Text="*"  SetFocusOnError="true"/>
            </td> 
            </tr> 
            </table> 
            </div> 
          <div class="form-group">
            <table style="width: 100%;">                       
            <tr>
            <td style="width: 98%;">
                <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="Appointment Date"></asp:Label>
                <asp:TextBox ID="txtdate" runat="server" class="form-control" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" CssClass="ajax__calendar"  PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" Enabled="true"  Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
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
           <%-- <div class="form-group">
            <asp:Label ID="lblTime" runat="server" text="Time"></asp:Label> 
            <asp:TextBox ID="txtTime" runat="server" class="form-control"></asp:TextBox>
            </div>--%>   
             <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Time"></asp:Label>
                    <asp:DropDownList ID="ddl_apt_time" runat="server" class="form-control"></asp:DropDownList>
                </td>
                 <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqTime" controltovalidate="ddl_apt_time" ErrorMessage="Required Appointment Time" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                 </td>
                 </tr> 
                 </table> 
                </div>  
                <div class="form-group">
                <asp:Label ID="lblApt_desc" runat="server" Text="Appointment Description"></asp:Label>
                <asp:TextBox ID="txtApt_Desc" runat="server" class="form-control"></asp:TextBox>
                </div>    
                </div>
            <div class="btn-toolbar list-toolbar">
            <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" class="btn btn-primary" Text ="Save"/>
            <asp:Button ID="btnCanel" runat="server" class="btn btn-primary" Text="Cancel" onclick="btnCanel_Click" CausesValidation="false" />
            </div>
            <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
            </div> 
       </div>       
 </ContentTemplate> 
</asp:UpdatePanel>
        </div>
</asp:Content>

