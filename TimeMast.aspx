<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="TimeMast.aspx.cs" Inherits="TimeMast" Title="Time Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<script runat="server">    
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Time Master</h>
        </div>
        <div class="panel-body" >
            <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:HiddenField ID="lblTime_id" runat="server"/>                       
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">                
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Time Interval"></asp:Label>                   
                <asp:TextBox ID="txtApt_time" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqCode" controltovalidate="txtApt_time" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td>
                </tr>
                </table>                
                </div>                      
                <div class="btn-toolbar list-toolbar">                
                 <asp:Button ID="btn_save" runat="server" Text="SAVE" OnClick="btn_save_Click" class="btn btn-primary"/>    
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" onclientclick="return askConfirm()" />
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate> 
 </asp:UpdatePanel> 
</asp:Content>
