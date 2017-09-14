<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="CochlearImplant.aspx.cs" Inherits="CochlearImplant" Title="Cochlear Implant" %>
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
    <div class="panel-default">
<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
  <ContentTemplate> 
    <div class="panel-heading">
        <h class="text-muted text-center">Cochlear Implant</h>
    </div>
    <%--<div class="pull-right padding-top-small padding-bottom-small padding-right-small">                       
                    <button class="btn btn-primary" onclick="btnprint_Click">Next</button>
                    <asp:Button ID="btnnxt" runat="server" Text="Next" class="btn btn-primary" /> 
    </div>--%>
    <div class="panel-body">
        <div class="col-sm-push-0 col-md-4">
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
        <%-- <asp:HiddenField ID="lblptnttype" runat="server" /> --%>
            <asp:Label ID="Label1" runat="server" Text="Patient Type" />
            <asp:Label ID="lblptnttype" runat="server" class="form-control" />
        </div>        
        <div class="form-group">
                <table style="width:100%">
                    <tr>
                    <td style="width:98%">
                        <asp:Label ID="Label23" runat="server" ForeColor="Red" Text="*"></asp:Label>
                         <asp:Label ID="Label5" runat="server" Text="Patient Name" />                
                            <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                            <div id="divwidth" style="display: none">
                            </div>
                            <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth">
                            </AjaxToolkit:AutoCompleteExtender>  
                             </td>
                    <td style="width:2%">
                    <asp:RequiredFieldValidator runat="server" id="reqPtNm" controltovalidate="txtptnt_nm" Text="*"  SetFocusOnError="true"  EnableClientScript="true"/>
                    </tr> 
                    </table>                           
        </div>
        <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Date Of Birth"/>
            <asp:Label ID="lblptntdob" runat="server" class="form-control" Enabled="false" />
        </div>
        <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Age"/>
            <asp:Label ID="lblptntage" runat="server" class="form-control" Enabled="false" />
        </div>
        <div class="form-group">                
                <asp:Label ID="Label8" runat="server" Text="Gender"/>
            <asp:Label ID="lblgender" runat="server" class="form-control" Enabled="false"/>
        </div>
        <div class="form-group">
                <asp:Label ID="Label22" runat="server" Text="Profession"/>
            <asp:Label ID="lblprofession" runat="server" class="form-control" Enabled="false"/>
        </div>
        </div>
        <div class="col-sm-push-0 col-md-4">
            <h3 class="label label-primary img-label padding-top-small padding-bottom-small">Surgical Details</h3>
            <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Name Of Surgeon"/>
                        <asp:DropDownList ID="ddl_Surgeon" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_complaints_SelectedIndexChanged"
                            Class="form-control">
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
            </div>
            <div class="form-group">
            <table style="width:100%">
               <tr>
                <td style="width:98%">
                <asp:Label ID="Label10" runat="server" Text="Surgery Date"/>
                <asp:TextBox ID="txtSurDate" runat="server" class="form-control" MaxLength="15"></asp:TextBox>
                 <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtSurDate_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtSurDate" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                 </AjaxToolkit:CalendarExtender>
                   </td>
                <td style="width:2%">                                      
                <div>
                <asp:Image ID="CalImage" ImageUrl="~/images/calendar.png" runat="server" />
                </div>
                </td>
               </tr> 
              </table> 
            </div>
            <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Birth history"/>
                <asp:TextBox ID="txtbirthhistry" runat="server" class="form-control" MaxLength="2000"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Medical history"/>
                <asp:TextBox ID="txtmedhistry" runat="server" class="form-control" MaxLength="2000"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label13" runat="server" Text="Ear Implanted"/>                
                        <fieldset title="DDLSURGEON">
                            <asp:RadioButtonList ID="rbtearsite" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtearsite_SelectedIndexChanged" AutoPostBack="True" Style="width:100%">
                                <asp:ListItem>Right</asp:ListItem>
                                <asp:ListItem>Left</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                            </asp:RadioButtonList>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="Implanted Model"/>
                <asp:TextBox ID="txtImpMod" runat="server" MaxLength="15" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="Label15" runat="server" Text="Serial Number"/>
                <asp:TextBox ID="txtSrno" runat="server" MaxLength="15" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-push-0 col-md-4">            
        <asp:Label ID="Label19" runat="server" Text="Speech Processor Details" class="label label-primary img-label padding-top-small padding-bottom-small"></asp:Label>
            <asp:Label ID="Label17" runat="server" Text="Right Ear" class="label label-success img-label padding-top-small padding-bottom-small" style="background-color:Red"></asp:Label>
            <div class="form-group">
                    <asp:Label ID="lblSPMR" runat="server" Text="Speech Processor Model"/>
                <asp:TextBox ID="txtSPMR" runat="server" MaxLength="15" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                    <asp:Label ID="lblSNR" runat="server" Text="Serial Number"/>
                <asp:TextBox ID="txtSNR" runat="server" MaxLength="15" Class="form-control" />
            </div>
            <div class="form-group">
             <table style="width:100%">
               <tr>
                <td style="width:98%">
                    <asp:Label ID="lblDFFR" runat="server" Text="Date First Fitted"/>
                <asp:TextBox ID="txtDFFR" runat="server" MaxLength="15" class="form-control" />
                 <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDFFR_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtDFFR" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                 </AjaxToolkit:CalendarExtender>
                   </td>
                <td style="width:2%">                                      
                <div>
                <asp:Image ID="Cal1Image" ImageUrl="~/images/calendar.png" runat="server" />
                </div>
                </td>
               </tr> 
              </table> 
            </div>
            <asp:Label ID="Label18" runat="server" Text="Left Ear" class="label label-primary img-label padding-top-small padding-bottom-small"></asp:Label>
            <div class="form-group">
                    <asp:Label ID="lblSPML" runat="server" Text="Speech Processor Model"/>
                <asp:TextBox ID="txtSPML" runat="server" MaxLength="15" class="form-control" />
            </div>
            <div class="form-group">
                    <asp:Label ID="lblSNL" runat="server" Text="Serial Number"/>
                <asp:TextBox ID="txtSNL" runat="server" MaxLength="15" class="form-control" />
            </div>
            <div class="form-group">
            <table style="width:100%">
               <tr>
                <td style="width:98%">
                    <asp:Label ID="lblDFFL" runat="server" Text="Date First Fitted"/>
                <asp:TextBox ID="txtDFFL" runat="server" MaxLength="15" class="form-control" />
                 <AjaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtDFFL_OnTextChanged" PopupPosition="BottomLeft" TargetControlID="txtDFFL" OnClientDateSelectionChanged="CheckDateEalier" CssClass="ajax__calendar">
                 </AjaxToolkit:CalendarExtender>
                   </td>
                <td style="width:2%">                                      
                <div>
                <asp:Image ID="Cal2Image" ImageUrl="~/images/calendar.png" runat="server" />
                </div>
                </td>
               </tr> 
              </table> 
            </div>
        </div>
        <div class="pull-right padding-top-small padding-bottom-small padding-right-small">            
                <asp:Button ID="btn_save" runat="server" Width="64px" Text="Save" OnClick="btn_save_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"></asp:Button>                   
                    <asp:Button ID="btnprint" runat="server" Text="PRINT" OnClick="btnprint_Click" class="btn btn-primary"></asp:Button>                                    
        </div>
    </div>
 <div class="form-group">
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
       <asp:GridView ID="GridView1" runat="server" AllowSorting="True" Font-Size="Small" AutoGenerateColumns="False" BackColor="White" BorderColor="White" DataKeyNames=" Cho_Impl_id, apt_id, ptnt_id, Nm_Surg, Surg_Dt, birth_histry, med_histry, Ear_Implant, Implant_Model, Sr_No, RSp_Pr_Mod, RSr_No,RDt_Fst_Ftd, LSp_Pr_Mod, LSr_No, LDt_Fst_Ftd"
        class="table table-bordered table-striped"  style="width:100%"  GridLines="None">
        <Columns>
           <%-- <asp:BoundField DataField="Cho_Impl_dt" HeaderText="CH Date" SortExpression="Cho_Impl_dt" />--%>
            <asp:BoundField DataField="Cho_Impl_id" HeaderText="CH Implant Id" SortExpression="Cho_Impl_id" />
            <asp:BoundField DataField="Nm_Surg" HeaderText="Nm Surgen" SortExpression="Nm_Surg" />
            <asp:BoundField DataField="Surg_Dt" HeaderText="Sur Date" SortExpression="Surg_Dt" />
            <asp:BoundField DataField="birth_histry" HeaderText="Birth Hst" SortExpression="birth_histry" />
            <asp:BoundField DataField="med_histry" HeaderText="Med Hst" SortExpression="med_histry" />
            <asp:BoundField DataField="Ear_Implant" HeaderText="Ear Impl" SortExpression="Ear_Implant" />
            <asp:BoundField DataField="Implant_Model" HeaderText="Impl Model" SortExpression="Implant_Model" />
            <asp:BoundField DataField="Sr_No" HeaderText="Srno" SortExpression="Sr_No" />
            <asp:BoundField DataField="RSp_Pr_Mod" HeaderText="Rt Model" SortExpression="RSp_Pr_Mod" />
            <asp:BoundField DataField="RSr_No" HeaderText="Rt Srno" SortExpression="RSr_No" />
            <asp:BoundField DataField="RDt_Fst_Ftd" HeaderText="Rt Date" SortExpression="RDt_Fst_Ftd" />
            <asp:BoundField DataField="LSp_Pr_Mod" HeaderText="Lt Model" SortExpression="LSp_Pr_Mod" />
            <asp:BoundField DataField="LSr_No" HeaderText="Lt Srno" SortExpression="LSr_No" />
            <asp:BoundField DataField="LDt_Fst_Ftd" HeaderText="Lt Date" SortExpression="LDt_Fst_Ftd" />
            <asp:ButtonField CommandName="Select" HeaderText="Select Form" Text="Select" />
        </Columns> 
    </asp:GridView>
    </asp:Panel>  
    </div> 
   </ContentTemplate>
 </asp:UpdatePanel>
</div> 
</asp:Content>
