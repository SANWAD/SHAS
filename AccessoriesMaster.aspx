<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="AccessoriesMaster.aspx.cs" Inherits="AccessoriesMaster" Title="Hearing Aid Accessories Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
   <ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Accessories Master</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group"> 
                     <asp:HiddenField ID="lbl_ac_id" runat="server" />      
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Hearing Aid Accessory Description"></asp:Label>
                        &nbsp;<asp:TextBox ID="txt_ac_desc" runat="server" class="form-control" 
                            ontextchanged="txt_ac_desc_TextChanged" AutoPostBack="true" ></asp:TextBox></td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator ID="reqName" ControlToValidate="txt_ac_desc" runat="server" ErrorMessage="Required Accessories Name" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td> 
                </tr> 
                </table> 
                </div>
                <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Accessories Is Already Exists" 
                        ForeColor="Red" Visible="false"  ></asp:Label>
                </div>
                <div class="form-group">     
                <table style="width:100%">
                <tr>
                <td style="width:99%">           
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Purchase Price"></asp:Label>
                    <asp:TextBox ID="txtPrice" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                     </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPrice" runat="server" ErrorMessage="Required Accessories Price" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td> 
                </tr> 
                </table> 
                </div>
                <div class="form-group">     
                <table style="width:100%">
                <tr>
                <td style="width:99%">           
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="Sale Price"></asp:Label>
                    <asp:TextBox ID="txtSale" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                     </td>
                <td style="width:1%">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSale" runat="server" ErrorMessage="Required Accessories Sale Price" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td> 
                </tr> 
                </table> 
                </div>
                 <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Stock Transfer"></asp:Label>
                    <asp:DropDownList ID="DRPReturn" runat="server" AutoPostBack="True" class="form-control">
                        <asp:ListItem Selected="True">Purchase</asp:ListItem>
                        <asp:ListItem>Stock Transfer</asp:ListItem>
                        <asp:ListItem>Stock Return From Center</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-push-0 col-md-5">  
            <div class="form-group">
            </div>      
                <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Add Quantity"></asp:Label>
                    <asp:TextBox ID="txtQty" runat="server" class="form-control"></asp:TextBox>
                    <asp:Label ID ="lblQty" runat="server" Text=""></asp:Label>
                </div>
                <%--<div class="form-group">                    
                    <asp:Label ID="Label6" runat="server" Text="Center"></asp:Label>                        
                                <asp:TextBox ID="txtptntNm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                <div id="divwidth" style="display: none">
                                </div>
                                <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptntNm" FirstRowSelected="true" ServiceMethod="GetEmpCode" ServicePath="../WebService1.asmx" MinimumPrefixLength="3" EnableCaching="true" CompletionInterval="10" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                                </AjaxToolkit:AutoCompleteExtender>                         
                </div>--%>
                <div class="btn-toolbar list-toolbar">               
                <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" class="btn btn-primary" />
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" onclientclick="return askConfirm()" onclick="btnCancel_Click" CausesValidation="false"/>                   
                </div>
                <div class="form-group"> 
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                </div> 
            </div>
        </div>
    </div>     
    </ContentTemplate> 
</asp:UpdatePanel>
</asp:Content>
