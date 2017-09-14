<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_m_inward.aspx.cs" Inherits="h_m_inward" Title="Hearing Aid Inward" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
  <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
<ContentTemplate>  
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Inward</h>
        </div>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">       
                    <div class="form-group">                     
                     <asp:HiddenField ID="lblhm_inw_id" runat="server" />
                    </div>                   
                    <div class="form-group">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Inward Type"></asp:Label>
                     <asp:DropDownList ID="ddlordertype" runat="server" class="form-control" onselectedindexchanged="ddlordertype_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Hearing Aid</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="form-group">
                     <table style="width: 100%;">
                    <tr>
                    <td style="width: 98%;">
                    <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label4" runat="server" Text="Order No"></asp:Label>
                     <asp:TextBox ID="txt_ordno" runat="server" class="form-control" ></asp:TextBox>
                      </td>
                      <td style="width:2%;">
                      <asp:RequiredFieldValidator runat="server" id="reqPtntNm" controltovalidate="txt_ordno" ErrorMessage="Required Order No" Text="*"  SetFocusOnError="true"/>
                      </td> 
                     </tr> 
                     </table> 
                     </div>         
                      <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Hearing Aid"></asp:Label>                           
                             <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" 
                                class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="ddl_mach_model" runat="server" 
                                AppendDataBoundItems="true" AutoPostBack="True" class="form-control" 
                                onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="ddl_mach_type" runat="server" 
                                AppendDataBoundItems="true" AutoPostBack="True" class="form-control" 
                                onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
                            <asp:TextBox ID="txt_mach" runat="server" class="form-control" ></asp:TextBox>
                          <asp:HiddenField ID="lblmach_id" runat="server" />
                        </div>          
                        </div>
                        <div class="col-sm-push-0 col-md-5">                       
                     <div class="form-group">
                     <table style="width:100%">
                     <tr>
                     <td style="width:99%"> 
                     <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                     <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
                     <asp:TextBox ID="txtqty" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                     </td>
                     <td style="width:1%">
                     <asp:RequiredFieldValidator runat="server" id="reqQty" controltovalidate="txtqty" ErrorMessage="Required Quantity" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                     </td>  
                     </tr>
                     </table>
                    </div>  
                     <div class="form-group">
                     <asp:Label ID="Label7" runat="server" Text="Serial No From" Visible="false" ></asp:Label>
                     <asp:TextBox ID="txtsrno_from" runat="server" class="form-control" Visible="false">0</asp:TextBox>
                    </div>    
                    <div class="form-group">
                     <asp:Label ID="Label8" runat="server" Text="Serial No To" Visible="false"></asp:Label>
                     <asp:TextBox ID="txtsrno_to" runat="server" class="form-control" Visible="false">0</asp:TextBox>
                    </div>                
                   <div class="btn-toolbar list-toolbar">
                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>                        
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" onclick="btnCancel_Click"></asp:Button>
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

