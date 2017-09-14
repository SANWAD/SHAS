<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="appoint_cancel.aspx.cs" Inherits="AptCancle" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Appointment Cancle</h>
        </div>
        <div class="panel-body">
             <div class="col-sm-push-0 col-md-5">              
                    <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Appointment Id"></asp:Label> 
                     <asp:Label ID="lblaptid" runat="server" class="form-control"></asp:Label>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Date"></asp:Label> 
                     <asp:Label ID="lbldate" runat="server" Class="form-control"></asp:Label>
                     </div>
                    <div class="form-group">
                    <asp:Label ID="Label2" runat="server">Patient For</asp:Label> 
                     <uc1:ComboBox ID="ptnt_for" runat="server" class="form-control" />
                    </div>
                    <div class="form-group">                 
                     <table>
                     <tr><td>
                            <asp:Label ID="Label3" runat="server">Appointment Date</asp:Label> 
                            <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                            </AjaxToolkit:CalendarExtender>
                     </td>
                    <td>
                        <div>
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                   </td></tr>
                   </table> 
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label4" runat="server">Patient Name</asp:Label> 
                     <uc1:ComboBox ID="CmbPtnt_Nm" runat="server" class="form-control" />
                    </div> 
                    <div class="form-group">
                    <asp:Label ID="Label6" runat="server">Time</asp:Label> 
                    <asp:TextBox ID="txt_time" runat="server" MaxLength="15" ReadOnly="True" class="form-control"></asp:TextBox>
                    </div>                    
                     <div class="btn-toolbar list-toolbar">
                     <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>
                    <fieldset>
                     <asp:Button ID="btn_del" runat="server" OnClick="btn_del_Click" Text="Cancel Appointment" class="btn btn-primary"/>
                     </fieldset> 
                     </ContentTemplate>
               </asp:UpdatePanel> 
                        <%--<button class="btn btn-primary"><i class="fa fa-save"></i>Save</button>
                        <button class="btn btn-primary" data-dismiss="modal">Cancel</button>
                        <a href="#myModal" data-toggle="modal" class="btn btn-danger">Delete</a>--%>
                    </div>
              </div>
    </div>
        </div>
</asp:Content>
