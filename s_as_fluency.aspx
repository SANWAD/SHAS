<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_fluency.aspx.cs" Inherits="Clinical_Forms_s_as_fluency" Title=" Fluency" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="panel-heading">
        <h class="text-muted text-center">Fluency Assessment</h>
    </div>
    <div><strong><asp:Label ID="Label3" runat="server"  ForeColor="Red" Text="Running Page No  6..........................................................................................End Of Report"></asp:Label></strong></div>
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
     <ContentTemplate>
    <div style="text-align:center">            
        <asp:Button ID="btn_prev1" class="btn btn-primary" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_prev1_Click" />
        <asp:Label ID="lblDate" runat="server" class="form-control" Width="145px"></asp:Label>
    </div>
    <div class="panel-body">        
        <div class="col-sm-push-0 col-md-5">
            <div class="form-group"> 
                <asp:HiddenField ID="lbl_asid" runat="server" /> 
                <asp:HiddenField ID="lbl_aptid" runat="server" />
                <asp:HiddenField ID="lbl_ptntid" runat="server" />
            <table style="width:100%">
                <tr>
                <td style="width:99%">              
                        <asp:RadioButtonList ID="rbtn_fl_appl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtn_fl_appl_SelectedIndexChanged">
                            <asp:ListItem>Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                            <asp:ListItem>Not Applicable</asp:ListItem>
                        </asp:RadioButtonList>
                        <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqrbtn_fl" ControlToValidate="rbtn_fl_appl" runat="server" ErrorMessage="Required To Select Option" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
                </table>    
            </div>
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Pauses"></asp:Label>
                <asp:TextBox ID="txt_pauses" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label9" runat="server" Text="Repeatation"></asp:Label>
                <asp:DropDownList ID="ddl_repatation" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Whole Word</asp:ListItem>
                    <asp:ListItem>Part Of Word</asp:ListItem>
                    <asp:ListItem>Absent</asp:ListItem>
                    <asp:ListItem Selected="true">Not Appicable</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Reading Fluency"></asp:Label>
                <asp:DropDownList ID="ddl_read" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Present Symptoms</asp:ListItem>
                    <asp:ListItem>Absent Symptoms</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label12" runat="server" Text="Fluency With Strangers" Width="209px"></asp:Label>
                <asp:DropDownList ID="ddl_strang" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Fluency Increases</asp:ListItem>
                    <asp:ListItem>Fluency Decreases</asp:ListItem>
                    <asp:ListItem>No Variation</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label13" runat="server" Text="Fluency with Opposite Gender"></asp:Label>
                <asp:DropDownList ID="ddl_op_gender" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Fluency Increases</asp:ListItem>
                    <asp:ListItem>Fluency Decreases</asp:ListItem>
                    <asp:ListItem>No Variation</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label15" runat="server" Text="Varitation with Language"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_var_lang" runat="server" class="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddl_var_lang_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Present</asp:ListItem>
                            <asp:ListItem>Absent </asp:ListItem>
                            <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:TextBox ID="txt_var_lang" runat="server" MaxLength="50" Visible="False" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label24" runat="server" Text="Word Specificity"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_word_spec" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_word_spec_SelectedIndexChanged"
                            class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Present</asp:ListItem>
                            <asp:ListItem>Absent </asp:ListItem>
                            <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_word_spec" runat="server" MaxLength="50" Visible="False" class="form-control"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="form-group">
                <asp:Label ID="Label25" runat="server" Text="Secondries"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Word Specificity"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_secondries" runat="server" OnSelectedIndexChanged="ddl_secondries_SelectedIndexChanged"
                            class="form-control" AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Present</asp:ListItem>
                            <asp:ListItem>Absent </asp:ListItem>
                            <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_second" runat="server" Visible="False" class="form-control"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:Label ID="lblTInit" runat="server" Text="Topic initation"></asp:Label>
                <asp:RadioButtonList ID="rbtTInit" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Not Developed</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTmain" runat="server" Text="Topic Maintainance"></asp:Label>
                <asp:RadioButtonList ID="rbtTmain" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Not Developed</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTClo" runat="server" Text="Topic Closure"></asp:Label>
                <asp:RadioButtonList ID="rbtTClo" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Not Developed</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSTell" runat="server" Text="Story Telling/Experiance Sharing"></asp:Label>
                <asp:RadioButtonList ID="rbtSTell" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                    <asp:ListItem>Age Approprite</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                    <asp:ListItem>Not Developed</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="col-sm-push-0 col-md-5">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text=" Receptive Language Age"></asp:Label>
                <table style="width: 100%;">
                    <tr>
                        <th>
                <asp:TextBox ID="txtmed_age" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                        </th>
                        <th>
                            Years
                        </th>
                        <th>
                            <asp:TextBox ID="txt_lang_mnths" runat="server" class="form-control" MaxLength="10" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                        </th>
                        <th>
                            Months
                        </th>
                    </tr>
                    </table>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text=" Expressive Language Age" ></asp:Label>
                        <table style="width: 100%;">
                    <tr>
                        <th>
                <asp:TextBox ID="txtmed_age1" runat="server" MaxLength="10" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                            </th>
                        <th>
                            Years
                        </th>
                        <th>
                    <asp:TextBox ID="txt_lang_mnths1" runat="server" MaxLength="10" class="form-control" onkeydown="return isNumeric(event.keyCode);" ></asp:TextBox>    </th>
                        <th>
                            Months
                        </th>
                    </tr>
                    </table>
                    </div>
                    <div class="form-group">
                    <asp:Label ID="Label112" runat="server" Text="Provisional Diagnosis" ></asp:Label>
                    
                        <asp:TextBox ID="txt_pro_diagn" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Recomadations" ></asp:Label>
                    
                        <asp:TextBox ID="txtoverimpression" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="page_validation_wiz6" runat="server" ErrorMessage="*" Font-Bold="True"
                            Font-Names="Georgia" Font-Size="14pt" OnServerValidate="page_validation_wiz6_ServerValidate"></asp:CustomValidator>
                    </div>
                    
                    <div class="form-group">
                    <asp:UpdatePanel ID="UpdatePanel33" UpdateMode="Conditional" runat="Server">
                                <ContentTemplate>
                                    <asp:Button ID="btn_prev" runat="server" class="btn btn-primary" Text="Previous Page"
                                        CausesValidation="False" OnClick="btn_prev_Click" />
                                    <asp:Button ID="btn_save" runat="server" class="btn btn-primary" Text="Save" OnClick="btn_save_Click1" OnClientClick=""/>
                                    <asp:Button ID="btn_print" runat="server" Text="Print" CausesValidation="False" OnClick="btn_print_Click" class="btn btn-primary" />
                                    </td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    
                    </div>
                    <%--<td colspan="2" style="text-align: center">
                        <asp:Button ID="btn_prev" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="12pt" Text="PREVIOUS PAGE" CausesValidation="False" OnClick="btn_prev_Click"
                            Width="145px" BackColor="Silver" /><asp:Button ID="btn_save" runat="server" Font-Bold="True"
                                Font-Names="Times New Roman" Font-Size="12pt" Text="SAVE" OnClick="btn_save_Click1"
                                BackColor="Silver" />
                                <asp:Button ID="btn_print" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                                    Font-Size="12pt" Text="PRINT" OnClick="btn_print_Click" CausesValidation="False"
                                    BackColor="Silver" />
                    </td>
                </tr>
                </tbody> </table>--%>
            </div>
            </div>
     </ContentTemplate> 
    </asp:UpdatePanel>   
</asp:Content>
