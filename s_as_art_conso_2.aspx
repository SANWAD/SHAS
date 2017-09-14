<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_art_conso_2.aspx.cs" Inherits="Clinical_Forms_s_as_art_conso_2" Title="Articulation Consonants 2" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">    
        <div class="panel-heading">
            <h class="text-muted text-center">Articulation Consonants 2</h>
        </div>
        <div><strong><asp:Label ID="Label2" runat="server"  ForeColor="Red" Text="Running Page No  5..........................................................................................Total Pages 6"></asp:Label></strong></div>
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>
        <div style="text-align:center">
            
                    <asp:Button ID="btn_pre1" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_pre1_Click" class="btn btn-primary" />
                    <asp:Button ID="Save" runat="server" class="btn btn-primary" OnClick="btn_save_Click" Text="Save" />                        
                    <asp:Button ID="btn_nxt1" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt1_Click" class="btn btn-primary" />           
                    <asp:Label ID="lblDate" runat="server" class="form-control"></asp:Label>
        </div>
        <div class="form-control">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
        </div>
        <div class="panel-body">
            <div class="form-group">
                        <div class="col-sm-push-0 col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnPsit" runat="server" class="btn btn-primary" OnClick="btnPsit_Click" Text="Position All"/>
                            </div>
                        </div>
                        <div class="col-sm-push-0 col-md-6">
                            <div class="form-group"> 
                                <asp:HiddenField ID="lbl_asid" runat="server" />  
                                <asp:HiddenField ID="lbl_aptid" runat="server" />
                                <asp:HiddenField ID="lbl_ptntid" runat="server" />                         
                        <table style="width:100%">
                        <tr>
                        <td style="width:99%">
                            <asp:RadioButtonList Style="width:100%" ID="rbtn_art_conso2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtn_art_conso2_SelectedIndexChanged" RepeatDirection="Horizontal" >
                                <asp:ListItem>Applicable</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>Not Applicable</asp:ListItem>
                            </asp:RadioButtonList>
                       </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqrbtn_art" ControlToValidate="rbtn_art_conso2" runat="server" ErrorMessage="Required To Select the Option" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
                </table> 
                            </div>
                        </div>
            </div>
            <table class="table table-hover table-responsive">
                <tbody>
                    <tr>
                        <td class="" style="width: 98px">
                        </td>
                        <td class="" >
                            <label class="h4">
                                Position</label>
                        </td>
                        <td class="" style="width: 99px">
                        </td>
                        <td >
                            <label class="h4">
                                Type</label>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px" >
                            <asp:Image ID="Image3331" runat="server" ImageUrl="~/Images/conso/ba.gif" Width="86px" />
                        </td>
                        <td class="" >                            
                        <asp:DropDownList ID="ddl_ba_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px" >
                            <asp:Image ID="Image413" runat="server" ImageUrl="~/Images/conso/ba.gif" Height="23px" />
                        </td>
                        <td >
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_ba" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image5311" runat="server" ImageUrl="~/Images/conso/bha.gif" Width="88px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_bha_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px" >
                            <asp:Image ID="Image631" runat="server" ImageUrl="~/Images/conso/bha.gif" Height="24px" />
                        </td>
                        <td >
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_bha" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px" >
                            <asp:Image ID="Image731" runat="server" ImageUrl="~/Images/conso/ma.gif" Width="89px" />
                        </td>
                        <td class="" >
                        <asp:DropDownList ID="ddl_ma_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px" >
                            <asp:Image ID="Image831" runat="server" ImageUrl="~/Images/conso/ma.gif" Width="81px" />
                        </td>
                        <td>                   
                                    <asp:RadioButtonList Style="width:100%" ID="rbtn_ma" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem>Substitutation</asp:ListItem>
                                        <asp:ListItem>Omission</asp:ListItem>
                                        <asp:ListItem>Distortion</asp:ListItem>
                                        <asp:ListItem>Addition</asp:ListItem>
                                        <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                        <asp:ListItem>Normal</asp:ListItem>
                                    </asp:RadioButtonList>
                          
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image931" runat="server" ImageUrl="~/Images/conso/ya.gif" Width="93px" />
                        </td>
                        <td class="">
                       <asp:DropDownList ID="ddl_ya_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image1031" runat="server" ImageUrl="~/Images/conso/ya.gif" Width="104px" />
                        </td>
                        <td>  
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_ya" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image1131" runat="server" ImageUrl="~/Images/conso/ra.gif" Width="91px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_ra_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image1231" runat="server" ImageUrl="~/Images/conso/ra.gif" Width="97px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_ra" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image1331" runat="server" ImageUrl="~/Images/conso/la1.gif" Width="88px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_la_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image1431" runat="server" ImageUrl="~/Images/conso/la1.gif" Width="94px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_la" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image45" runat="server" ImageUrl="~/Images/conso/va.gif" Width="87px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_va_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image46" runat="server" ImageUrl="~/Images/conso/va.gif" Width="93px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_va" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image1531" runat="server" ImageUrl="~/Images/conso/sha.gif" Width="87px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_sha_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image1631" runat="server" ImageUrl="~/Images/conso/sha.gif" Width="90px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_sha" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image1731" runat="server" ImageUrl="~/Images/conso/pot_sha.gif" Width="85px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_pot_sha_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image1831" runat="server" ImageUrl="~/Images/conso/pot_sha.gif" Width="93px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_pot_sha" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image1931" runat="server" ImageUrl="~/Images/conso/sa.gif" Width="87px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_sa_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image2031" runat="server" ImageUrl="~/Images/conso/sa.gif" Width="90px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_sa" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image2131" runat="server" ImageUrl="~/Images/conso/ha.gif" Width="88px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_ha_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image2231" runat="server" ImageUrl="~/Images/conso/ha.gif" Width="90px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_ha" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image2331" runat="server" ImageUrl="~/Images/conso/la.gif" Width="96px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_la1_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image2431" runat="server" ImageUrl="~/Images/conso/la.gif" Width="92px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_la1" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image2531" runat="server" ImageUrl="~/Images/conso/ksha.gif" Width="94px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_ksha_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image2631" runat="server" ImageUrl="~/Images/conso/ksha.gif" Width="97px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_ksha" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image2731" runat="server" ImageUrl="~/Images/conso/gya.gif" Width="91px" />
                        </td>
                        <td class="">
                        <asp:DropDownList ID="ddl_gya_pos" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Initial</asp:ListItem>
                            <asp:ListItem>Middle</asp:ListItem>
                            <asp:ListItem>Final</asp:ListItem>
                            <asp:ListItem>Initial-Middle</asp:ListItem>
                            <asp:ListItem>Initial-Final</asp:ListItem>
                            <asp:ListItem>Middle-Final</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image2831" runat="server" ImageUrl="~/Images/conso/gya.gif" Width="95px" />
                        </td>
                        <td>
                            <asp:RadioButtonList Style="width:100%" ID="rbtn_gya" runat="server" RepeatDirection="Horizontal" >
                                <asp:ListItem>Substitutation</asp:ListItem>
                                <asp:ListItem>Omission</asp:ListItem>
                                <asp:ListItem>Distortion</asp:ListItem>
                                <asp:ListItem>Addition</asp:ListItem>
                                <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="" style="width: 98px">
                            <asp:Image ID="Image2931" runat="server" ImageUrl="~/Images/conso/sra.gif" Width="91px" />
                        </td>
                        <td class="">
                            <asp:DropDownList ID="ddl_sra_pos" runat="server" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="" style="width: 99px">
                            <asp:Image ID="Image3031" runat="server" ImageUrl="~/Images/conso/sra.gif" Width="94px" />
                        </td>
                        <td>
                        <asp:RadioButtonList Style="width:100%" ID="rbtn_sra" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Substitutation</asp:ListItem>
                            <asp:ListItem>Omission</asp:ListItem>
                            <asp:ListItem>Distortion</asp:ListItem>
                            <asp:ListItem>Addition</asp:ListItem>
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                            <div class="form-group">
                                <asp:Label ID="lbl_msg3" runat="server" Text="Please Check The Page Again..." class="text-warning"></asp:Label>
                            </div>
                        </td>
                        <td class="text-right" colspan="2">
                                    <asp:Button ID="btn_prev" runat="server" class="btn btn-primary" Text="Previous Page"
                                        CausesValidation="False" OnClick="btn_prev_Click" />
                                    <asp:Button ID="btn_save" runat="server" class="btn btn-primary" Text="Save" OnClick="btn_save_Click" />
                                    <asp:Button ID="btn_nxt" runat="server" Text="Next Page" CausesValidation="False"
                                        OnClick="btn_nxt_Click" class="btn btn-primary" />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

