<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="earmould.aspx.cs" Inherits="Ear_Mould" Title="Ear Mould" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" >
    function Calc() {
        var MPrice = document.getElementById('<%=txtprice.ClientID %>').value;
        var RecAmt = document.getElementById('<%=txtrecamt.ClientID %>').value;
        var Result = parseInt(MPrice) - parseInt(RecAmt);
        if (!isNaN(Result)) {
            document.getElementById('<%=txtremamt.ClientID %>').value = Result;
        }
    }
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
    <div class="panel panel-default">
 <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
   <ContentTemplate> 
        <div class="panel-heading">
            <h class="text-muted text-center">Ear Mould</h>
        </div>
        <div class="panel-body">
           <div class="col-sm-push-0 col-md-5">       
                      <div class="form-group">
                           <asp:HiddenField ID="lbleMould_id" runat="server" />
                       </div>
                      <div class="form-group">
                           <table style="width:100%">
                            <tr>
                            <td style="width:99%">
                           <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                           <asp:Label ID="Label2" runat="server" Text="Patient Name"></asp:Label>
                           <asp:TextBox ID="txtPtnt_nm" runat="server" class="form-control"></asp:TextBox>
                            <div id="divwidth" style="display:list-item">
         </div>
        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="divwidth" UseContextKey="true">
        </AjaxToolkit:AutoCompleteExtender> 
                           <asp:HiddenField ID="lblptnt_id" runat="server" />
                           </td> 
                           <td style="width:1%">
                           <asp:RequiredFieldValidator runat="server" id="reqPNm" controltovalidate="txtPtnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                           </td> 
                           </tr> 
                           </table> 
                       </div>
                      <div class="form-group">
                      <table style="width:100%">
                        <tr>
                        <td style="width:99%">
                            <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                           <asp:Label ID="Label4" runat="server" Text="Ear Site"></asp:Label>
                           <asp:RadioButtonList ID="rbte_site" runat="server" RepeatDirection="Horizontal" Style="width:100%" >
                                <asp:ListItem>Right</asp:ListItem>
                                <asp:ListItem>Left</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                            </asp:RadioButtonList>
                            </td> 
                            <td style="width:1%">
                            <asp:RequiredFieldValidator runat="server" id="reqSit" controltovalidate="rbte_site" ErrorMessage="Required To Select Ear Site" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                            </td> 
                            </tr> 
                            </table> 
                       </div>                     
                      <div class="form-group">
                      <table style="width:100%">
                        <tr>
                        <td style="width:99%">
                            <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*"></asp:Label>
                          <asp:Label ID="Label6" runat="server" Text="Mould Price"></asp:Label>
                          <asp:TextBox ID="txtprice" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="Calc()"></asp:TextBox>
                          </td> 
                          <td style="width:1%">
                          <asp:RequiredFieldValidator runat="server" id="reqPrice" controltovalidate="txtprice" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                          </td> 
                          </tr> 
                          </table> 
                       </div>
                      <div class="form-group ">
                           <table style="width:100%">
                            <tr>
                                  <td style="width:98%">
                                        <asp:Label ID="Label5" runat="server" Text="Date Of Return To patient"></asp:Label>
                                        <asp:TextBox ID="txtdt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>                                    
                                        <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtdt_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtdt" CssClass="ajax__calendar" Format="dd/MM/yyyy" DaysModeTitleFormat="" TodaysDateFormat="dd/MM/yyyy">
                                        </AjaxToolkit:CalendarExtender>
                                     </td>
                                  <td style="width:2%">                                      
                                           <div>
                                            <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                                            </div>
                                      </td>
                            </tr> 
                            </table> 
                    </div>
           </div>         
           <div class="col-sm-push-0 col-md-5">
                       <div class="form-group">
                       </div> 
                       <div class="form-group">
                       <table style="width:100%">
                        <tr>
                        <td style="width:99%">
                            <asp:Label ID="Label12" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Text="Received Amount"></asp:Label>
                            <asp:TextBox ID="txtrecamt" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="Calc()"></asp:TextBox>
                        </td> 
                        <td style="width:91%">
                        <asp:RequiredFieldValidator runat="server" id="reqRec" controltovalidate="txtrecamt"   Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                        </td> 
                        </tr> 
                        </table> 
                        </div>
                       <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Remaning Amount"></asp:Label>
                            <asp:TextBox ID="txtremamt" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                        </div>
                       <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Comment"></asp:Label>
                        <asp:TextBox ID="txtcomment" runat="server" class="form-control"></asp:TextBox>
                       </div>
                       <div class="btn-toolbar list-toolbar">
                          <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"></asp:Button>                          
                          <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" onclientclick="return askConfirm()"></asp:Button> 
                          <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" 
                               Enabled="False" onclick="btnPrint_Click"></asp:Button>                     
                    </div>  
                     <div class="form-group">
                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                     </div>               
           </div>
        </div> 
        </ContentTemplate> 
</asp:UpdatePanel>           
 </div> 
</asp:Content>

