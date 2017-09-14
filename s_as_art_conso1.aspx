<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_art_conso1.aspx.cs" Inherits="Clinical_Forms_s_as_art_conso1" Title="Articulation Consonants 1" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-default">
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
       <ContentTemplate>
        <div class="panel-heading">
            <h class="text-muted text-center">Articulation Consonants 1</h>
        </div>  
        <div><strong><asp:Label ID="Label2" runat="server"  ForeColor="Red" Text="Running Page No  4..........................................................................................Total Pages 6"></asp:Label></strong></div>      
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-6" style="width:100%">
            <div class="form-group" style="text-align:center">
                            <asp:Button ID="btn_pre1" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_pre1_Click" class="btn btn-primary" />
                            <asp:Button ID="Save" runat="server" class="btn btn-primary" OnClick="btn_save_Click" Text="Save" />
                            <asp:Button ID="btn_nxt1" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt1_Click" class="btn btn-primary" />                            
                            <asp:Button ID="btnAllP" runat="server" class="btn btn-primary" OnClick="btnAllP_Click" Text="Position All" />
                            <asp:Label ID="lblDate" runat="server" class="form-control"></asp:Label>
                            </div>
            <div class="form-group">
            <asp:HiddenField ID="lbl_asid" runat="server" />
            <asp:HiddenField ID="lbl_aptid" runat="server" />
            <asp:HiddenField ID="lbl_ptntid" runat="server" />
            
            <table style="width:100%">
                <tr>
                <td style="width:99%">
                                <asp:RadioButtonList Style="width: 100%" ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem>Applicable</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                                 </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqRbt" ControlToValidate="RadioButtonList1" runat="server" ErrorMessage="Required to Select the Option" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
                </table> 
                            </div>                                 
                
            <div class="form-group" style="width:100%"> 
            <table id="TABLE2" class="table table-hover table-responsive" style="width:100%">
                <tbody>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <label class="h4">Position</label>
                        </td>
                        <td>
                        </td>
                        <td style="width:80%">
                            <label class="h4">Type</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="image23232" runat="server" ImageUrl="~/Images/conso/ka.gif" Width="93px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ka_pos" runat="server" class="form-control" Width="150px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>Normal</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Initial</asp:ListItem>
                                <asp:ListItem>Middle</asp:ListItem>
                                <asp:ListItem>Final</asp:ListItem>
                                <asp:ListItem>Initial-Middle</asp:ListItem>
                                <asp:ListItem>Initial-Final</asp:ListItem>
                                <asp:ListItem>Middle-Final</asp:ListItem>
                                <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/conso/ka.gif" Width="98px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ka" runat="server" RepeatDirection="Horizontal" 
                                style="width: 100%" Height="22px" Width="554px">
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
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/conso/kha.gif" Width="86px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_kha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/conso/kha.gif" Width="95px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_kha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/conso/ga.gif" Width="86px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ga_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/conso/ga.gif" Width="92px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ga" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/conso/gha.gif" Width="81px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_gha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/conso/gha.gif" Width="92px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_gha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/conso/NA1.gif" Width="79px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_na_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/conso/NA1.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_na" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/conso/c.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_c_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/conso/c.gif" />
                        </td>
                        <td style="width:60%">
                            <asp:RadioButtonList ID="rbtn_c" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/conso/cha.gif" Width="76px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_cha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/conso/cha.gif" Width="105px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_cha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/conso/j.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_j_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/Images/conso/j.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_j" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image17" runat="server" ImageUrl="~/Images/conso/jha.gif" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_jh_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image18" runat="server" ImageUrl="~/Images/conso/jha.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_jha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image19" runat="server" ImageUrl="~/Images/conso/tra.gif" Width="81px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_tra_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image20" runat="server" ImageUrl="~/Images/conso/tra.gif" Width="90px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_tra" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image21" runat="server" ImageUrl="~/Images/conso/TA1.gif" Width="77px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ta1_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image22" runat="server" ImageUrl="~/Images/conso/TA1.gif" Width="94px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ta1" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/Images/conso/tha1.gif" Width="84px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_tha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image24" runat="server" ImageUrl="~/Images/conso/tha1.gif" Width="92px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_tha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image25" runat="server" ImageUrl="~/Images/conso/da1.gif" Width="82px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_d1_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image26" runat="server" ImageUrl="~/Images/conso/da1.gif" Width="91px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbn_da" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image27" runat="server" ImageUrl="~/Images/conso/dha.gif" Width="78px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_dha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image28" runat="server" ImageUrl="~/Images/conso/dha.gif" Width="94px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_dha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image29" runat="server" ImageUrl="~/Images/conso/BigNa.gif" Width="78px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_bign_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image30" runat="server" ImageUrl="~/Images/conso/BigNa.gif" Width="92px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_bign" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image31" runat="server" ImageUrl="~/Images/conso/ta.gif" Width="84px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_ta_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image32" runat="server" ImageUrl="~/Images/conso/ta.gif" Width="94px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_ta" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/conso/tha.gif" Width="86px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_tha1_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image34" runat="server" ImageUrl="~/Images/conso/tha.gif" Width="95px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_tha1" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image35" runat="server" ImageUrl="~/Images/conso/da.gif" Width="87px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_d_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image36" runat="server" ImageUrl="~/Images/conso/da.gif" Width="94px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_d" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td class="style1">
                            <asp:Image ID="Image37" runat="server" ImageUrl="~/Images/conso/dha1.gif" Width="90px" />
                        </td>
                        <td class="style1">
                            <asp:DropDownList ID="ddl_dha1_pos" runat="server" class="form-control" Width="150px">
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
                        <td class="style1">
                            <asp:Image ID="Image38" runat="server" ImageUrl="~/Images/conso/dha1.gif" Width="92px" />
                        </td>
                        <td class="style1">
                            <asp:RadioButtonList ID="rbtn_dha1" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image39" runat="server" ImageUrl="~/Images/conso/na.gif" Width="91px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_na1_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image40" runat="server" ImageUrl="~/Images/conso/na.gif" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_na1" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image41" runat="server" ImageUrl="~/Images/conso/pa.gif" Width="93px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_pa_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image42" runat="server" ImageUrl="~/Images/conso/pa.gif" Width="95px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_pa" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                        <td>
                            <asp:Image ID="Image43" runat="server" ImageUrl="~/Images/conso/pha.gif" Width="95px" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_pha_pos" runat="server" class="form-control" Width="150px">
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
                        <td>
                            <asp:Image ID="Image44" runat="server" ImageUrl="~/Images/conso/pha.gif" Width="93px" />
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_pha" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
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
                                <asp:Label ID="lbl_msg2" runat="server" Text="Please Check Page Again..." class="text-warning"></asp:Label>
                            </div>
                        </td>
                        <td class="text-right" colspan="2">
                            <asp:Button ID="btn_prev" runat="server" class="btn btn-primary" Text="Previous Page" CausesValidation="False" OnClick="btn_prev_Click" />
                            <asp:Button ID="btn_save" runat="server" class="btn btn-primary" Text="Save" OnClick="btn_save_Click" />
                            <asp:Button ID="btn_nxt" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt_Click" class="btn btn-primary" />
                        </td>                               
                    </tr>                    
                </tbody>
            </table>
        </div>  
            </div>
        </div> 
         </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
