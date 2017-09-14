<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Quatation.aspx.cs" Inherits="Quatation" Title="Quotation"  MaintainScrollPositionOnPostback="false"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" >
    function Vatcal() {
        var Price = document.getElementById('<%=txtmachprice.ClientID %>').value;
        var Price1 = document.getElementById('<%=txtmachprice1.ClientID %>').value;
        var Vat = document.getElementById('<%=txtvat.ClientID %>').value;
        var VatCal = ((parseInt(Price) + parseInt(Price1)) * parseInt(Vat)) / 100;
        var Result = (VatCal + parseInt(Price) + parseInt(Price1)) 
        if (!isNaN(Result)) {
            document.getElementById('<%=txttot.ClientID %>').value = Result;
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




<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
 <div class="panel panel-default">  
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Quotation</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
        <div class="form-group">
        <asp:HiddenField ID="lblquat_id" runat="server" />
        </div>       
        <div class="form-group">
         <table style="width:100%">
                    <tr>
                    <td style="width:98%">  
                    <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>              
                    <asp:Label ID="Label2" runat="server" Text="Patent Name"></asp:Label>
  <div>  
        <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control"></asp:TextBox> 
         <div id="divwidth" style="display:list-item">
         </div>
        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="divwidth"  UseContextKey="true">
        </AjaxToolkit:AutoCompleteExtender>
        </div>        
     </td>
    <td style="width:2%">
    <asp:HiddenField ID="lblptnt_id" runat="server" />
    <asp:RequiredFieldValidator runat="server" id="reqPtNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
    </td>
    </tr>                    
    </table>
  </div>
  <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Ear Site"></asp:Label>
         <asp:RadioButtonList ID="rbte_site" runat="server" 
            RepeatDirection="Horizontal" Style="width:100%" 
            onselectedindexchanged="rbte_site_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem Selected="True" >Right</asp:ListItem>
            <asp:ListItem>Left</asp:ListItem>
            <asp:ListItem>Both</asp:ListItem>
           <%-- <asp:ListItem>Bianaural Fitting</asp:ListItem>--%>
         </asp:RadioButtonList>
        </div>
        <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Hearing Aid For Right Ear"></asp:Label> 
        <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="true" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged" Enabled="false"></asp:DropDownList>                        
        <asp:TextBox ID="txt_mach" runat="server" class="form-control" ></asp:TextBox>        
        <asp:HiddenField ID="lblmach_id" runat="server" />        
        </div>
        <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="Hearing Aid Price"></asp:Label>        
         <asp:TextBox ID="txtmachprice" runat="server" class="form-control" onkeyup="Vatcal()" Text="0" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
         <%-- AutoPostBack ="true" ontextchanged="txtmachprice_TextChanged" --%>
        </div>
       
        </div>
        <div class="col-sm-push-0 col-md-5">       
         <div class="form-group" >
            <asp:Label ID="Label1" runat="server" Text="Hearing Aid For Left Ear"></asp:Label>
            <asp:DropDownList ID="ddl_comp1" runat="server" AutoPostBack="True" 
                class="form-control" onselectedindexchanged="ddl_comp1_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddl_model1" runat="server" AppendDataBoundItems="true" 
                AutoPostBack="True" class="form-control" 
                onselectedindexchanged="ddl_model1_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddl_type1" runat="server" AppendDataBoundItems="true" 
                AutoPostBack="True" class="form-control" 
                onselectedindexchanged="ddl_type1_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txt_mach1" runat="server" class="form-control"></asp:TextBox>           
            <asp:HiddenField ID="lbl_mach_id_lt" runat="server" />
            <asp:Label ID="lblQty1" runat="server" Text="Label" Visible="False" class="form-control"></asp:Label>
            <%--<asp:HiddenField ID="lblSale_price1" runat="server" />--%>
            </div> 
            <div class="form-group">
        <asp:Label ID="Label9" runat="server" Text="Hearing Aid Price"></asp:Label>        
         <asp:TextBox ID="txtmachprice1" runat="server" class="form-control" onkeyup="Vatcal()" Text="0" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
         <%-- AutoPostBack ="true" ontextchanged="txtmachprice_TextChanged" --%>
        </div> 
        <%--<div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Audio Ratio"></asp:Label>
         <asp:TextBox ID="txtaudrat" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
        </div>--%>
        <div class="form-group">
        <asp:Label ID="Label7" runat="server" Text="Vat"></asp:Label>
         <asp:TextBox ID="txtvat" runat="server" class="form-control"  onkeyup="Vatcal()" 
                Text="0" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox> 
         <%--AutoPostBack ="true" ontextchanged="txtmachprice_TextChanged"     --%>
        </div>
        <div class="form-group">
        <asp:Label ID="Label8" runat="server" Text="Total"></asp:Label>
         <asp:TextBox ID="txttot" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="btn-toolbar list-toolbar">                      
             <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"></asp:Button>
             <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>    
             <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" onclick="btnPrint_Click" Enabled="False"></asp:Button>                                                                
        </div>
        <div class="form-group">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
        </div>
        </div> 
        </div>         
      </div> 
  </ContentTemplate> 
</asp:UpdatePanel> 
</asp:Content>

