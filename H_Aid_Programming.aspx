<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="H_Aid_Programming.aspx.cs" Inherits="H_Aid_Programming" Title="Hearing Aid Programming" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" >
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
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Programming</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="lbl_H_Prg_id" runat="server" /> 
                </div>
                <div class="form-group"> 
                <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">                   
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label2" runat="server" text="PATIENT NAME"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>                                
                                <asp:HiddenField ID="LblPtntid" runat="server" />
                                <div id="divwidth" style="display: none">
                                </div>
                                <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" CompletionSetCount="1" MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                                </AjaxToolkit:AutoCompleteExtender>                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                         </td> 
                     <td style="width: 1%;">
                     <asp:RequiredFieldValidator runat="server" id="reqPNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true" EnableClientScript="true"/>
                     </td>
                     </tr> 
                     </table> 
                    </div>               
                <div class="form-group">
                        <asp:Label ID="Label4" runat="server" text="PROGRAMMING STEPS"></asp:Label>    
                        <asp:DropDownList ID="rbtReturn" runat="server" class="form-control">
                        <asp:ListItem Selected="True">I Step</asp:ListItem>
                        <asp:ListItem>II Step</asp:ListItem>
                        <asp:ListItem>III Step</asp:ListItem>
                        <asp:ListItem> Above III Step</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="form-group"> 
                 <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">                   
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>                   
                    <asp:Label ID="Label5" runat="server" text="COMPLAINTS"></asp:Label>    
                <asp:TextBox ID="txtCompl" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                 </td> 
                     <td style="width: 1%;">
                     <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtCompl" ErrorMessage="Required Complents" Text="*"  SetFocusOnError="true" EnableClientScript="true"/>
                     </td>
                     </tr> 
                     </table> 
            </div>
            </div>
            <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
            </div> 
             <div class="form-group">                
                    <asp:Label ID="Label3" runat="server" text="TIME"></asp:Label>    
                    <asp:DropDownList ID="ddlTime" runat="server" class="form-control">
                        <asp:ListItem>15 Minutes</asp:ListItem>
                        <asp:ListItem>30 Minutes</asp:ListItem>
                        <asp:ListItem>45 Minutes</asp:ListItem>
                        <asp:ListItem>60 Minutes</asp:ListItem>
                    </asp:DropDownList>
                </div>
            
             <div class="form-group">
                <asp:Label ID="Label6" runat="server" text="COMMENT AFTER PROGRAMMING"></asp:Label>    
                <asp:TextBox ID="txtCom_After" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>
             <div class="btn-toolbar list-toolbar"> 
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
             <ContentTemplate>            
               <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"/>
               <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" />
               <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" 
                     onclick="btnPrint_Click"/>
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
