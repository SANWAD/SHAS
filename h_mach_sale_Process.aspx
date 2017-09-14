<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="h_mach_sale_Process.aspx.cs" Inherits="h_mach_sale_Process" Title="Hearing Aid Sale In Process" AutoEventWireup="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="lib/AjaxCallBack.js"></script>
    <script src="lib/JScript_Refresh.js" type="text/javascript"></script>
    <script type="text/javascript" src="lib/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="lib/bootstrap/js/bootstrap.js"></script>
 <script  language="javascript" type="text/javascript">
     function addPB() {
         var HAPrice = document.getElementById('<%=txtmachprice.ClientID %>').value;
         var AmtRec = document.getElementById('<%=txtrecamt.ClientID %>').value;
         var Result = parseInt(HAPrice) - parseInt(AmtRec);
         if (!isNaN(Result)) {
             document.getElementById('<%=txtdueamt.ClientID %>').value = Result;
         }
     }
     function PriceCal() {
         var Price = document.getElementById('<%=lblPrice.ClientID %>').value;
         var Price1 = document.getElementById('<%=lblPrice1.ClientID %>').value;
         var Result = parseInt(Price) + parseInt(Price1);
         if (!isNaN(Result)) {
             document.getElementById('<%= txtmachprice.ClientID %>').value = Result;
         }

     }        
    </script>
  <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
           <ContentTemplate>
     <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Sale In Process</h>
        </div>
        <div class="panel-body">
 <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>--%>
        <div class="col-sm-push-0 col-md-5">
           <div class="form-group">
               <asp:HiddenField ID="lblsale_id" runat="server" />
           </div>
           <div class="form-group" >
                    <table style="width:100%">
                    <tr>
                    <td style="width:98%">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>                   
                    <asp:Label ID="Label3" runat="server" Text="Patent Name"></asp:Label>
                     <asp:TextBox ID="Ptnt_Nm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                     <div id="divwidth" style="display: none">
                        </div>
                        <%--<AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="Ptnt_Nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                        </AjaxToolkit:AutoCompleteExtender>--%>     
                        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="Ptnt_Nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                        </AjaxToolkit:AutoCompleteExtender>              
                     </td>
                    <td style="width:1%">
                   <asp:HiddenField ID="lblptnt_id" runat="server" />
                   <asp:RequiredFieldValidator runat="server" id="reqPtntNm" controltovalidate="Ptnt_Nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
                    </td>
                    </tr>                    
                    </table>
                    </div>
           <div class="form-group">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>  
                    <asp:Label ID="Label4" runat="server" Text="Hearing Aid Trial"></asp:Label>
                    <asp:DropDownList ID="ddl_complete" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddl_complete_SelectedIndexChanged" >
                        <asp:ListItem>Not Complete</asp:ListItem>
                        <asp:ListItem>Complete</asp:ListItem>                       
                        </asp:DropDownList> 
                         </td>
                      <td style="width: 1%;">
                      <asp:RequiredFieldValidator runat="server" id="reqComp" controltovalidate="ddl_complete" ErrorMessage="Required" Text="*"  SetFocusOnError="true"/>
                      </td> 
                     </tr> 
                     </table>            
                    </div>
           <div class="form-group">      
           <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>     
        <asp:Label ID="Label5" runat="server" Text="Ear Site"></asp:Label>
         <asp:RadioButtonList ID="rbte_site" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbte_site_SelectedIndexChanged" style="width:100%">
            <asp:ListItem>Right</asp:ListItem>
            <asp:ListItem>Left</asp:ListItem>
            <asp:ListItem>Both</asp:ListItem>
            <asp:ListItem>Bianaural Fitting</asp:ListItem>
         </asp:RadioButtonList>
          </td>
              <td style="width: 1%;">
              <asp:RequiredFieldValidator runat="server" id="reqSite" controltovalidate="rbte_site" ErrorMessage="Required To Select Ear Site" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
              </td> 
             </tr> 
             </table>     
        </div>
           <div class="form-group">
        <asp:Label ID="Label18" runat="server"  Text="Hearing Aid For Right Ear"></asp:Label>
        <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
        <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>
        <asp:HiddenField ID="lbl_mach_id_rt" runat="server" />
               <asp:HiddenField ID="lblPrice" runat="server" />
        </div>
           <div class="form-group">
            <asp:Label ID="Label19" runat="server"  Text="Hearing Aid Left Ear"></asp:Label>
                    <asp:DropDownList ID="ddl_comp1" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddl_model1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_model1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddl_type1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_type1_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="txt_mach1" runat="server" class="form-control"></asp:TextBox>
                    <asp:HiddenField ID="lbl_mach_id_lt" runat="server" />
                    <asp:HiddenField ID="lblPrice1" runat="server" />
                    </div>
                      
        </div>
 <%--   </ContentTemplate> 
  </asp:UpdatePanel> --%>            
        <div class="col-sm-push-0 col-md-5">
        <div class="form-group">
        </div>         
         <div class="form-group">
                     <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                      <asp:Label ID="Label8" runat="server"  Text="Hearing Aid Price"></asp:Label>
                                    <asp:TextBox ID="txtmachprice" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="addPB()"></asp:TextBox>
                                    </td> 
                                    <td style="width: 50%;">
                                     <asp:Label ID="Label20" runat="server"  Text="Received Amount"></asp:Label>
                        <asp:TextBox ID="txtrecamt" runat="server"  Text="0" class="form-control" 
                                            onkeydown="return isNumeric(event.keyCode);" onkeyup="addPB()" 
                                            ontextchanged="txtrecamt_TextChanged"></asp:TextBox>
                                    </td> 
                                </tr>                            
                        </table>
                    </div>                
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server"  Text="Due Amount" ></asp:Label>
                        <asp:TextBox ID="txtdueamt" runat="server" Text="" ReadOnly="True" class="form-control" onkeydown="return isNumeric(event.keyCode);" style="width: 50%;"></asp:TextBox>                   
                    </div>                    
                      <div class="form-group">
                         <asp:Label ID="Label11" runat="server"  Text="Ear Mould"></asp:Label>
                           <asp:RadioButtonList ID="rbtem" runat="server" RepeatDirection="Vertical"  Style="width:100%">
                            <asp:ListItem>Complete</asp:ListItem>
                            <asp:ListItem Selected="True" >Not Complete</asp:ListItem>
                            <asp:ListItem>Impression taken</asp:ListItem>
                            <asp:ListItem>Impression not taken</asp:ListItem>
                            <asp:ListItem>Not Applicable</asp:ListItem>
                           </asp:RadioButtonList>
                        </div>
                          <div class="form-group">
                          <asp:Label ID="Label12" runat="server" Text="Other Doccument are Ready or Not"></asp:Label>
                           <asp:RadioButtonList id="rbtdoc" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbtdoc_SelectedIndexChanged" style="width:100%">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>                          
                          </div> 
                           <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Comment"></asp:Label>
                        <asp:TextBox ID="txtcomment" runat="server" Text="" class="form-control" TextMode="MultiLine" ></asp:TextBox>                   
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="Next Visit"></asp:Label>                    
                    <asp:TextBox ID="txtDate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                        <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" TargetControlID="txtDate"  Format="dd/MM/yyyy" CssClass="ajax__calendar">
                        </AjaxToolkit:CalendarExtender>
                         <asp:Label ID="lblmas" runat="server" Visible="False" Font-Bold="True" class="form-control"></asp:Label>
                    </div>                     
                    <div class="btn-toolbar list-toolbar">         
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                        <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button> 
                    </div>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"  ShowMessageBox="true" EnableClientScript="true" />
                    </div>
                    </div>
       </div>      
       </div>
        </ContentTemplate> 
       </asp:UpdatePanel>  
</asp:Content>

