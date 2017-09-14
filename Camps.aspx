<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Camps.aspx.cs" Inherits="Camps" Title="Camp's" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Camp's</h>
        </div>
        <div class="panel-body">
             <div class="col-sm-push-0 col-md-5">          
                    <div class="form-group">
                        <asp:HiddenField ID="lblcamp_id" runat="server" />
                    </div>
                    <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label2" runat="server"  Text="Camp Name"></asp:Label>
                     <asp:TextBox ID="txtcampnm" runat="server" class="form-control"></asp:TextBox>
                     </td> 
                     <td style="width:1%">
                     <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txtcampnm" runat="server" ErrorMessage="Required Camp Name" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                     </td> 
                     </tr> 
                     </table> 
                    </div>
                     <div class="form-group">
                   <table style="width:100%">
                   <tr>
                   <td style="width:95%">
                       <asp:Label ID="Label12" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server"  Text="Camp Date"></asp:Label>
                     <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
                    <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtdate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdate" CssClass="ajax__calendar" Format="dd/MM/yyyy">
                    </AjaxToolkit:CalendarExtender>
                    </td>
                    <td style="width:2%">
                        <div>
                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                            <asp:RequiredFieldValidator ID="regDt" ControlToValidate="txtdate" runat="server" ErrorMessage="Required Camp Date" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </td>                    
                    </tr>
                    </table>
                    </div>
                     <div class="form-group">
                    <asp:Label ID="Label4" runat="server"  Text="Camp Duration in Days"></asp:Label>
                     <asp:TextBox ID="txtduration" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                     <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Number Of Visitors"></asp:Label>
                     <asp:TextBox ID="txtno_vis" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Audiometry Done"></asp:Label>
                     <asp:TextBox ID="txtaud_done" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                    </div>
                    <div class="col-sm-push-0 col-md-5"> 
                    <div class="form-group">
                    </div> 
                    <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Fitting Booked"></asp:Label>
                     <asp:TextBox ID="txtfit_book" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Patient Names"></asp:Label>
                     <asp:TextBox ID="txtptntnm" runat="server" class="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Mode Of Advertisment"></asp:Label>
                     <asp:TextBox ID="txtmode_adv" runat="server" class="form-control" ></asp:TextBox>
                    </div>
                     <div class="btn-toolbar list-toolbar">
                     <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                     <ContentTemplate>
                    <fieldset>                                             
                     <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                      <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>
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
