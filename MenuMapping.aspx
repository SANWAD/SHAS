<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="MenuMapping.aspx.cs" Inherits="MenuMapping" Title="Menu Mapping" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
<script type="text/javascript" src="lib/AjaxCallBack.js"></script>
    <script src="lib/JScript_Refresh.js" type="text/javascript"></script>
    <script type="text/javascript" src="lib/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript"  language="javascript">
        function GetSelectedValue() {
            var chkBox = document.getElementById("<%=chkSubMenu.ClientID %>");
            var checkbox = chkBox.getElementsByTagName('input');
            var objTextBox = document.getElementById('<%=lblChk.ClientID %>');
            document.write(chkBoxText);
            var counter = 0;
            objTextBox.value = "";
            for (var i = 0; i < checkbox.length; i++) {              
                if (checkbox[i].checked) {
                    var chkBoxText = checkbox[i].parentNode.getElementsByTagName('label');                    
                    if (objTextBox.value == "") {
                        objTextBox.value = chkBoxText[0].innerHTML;
                        document.write(objTextBox.value);
                    }
                    else {
                        objTextBox.value = objTextBox.value  + ", " + chkBoxText[0].innerHTML;
                        document.write(objTextBox.value);
                    }

                }
                
            }
        }          
</script>
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Menu Mapping</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-7">
            <div class="form-group">
                <asp:HiddenField ID="lbl_MAPID" runat="server"/>                       
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">                
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="User"></asp:Label> 
                    <asp:DropDownList ID="ddlUser" runat="server" class="form-control" onselectedindexchanged="ddlUser_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqUser" controltovalidate="ddlUser" ErrorMessage="Required to select User" Text="*"  SetFocusOnError="true"/>
                </td>
                </tr>
                </table>                
                </div>
               
                <div class="form-group">
                        <asp:Label ID="lblMastMenu" runat="server" Text="Master Menu"></asp:Label>
                        <asp:HiddenField ID="MenuIdMast" runat="server" />
                        <div style="width:100%">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Height="200px" class="form-control">
                    <asp:CheckBoxList ID="chkMastMenu" runat="server" RepeatDirection="Vertical" style="width:100%" onselectedindexchanged="chkMastMenu_SelectedIndexChanged" AutoPostBack="true"></asp:CheckBoxList>
                        </asp:Panel>
                        </div>
                </div> 
                 <div class="form-group">               
                        <asp:Label ID="lblMenu" runat="server" Text="Sub Menu"></asp:Label> 
                        <div style="width:100%"> 
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto"  Height="200px" class="form-control">                                       
                        <asp:CheckBoxList ID="chkSubMenu" runat="server" RepeatDirection="Vertical" style="width:100%" onselectedindexchanged="chkSubMenu_SelectedIndexChanged" ><%--AutoPostBack="true"--%></asp:CheckBoxList>
                        </asp:Panel>
                        </div> 
                 <div class="form-group">
                  <asp:Label ID="Label2" runat="server" Text="ISActive"></asp:Label>
                  <asp:CheckBox ID="ChkIsAct" runat="server" class="form-control"/>
                   <asp:Label ID="lblChk" runat="server" Visible="false"></asp:Label><asp:Label ID="lblChk1" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="lblChild_MapId" runat="server" Visible="False"></asp:Label>
                  </div>               
                </div>      
                 <div>
                    <asp:Label ID="lblMsg" runat="server" Text="User Name Already Exists" ForeColor="Red" Visible="false"></asp:Label>
                </div>             
                <div class="btn-toolbar list-toolbar">                
                 <asp:Button ID="btn_save" runat="server" Text="SAVE" OnClick="btn_save_Click" class="btn btn-primary"/>    
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" onclientclick="return askConfirm()" />
                </div>
                <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" EnableClientScript="true" />
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate> 
 </asp:UpdatePanel> 
</asp:Content>
