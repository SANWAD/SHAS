<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="MachineMaster.aspx.cs" Inherits="MachineMaster" Title="Hearing Aid Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Hearing Aid Master</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-4">
                <div class="form-group">
                <asp:HiddenField ID="lblmach_id" runat="server" />
                
                     <asp:Label ID="Label1" runat="server" Text="Hearing Aid Code" > </asp:Label> 
                    <asp:TextBox ID="lblmach_id1" runat="server" class="form-control"></asp:TextBox>  
                </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
                <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Hearing Aid Company"> </asp:Label>                       
                        <%--<asp:TextBox ID="txtmachcomp" runat="server" class="form-control"></asp:TextBox>--%> 
                        <asp:DropDownList id="ddl_comp" runat="server" class="form-control"></asp:DropDownList>                       
                         </td> 
                    <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqMachComp" controltovalidate="ddl_comp" ErrorMessage="Required Hearing Aid Company" Text="*"  SetFocusOnError="true"/>
                    </td> 
                    </tr> 
                    </table>  
                </div> 
          </ContentTemplate>
        </asp:UpdatePanel>                
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Hearing Aid Model"> </asp:Label> 
                    <asp:TextBox ID="txtmodel_no" runat="server" class="form-control"></asp:TextBox>
                     </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator runat="server" id="reqModel" controltovalidate="txtmodel_no" ErrorMessage="Required Hearing Aid Model" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                </td> 
                </tr> 
                </table> 
                </div>
                <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                        <asp:Label ID="Label5" runat="server" Text="Hearing Aid Type"> </asp:Label> 
                        <asp:TextBox ID="txtmach_type" runat="server" class="form-control" 
                            AutoPostBack="true" ontextchanged="txtmach_type_TextChanged"></asp:TextBox>                        
                        </td> 
                       <td style="width:1%">
                        <asp:RequiredFieldValidator runat="server" id="reqMtype" controltovalidate="txtmach_type" ErrorMessage="Required Hearing Aid Type" Text="*"  SetFocusOnError="true"/>
                        </td>
                        </tr> 
                     </table>                    
                </div>
                <div>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Hearing Aid Already Exist" Visible="False"></asp:Label>
                </div>
                <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Hearing Aid Description"> </asp:Label>                        
                    <asp:TextBox ID="txtmachdesc" runat="server" class="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </div>
                 <div class="form-group">
                               <asp:Label ID="Label7" runat="server" Text="Hearing Aid Quantity"> </asp:Label>                             
                                <asp:RadioButtonList ID="rbtReturn" runat="server" class="radio" 
                                    AutoPostBack="True" style="width:100%" RepeatDirection="Vertical" >
                                    <asp:ListItem Selected="True">Purchase</asp:ListItem>
                                    <asp:ListItem>Purchase Rtn</asp:ListItem>
                                    <asp:ListItem>Stock Trn</asp:ListItem>
                                    <asp:ListItem>Stock Rtn From Center</asp:ListItem>
                                </asp:RadioButtonList>
                           </div>
            </div>
            <div class="col-sm-push-0 col-md-4">
                           
              <%-- <div class="form-group">
               <asp:Label ID="Label8" runat="server" Text="Center"> </asp:Label> 
                <div class="form-control">                                  
                      <asp:TextBox ID="Center" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>                                  
                        <AjaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="Center" FirstRowSelected="true" ServiceMethod="GetEmpCode" ServicePath="/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="10" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth">
                        </AjaxToolkit:AutoCompleteExtender>
                    </div>   
               </div> --%>
                
                <div class="form-group"><table style="width:100%"><tr><td style="width:50%">
                    <asp:Label ID="Label9" runat="server" Text="Purchase Price"> </asp:Label> 
                    <asp:TextBox ID="txtprice" runat="server" MaxLength="10" class="form-control" Text="" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </td>
                    <td style="width:50%">
                    <asp:Label ID="Label17" runat="server" Text="Sale Price"> </asp:Label> 
                    <asp:TextBox ID="txtSale" runat="server" MaxLength="10" class="form-control" Text="" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox></td>
                    </tr></table>
                </div>
                <div class="form-group">
                <table style="width:100%"><tr><td style="width:50%">
                <asp:Label ID="Label8" runat="server" Text="Quantity"> </asp:Label> <asp:Label ID="lblQty" runat="server" ></asp:Label>
                    <asp:TextBox ID="txtAdd" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </td> 
                    <td style="width:50%">
                    <asp:Label ID="Label10" runat="server" Text="Battery Size"> </asp:Label> 
                    <asp:TextBox ID="txtBtrSiz" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                    </td> 
                    </table> 
                </div>
                <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Channel"> </asp:Label> 
                    <asp:TextBox ID="txtChan" runat="server" Class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Gain"> </asp:Label> 
                    <asp:TextBox ID="txtGain" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label13" runat="server" Text="Fitting Range"> </asp:Label> 
                    <asp:TextBox ID="txtFit_Ran" runat="server" Class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
                <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Technology"> </asp:Label> 
                    <asp:DropDownList ID="ddlTech" runat="server" class="form-control">
                        <asp:ListItem>Analog</asp:ListItem>
                        <asp:ListItem Selected="true">Trimer Digital</asp:ListItem>
                        <asp:ListItem>Programmable Digital</asp:ListItem>
                        <asp:ListItem>FM</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                        <asp:Label ID="Label15" runat="server" Text="Currancy Type"> </asp:Label> 
                    <asp:DropDownList ID="ddl_cur" runat="server" class="form-control">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Selected="TRUE">Rupees</asp:ListItem>
                        <asp:ListItem>Dollar</asp:ListItem>
                        <asp:ListItem>Euro</asp:ListItem>
                        <asp:ListItem>Australian Dollar</asp:ListItem>
                        <asp:ListItem>Pound</asp:ListItem>
                        <asp:ListItem>Yuan</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="btn-toolbar list-toolbar">
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                    <ContentTemplate>              
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                    <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>                   
                   </ContentTemplate> 
                </asp:UpdatePanel> 
                </div>     
            </div>
            <div class="col-sm-push-0 col-md-4">
                <div class="form-group">
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
