<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_assessment.aspx.cs" Inherits="Inward" Title="Hearing Problem Assessment" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
    <div class="panel-heading">
        <h class="text-muted text-center">Hearing Problem Assessment</h>
    </div>
    <div class="pull-right padding-top-small padding-bottom-small padding-right-small">
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
            <ContentTemplate>
             <asp:Button ID="btnNext" runat="server" Text="Next"  class="btn btn-primary" onclick="btnNext_Click"/>
             <asp:Button ID="btn_print" runat="server" Text="Print" class="btn btn-primary" 
                    onclick="btn_print_Click"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="Server">
     <ContentTemplate>
    <div class="panel-body">
        <div class="col-sm-push-0 col-md-3">
            <div class="form-group">
                <asp:Image ID="Image1" runat="server" Height="114px" Width="108px" />
                 <asp:HiddenField ID="lblas_id" runat="server" />
                <asp:HiddenField ID="lblaptid" runat="server" />
                <asp:HiddenField ID="lblptnt_id" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Patient Type" />
                <asp:Label ID="lblptnttype" runat="server" class="form-control" />
            </div>
            <div class="form-group">
            <table style="width:100%">
                    <tr>
                    <td style="width:98%">
            <asp:Label ID="lblind" runat="server" ForeColor="Red" Text="*"></asp:Label>                    
                    <asp:Label ID="Label6" runat="server" Text="Patient Name" />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtptntNm" runat="server" class="form-control"></asp:TextBox>
                        <div id="divwidth" style="display: none">
                        </div>
                        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptntNm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="1000" CompletionSetCount="1" CompletionListElementID="divwidth">
                        </AjaxToolkit:AutoCompleteExtender>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td style="width:2%">
                    <asp:RequiredFieldValidator runat="server" id="reqPtntName" controltovalidate="txtptntNm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
                    </td> 
                    </tr> 
                    </table>                 
            </div>
            <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:45%">
            <asp:Label ID="Label7" runat="server" Text="Date Of Birth" />
                <asp:Label ID="lblptntdob" runat="server" class="form-control" />
                </td>
                <%--<td style="width:25%">
                
                </td>
                <td style="width:30%">
                 
                </td>--%>
                </tr>
                </table>                    
            </div>
             <div class="form-group">
             <asp:Label ID="Label8" runat="server" Text="Age" />
                <asp:Label ID="lblptntage" runat="server" class="form-control" />
             </div> 
             <div class="form-group">
             <asp:Label ID="Label9" runat="server" Text="Gender" />
                <asp:Label ID="lblgender" runat="server" class="form-control" />
             </div>           
            <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Profession" />
                <asp:Label ID="lblprofession" runat="server" class="form-control" />
            </div>
              <h3 class="label label-primary img-label padding-top-small padding-bottom-small">ASSESSMENT</h3>
             <div class="form-group">
                <asp:Label ID="Label11" runat="server" Text="Complaints" />                
                        <asp:DropDownList ID="ddl_complaints" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_complaints_SelectedIndexChanged" class="form-control">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Pain</asp:ListItem>
                            <asp:ListItem>Ear Discharge</asp:ListItem>
                            <asp:ListItem>Hearing Loss</asp:ListItem>
                            <asp:ListItem>Tinnitus</asp:ListItem>
                            <asp:ListItem>Vertigo</asp:ListItem>
                            <asp:ListItem>Nausia</asp:ListItem>
                            <asp:ListItem>Headache</asp:ListItem>
                            <asp:ListItem>Hearing Screening</asp:ListItem>
                            <asp:ListItem>Hearing Asessment</asp:ListItem>
                        </asp:DropDownList>                  
                <asp:TextBox ID="txt_comp" runat="server" MaxLength="2000" TextMode="MultiLine" class="form-control"></asp:TextBox>               
            </div>     
             <div class="form-group">
                <asp:Label ID="Label12" runat="server" Text="Birth history" />
                <asp:TextBox ID="txtbirthhistry" runat="server" class="form-control" MaxLength="2000" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-push-0 col-md-3">
            <div class="form-group">
            </div>
            <div class="form-group">
                <asp:Label ID="Label13" runat="server" Text="Medical history" />
                <asp:TextBox ID="txtmedhistry" runat="server" MaxLength="2000" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>   
            <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="Consagnuinity" />
                <asp:TextBox ID="txtcons" runat="server" Class="form-control" MaxLength="15"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label15" runat="server" Text="Infection" />
                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                        <asp:ListBox ID="lst_infection" runat="server" OnSelectedIndexChanged="lst_infection_SelectedIndexChanged" AutoPostBack="true" class="form-control"></asp:ListBox>
                        <asp:TextBox ID="txt_inf_other" runat="server" class="form-control"></asp:TextBox>
                        <asp:Button ID="btn_inf" runat="server" Text="Add" OnClick="btn_inf_Click" class="btn btn-primary" />
                 <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <div class="form-group">
                <asp:Label ID="Label16" runat="server" Text="Disease" />                
                <asp:ListBox ID="lst_disease" runat="server" OnSelectedIndexChanged="lst_disease_SelectedIndexChanged"   AutoPostBack="true" class="form-control"></asp:ListBox>
                <asp:TextBox ID="txt_disease_other" runat="server" class="form-control"></asp:TextBox>
                <asp:Button ID="btn_disease" runat="server" Text="Add" OnClick="btn_disease_Click" CausesValidation="False" class="btn btn-primary" />                  
            </div>                 
        </div>        
        <div class="col-sm-push-0 col-md-3">
            <div class="form-group">
            </div>
            <div class="form-group">
                    <asp:Label ID="Label17" runat="server" Text="Noise Exposure" />                
                        <asp:TextBox ID="txt_n_i" runat="server" class="form-control"></asp:TextBox>
                        <asp:DropDownList ID="ddlnoise" runat="server" class="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlnoise_SelectedIndexChanged">
                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                            <asp:ListItem>From 1 Year</asp:ListItem>
                            <asp:ListItem>More Than 1 to 2  Year</asp:ListItem>
                            <asp:ListItem>from 2 to 3  Years</asp:ListItem>
                            <asp:ListItem>More than 5 Years</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_noi_exp" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>                  
            </div>      
            <div class="form-group">
                    <asp:Label ID="Label18" runat="server" Text="trauma" />
                <asp:TextBox ID="txttrauma" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label19" runat="server" Text="Ototoxocity" />
                <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                        <asp:RadioButtonList Style="width: 100%" ID="rbtototxo" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtototxo_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:DropDownList ID="ddltoxnm" runat="server" class="form-control" >
                            <asp:ListItem>Quinine</asp:ListItem>
                            <asp:ListItem>Asprin</asp:ListItem>
                            <asp:ListItem>Steroids</asp:ListItem>
                            <asp:ListItem>Anti TB</asp:ListItem>
                            <asp:ListItem>Amikacin</asp:ListItem>
                            <asp:ListItem>Gentmycin</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddl_duration" runat="server" AutoPostBack="true" class="form-control"
                            OnSelectedIndexChanged="ddl_duration_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Selected="True">&lt; 1 Month</asp:ListItem>
                            <asp:ListItem>&lt; 6Months</asp:ListItem>
                            <asp:ListItem>&lt; 1 Year</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblot_tox" runat="server" Visible="False" class="label-info"></asp:Label>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>          
            <div class="form-group">
                <asp:Label ID="Label20" runat="server" Text="previous Hearing aid User" />                
                        <asp:RadioButtonList Style="width: 100%" ID="rbtp_h_a_user" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtp_h_a_user_SelectedIndexChanged">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label21" runat="server" Text="Ear Site" />                
                        <asp:RadioButtonList Style="width: 100%" ID="rbtearsite" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbtearsite_SelectedIndexChanged" >
                            <asp:ListItem Selected="True" >Right</asp:ListItem>
                            <asp:ListItem>Left</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                        </asp:RadioButtonList>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Previous Hearing aid" />
                     <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>                     
                        <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="ddl_mach_type" runat="server" OnSelectedIndexChanged="ddl_mach_type_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True" class="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>                  
            </div>            
        </div>
        <div class="col-sm-push-0 col-md-3"> 
            <div class="form-group">
                    <asp:Label ID="Label26" runat="server" Text="Previous Hearing aid Experiance" Visible="False" />
                <asp:TextBox ID="txtprevexp" runat="server" class="form-control" TextMode="MultiLine">Whether patient is happy with previous H.AID.  YES  / NO. And want to change . YES /NO</asp:TextBox>
            </div>                                    
            <div class="btn-toolbar list-toolbar">                            
                <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" class="btn btn-primary"></asp:Button>
                <asp:Button ID="btnnxt" runat="server" Text="Next" OnClick="btnprint_Click" class="btn btn-primary" CausesValidation="false" ></asp:Button>                            
                
            </div>
            
            <div class="form-group">
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="h_as_id" class="table table-bordered table-striped"  style="width:100%"  GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="created_dt" HeaderText="Asses Date" SortExpression="created_dt" />
                        <asp:BoundField DataField="h_as_id" HeaderText="Asses No" InsertVisible="False" ReadOnly="True" SortExpression="h_as_id" />
                        <asp:BoundField DataField="ptnt_id" HeaderText="Patient Id" SortExpression="ptnt_id" />
                        <asp:BoundField DataField="apt_id" HeaderText="Apt Id" SortExpression="apt_id" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                </asp:Panel> 
            </div>                       
        </div>      
    </div>
     </ContentTemplate>
 </asp:UpdatePanel>
 </asp:Panel>
</asp:Content>
