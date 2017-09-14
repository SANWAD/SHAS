<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Comp_HAidTrial.aspx.cs" Inherits="Comp_HAidTrial" Title="Company Trial" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 

    <script  language="javascript" type="text/javascript">
        function addPB() {
            var Rec = document.getElementById('<%=txtRec_Qty.ClientID %>').value;
            var Ret = document.getElementById('<%=txtRet_Qty.ClientID %>').value;            
            var Result = parseInt(Rec) - parseInt(Ret);
            if (!isNaN(Result)) {
                document.getElementById('<%=txtHAid_Stock.ClientID %>').value = Result;
            }
        }
</script>      
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Purchase On Trial</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">  
            <div class="form-group">
                <asp:HiddenField ID="lblTriaMach_No" runat="server" />
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                 <asp:TextBox ID="txtComp_Name" runat="server" class="form-control" 
                            AutoCompleteType="FirstName"></asp:TextBox>
                 </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqComp_Name" controltovalidate="txtComp_Name" ErrorMessage="Required Company Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Model Name"></asp:Label>
                        (Type the Name)<asp:TextBox ID="txtModel_Name" runat="server" class="form-control" AutoCompleteType="Company"></asp:TextBox></td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqModel_Name" controltovalidate="txtModel_Name" ErrorMessage="Required Model Name" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>    
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
               <asp:Label ID="Label4" runat="server" Text="H Aid Type"></asp:Label>
               <asp:TextBox ID="txtHAid_Type" runat="server" class="form-control" AutoCompleteType="Company"></asp:TextBox>
               </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqHAid_Type" controltovalidate="txtHAid_Type" ErrorMessage="Required Hearing Aid Type" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
              <asp:Label ID="Label5" runat="server" Text="Hearing Aid Received Quantity"></asp:Label>
              <asp:TextBox ID="txtRec_Qty" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="addPB()" Text="0" ></asp:TextBox>
              </td> 
                 <td style="width:99%">
                 <asp:RequiredFieldValidator runat="server" id="reqRec_Qty" controltovalidate="txtRec_Qty" ErrorMessage="Required Received Quantity" Text="*"  SetFocusOnError="true"/>
                 </td> 
                 </tr> 
                 </table> 
            </div>                
        </div>
        <div class="col-sm-push-0 col-md-5"> 
            <div class="form-group">
            </div> 
            <div class="form-group">
              <asp:Label ID="Label6" runat="server" Text="Hearing Aid Return Quantity"></asp:Label>
              <asp:TextBox ID="txtRet_Qty" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="addPB()" Text="0"></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:Label ID="Label7" runat="server" Text="Hearing Aid Stock"></asp:Label>
              <asp:TextBox ID="txtHAid_Stock" runat="server" class="form-control" Text="0" ></asp:TextBox>
            </div>
            <div class="form-group">
              <asp:Label ID="Label11" runat="server" Text="Reason For Hearing Aid Return"></asp:Label>
              <asp:TextBox ID="txtRea_HAid" runat="server" class="form-control"  AutoCompleteType="Disabled"></asp:TextBox>             
               <%--<AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" TargetControlID="txtRea_HAid" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" CssClass="ajax__calendar">
               </AjaxToolkit:CalendarExtender>--%>
            </div>
            <div style="height: 5Px;">
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

