<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_digno.aspx.cs" Inherits="s_digno" Title="Untitled Page"  MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="panel-heading"  style="text-align:center">
        <h class="text-muted text-center">Speech Problem Reassesment</h>
    </div>
    <div class="panel-body">
     <div class="col-sm-push-0 col-md-3">
    <div class="form-group">
    <asp:Image ID="Image1" runat="server" Height="114px" Width="108px" />
    </div>
    <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Reassesment Id" />
                <asp:Label ID="lblas_id" runat="server" Class="form-control" /><asp:Label ID="lbldate" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Assesment Id" />
                <asp:Label ID="lblaptid" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Appointment Id" />
                <asp:Label ID="Label6" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Patient Id" />
                <asp:Label ID="lblptnt_id" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Patient Type" />
                <asp:Label ID="lblptnttype" runat="server" class="form-control" />
            </div>
            <div class="form-group">
            <asp:Label ID="Label12" runat="server" Text="Patient Name" />
            <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control"></asp:TextBox>
            </div>
    </div> 
    <div class="col-sm-push-0 col-md-12">
     <table class="table">
                    <tbody>
                        <tr>
                            <td class="text-right h5">
                            <asp:Label ID="Label27" runat="server" Text="Mother Tongue"></asp:Label>
                            </td> 
                            <td style="width:30%">
                            <asp:DropDownList ID="ddl_mother_tongue" runat="server" class="form-control">
                            </asp:DropDownList>
                            </td> 
                            <td class="text-right h5">
                            <asp:Label ID="Label28" runat="server" Text="Mode Of Expression"></asp:Label>
                            </td> 
                            <td style="width:30%">
                             <asp:DropDownList ID="ddl_mode_exp" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Word</asp:ListItem>
                            <asp:ListItem>Gesture</asp:ListItem>
                            <asp:ListItem>Sign Language</asp:ListItem>
                            <asp:ListItem Value="Symbolic ">Symbolic</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            </tr>
                             <tr>
                            <td class="text-right h5">
                             <asp:Label ID="Label29" runat="server" Text="Expression Language"></asp:Label>
                            </td> 
                            <td>
                           <asp:DropDownList ID="ddl_expressive_lang" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>One Word</asp:ListItem>
                            <asp:ListItem>Two Word</asp:ListItem>
                            <asp:ListItem>Phrases</asp:ListItem>
                            <asp:ListItem>Simple Sentence</asp:ListItem>
                            <asp:ListItem>Complex Sentence</asp:ListItem>
                            </asp:DropDownList>
                            </td> 
                            <td class="text-right h5">
                            <asp:Label ID="Label30" runat="server" Text="Receptive Language"></asp:Label>
                            </td> 
                            <td>
                            <asp:DropDownList ID="ddl_rec_lang" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Simple Command</asp:ListItem>
                            <asp:ListItem>Two Directional Command</asp:ListItem>
                            <asp:ListItem>Complex Command</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            </tr>
                            <tr>
                            <td class="text-right h5">
                             <asp:Label ID="Label7" runat="server" Text="Languages Used"></asp:Label>
                            </td> 
                            <td>
                           <asp:ListBox ID="lst_lang_used" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lst_lang_used_SelectedIndexChanged" class="form-control"></asp:ListBox><br />
                           <asp:TextBox ID="txtsel1" runat="server" TextMode="MultiLine" ReadOnly="true" class="form-control"></asp:TextBox>
                            </td> 
                            <td class="text-right h5">
                            <asp:Label ID="Label8" runat="server" Text="Enviromental Language"></asp:Label>
                            </td> 
                            <td>
                            <asp:ListBox ID="lst_env_lang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lst_env_lang_SelectedIndexChanged" class="form-control"></asp:ListBox><br />
                            <asp:TextBox ID="txtsel2" runat="server" TextMode="MultiLine" ReadOnly="true" class="form-control"></asp:TextBox>
                            </td>
                            </tr>
                            
                            <tr>
                            <td class="text-right h5">
                             <asp:Label ID="Label31" runat="server" Text="Oral Peripheral Function"></asp:Label>
                            </td> 
                            <td>
                           <asp:DropDownList ID="ddl_oral_fun" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Adequate</asp:ListItem>
                            <asp:ListItem>Inadequate</asp:ListItem>
                           </asp:DropDownList>
                            </td> 
                            <td class="text-right h5">
                            <asp:Label ID="Label32" runat="server" Text="Fluency"></asp:Label>
                            </td> 
                            <td>
                            <asp:DropDownList ID="ddl_fluency" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Pauses Frequently</asp:ListItem>
                            <asp:ListItem>Part of Word Repetation</asp:ListItem>
                            <asp:ListItem>Whole Word Repetation</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            </tr>
                            
                            <tr>
                            <td class="text-right h5">
                             <asp:Label ID="Label33" runat="server" Text="Behavioural Observation"></asp:Label>
                            </td> 
                            <td>
                          <asp:DropDownList ID="ddl_beh_obs" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Co-Operative</asp:ListItem>
                            <asp:ListItem>Non Co-Operative</asp:ListItem>
                            <asp:ListItem>Restless</asp:ListItem>
                            <asp:ListItem>Friendly</asp:ListItem>
                            <asp:ListItem>Shy</asp:ListItem>
                            <asp:ListItem>Temper Tantrum</asp:ListItem>
                            </asp:DropDownList>
                            </td> 
                            <td class="text-right h5">
                            <asp:Label ID="Label34" runat="server" Text="Dignosis Details"></asp:Label>
                            </td> 
                            <td>
                            <asp:TextBox ID="txts_digno_det" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td class="text-right h5">
                             <asp:Label ID="Label36" runat="server" Text="Recomanded Language"></asp:Label>
                            </td> 
                            <td>
                            <asp:DropDownList ID="ddl_recom_lang" runat="server" class="form-control">
                            </asp:DropDownList>
                            </td>
                            <td class="text-right h5">
                            <asp:Label ID="Label9" runat="server" Text="Nasality Rating"></asp:Label>
                            </td> 
                            <td>
                            <asp:DropDownList ID="ddl_nasal_rate" runat="server" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>-1</asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            </tr>
                            <tr>
                            <td class="text-right h5">
                            <asp:Label ID="Label10" runat="server" Text="Recomandetions"></asp:Label>
                            </td> 
                            <td>
                             <asp:TextBox ID="txt_recom" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                            </td>
                            <td class="text-right h5">
                            
                            </td>
                            <td>
                            
                            </td>
                            </tr>
                            <tr>
                            <td class="text-right h5">
                            <asp:Label ID="Label11" runat="server" Width="113px" Text="Next Meeting/s" Visible="False"></asp:Label>
                            </td>
                            <td>
                            <asp:DropDownList ID="ddlnxtmeet" runat="server" OnSelectedIndexChanged="ddlnxtmeet_SelectedIndexChanged" Visible="False" class="form-control">
                            <asp:ListItem>Next Appointment</asp:ListItem>
                            <asp:ListItem>Once In week</asp:ListItem>
                            <asp:ListItem>Twice In Week</asp:ListItem>
                            <asp:ListItem>Daily For Week</asp:ListItem>
                            <asp:ListItem>Daily For Month</asp:ListItem>
                            <asp:ListItem>Once In Month</asp:ListItem>
                            <asp:ListItem>Once In Fifteen Days</asp:ListItem>
                            <asp:ListItem>Twice In Fifteen Days</asp:ListItem>
                            <asp:ListItem>Once In Six Month</asp:ListItem>
                            <asp:ListItem>Once In Year</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            </tr>
                            
                            <tr>
                            <td colspan="4" class="text-center">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                                <%--<asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_Click"/>--%>
                                </ContentTemplate> 
                                </asp:UpdatePanel>
                                </td>
                                </tr>                                 
                            </tbody> 
                            </table> 
    </div> 
    </div> 
    
</asp:Content>

