<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_asses.aspx.cs" Inherits="Clinical_Forms_s_as_asses" Title="Assessment " MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>
    <div class="panel">
        <div class="panel-heading">
            <h class="text-muted text-center">Speech Problem Assessment</h>
        </div>        
        <div class="pull-right padding-top-small padding-bottom-small padding-right-small">
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>
                    <fieldset title="Next">
                        <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-primary" OnClick="btn_nxt_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CausesValidation="False" class="btn btn-primary" onclick="btnPrint_Click"/>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="panel-body">
        
            <a href="s_as_asses.aspx">s_as_asses.aspx</a>
            <div class="col-sm-push-4 col-md-5">
                <div class="form-group">
                    <asp:Image ID="Image1" runat="server" Height="114px" Width="108px" />
                </div>
                <div class="form-group">
                   <asp:HiddenField ID="lblas_id" runat="server" />
                </div>
                <div class="form-group">
                       <asp:HiddenField ID="lblaptid" runat="server" />
                </div>
                <div class="form-group">
                   <asp:HiddenField ID="lblptnt_id" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblptnttype" runat="server" class="form-control" />
                </div>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:99%">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="Patient Name"/>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtptntNm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                            <div id="divwidth" style="display: none">
                            </div>
                            <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptntNm" FirstRowSelected="true" ServicePath="WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" CompletionListElementID="divwidth">
                            </AjaxToolkit:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td> 
                <td style="width:1%">
                <asp:RequiredFieldValidator ID="reqPtnt_nm" ControlToValidate="txtptntNm" runat="server" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                </tr> 
                </table>    
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Date Of Birth"/>
                    <asp:Label ID="lblptntdob" runat="server" class="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Age"/>
                    <asp:Label ID="lblptntage" runat="server" class="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" Text="Gender"/>
                    <asp:Label ID="lblgender" runat="server" class="form-control" />
                </div>
                <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Profession"/>
                    <asp:Label ID="lblprofession" runat="server" class="form-control" />
                </div>
            </div>
            <div class="col-sm-push-0 col-md-12">
                <table class="table">
                    <tbody>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label10" runat="server" Text="Birth History"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbirthhistry" runat="server" MaxLength="2000" Rows="2" class="form-control"></asp:TextBox>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label11" runat="server" Text="Medical History"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmedhistry" runat="server" MaxLength="2000" Rows="2" Class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label12" runat="server" Text="Mother Tounge"/>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddl_mother_tongue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_mother_tongue_SelectedIndexChanged"
                                            class="form-control">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_lang" runat="server" class="form-control"></asp:TextBox>
                                        <asp:Button ID="btn_add_lang" runat="server" OnClick="btn_add_lang_Click" Text="Add"
                                            class="btn btn-primary" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label13" runat="server" Text="Communication"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcom" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label14" runat="server" Text="Languages Used"/>
                            </td>
                            <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                               <ContentTemplate>
                                <asp:ListBox ID="lst_lang_used" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lst_lang_used_SelectedIndexChanged"
                                    class="form-control" Rows="2"></asp:ListBox>
                                <asp:TextBox ID="txtsel1" runat="server" Rows="2" class="form-control"></asp:TextBox>
                                </ContentTemplate> 
                                </asp:UpdatePanel> 
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label15" runat="server" Text="Enviromental Language"/>
                            </td>
                            <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                               <ContentTemplate>
                                <asp:ListBox ID="lst_env_lang" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lst_env_lang_SelectedIndexChanged"
                                    class="form-control" Rows="2"></asp:ListBox>
                                <asp:TextBox ID="txtsel2" runat="server" Rows="2" class="form-control"></asp:TextBox>
                                </ContentTemplate> 
                                </asp:UpdatePanel> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="text-center">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Style="width: 50%"
                                    OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                    <asp:ListItem>Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label16" runat="server" Text="Seperation from Parent"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txtseppar" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label17" runat="server" Text="Eye Contact"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtneyecont" runat="server" Style="width: 100%" RepeatDirection="Horizontal">
                                    <asp:ListItem>Present</asp:ListItem>
                                    <asp:ListItem>Absent</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label18" runat="server" Text="Social Smile"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsocsmile" runat="server" MaxLength="2000" class="form-control"
                                    Rows="2"></asp:TextBox>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label19" runat="server" Text="Attention Span"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnattspan" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
                                    <asp:ListItem>Poor</asp:ListItem>
                                    <asp:ListItem>Good</asp:ListItem>
                                    <asp:ListItem>Inadequate</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label20" runat="server" Text="Concentration"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnconcetration" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Poor</asp:ListItem>
                                    <asp:ListItem>Good</asp:ListItem>
                                    <asp:ListItem>Inadequate</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label21" runat="server" Text="Distractibility"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtndistrability" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
                                    <asp:ListItem>Easily</asp:ListItem>
                                    <asp:ListItem>Stable</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label22" runat="server" Text="Co-Operation"/>
                            </td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="rbtncoop" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
                                    <asp:ListItem>Co-Operative</asp:ListItem>
                                    <asp:ListItem>Non Co-Operative</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label23" runat="server" Text="Interest In Toys"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtninttoy" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label24" runat="server" Text="Physical Movement"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnphymov" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>Hyper</asp:ListItem>
                                    <asp:ListItem>Low</asp:ListItem>
                                    <asp:ListItem>Clumpsy</asp:ListItem>
                                    <asp:ListItem Selected="True">Parapledigia</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label25" runat="server" Text="Facial Movement"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnfacmov" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>Abnormal</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label26" runat="server" Text="Imitation Skills"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnimmtskill" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Good</asp:ListItem>
                                    <asp:ListItem>Poor</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label27" runat="server" Text="Toilet Control"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtntoiletcont" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Achived</asp:ListItem>
                                    <asp:ListItem>Not Achived</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label28" runat="server" Text="Abnormal Behaviour"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_abn_beh" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="text-center">
                                <div>
                                    <label class="text-center h4">SUPRA SEGMENTAL</label>
                                    <asp:RadioButtonList ID="rbtn_supra" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtn_supra_SelectedIndexChanged"
                                        RepeatDirection="Horizontal" Style="width: 100%">
                                        <asp:ListItem>Applicable</asp:ListItem>
                                        <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label29" runat="server" Text="Intonation"/>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlintonation" runat="server" class="form-control">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Flat</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>Abnormal</asp:ListItem>
                                    <asp:ListItem Selected="TRUE">Not Applicable</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label30" runat="server" Text="Emphasis"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnemphasis" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Appropriate</asp:ListItem>
                                    <asp:ListItem>Inappropriate</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label31" runat="server" Text="Phrasing"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnphrasing" runat="server" RepeatDirection="Horizontal"
                                    Style="width: 100%">
                                    <asp:ListItem>Appropriate</asp:ListItem>
                                    <asp:ListItem>Inappropriate</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="text-right h4">
                                    <asp:Label ID="Label32" runat="server" Text="Rate"/>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnrate" runat="server" RepeatDirection="Horizontal" Style="width: 100%">
                                    <asp:ListItem>Fast</asp:ListItem>
                                    <asp:ListItem>Slow</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right h4">
                                    <asp:Label ID="Label33" runat="server" Text="Appointment"/>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlnxtmeet" runat="server" class="form-control">
                                    <asp:ListItem>Next Appointment</asp:ListItem>
                                    <asp:ListItem>Once In week</asp:ListItem>
                                    <asp:ListItem>Twice In WeeK</asp:ListItem>
                                    <asp:ListItem>Daily For Week</asp:ListItem>
                                    <asp:ListItem>Daily For Month</asp:ListItem>
                                    <asp:ListItem>Once In Month</asp:ListItem>
                                    <asp:ListItem>Once In Fifteen Days</asp:ListItem>
                                    <asp:ListItem>Twice In Fifteen Days</asp:ListItem>
                                    <asp:ListItem>Once In Six Month</asp:ListItem>
                                    <asp:ListItem>Once In Year</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="text-right h4">
                             <asp:Label ID="Label34" runat="server" Text="Start Appointment"/>
                            </td>
                            <td>
                                <table style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <th style="width: 40%;">
                                                <asp:TextBox ID="txtB_Date" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtB_Date_OnTextChanged"
                                                    PopupPosition="BottomLeft" TargetControlID="txtB_Date" OnClientDateSelectionChanged="CheckDateEalier"
                                                    CssClass="ajax__calendar">
                                                </AjaxToolkit:CalendarExtender>
                                            </th>
                                            <th style="width: 10%;">
                                                <div>
                                                    <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" /></div>
                                            </th>
                                            <th style="width: 10%;">
                                                    <asp:Label ID="Label35" runat="server" Text="Time" class="text-right h4"/>
                                            </th>
                                            <th style="width: 40%;">
                                                <asp:DropDownList ID="ddl_apt_time" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </th>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right">
                                <asp:Label ID="lbl_msg_supra" runat="server" class="text-warning" Text="Please Select Appropriate Part Of supra Segmental"></asp:Label>
                                <asp:CustomValidator ID="valid_page_wiz1" runat="server" ErrorMessage="Please Check The Page Again....."
                                    class="text-warning" OnServerValidate="valid_page_wiz1_ServerValidate"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="text-right">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btn_New" runat="server" class="btn btn-primary" OnClick="btn_New_Click" Text="New" />
                                <asp:Button ID="btn_save" runat="server" class="btn btn-primary" Text="Save" OnClick="btn_save_Click" />
                                <asp:Button ID="btn_nxt" runat="server" Text="Next" class="btn btn-primary" OnClick="btn_nxt_Click" />
                                <asp:Button ID="btn_print" runat="server" OnClick="btn_print_Click" Text="Print" class="btn btn-primary" />
                                <asp:Button ID="lblNxt_Apt" runat="server" Text="Next Appointment" class="btn btn-primary" OnClick="lblNxt_Apt_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="4" class="text-left">
                         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
                        </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="s_asses_id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" class="table-hover table-bordered" style="width:100%">
                                    <Columns>
                                        <asp:BoundField DataField="s_asses_date" HeaderText="Asses Date" SortExpression="s_asses_date" />
                                        <asp:BoundField DataField="s_asses_id" HeaderText="Asses No" InsertVisible="False" ReadOnly="True" SortExpression="s_asses_id" />
                                        <asp:BoundField DataField="ptnt_id" HeaderText="Patient Id" SortExpression="ptnt_id" />
                                        <asp:BoundField DataField="apt_id" HeaderText="Apt Id" SortExpression="apt_id" />
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel>
</asp:Content>
