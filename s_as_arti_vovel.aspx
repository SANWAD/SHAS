<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_arti_vovel.aspx.cs" Inherits="Clinical_Forms_s_as_arti_vovel" Title="Articulation Vovels"  MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
  <div class="panel panel-default"> 
  <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>    
    <div class="panel-heading" >
            <h class="text-muted text-center">Articulation Consonants 1</h>
        </div>  
        <div><strong><asp:Label ID="Label2" runat="server"  ForeColor="Red" Text="Running Page No  3..........................................................................................Total Pages 6"></asp:Label></strong></div> 
    <div class="panel-body">              
                        <div class="col-sm-push-0 col-md-6">
                 <div class="form-group" style="text-align:center">            
                    <asp:Button ID="Button1" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_pre1_Click" class="btn btn-primary"  />
                    <asp:Button ID="Button2" runat="server" class="btn btn-primary" OnClick="btn_save_Click1" Text="Save" />
                    <asp:Button ID="Button3" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt1_Click" class="btn btn-primary" />
                    <asp:Button ID="btnPosAll" runat="server" class="btn btn-primary" OnClick="btnPosAll_Click" Text="Position All"/> 
                     <asp:HiddenField ID="lbl_asid" runat="server" />
                     <asp:HiddenField ID="lbl_aptid" runat="server" />
                     <asp:HiddenField ID="lbl_ptntid" runat="server" />
                 <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:RadioButtonList ID="rbtn_vovel_apl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtn_vovel_apl_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem >Applicable</asp:ListItem>
                        <asp:ListItem >Normal</asp:ListItem>                                    
                    </asp:RadioButtonList>   
                   <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqrbtn_vovel" ControlToValidate="rbtn_vovel_apl" runat="server" ErrorMessage="Required to Select the Option" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
                </table>           
                 </div>
     <div class="form-group">
        <strong><span>
            <table class="table table-hover table-responsive" style="width:100%">
                <tbody>                   
                    <tr>
                        <td style="width:30%">
                        </td>
                        <td>
                            <label class="h5">Position</label>
                        </td>
                        <td>
                        </td>
                        <td>
                        <label class="h5"> Type</label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Image ID="Image141" runat="server" Height="45px" ImageUrl="~/Images/Vovels/a.gif" Width="76px" />
                        </td>
                        <td style="width:30%">
                            <asp:DropDownList ID="ddl_a_pos" runat="server"  class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image241" runat="server" Height="45px" ImageUrl="~/Images/Vovels/a.gif"
                                Width="76px" />
                        </td>
                        <td >
                            <asp:RadioButtonList ID="rbtn_a" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image341" runat="server" ImageUrl="~/Images/Vovels/aa.gif" Width="76px" />
                        </td>
                        <td style="width:30%">
                            <asp:DropDownList ID="ddl_aa_pos" runat="server"  class="form-control" Width="200px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image414" runat="server" ImageUrl="~/Images/Vovels/aa.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_aa" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image54" runat="server" ImageUrl="~/Images/Vovels/i.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_i_pos" runat="server" class="form-control" Width="200px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image61" runat="server" ImageUrl="~/Images/Vovels/i.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_i" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected ="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image71" runat="server" ImageUrl="~/Images/Vovels/I1.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_i1_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image814" runat="server" ImageUrl="~/Images/Vovels/I1.gif" Width="75px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_i1" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image914" runat="server" ImageUrl="~/Images/Vovels/u.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_u_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image1041" runat="server" ImageUrl="~/Images/Vovels/u.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_u" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1141" runat="server" ImageUrl="~/Images/Vovels/u1.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_u1_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image1241" runat="server" ImageUrl="~/Images/Vovels/u1.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_u1" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1341" runat="server" ImageUrl="~/Images/Vovels/e.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_e_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image1441" runat="server" ImageUrl="~/Images/Vovels/e.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_e" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1511" runat="server" ImageUrl="~/Images/Vovels/ai.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ai_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image1611" runat="server" ImageUrl="~/Images/Vovels/ai.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ai" runat="server" RepeatDirection="Horizontal" style="width:100%">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1711" runat="server" ImageUrl="~/Images/Vovels/o.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_o_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image1811" runat="server" ImageUrl="~/Images/Vovels/o.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_o" runat="server" RepeatDirection="Horizontal" Width="574px" ForeColor="#404040">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1911" runat="server" ImageUrl="~/Images/Vovels/au.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_au_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image2011" runat="server" ImageUrl="~/Images/Vovels/au.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_au" runat="server" RepeatDirection="Horizontal" Width="574px" ForeColor="#404040">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2111" runat="server" ImageUrl="~/Images/Vovels/an.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_an_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image2211" runat="server" ImageUrl="~/Images/Vovels/an.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_an" runat="server" RepeatDirection="Horizontal" Width="576px" ForeColor="#404040">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2311" runat="server" ImageUrl="~/Images/Vovels/ah.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ah_pos" runat="server" style="width:100%" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                               <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image2411" runat="server" ImageUrl="~/Images/Vovels/ah.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ah" runat="server" RepeatDirection="Horizontal" style="width:100%" class="form-control">
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>   
                                  
                    <tr>
                    <td colspan="2">
                            <div class="form-group">
                               <asp:CustomValidator ID="page_validate_wiz3" runat="server" ErrorMessage="Please Check Page Again...." Font-Bold="True" Font-Names="Georgia" Font-Size="14pt" OnServerValidate="page_validate_wiz3_ServerValidate"></asp:CustomValidator>
                            </div>
                        </td> 
                        <td class="text-right" colspan="2">                          
                                    <asp:Button ID="btn_prev" runat="server" class="btn btn-primary" Text="Previous Page" CausesValidation="False" OnClick="btn_prev_Click" />
                                    <asp:Button ID="btn_save" runat="server" class="btn btn-primary" Text="Save" OnClick="btn_save_Click1" />
                                    <asp:Button ID="btn_nxt" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt_Click" class="btn btn-primary" />                                                                   
                        </td> 
                    </tr>
                </tbody>
            </table>
        </span></strong>
    </div>
  </div>               
 </div>   
    </ContentTemplate>
 </asp:UpdatePanel>
  </div>         
</asp:Content>
