<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_m_order.aspx.cs" Inherits="h_m_order" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
 <ContentTemplate>
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Order</h>
        </div>
        <div class="panel-body">
             <div class="col-sm-push-0 col-md-5"> 
             <div class="form-group">
             <asp:HiddenField ID="lblord_no" runat="server" />
             <asp:HiddenField ID="lblitem_no" runat="server" />
             </div>             
             <div class="form-group"> 
             <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
             <asp:Label ID="Label2" runat="server" Text="Order Type"></asp:Label>
              <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="true" class="form-control"  onselectedindexchanged="ddlordertype_SelectedIndexChanged">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Accesorries</asp:ListItem>
                <asp:ListItem>Hearing Aid</asp:ListItem>
              </asp:DropDownList>
             </div>
             <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Hearing Aid"></asp:Label>
                 <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" 
                     class="form-control" 
                     onselectedindexchanged="ddl_comp_SelectedIndexChanged" 
                     AppendDataBoundItems="True"></asp:DropDownList>
                 <asp:DropDownList ID="ddl_mach_model" runat="server" 
                     AppendDataBoundItems="true" AutoPostBack="True" class="form-control" 
                     onselectedindexchanged="ddl_mach_model_SelectedIndexChanged" ></asp:DropDownList>
                 <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" 
                     AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged" ></asp:DropDownList>
                <asp:TextBox ID="txt_mach" runat="server" class="form-control" ></asp:TextBox>
                 <asp:HiddenField ID="lblmach_id" runat="server" />
                <asp:DropDownList ID="ddlacc_desc" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
            </div>            
            </div>
            <div class="col-sm-push-0 col-md-5">
             <div class="form-group">
             <table style="width:100%">
             <tr>
             <td style="width:99%"> 
             <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text="Quantity"></asp:Label>
             <asp:TextBox ID="txtqty" runat="server" MaxLength="10" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
              </td>
             <td style="width:1%">
             <asp:RequiredFieldValidator runat="server" id="reqQty" controltovalidate="txtqty" ErrorMessage="Required Quantity" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
             </td>  
             </tr>
             </table>
             </div>
             <div class="form-group">
             <asp:Label ID="Label5" runat="server" Text="Order By"></asp:Label>
             <asp:TextBox ID="txtorder_by" runat="server" MaxLength="50" class="form-control"></asp:TextBox>
             </div>
             <div class="btn-toolbar list-toolbar">
                 <asp:Button ID="btnadd" runat="server" Text="Add Item" OnClick="btnadd_Click" class="btn btn-primary"></asp:Button>
                 <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"></asp:Button>
             </div>
              <div class="form-group">
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
             </div> 
            <div class="col-sm-push-0 col-md-5">
            <div class="form-group ">
            <asp:GridView ID="GridView1" runat="server" Width="763px" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
            <Columns>
                <asp:BoundField DataField="" HeaderText="Order No" />
                <asp:BoundField DataField="" HeaderText="Item No" />
                <asp:BoundField DataField="" HeaderText="Order Type" />
                <asp:BoundField DataField="" HeaderText="Machine Id" />
                <asp:BoundField DataField="" HeaderText="Quantity" />
                <asp:BoundField DataField="" HeaderText="Order By" />
            </Columns>               
            </asp:GridView>
            </div> 
            </div>
             </div>
        </div>
         </ContentTemplate> 
 </asp:UpdatePanel> 
 </div>        
</asp:Content>

