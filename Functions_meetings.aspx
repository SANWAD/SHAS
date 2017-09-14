<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Functions_meetings.aspx.cs" Inherits="Functions_meetings" Title="Functions & Meetings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="panel panel-default">
    <div class="panel-heading">
        <h class="text-muted text-center">Functions & Meetings</h>
    </div>
    <div class="panel-body" >
        <div class="col-sm-push-0 col-md-5">
        <div class="form-group">
        <asp:HiddenField ID="lblfunct_id" runat="server" />
        </div>
        <div class="form-group">
        <asp:HiddenField ID="lbl_apt_id" runat="server" />
        </div>
        <div class="form-group">
        <table style="width:100%">
        <tr>
        <td style="width:99%">        
        <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>        
        <asp:Label ID="Label3" runat="server" Text="Description of Meeting"></asp:Label>
        <asp:TextBox ID="txtn_days" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
        </td> 
        <td style="width:1%"> 
        <asp:RequiredFieldValidator runat="server" id="reqDays" controltovalidate="txtn_days" ErrorMessage="Required Number Of Days Function"  Text="*"  SetFocusOnError="true"/>
        </td> 
        </tr> 
        </table> 
        </div>
        <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:48%">
                        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label4" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" TargetControlID="txtdate" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:2%">
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                            <asp:RequiredFieldValidator runat="server" id="reqFdt" controltovalidate="txtdate" ErrorMessage="Required From Date" Text="*"  SetFocusOnError="true"/>
                            </td>                              
                    <td style="width:48%">
                        <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label6" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="lblto_date" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="lblto_date_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="lblto_date" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:2%">
                            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
                            <asp:RequiredFieldValidator runat="server" id="reqTdt" controltovalidate="lblto_date" ErrorMessage="Required To Date" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                            </td></tr></table>
                            </div>                            
        <div class="btn-toolbar list-toolbar">
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
            <ContentTemplate>
            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
            <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>
            </ContentTemplate> 
            </asp:UpdatePanel> 
        </div>  
        <div class="form-group">
           <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
        </div> 
        </div> 
        </div> 
</div> 
</asp:Content>

