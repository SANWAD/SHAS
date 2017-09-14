<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="advertising.aspx.cs" Inherits="Advertising" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Advertising</h>
        </div>
        <div class="panel-body">
<div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="lblad_id" runat="server" />
                </div>                
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">                    
                    <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label2" runat="server">Media</asp:Label> 
                    <asp:TextBox ID="txtmedia" runat="server" class="form-control"></asp:TextBox>
                </td> 
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqMedi" controltovalidate="txtmedia" ErrorMessage="Required Media Name" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr> 
                </table> 
                </div>
                <div class="form-group">
                   <table style="width:100%">
                   <tr>
                   <td style="width:48%">
                   <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server">Advertisment From Date</asp:Label> 
                    <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                    </AjaxToolkit:CalendarExtender>
                    </td>
                    <td style="width:2%">
                     <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtdate" ErrorMessage="Required From Date" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                        </td>
                        <td style="width:48%">
                        <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                       <asp:Label ID="Label4" runat="server">Advertisment To Date</asp:Label> 
                    <asp:TextBox ID="txtdtfrom" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                    <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtdtfrom_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdtfrom" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                    </AjaxToolkit:CalendarExtender>
                    </td> 
                   <td style="width:2%">
                        <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
                        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtdtfrom" ErrorMessage="Required To Date" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                        </td>
                        </tr></table>
                </div>
                <div class="form-group">
                <asp:Label ID="Label10" runat="server">Advertisment Frequency</asp:Label> 
                <asp:DropDownList ID="ddl_ad_freq" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>For Three Day</asp:ListItem>
                    <asp:ListItem>Once in Week</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                     <asp:ListItem>Fortnight</asp:ListItem>
                    <asp:ListItem>Monthly</asp:ListItem>
                    <asp:ListItem>Half Yearly</asp:ListItem> 
                    <asp:ListItem>Yearly</asp:ListItem>                  
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label12" runat="server">Name of group</asp:Label> 
                <asp:TextBox ID="txt_nm_media" runat="server" class="form-control"></asp:TextBox>
            </div>
         </div>
        <div class="col-sm-push-0 col-md-5">    
            <div class="form-group">
            </div> 
            <div class="form-group">
                <asp:Label ID="Label14" runat="server">Cost</asp:Label> 
                <asp:TextBox ID="txt_cost" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server">Result</asp:Label> 
                <asp:TextBox ID="txt_result" runat="server" class="form-control"></asp:TextBox>
            </div>
            
            <div class="btn-toolbar list-toolbar">
             <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>
                    <fieldset>      
            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>    
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCancel_Click" onclientclick="return askConfirm()" CausesValidation="false"></asp:Button>                           
                </fieldset> 
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
