<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="bill" Title="Petty Cash" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Petty Cash</h>
        </div>        
       <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
       <ContentTemplate>    
    <script  language="javascript" type="text/javascript">
        function addPB() {
            var PTA = document.getElementById('<%=txtPTA.ClientID %>').value;
            var BERA = document.getElementById('<%=txtBera.ClientID %>').value;
            var IMP = document.getElementById('<%=txtImp.ClientID %>').value;
            var TDT = document.getElementById('<%=txtTDT.ClientID %>').value;
            var SisiT = document.getElementById('<%=txtSisiT.ClientID %>').value;
            var FFAud = document.getElementById('<%=txtFFAud.ClientID %>').value;

            var SE = document.getElementById('<%=txtSE.ClientID %>').value;
            var StD = document.getElementById('<%=txtStD.ClientID %>').value;
            var StM = document.getElementById('<%=txtStM.ClientID %>').value;
            var HAP = document.getElementById('<%=txtHAP.ClientID %>').value;
            var Coun = document.getElementById('<%=txtCoun.ClientID %>').value;
            var Other = document.getElementById('<%=txtOther.ClientID %>').value;
            var Result = parseInt(PTA) + parseInt(BERA) + parseInt(IMP) + parseInt(TDT) + parseInt(SisiT) + parseInt(FFAud) + parseInt(SE) + parseInt(StD) + parseInt(StM)+ parseInt(HAP) + parseInt(Coun) + parseInt(Other);
            if (!isNaN(Result)) {
                document.getElementById('<%=txt_bill_amt.ClientID %>').value = Result;
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
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">               
               <div class="form-group">
                   <asp:HiddenField ID="lbl_bill_no" runat="server" />
               </div>
               <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Patient Name"></asp:Label>
                     <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" ></asp:TextBox> 
                     <div id="divwidth" style="display:list-item">
                        </div>
                        <AjaxToolkit:AutoCompleteExtender ID="AutoPtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                        </AjaxToolkit:AutoCompleteExtender>
                   <asp:HiddenField ID="lblptnt_id" runat="server" />                    
                    </td> 
                   <td style="width:1%">
                   <asp:RequiredFieldValidator runat="server" id="reqPNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                   </td>
                    </tr>
                    </table> 
                    </div>
               <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Pure Tune Audiometry:"></asp:Label>
                     <asp:TextBox ID="txtPTA" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
               <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Bera:"></asp:Label>
                     <asp:TextBox ID="txtBera" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                     <!--onkeydown="return isNumeric(event.keyCode);" AutoPostBack="true" ontextchanged="txtBera_TextChanged"-->
                    </div>
               <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Impedance:"></asp:Label>
                     <asp:TextBox ID="txtImp" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
               <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Tone-Decay Test:"></asp:Label>
                     <asp:TextBox ID="txtTDT" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
               <div class="form-group">
                    <asp:Label ID="Label19" runat="server" Text="SISI Test:"></asp:Label>
                     <asp:TextBox ID="txtSisiT" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>      
                     <div class="form-group">
                    <asp:Label ID="Label20" runat="server" Text="Free-Field Audiometry:"></asp:Label>
                     <asp:TextBox ID="txtFFAud" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                       
        </div> 
        <div class="col-sm-push-0 col-md-5"> 
                   <div class="form-group"> 
                   </div>  
                    <div class="form-group">
                    <asp:Label ID="Label21" runat="server" Text="Speech Evaluation:"></asp:Label>
                     <asp:TextBox ID="txtSE" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>   
                         <div class="form-group">
                    <asp:Label ID="Label22" runat="server" Text="Speech Therapy(Daily):"></asp:Label>
                     <asp:TextBox ID="txtStD" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label23" runat="server" Text="Speech Therapy(Monthly):"></asp:Label>
                     <asp:TextBox ID="txtStM" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label24" runat="server" Text="Hearing Aid Programming:"></asp:Label>
                     <asp:TextBox ID="txtHAP" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label25" runat="server" Text="Counsulition:"></asp:Label>
                     <asp:TextBox ID="txtCoun" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="lblOther" runat="server" Text="Other / ASSR / OAE / H.AID TRIAL / MOULD / H.AID REPAIR / H.AID PROGRAMMING :"></asp:Label>
                     <asp:TextBox ID="txtOther" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" Text="0" onkeyup="addPB()"></asp:TextBox>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Amount:"></asp:Label>
                     <asp:TextBox ID="txt_bill_amt" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </div>
                     <div class="btn-toolbar list-toolbar">                     
                     <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="SAVE" class="btn btn-primary" OnClientClick="checkPrintReq()"/>
                     <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCancel_Click" CausesValidation="false" />
                     <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" 
                             onclick="btnPrint_Click" Enabled="False"/>
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


