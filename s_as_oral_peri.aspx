<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_oral_peri.aspx.cs" Inherits="Clinical_Forms_s_as_oral_peri" Title="Oral Peripheral Assessment" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel-heading">
        <h class="text-muted text-center">Oral Peripheral Assessment</h>
    </div>
    <div><strong><asp:Label ID="Label4" runat="server"  ForeColor="Red" Text="Running Page No  2..........................................................................................Total Pages 6"></asp:Label></strong></div>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
      <ContentTemplate>
    <div class="panel-body">
    <%--<div class="pull-right padding-top-small padding-bottom-small padding-right-small"> --%>
          <div align="center" >                        
                        <asp:Button ID="Button1" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_prev_Click" class="btn btn-primary"/>
                        <asp:Button ID="Save" runat="server" Text="Save" OnClick="btn_save_Click1" class="btn btn-primary"/>
                        <asp:Button ID="Button3" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt_Click" class="btn btn-primary"/>                        
                        <asp:Label ID="lbldate" runat="server" class="btn btn-primary"></asp:Label>
                        <asp:HiddenField ID="lbl_asid" runat="server" />
                        <asp:HiddenField ID="lbl_aptid" runat="server" />
                        <asp:HiddenField ID="lbl_ptntid" runat="server" />
          </div>
           <div class="col-sm-push-0 col-md-6">
            <div class="form-group">
                <asp:Label ID="Label311" runat="server" Text="Lips structure"></asp:Label>
                <asp:DropDownList ID="ddl_lips_struct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Abnormal</asp:ListItem>
                    <asp:ListItem>Cleft Left</asp:ListItem>
                    <asp:ListItem>Cleft Right</asp:ListItem>
                    <asp:ListItem>Cleft Bilateral</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label411" runat="server" Text="Lips Function"></asp:Label>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Puckering"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_puck" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem>Adequate</asp:ListItem>
                                <asp:ListItem>Inadequate</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Blowing"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbtn_blow" runat="server" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem>Adequate</asp:ListItem>
                                <asp:ListItem>Inadequate</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Sucking"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rbtn_suck" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Style="width: 100%;" OnSelectedIndexChanged="rbtn_suck_SelectedIndexChanged">
                                        <asp:ListItem>Adequate</asp:ListItem>
                                        <asp:ListItem>Inadequate</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <asp:TextBox ID="txt_lips" runat="server" Font-Bold="False" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label511" runat="server" Text="Teeth structure"></asp:Label>
                <asp:DropDownList ID="ddl_teeth_struct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Abnormal</asp:ListItem>
                    <asp:ListItem>Additional Abnormal Tooth</asp:ListItem>
                    <asp:ListItem>Dental Carries</asp:ListItem>
                    <asp:ListItem>Overbite</asp:ListItem>
                    <asp:ListItem>Misssing</asp:ListItem>
                    <asp:ListItem>Malalingment</asp:ListItem>
                    <asp:ListItem>Lowerbite</asp:ListItem>
                    <asp:ListItem>Missing &amp; Dental Carries</asp:ListItem>
                    <asp:ListItem>Missing &amp; Overbite</asp:ListItem>
                    <asp:ListItem>Missing &amp; Lowerbite</asp:ListItem>
                    <asp:ListItem Value="Dental Carries">Dental Carries &amp; Overbite </asp:ListItem>
                    <asp:ListItem>Dental Carries &amp; Lowerbite</asp:ListItem>
                    <asp:ListItem>Additional Teeth</asp:ListItem>
                    <asp:ListItem>Additional Teeth with Mall Alignment</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label611" runat="server" Text="Teeth Function"></asp:Label>
                <asp:DropDownList ID="ddl_teeth_funct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Biting Adequate,Chewing Inadequate</asp:ListItem>
                    <asp:ListItem>Chewing Adequate,Biting In Adequate</asp:ListItem>
                    <asp:ListItem>Chewing And Biting Adequate</asp:ListItem>
                    <asp:ListItem>Biting And Chewing Inadequate</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label711" runat="server" Text="Tongue structure"></asp:Label>
                <asp:DropDownList ID="ddl_tongue_struct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Abnormal</asp:ListItem>
                    <asp:ListItem>Microglossia</asp:ListItem>
                    <asp:ListItem>Megaloglossia</asp:ListItem>
                    <asp:ListItem>Tongue Tie</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label811" runat="server" Text="Tongue Function"></asp:Label>
                <asp:DropDownList ID="ddl_tongue_funct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">All Movements Normal</asp:ListItem>
                    <asp:ListItem>All Movements Abnormal</asp:ListItem>
                    <asp:ListItem>lateral &amp; Protrusion Adequate,Elevation &amp; retroflexion Inadequate</asp:ListItem>
                    <asp:ListItem>lateral &amp; Retroflexion Adequate,protrusion &amp; Elevation Inadequate</asp:ListItem>
                    <asp:ListItem>lateral &amp; Elevation Adequate,retroflexion &amp; Protrusion Inadequate</asp:ListItem>
                    <asp:ListItem>protrusion &amp; Elevation Adequate,lateral &amp; Retroflexion Inadequate </asp:ListItem>
                    <asp:ListItem>protrusion &amp; Retroflexion Adequate,lateral &amp; Elevation Inadequate</asp:ListItem>
                    <asp:ListItem>Elevation  &amp; Retroflexion Adequate,lateral &amp; protrusion Inadequate </asp:ListItem>
                    <asp:ListItem>lateral Adequate &amp; Elevation ,retroflexion &amp; Protrusion Inadequate</asp:ListItem>
                    <asp:ListItem>protrusion Adequate Elevation &amp;,lateral &amp; Retroflexion Inadequate </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label911" runat="server" Text="Hard Palate structure"></asp:Label>
                <asp:DropDownList ID="ddl_hard_palate_struct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Abnormal</asp:ListItem>
                    <asp:ListItem>High Arched</asp:ListItem>
                    <asp:ListItem>Shallow Arched</asp:ListItem>
                    <asp:ListItem>Cleft Left</asp:ListItem>
                    <asp:ListItem>Cleft Right</asp:ListItem>
                    <asp:ListItem Value="Cleft Bilateral">Cleft Bilateral</asp:ListItem>
                    <asp:ListItem>Uvular Fistula</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label101" runat="server" Text="Hard Palate Function"></asp:Label>
                <asp:DropDownList ID="ddl_hard_palate_funct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Adequate</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label112" runat="server" Text="Soft Palate structure"></asp:Label>
                <asp:DropDownList ID="ddl_soft_palate_struct" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Normal</asp:ListItem>
                    <asp:ListItem>Abnormal</asp:ListItem>
                    <asp:ListItem>Short</asp:ListItem>
                    <asp:ListItem>Absent Uvula</asp:ListItem>
                    <asp:ListItem>Cleft Left</asp:ListItem>
                    <asp:ListItem>Cleft Right</asp:ListItem>
                    <asp:ListItem>Cleft Bilateral</asp:ListItem>
                    <asp:ListItem>Submucous Cleft</asp:ListItem>
                    <asp:ListItem>Operated Cleft</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label121" runat="server" Text="Soft Palate Function"></asp:Label>
                <asp:DropDownList ID="ddl_soft_pal_fun" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Adequate</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label364" runat="server" Text="Drooling Control"></asp:Label>
                <asp:DropDownList ID="ddl_drool_cont" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Achived</asp:ListItem>
                    <asp:ListItem>Not Achived</asp:ListItem>
                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label131" runat="server" Text="Parental Observation"></asp:Label>
                <asp:TextBox ID="txt_par_obs" runat="server" MaxLength="2000" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label141" runat="server" Text="Clinical Observation"></asp:Label>
                <asp:TextBox ID="txtcl_obs" runat="server" MaxLength="2000" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>            
            </div>            
            <div class="col-sm-push-0 col-md-6">
            <div class="form-group">
                <asp:Label ID="Label424" runat="server" Text="Voice Pitch"></asp:Label>
                <asp:DropDownList ID="ddl_v_pitch" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Monotonus</asp:ListItem>
                    <asp:ListItem Selected="true">Appropriate</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label434" runat="server" Text="Voice Quality"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_voice_qual" runat="server" class="form-control" OnSelectedIndexChanged="ddl_voice_qual_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Nasal</asp:ListItem>
                            <asp:ListItem>Denasal</asp:ListItem>
                            <asp:ListItem>Harsh</asp:ListItem>
                            <asp:ListItem>Hoarse</asp:ListItem>
                            <asp:ListItem Selected="True">Appropriate</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblNasal" runat="server" Text="Nasality" Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddlNasal" runat="server" class="form-control" Visible="False">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>+0</asp:ListItem>
                            <asp:ListItem>+1</asp:ListItem>
                            <asp:ListItem>+2</asp:ListItem>
                            <asp:ListItem>+3</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblDena" runat="server" Text="DeNasality" Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddlDena" runat="server" class="form-control" Visible="False">
                            <asp:ListItem>-0</asp:ListItem>
                            <asp:ListItem>-1</asp:ListItem>
                            <asp:ListItem>-2</asp:ListItem>
                            <asp:ListItem>-3</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="form-group">
                <asp:Label ID="Label444" runat="server" Text="Voice intensity"></asp:Label>
                <asp:DropDownList ID="ddl_intensity" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="true">Adequate</asp:ListItem>
                    <asp:ListItem>Inadequate</asp:ListItem>
                    <asp:ListItem>Loud</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label454" runat="server" Text="Maximum Phonation  Duration"></asp:Label>
                <asp:TextBox ID="txtmax_phon_dura" runat="server" MaxLength="3" class="form-control" Width="128px" placeholder="In second"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label46" runat="server" Text="Inteligibility"></asp:Label>
                <asp:DropDownList ID="ddl_inteligibility" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">0-Normal</asp:ListItem>
                    <asp:ListItem>1-Can Understand But Speech Is Not Normal</asp:ListItem>
                    <asp:ListItem>2-Can Understand With Little Effort</asp:ListItem>
                    <asp:ListItem>3-Can Understand With Concentration and Requires Two or Three Repetation</asp:ListItem>
                    <asp:ListItem>4-Can Understand With Difficulty By Family Members</asp:ListItem>
                    <asp:ListItem>5-Can Understand With Effort if Content is Known</asp:ListItem>
                    <asp:ListItem>6-Can Not Understand With Effort if Content is Known</asp:ListItem>
                    <asp:ListItem>Not Applicable</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label354" runat="server" Text="Spontanious Vocalisation"></asp:Label>
                <asp:DropDownList ID="ddl_spont_vocal" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                    <asp:ListItem>Cooing</asp:ListItem>
                    <asp:ListItem>Babling</asp:ListItem>
                    <asp:ListItem>Polysyllabic Babling</asp:ListItem>
                    <asp:ListItem>Jargan</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label384" runat="server" Text="Pitch Control"></asp:Label>
                <asp:DropDownList ID="ddl_pitch_cont" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="True">Adequate</asp:ListItem>
                    <asp:ListItem>Not Achived</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label374" runat="server" Text="Intesity Control"></asp:Label>
                <asp:DropDownList ID="ddl_int_cont" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Selected="true">Normal</asp:ListItem>
                    <asp:ListItem>Inadeqate</asp:ListItem>
                    <asp:ListItem>Not Achived</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label674" runat="server" Text="Breathing Pattern"></asp:Label>
                <asp:DropDownList ID="ddl_breath_cont" runat="server" class="form-control">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Thorasic</asp:ListItem>
                    <asp:ListItem>Abdominal</asp:ListItem>
                    <asp:ListItem>Diaphragmatic</asp:ListItem>
                    <asp:ListItem>Clavicular</asp:ListItem>
                    <asp:ListItem>Denasal</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label334" runat="server" Text="Diadochokinetic Rate"></asp:Label>
                <br />
                <asp:RadioButtonList ID="rbtn_dia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtn_dia_SelectedIndexChanged" RepeatDirection="Horizontal" Style="width: 100%;">
                    <asp:ListItem>Applicable</asp:ListItem>
                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label172" runat="server" Text="PA"></asp:Label>
                <asp:DropDownList ID="ddl_pa" runat="server" OnSelectedIndexChanged="ddl_pa_SelectedIndexChanged" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label182" runat="server" Text="TA"></asp:Label>
                <asp:DropDownList ID="ddl_ta" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label192" runat="server" Text="KA"></asp:Label>
                <asp:DropDownList ID="ddl_ka" runat="server" class="form-control">
                </asp:DropDownList>
                <div class="form-group">
                    <asp:Label ID="Label202" runat="server" Text="LA"></asp:Label>
                    <asp:DropDownList ID="ddl_la" runat="server" class="form-control">
                    </asp:DropDownList>
                    <div class="form-group">
                        <asp:Label ID="lbl_msg" runat="server" class="text-warning" Text="PLEASE FILL DIADOCHOKINETIC RATES VALUES"></asp:Label>
                        <asp:CustomValidator ID="pagevalidate_wiz3" runat="server" ErrorMessage="Please Chech The Page Again...." class="text-warning" OnServerValidate="pagevalidate_wiz3_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btn_prev" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_prev_Click" class="btn btn-primary"/>
                        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click1" class="btn btn-primary"/>
                        <asp:Button ID="btn_nxt" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt_Click" class="btn btn-primary"/>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>
