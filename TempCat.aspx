<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="TempCat.aspx.cs" Inherits="TempCat" Title="Template Category" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Template Category</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-5">           
            <div class="form-group">
                <asp:HiddenField ID="lbl_Temp_id" runat="server"/>                       
                </div>                         
                <div class="form-group">
                <tr>
                <td style="width:99%"> 
                <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*"></asp:Label>
                 <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                    <asp:DropDownList ID="ddlMsgCat" runat="server" class="form-control"></asp:DropDownList>
                </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="ddlMsgCat" ErrorMessage="Required to select Massage Description" Text="*" SetFocusOnError="true" /> 
                </td>
                </tr>
                </table>
                </div>                  
                  <div class="form-group">
                    <table Style="width:100%">
                    <tr>
                    <td style="width:48%">
                        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label4" runat="server" Text="From Date"></asp:Label>
                            <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:2%">
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                            <asp:RequiredFieldValidator runat="server" id="reqFdt" controltovalidate="txtdate" ErrorMessage="Required From Date" Text="*"  SetFocusOnError="true"/>
                            </td>                              
                    <td style="width:48%">
                        <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label6" runat="server" Text="To Date"></asp:Label>
                            <asp:TextBox ID="lblto_date" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                            <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="lblto_date_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="lblto_date" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                            </AjaxToolkit:CalendarExtender>
                            </td>
                            <td style="width:2%">
                            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
                            <asp:RequiredFieldValidator runat="server" id="reqTdt" controltovalidate="lblto_date" ErrorMessage="Required To Date" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                            </td></tr></table>
                   </div>   
                    <div class="form-group">   
                  <asp:Label ID="Label7" runat="server" Text="Massage Body"></asp:Label>
                      <asp:TextBox ID="txtMsgBody" runat="server" class="form-control" TextMode="MultiLine" MaxLength="120" ></asp:TextBox>  
                  </div>
                    <div class="form-group">
                  <asp:Label ID="Label1" runat="server" Text="ISActive"></asp:Label>
                  <asp:CheckBox ID="ChkIsAct" runat="server" class="form-control" />
                  </div>   
                  
                <%-- <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Template Description Already Exists" ForeColor="Red" Visible="false"></asp:Label>
                </div> --%>            
                <div class="btn-toolbar list-toolbar"> 
                  <asp:Button ID="btn_save" runat="server" Text="SUBMIT" class="btn btn-primary" 
                        onclick="btn_save_Click"/>     
                        <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary"  onclientclick="return askConfirm()" onclick="btnCan_Click" />    
                </div>
               
            </div>
            <div class="col-sm-push-0 col-md-5"> 
            <asp:Label ID="Label10" runat="server" Text="Keys"></asp:Label>
            </div> 
        </div>
         <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" EnableClientScript="true" />
                </div>
    </div>
    </ContentTemplate> 
 </asp:UpdatePanel> 
</asp:Content>
