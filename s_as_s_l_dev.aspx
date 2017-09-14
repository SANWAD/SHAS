<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="s_as_s_l_dev.aspx.cs" Inherits="s_as_s_l_dev" Title="Untitled Page"  MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="panel panel-default">
 <div class="panel-heading" style="width:100%; height:100%">
        <h class="text-muted text-center">Speech & Language Development</h>
    </div>
    <div><strong><asp:Label ID="Label2" runat="server"  ForeColor="Red" Text="Running Page No  1..........................................................................................Total Pages 6"></asp:Label></strong></div>
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
    <ContentTemplate>
    <div class="panel-body" style="width:100%">
    <div  align="center"  class="form-group"> 
                    <fieldset title="Next">                      
                       <asp:Button ID="btn_pre1" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_pre1_Click"  class="btn btn-primary"/>
                       <asp:Button ID="btn_nxt1" runat="server" Text="Next Page" CausesValidation="False" OnClick="btn_nxt1_Click"  class="btn btn-primary"/>
                       <asp:Button ID="Save" runat="server" BorderStyle="None" OnClick="btn_save_Click" Text="Save"  class="btn btn-primary"/>
                       <asp:Label ID="lblDate" runat="server"></asp:Label>
                        <asp:HiddenField ID="lbl_asid" runat="server" />
                        <asp:HiddenField ID="lbl_aptid" runat="server" />
                        <asp:HiddenField ID="lbl_ptntid" runat="server" />
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
        </div>    
    <div class="col-sm-push-0 col-md-5" style="width:100%">
     <table class="table table-responsive table-hover">
    <tbody>
        <tr>
            <td class="text-right h5" style="width: 207px">    
            </td>
            <td style="width: 429px">
             <asp:RadioButtonList ID="rbtn_sp_lang_chk" runat="server" Font-Bold="True" 
                    Font-Size="8pt" AutoPostBack="True" 
                    OnSelectedIndexChanged="rbtn_sp_lang_chk_SelectedIndexChanged" 
                    style="height:19px" Height="19px" RepeatDirection="Horizontal" >
                <asp:ListItem >Not Applicable</asp:ListItem>
                <asp:ListItem>Not Achived</asp:ListItem>
                <asp:ListItem>Age Appropriate</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="reqrbtn_sp" ControlToValidate="rbtn_sp_lang_chk" runat="server" ErrorMessage="Required To Select the Option" Text="*"  SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
            <td class="text-right h5">
    
            </td>
       </tr>
       
        <tr>
            <td class="text-right h5" style="width: 207px">
              <asp:Label ID="Label74" runat="server" Text="Sentence structure"></asp:Label>
            </td>
            <td style="width: 350px">
             <asp:DropDownList ID="ddlsentstruct" runat="server" class="form-control" Width="300px">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>One Word</asp:ListItem>
                <asp:ListItem>Two Word</asp:ListItem>
                <asp:ListItem>Telegraphic Phrase</asp:ListItem>
                <asp:ListItem>Simple Sentence</asp:ListItem>
                <asp:ListItem>Complex Sentence</asp:ListItem>
                <asp:ListItem Value="Interogative">Interogative</asp:ListItem>
                <asp:ListItem>All Type</asp:ListItem>
                <asp:ListItem>Vocalisation</asp:ListItem>
                <asp:ListItem>Interogative &amp; Simple</asp:ListItem>
                <asp:ListItem>Interogative &amp; Complex</asp:ListItem>
                <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
                <asp:ListItem>Age Appropriate</asp:ListItem>
                <asp:ListItem>Not Achived</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td class="text-right h4">
    
            </td>
           </tr>
           <tr>
           <td class="text-right h4" style="width: 207px">
        
           </td>
           <td class="text-left h4">
           <asp:Label ID="Label243" runat="server" Text="Receptive"></asp:Label>
           </td>
            <td class="text-left h4">
        <asp:Label ID="Label324" runat="server" Text="Expressive"></asp:Label>
           </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label44" runat="server" Text="Simple command"></asp:Label></td>
       </td>
       <td style="width: 300px">
       <asp:RadioButtonList ID="rbtnsimpcmd" runat="server" Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Can Follow</asp:ListItem>
            <asp:ListItem>Can not Follow</asp:ListItem>
            <asp:ListItem Selected="True" >Not applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtn_simpcmd" runat="server" Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Present</asp:ListItem>
            <asp:ListItem Value="Absent">Absent</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label54" runat="server" Text="Body Part"></asp:Label>
       </td>
       <td style="width: 350px">
        <asp:DropDownList ID="ddlbodypartno" runat="server" >
            <asp:ListItem>No of Part</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1 To 5</asp:ListItem>
            <asp:ListItem>6 To 10</asp:ListItem>
            <asp:ListItem>11 To 15</asp:ListItem>
            <asp:ListItem>16 To 20</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlbodyparttype" runat="server" class="form-control"  style="width: 300px">
            <asp:ListItem>Type Of Body Part</asp:ListItem>
            <asp:ListItem>Fine</asp:ListItem>
            <asp:ListItem>Gross</asp:ListItem>
            <asp:ListItem>Both Gross &amp; Fine</asp:ListItem>
            <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
        </asp:DropDownList>
       </td>
       <td>
        <asp:RadioButtonList ID="rbt_body_part" runat="server"  Font-Bold="True" Font-Size="8pt" OnSelectedIndexChanged="rbt_body_part_SelectedIndexChanged">
            <asp:ListItem>Present</asp:ListItem>
            <asp:ListItem>Absent</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label741" runat="server" Text="Common Object"></asp:Label>
       </td>
       <td style="width: 350px">
       <asp:DropDownList ID="ddlcomobjcomp" runat="server" style="width: 300px">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>0-10</asp:ListItem>
            <asp:ListItem>10-25</asp:ListItem>
            <asp:ListItem>25-50</asp:ListItem>
            <asp:ListItem>50-100</asp:ListItem>                            
            <asp:ListItem>100-200</asp:ListItem>
            <asp:ListItem>200-400</asp:ListItem>                            
            <asp:ListItem>400-500</asp:ListItem>                            
            <asp:ListItem>&gt;501</asp:ListItem>
            <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
        </asp:DropDownList>
       </td>
       <td>
       <asp:DropDownList ID="ddlcomobjexp" runat="server"  Font-Bold="True" Font-Size="8pt" style="width: 300px">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>0-10</asp:ListItem>
            <asp:ListItem>10-25</asp:ListItem>
            <asp:ListItem>25-50</asp:ListItem>
            <asp:ListItem>50-100</asp:ListItem>                            
            <asp:ListItem>100-200</asp:ListItem>
            <asp:ListItem>200-400</asp:ListItem>                            
            <asp:ListItem>400-500</asp:ListItem>                            
            <asp:ListItem>&gt;501</asp:ListItem>
            <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
        </asp:DropDownList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label94" runat="server" Text="Colours"></asp:Label>
       </td>
       <td style="width: 350px;">
       <asp:RadioButtonList ID="rbtncolorcomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Shades</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtncolorexp" runat="server"  Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Shades</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label11" runat="server" Text="Numerals"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnnumeralcomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="424px"> 
            <asp:ListItem>Can Understand Value</asp:ListItem>
            <asp:ListItem>Can Not Understand Value</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnnumeralexp" runat="server"   Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Can Resite</asp:ListItem>
            <asp:ListItem>Can not Resite</asp:ListItem>
            <asp:ListItem>Can Count Object</asp:ListItem>
            <asp:ListItem>Can Not Count Object</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Language" runat="server" Text="Fruits"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnfruitcomp" runat="server"   
               Font-Bold="True" Font-Size="8pt" Width="424px">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnfruitexp" runat="server"  
               Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label154" runat="server" Text="Animals"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnanimalcomp" runat="server"  Font-Bold="True" Font-Size="8pt" Width="424px">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnanimaexp" runat="server"  Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label174" runat="server" Text="Vegetables"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnvegcomp" runat="server"  Font-Bold="True" Font-Size="8pt" Width="424px">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnvegexp" runat="server"   Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label194" runat="server" Text="Clothes"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnclothescomp" runat="server"  Font-Bold="True" Font-Size="8pt" Width="424px">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnclothesexp" runat="server"  Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label214" runat="server" Text="Place"></asp:Label>
       </td>
       <td style="width: 429px">
       <asp:RadioButtonList ID="rbtnplacecomp" runat="server" 
               Font-Bold="True" Font-Size="8pt" Width="424px">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
        <asp:RadioButtonList ID="rbtnplacesexp" runat="server"  
               Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Common</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px" >
        <asp:Label ID="Label234" runat="server" Text="Money"></asp:Label>
       </td>
              
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnmoneycomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Identify</asp:ListItem>
            <asp:ListItem>Can Identify Denominations</asp:ListItem>
            <asp:ListItem>Can Do Transaction</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnmoneyexp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Express</asp:ListItem>
            <asp:ListItem>Can Express Denominations</asp:ListItem>
            <asp:ListItem>Can Express Transaction</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label254" runat="server" Text="Time"></asp:Label>
       </td> 
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtntimecomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Understand Day Night Concept</asp:ListItem>
            <asp:ListItem>Can Identify Time</asp:ListItem>
            <asp:ListItem>Can Read Clock</asp:ListItem>
            <asp:ListItem>Can Follow Time</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td style="width: 350px">
        <asp:RadioButtonList ID="rbtntmieexp" runat="server"   Font-Bold="True" Font-Size="8pt" style="width: 300px">
            <asp:ListItem>Express Day Night Concept</asp:ListItem>
            <asp:ListItem>Can Identify Time</asp:ListItem>
            <asp:ListItem>Can Express Clock</asp:ListItem>
            <asp:ListItem>Can follow Time</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label14" runat="server" Text="Tense"></asp:Label>
       </td>
       <td style="width: 350px">
        <%--<asp:RadioButtonList ID="rbtn_comp_tense" runat="server"  RepeatDirection="Horizontal"  class="form-control" Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Can Understand Future</asp:ListItem>
            <asp:ListItem>Can Understand Past</asp:ListItem>
            <asp:ListItem>Can Understand Present</asp:ListItem>
            <asp:ListItem>Can understand all Tenses</asp:ListItem>
            <asp:ListItem>Can Understand Present but cant understand Future</asp:ListItem>
            <asp:ListItem>Can Understand Present but cant understand past</asp:ListItem>
            <asp:ListItem>Can Understand Past but cant understand Future</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>--%>
        <asp:RadioButtonList ID="rbtn_comp_tense" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Understand Future</asp:ListItem>
            <asp:ListItem>Present a Not</asp:ListItem>
            <asp:ListItem>Past a Not</asp:ListItem>
            <asp:ListItem>Future</asp:ListItem>
            <asp:ListItem>Not Present</asp:ListItem>  
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>          
        </asp:RadioButtonList>
       </td>     
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtntenseexp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Express Future</asp:ListItem>
            <asp:ListItem>Can Express Past</asp:ListItem>
            <asp:ListItem>Can Express Present</asp:ListItem>
            <asp:ListItem>Can Express all Tenses</asp:ListItem>
            <asp:ListItem>Can Express Present but cant Express Future</asp:ListItem>
            <asp:ListItem>Can Express Present but cant Express past</asp:ListItem>
            <asp:ListItem>Can Express Past but cant Express Future</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label274" runat="server" Text="Prepositions"></asp:Label>
       </td>
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtprepocomp" runat="server" Width="300px" Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td>
       <asp:RadioButtonList ID="rbtnprepoexp" runat="server" Font-Bold="True" Font-Size="8pt">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label304" runat="server" Text="Adjectives"></asp:Label>
       </td>
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnadjcomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnadjexp" runat="server" Font-Bold="True" Font-Size="8pt" style="width: 300px">
            <asp:ListItem>Basic</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label294" runat="server" Text="Action Verbs"></asp:Label>
       </td>
       <td style="width: 350px">
       <asp:DropDownList ID="ddlactionverbscomp" runat="server" Font-Bold="True" Font-Size="8pt" style="width: 300px">
            <asp:ListItem>No of Verbs</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>10 To 20</asp:ListItem>
            <asp:ListItem>21 To 50</asp:ListItem>
            <asp:ListItem>51 To 100</asp:ListItem>
            <asp:ListItem>100 To 200</asp:ListItem>
            <asp:ListItem>&gt;200</asp:ListItem>
            <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
        </asp:DropDownList>
       
       </td>
       <td style="width: 350px"> 
       <asp:DropDownList ID="ddl_action_verbs_exp" runat="server"  Font-Bold="True" Font-Size="8pt" style="width: 300px">
            <asp:ListItem>No of Verbs</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>10 To 20</asp:ListItem>
            <asp:ListItem>21 To 50</asp:ListItem>
            <asp:ListItem>51 To 100</asp:ListItem>
            <asp:ListItem>100 To 200</asp:ListItem>
            <asp:ListItem>&gt;200</asp:ListItem>
            <asp:ListItem Selected="true" >Not Applicable</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
        </asp:DropDownList>
       </td>
       </tr>
       <tr>
       <td class="text-right h5" style="width: 207px">
       <asp:Label ID="Label344" runat="server" Text="Emotions"></asp:Label>
       </td>
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnemotionscomp" runat="server" Font-Bold="True" Font-Size="8pt" Width="300px">
            <asp:ListItem>Can Understand</asp:ListItem>
            <asp:ListItem>Can Not Understand</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>
       </td>
       <td style="width: 350px">
       <asp:RadioButtonList ID="rbtnemotationsexp" runat="server" Font-Bold="True" Font-Size="8pt" width="300px">
            <asp:ListItem>Can Express</asp:ListItem>
            <asp:ListItem>can not Express</asp:ListItem>
            <asp:ListItem Selected="True" >Not Applicable</asp:ListItem>
            <asp:ListItem>Not Achived</asp:ListItem>
            <asp:ListItem>Age Appropriate</asp:ListItem>
        </asp:RadioButtonList>       
       </td>
       </tr>
       <tr>
       <td colspan="3" rowspan="1" style="text-align:center;">
       <asp:CustomValidator ID="validate_page_wiz2" runat="server" ErrorMessage="Please Check The Page Again....." OnServerValidate="validate_page_wiz2_ServerValidate"></asp:CustomValidator>
       </td>
       </tr>
       <tr>
       <td colspan="3" rowspan="1" style="text-align:center;">
       <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="Server">
       <ContentTemplate>
        <fieldset> 
        <asp:Button ID="btn_prev" runat="server" Text="Previous Page" CausesValidation="False" OnClick="btn_prev_Click" class="btn btn-primary"/>
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" class="btn btn-primary" />
        <asp:Button ID="btn_nxt" runat="server" Text="Next Page"  CausesValidation="False" OnClick="btn_nxt_Click" class="btn btn-primary"/>                        
        </fieldset> 
        </ContentTemplate> 
        </asp:UpdatePanel> 
       </td>
       </tr>
    </tbody>
    </table>
    </div> 
    </div> 
    </ContentTemplate> 
    </asp:UpdatePanel> 
    </div> 
</asp:Content>

