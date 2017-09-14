<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_trial.aspx.cs" Inherits="h_trial" Title="Hearing Aid Trial" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
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
        <h class="text-muted text-center">Hearing Aid Trial</h>
    </div>        
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:HiddenField ID="lbtrial_id" runat="server" />
            </div>
            <div class="form-group">
            <table style="width: 100%;">
            <tr>
            <td style="width: 99%;">
            <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Patent Name"></asp:Label>
             <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control"></asp:TextBox> 
             <div id="divwidth" style="display: none">
             </div>
             <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
             </AjaxToolkit:AutoCompleteExtender>                                        
             </td>
            <td style="width: 1%;">
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtptnt_nm" ErrorMessage="Required Patent Name" Text="*"  SetFocusOnError="true"/>
            <asp:HiddenField ID="lblptnt_id" runat="server" />
            </td>
            </tr>
            </table>
            </div>
            <div class="form-group">
            <asp:Label ID="Label2" runat="server">Hearing Aid Trial</asp:Label>
            <asp:DropDownList ID="ddl_complete" runat="server" AutoPostBack="True" 
                    class="form-control" 
                    onselectedindexchanged="ddl_complete_SelectedIndexChanged" >
                <asp:ListItem>Not Complete</asp:ListItem>
                <asp:ListItem>Complete</asp:ListItem> 
                <asp:ListItem>HAid Trial</asp:ListItem>                       
                </asp:DropDownList>
            </div>
            <div class="form-group">
            <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Ear Site"></asp:Label>
             <asp:RadioButtonList ID="rbte_site" runat="server" RepeatDirection="Horizontal" 
                        AutoPostBack="true" onselectedindexchanged="rbte_site_SelectedIndexChanged" 
                        style="width:100%" Enabled="False">
                <asp:ListItem>Right</asp:ListItem>
                <asp:ListItem>Left</asp:ListItem>
                <asp:ListItem>Both</asp:ListItem>
             </asp:RadioButtonList>
             </td> 
               <td style="width:1%">
               <asp:RequiredFieldValidator runat="server" id="reqSit" controltovalidate="rbte_site" ErrorMessage="Select Ear Site" Text="*"  SetFocusOnError="true"/>
               </td> 
             </tr> 
             </table>   
            </div>
            <div class="form-group">
            <asp:Label ID="Label15" runat="server" Text="Hearing Aid Id Right Ear"></asp:Label>
            <asp:DropDownList id="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>                    
            <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList> 
            <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txt_mach" runat="server" class="form-control" Visible="false"></asp:TextBox>
            <asp:HiddenField ID="lbl_mach_id_rt" runat="server" />
            </div> 
         </div>
        <div class="col-sm-push-0 col-md-5">
         <div class="form-group">
         </div>
            <div class="form-group" >
                <asp:Label ID="Label1" runat="server" Text="Hearing Aid For Left Ear"></asp:Label>
                <asp:DropDownList ID="ddl_comp1" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp1_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddl_model1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_model1_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddl_type1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_type1_SelectedIndexChanged"></asp:DropDownList>
                <asp:TextBox ID="txt_mach1" runat="server" class="form-control"></asp:TextBox>           
                <asp:HiddenField ID="lbl_mach_id_lt" runat="server" />
                <asp:Label ID="lblQty1" runat="server" Text="Label" Visible="False" class="form-control"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Label12" runat="server">Comment</asp:Label>            
                <asp:TextBox ID="txtcomment" runat="server" class="form-control" MaxLength="100" Text="" TextMode="MultiLine"></asp:TextBox>
            </div>                   
            <div class="btn-toolbar list-toolbar" >
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" class="btn btn-primary" OnClientClick="checkPrintReq()"/>
                <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" />
                <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" onclick="btnPrint_Click" Visible="False"/>                        
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

