<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_digno.aspx.cs" Inherits="Clinical_Forms_h_digno" Title="Assesments details" MaintainScrollPositionOnPostback="true"  %>
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
    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
          <ContentTemplate>           
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Assesments details</h>
<%--                        <asp:GridView ID="gridh_lastdigno" runat="server" 
                AutoGenerateColumns="False" AllowPaging="True"
                            PageSize="4" 
                OnPageIndexChanging="gridh_lastdigno_PageIndexChanging" 
                class="table pagination" 
                onselectedindexchanged="gridh_lastdigno_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Date &amp; Time" DataField="h_digno_dt"></asp:BoundField>
                                <asp:BoundField HeaderText="Last Dignosis" DataField="h_digno_detail"></asp:BoundField>
                                <asp:BoundField DataField="h_avg_pta_right" HeaderText="PTA Right" />
                                <asp:BoundField DataField="h_avg_pta_left" HeaderText="PTA Left" />
                            </Columns>
                        </asp:GridView>--%>
        </div>            
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-12">
                <div class="form-group">
                    <div class="pull-right padding-top-small padding-bottom-small padding-right-small">                                                  
                                    <%--<button class="btn btn-primary" onclick="btnprint_Click">Next</button>--%> 
                    </div>
                    <asp:Label ID="lblPtnt_nm" runat="server" Width="30%" class="form-control padding-top-small padding-bottom-small padding-left-small" />
                    <asp:Label ID="lbldate" runat ="server" class="form-control"></asp:Label>
                    <asp:Label ID="lbl_msg" runat="server"  Font-Bold="True" Font-Italic="False" Text=" Assesments details" BackColor="Black" ForeColor="Yellow"></asp:Label>
                    <asp:HiddenField ID="lbl_asid" runat="server" />
                    <asp:HiddenField ID="lbl_aptid" runat="server" />
                    <asp:HiddenField ID="lbl_ptntid" runat="server" />
                </div>
                <%--<div class="panel panel-default">
                    <a href="#widget1container" class="panel-heading"  data-toggle="collapse">Details</a>
                    <div id="widget1container" class="panel-body collapse in">
                    </div>
                </div>--%>
            </div>
            <div class="col-sm-push-0 col-md-7">            
              <div class="panel panel-default">
                <a href="#widget1container1" class="panel-heading" data-toggle="collapse" style="width:100%">Audiogram AC </a>
                <div id="widget1container1" class="panel-body collapse in">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <table class="table table-bordered table-responsive">
                        <tr>
                            <td style="width: 2.0em;">
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    250 Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    500 Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    1K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    1.5K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    2K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    3K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    4K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    6K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                                <label>
                                    8K Hz</label>
                            </td>
                            <td style="width: 2.0em;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2.0em;">
                                <label style="color:Red">
                                    R</label>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_250_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_500_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_1k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_1_5k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_2k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_3k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_4k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_6k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_8k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">                                  
                                        <asp:Button ID="btn_unmasked_pta_r" runat="server" OnClick="btn_unmasked_pta_Click" Text="PTA" class="btn btn-default" />  
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2.0em;">
                                <div style="width: 2.0em;">
                                    <label style="color:Blue">
                                        L</label>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_250_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_500_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_1k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_1_5k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_2k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_3k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_4k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_6k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">
                                <asp:TextBox ID="txt_ac_8k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                            </td>
                            <td style="width: 2.0em;">                                    
                                        <asp:Button ID="btn_unmasked_pta_l" runat="server" Text="PTA" OnClick="btn_unmasked_pta_l_Click"
                                            class="btn btn-default" />                                     
                            </td>
                        </tr>
                    </table>
                    </asp:Panel> 
                </div>                    
                </div> 
            </Div>     
            <div class="col-sm-push-0 col-md-5">
                <div class="panel panel-default">
                    <a href="#widget1container2" class="panel-heading" data-toggle="collapse" style="width:100%">Audiogram BC </a>
                    <div id="widget1container2" class="panel-body collapse in">
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                        <table class="table table-bordered table-responsive">
                            <tr>
                                <td style="width: 2.0em;">
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        250 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        500 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1K Hz</label>
                                </td>
                                <td>
                                    <label>
                                        1.5K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        2K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        3K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        4K Hz</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color:Red">
                                        R
                                    </label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_250_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_500_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_1k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_1_5k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_2k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_3k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_4k_r" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:Blue">
                                        L</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_250_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_500_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_1k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_1_5k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_2k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_3k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_bc_4k_l" runat="server" Style="width: 2.0em;" Text=""></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel> 
                    </div>
                </div>
            </div>
            <div class="col-sm-push-0 col-md-7">
                <div class="panel panel-default">
                    <a href="#widget1container3" class="panel-heading" data-toggle="collapse" style="width:100%">A.C.Audiogram Masking </a>
                    <div id="widget1container3" class="panel-body collapse in">
                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto">
                        <table class="table table-bordered table-responsive">
                            <tr>
                                <td style="width: 2.0em;">
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        250 Hz</label>
                                </td>
                                <td>
                                    <label>
                                        500 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1.5K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        2K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        3K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        4K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        6K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        8K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:Red">
                                        R
                                    </label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_250_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_500_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1_5k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_2k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_mask_3k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_4k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_mask_6k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_8k_r" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                            <asp:Button ID="btn_masked_pta_r" runat="server" OnClick="btn_masked_pta_Click" Text="PTA" class="btn btn-default" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:Blue">
                                        L</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_250_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_500_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1_5k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_2k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_3k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_mask_4k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_6k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_8k_l" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">                                   
                                            <asp:Button ID="btn_masked_pta_l" runat="server" Text="PTA" OnClick="btn_masked_pta_l_Click"
                                                class="btn btn-default" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel> 
                    </div>
                </div>
            </div>
            <div class="col-sm-push-0 col-md-5">
                <div class="panel panel-default">
                    <a href="#widget1container4" class="panel-heading" data-toggle="collapse" style="width:100%">B.C.Audiogram Masking </a>
                    <div id="widget1container4" class="panel-body collapse in">
                    <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto">
                        <table class="table table-bordered table-responsive">
                            <tr>
                                <td style="width: 2.0em;">
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        250 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        500 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1.5K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        2K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        3K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        4K Hz</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="color:Red">
                                        R
                                    </label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_250_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_500_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1k_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1_5_k_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_2k_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_3k_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_4k_r_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:blue">
                                        L</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_250_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_500_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1k_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_1_5_k_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_2k_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_3k_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mask_4k_l_bc" runat="server" Style="width: 2.0em;" Text="">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel> 
                    </div>
                </div>
            </div>
            <div class="col-sm-push-0 col-md-7">          
              <div class="panel panel-default">
                <a href="#widget1container1" class="panel-heading" data-toggle="collapse" style="width:100%">UCL Thresholds :- </a>
                <div id="Div1" class="panel-body collapse in"> 
                <asp:Panel ID="Panel5" runat="server" ScrollBars="Auto">
                        <table class="table table-bordered table-responsive">
                            <tr>
                                <td style="width: 2.0em;">
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        250 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        500 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1.5K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        2K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        3K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        4K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        6K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        8K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:Red">
                                        R</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_250_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_500_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_1k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_1_5k_r" runat="server" Style="width: 2.0em;" Text="NA" ></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_2k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_3k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_4k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_6k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_8k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">                                  
                                    <asp:Button ID="btnUCL1" runat="server" Text="Average" class="btn btn-default" onclick="btnUCL1_Click" />  
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <div style="width: 2.0em;">
                                        <label style="color:Blue">L</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_250_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_500_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_1k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_1_5k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_2k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_3k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_4k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_6k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_ucl_8k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">                                    
                                    <asp:Button ID="btnUCL2" runat="server" Text="Average" class="btn btn-default" onclick="btnUCL2_Click" />                                     
                                </td>
                            </tr>
                        </table>
                        </asp:Panel> 
                </div> 
              </div> 
            </Div>               
            <div class="col-sm-push-0 col-md-5">                
              <div class="panel panel-default">
                <a href="#widget1container1" class="panel-heading" data-toggle="collapse" style="width:100%">MCL Thresholds :- </a>
                <div id="Div2" class="panel-body collapse in">
                <asp:Panel ID="Panel6" runat="server" ScrollBars="Auto">
                        <table class="table table-bordered table-responsive">
                            <tr>
                                <td style="width: 2.0em;">
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        250 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        500 Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        1.5K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        2K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        3K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        4K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        6K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <label>
                                        8K Hz</label>
                                </td>
                                <td style="width: 2.0em;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <label style="color:Red">
                                        R</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_250_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_500_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_1k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_1_5k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_2k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_3k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_4k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_6k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_8k_r" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">                                  
                                    <asp:Button ID="btnMCL1" runat="server" Text="Average" class="btn btn-default" onclick="btnMCL1_Click" />  
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2.0em;">
                                    <div style="width: 2.0em;">
                                        <label style="color:Blue">
                                            L</label>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_250_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_500_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_1k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_1_5k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_2k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_3k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_4k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_6k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">
                                    <asp:TextBox ID="txt_mcl_8k_l" runat="server" Style="width: 2.0em;" Text="NA"></asp:TextBox>
                                </td>
                                <td style="width: 2.0em;">                                    
                                    <asp:Button ID="btnMCL2" runat="server" Text="Average" class="btn btn-default" onclick="btnMCL2_Click" />                                     
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>  
                </div> 
              </div>
            </div>
       
            <div class="col-sm-push-0 col-md-12">
                <table class="table table-responsive">
                    <tbody>
                        <tr>
                            <td style="width:133px">
                            </td>
                            <td style="width: 436px">
                                <div class="form-group">
                                    <label>
                                        PTA Right Ear</label>
                                    <asp:TextBox ID="txt_pta_rt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default" Width="40">
                                    </asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <label>
                                        PTA Left Ear</label>
                                    <asp:TextBox ID="txt_pta_lt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default"
                                        Width="40">
                                    </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                        <td style="width:133px">
                        </td>
                         <td style="width: 436px">
                            <div class="form-group">
                                <label>UCL Right Ear</label>
                                <asp:TextBox ID="txt_ucl_rt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default" Width="40">
                                </asp:TextBox>
                            </div>
                         </td>
                         <td colspan="2">
                                <div class="form-group">
                                    <label>UCL Left Ear</label>
                                    <asp:TextBox ID="txt_ucl_lt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default" Width="40">
                                    </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                        <td style="width:133px">
                        </td>
                         <td style="width: 436px">
                            <div class="form-group">
                                <label>MCL Right Ear</label>
                                <asp:TextBox ID="txt_mcl_rt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default" Width="40">
                                </asp:TextBox>
                            </div>
                         </td>
                         <td colspan="2">
                                <div class="form-group">
                                    <label>MCL Left Ear</label>
                                    <asp:TextBox ID="txt_mcl_lt" runat="server" MaxLength="5" ReadOnly="True" class="form-label-default" Width="40">
                                    </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Pure Tone Audiometry</label>
                            </td>
                            <td class="style3" style="width: 436px">
                                        <asp:DropDownList ID="ddl_puretone_degree_right" runat="server" class="form-control">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                            <asp:ListItem>MILD</asp:ListItem>
                                            <asp:ListItem>MODERATE</asp:ListItem>
                                            <asp:ListItem>MODERATELY SEVERE</asp:ListItem>
                                            <asp:ListItem>SEVERE</asp:ListItem>
                                            <asp:ListItem>PROFOUND</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_puretone_type_loss_right" runat="server" class="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddl_puretone_type_loss_right_SelectedIndexChanged1">
                                            <asp:ListItem>Type Of Hear Loss</asp:ListItem>
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing  Sensitivity is Within Normal Limits</asp:ListItem>
                                            <asp:ListItem>CONDUCTIVE</asp:ListItem>
                                            <asp:ListItem>MIXED</asp:ListItem>
                                            <asp:ListItem>SN</asp:ListItem>
                                            <asp:ListItem>SLOPING</asp:ListItem>
                                            <asp:ListItem>FLAT</asp:ListItem>
                                            <asp:ListItem>RISING</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_pta_right" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
                            </td>
                            <td class="text-right" colspan="2">
                                        <asp:DropDownList ID="ddl_puretone_degree_left" runat="server" class="form-control">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                            <asp:ListItem>MILD</asp:ListItem>
                                            <asp:ListItem>MODERATE</asp:ListItem>
                                            <asp:ListItem>MODERATELY SEVERE</asp:ListItem>
                                            <asp:ListItem>SEVERE</asp:ListItem>
                                            <asp:ListItem>PROFOUND</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_puretone_type_loss_left" runat="server" class="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddl_puretone_type_loss_left_SelectedIndexChanged1">
                                            <asp:ListItem>Type Of Hear Loss</asp:ListItem>
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing  Sensitivity is Within Normal Limits</asp:ListItem>
                                            <asp:ListItem>CONDUCTIVE</asp:ListItem>
                                            <asp:ListItem>MIXED</asp:ListItem>
                                            <asp:ListItem>SN</asp:ListItem>
                                            <asp:ListItem>SLOPING</asp:ListItem>
                                            <asp:ListItem>FLATE</asp:ListItem>
                                            <asp:ListItem>RISING</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_pta_left" runat="server" class="form-control" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:133px">
                            </td>
                            <td class="style1" style="width: 436px">
                                <label class="label label-primary img-label padding-top-small padding-bottom-small" style="background-color:Red">Right Ear</label>
                            </td>
                            <td colspan="2" class="text-center">
                                <label class="label label-primary img-label padding-top-small padding-bottom-small">Left Ear</label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">
                                    Tympanometry</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                        <asp:DropDownList ID="ddl_tymp_graph_right" runat="server" class="form-control" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddl_tymp_graph_right_SelectedIndexChanged">
                                            <asp:ListItem>Select Graph</asp:ListItem>
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>'A'</asp:ListItem>
                                            <asp:ListItem>'Ad'</asp:ListItem>
                                            <asp:ListItem>'As'</asp:ListItem>
                                            <asp:ListItem>'B'</asp:ListItem>
                                            <asp:ListItem>'C'</asp:ListItem>
                                            <asp:ListItem>'c-u'</asp:ListItem>
                                            <asp:ListItem>'Flat'</asp:ListItem>                                            
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_comp_right" runat="server" class="form-control">
                                            <asp:ListItem>Normal Compliance</asp:ListItem>
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Very High</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Very Low</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlRPre" runat="server" OnSelectedIndexChanged="ddlRPre_SelectedIndexChanged" AutoPostBack="true" class="form-control">
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>Normal M.E.Pressure</asp:ListItem>
                                            <asp:ListItem>-Ve M.E.Pressure</asp:ListItem>
                                            <asp:ListItem>+Ve M.E.Pressure</asp:ListItem>
                                            <asp:ListItem>Seal Not Obtained</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_ref_rt" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddl_ref_rt_SelectedIndexChanged" class="form-control">
                                            <asp:ListItem>Reflexes</asp:ListItem>
                                            <asp:ListItem>Not Applicable</asp:ListItem>
                                            <asp:ListItem>Reflexes Absent</asp:ListItem>
                                            <asp:ListItem>Reflexes Present</asp:ListItem>
                                            <asp:ListItem>only IPSI Reflexes are Present</asp:ListItem>
                                            <asp:ListItem>only Contra Reflexes are Present</asp:ListItem>
                                            <asp:ListItem>Both the Reflexes are Present</asp:ListItem>
                                            <asp:ListItem>Both the Reflexes are Absent</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                        <asp:TextBox ID="txttymp_right" runat="server" MaxLength="100" class="form-control"></asp:TextBox>
                            </td>
                            <td colspan="2" class="text-left">
                                <div class="text-left">
                                            <asp:DropDownList ID="ddl_tymp_graph_left" runat="server" class="form-control" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddl_tymp_graph_left_SelectedIndexChanged">
                                                <asp:ListItem>Select Graph</asp:ListItem>
                                                <asp:ListItem>Not Applicable</asp:ListItem>
                                                <asp:ListItem>'A'</asp:ListItem>
                                                <asp:ListItem>'Ad'</asp:ListItem>
                                                <asp:ListItem>'As'</asp:ListItem>
                                                <asp:ListItem>'B'</asp:ListItem>
                                                <asp:ListItem>'C'</asp:ListItem>
                                                <asp:ListItem>'c-u'</asp:ListItem>
                                                <asp:ListItem>'Flat'</asp:ListItem>                                                
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddl_complaince_left" runat="server" class="form-control">
                                                <asp:ListItem>Normal Compliance</asp:ListItem>
                                                <asp:ListItem>Not Applicable</asp:ListItem>
                                                <asp:ListItem>Normal</asp:ListItem>
                                                <asp:ListItem>High</asp:ListItem>
                                                <asp:ListItem>Very High</asp:ListItem>
                                                <asp:ListItem>Low</asp:ListItem>
                                                <asp:ListItem>Very Low</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlLPre" runat="server" OnSelectedIndexChanged="ddlLPre_SelectedIndexChanged"
                                                AutoPostBack="True" class="form-control">
                                                <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                                <asp:ListItem>Normal M.E.Pressure</asp:ListItem>
                                                <asp:ListItem>-Ve M.E.Pressure</asp:ListItem>
                                                <asp:ListItem>+Ve M.E.Pressure</asp:ListItem>
                                                <asp:ListItem>Seal Not Obtained</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddl_reflexes_left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_reflexes_left_SelectedIndexChanged"
                                                class="form-control">
                                                <asp:ListItem>Reflexes</asp:ListItem>
                                                <asp:ListItem>Not Applicable</asp:ListItem>
                                                <asp:ListItem>Reflexes Absent</asp:ListItem>
                                                <asp:ListItem>Reflexes Present</asp:ListItem>
                                                <asp:ListItem>only IPSI Reflexes are Present</asp:ListItem>
                                                <asp:ListItem>only Contra Reflexes are Present</asp:ListItem>
                                                <asp:ListItem>Both the Reflexes are Present</asp:ListItem>
                                                <asp:ListItem>Both the Reflexes are Absent</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                            <asp:TextBox ID="txttymp_left" runat="server" class="form-control" MaxLength="100"></asp:TextBox></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">BERA Test</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                        <asp:DropDownList ID="ddl_bera_right" runat="server" class="form-control" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddl_bera_right_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Normal ABR Waveform</asp:ListItem>
                                            <asp:ListItem>Mild Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Moderate Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Severe Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Profound Hearing Loss</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_bera_rt" runat="server" Rows="2" class="form-control"></asp:TextBox>
                            </td>
                            <td class="text-right" colspan="2">
                                        <asp:DropDownList ID="ddl_bera_left" runat="server" class="form-control" OnSelectedIndexChanged="ddl_bera_left_SelectedIndexChanged"
                                            AutoPostBack="True">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Normal ABR Waveform</asp:ListItem>
                                            <asp:ListItem>Mild Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Moderate Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Severe Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Profound Hearing Loss</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_bera_lt" runat="server" Rows="2" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">ASSR Test</label>
                            </td>
                            <td class="style2" style="width: 436px">
                           <%-- <asp:DropDownList ID="ddlASSRR" runat="server" class="form-control" AutoPostBack="True">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Normal ABR Waveform</asp:ListItem>
                                            <asp:ListItem>Mild Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Moderate Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Severe Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Profound Hearing Loss</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtASSRR" runat="server" Rows="2" class="form-control"></asp:TextBox>--%>
                            </td>
                            <td class="text-right" colspan="2">
                            <%--<asp:DropDownList ID="ddlASSRL" runat="server" class="form-control" AutoPostBack="True">
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                            <asp:ListItem>Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Normal ABR Waveform</asp:ListItem>
                                            <asp:ListItem>Mild Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Moderate Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Severe Hearing Loss</asp:ListItem>
                                            <asp:ListItem>Profound Hearing Loss</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtASSRL" runat="server" Rows="2" class="form-control"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Speech Audiometry</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                        <asp:RadioButtonList ID="rbtn_speech_aud_right" runat="server" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="rbtn_speech_aud_right_SelectedIndexChanged" AutoPostBack="True"
                                            class="inline Radio" style="width:100%">
                                            <asp:ListItem>Applicable</asp:ListItem>
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                        </asp:RadioButtonList>
                            </td>
                            <td colspan="2" class="text-left">
                                        <asp:RadioButtonList ID="rbtn_speech_aud_left" runat="server" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="rbtn_speech_aud_left_SelectedIndexChanged" AutoPostBack="True" style="width:100%">
                                            <asp:ListItem>Applicable</asp:ListItem>
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                        </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Speech Audiometry</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                <div class="form-group">
                                    <label class="label label-primary img-label padding-top-small padding-bottom-small" style="background-color:Red">SRS (50dB SL)</label>
                                    <div class="form-control">
                                        <asp:TextBox ID="txt_sds_right" class="form-label" runat="server" Width="5.0em" MaxLength="3" onkeydown="return isNumeric(event.keyCode);">0</asp:TextBox>
                                        <label>in Percentage</label>
                                    </div>
                                    <label class="label label-primary img-label padding-top-small padding-bottom-small" style="background-color:Red">SRT</label>
                                    <div class="form-control">
                                        <asp:TextBox ID="txt_srt_right" runat="server" Width="5.0em" MaxLength="3" class="form-label" onkeydown="return isNumeric(event.keyCode);">0</asp:TextBox>
                                        <label>in dB</label>
                                    </div>
                                </div>
                            </td>
                            <td class="text-left" colspan="2">
                                <div class="form-group">
                                    <label class="label label-primary img-label padding-top-small padding-bottom-small">SRS (50dB SL)</label>
                                    <div class="form-control">
                                        <asp:TextBox ID="txt_sds_left" class="form-label" runat="server" Width="5.0em" MaxLength="3" onkeydown="return isNumeric(event.keyCode);">0</asp:TextBox>
                                        <label>in Percentage</label>
                                    </div>
                                    <label class="label label-primary img-label padding-top-small padding-bottom-small">SRT</label>
                                    <div class="form-control">
                                        <asp:TextBox ID="txt_srt_left" runat="server" Width="5.0em" MaxLength="3" class="form-label">0</asp:TextBox>
                                        <label>in dB</label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Special Test</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                <label class="label label-primary img-label padding-top-small padding-bottom-small" style="background-color:Red">
                                    Tonedecay Test</label>
                                <asp:DropDownList class="form-control" ID="ddl_spl_tonedecay_right" runat="server">
                                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                                    <asp:ListItem>Decay Mild</asp:ListItem>
                                    <asp:ListItem>Decay Strong</asp:ListItem>
                                    <asp:ListItem>Decay Absent</asp:ListItem>
                                </asp:DropDownList>
                                <label class="label label-primary img-label padding-top-small padding-bottom-small" style="background-color:Red">
                                    SISI Test</label>
                                <asp:DropDownList class="form-control" ID="ddl_spl_sisi_right" runat="server">
                                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>1 dB Increment  Identification Present</asp:ListItem>
                                    <asp:ListItem>1 dB Increment  Identification Absent</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="text-left" colspan="2">
                                <label class="label label-primary img-label padding-top-small padding-bottom-small">
                                    Tonedecay Test</label>
                                <asp:DropDownList class="form-control" ID="ddl_spl_tonedecay_left" runat="server">
                                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                                    <asp:ListItem>Decay Mild</asp:ListItem>
                                    <asp:ListItem>Decay Strong</asp:ListItem>
                                    <asp:ListItem>Decay Absent</asp:ListItem>
                                </asp:DropDownList>
                                <label class="label label-primary img-label padding-top-small padding-bottom-small">
                                    SISI Test</label>
                                <asp:DropDownList class="form-control" ID="ddl_spl_sisi_left" runat="server">
                                    <asp:ListItem Selected="true">Not Applicable</asp:ListItem>
                                    <asp:ListItem>Normal</asp:ListItem>
                                    <asp:ListItem>1 dB Increment  Identification Present</asp:ListItem>
                                    <asp:ListItem>1 dB Increment  Identification Absent</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">OAE Test</label>
                            </td>
                            <td class="style2" style="width: 436px">
                                <asp:RadioButtonList ID="rbtn_oae_right" runat="server" RepeatDirection="Horizontal" Font-Bold="True" OnSelectedIndexChanged="rbtn_oae_right_SelectedIndexChanged" Height="16px" Width="293px" AutoPostBack="true" style="width:100%" >
                                    <asp:ListItem>Pass</asp:ListItem>
                                    <asp:ListItem>Refer</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtPass" runat="server" class="form-control" Rows="2">
                                </asp:TextBox>
                            </td>
                            <td class="text-left" colspan="2">
                                <asp:RadioButtonList ID="rbtn_oae_left" runat="server" RepeatDirection="Horizontal" Font-Bold="True" OnSelectedIndexChanged="rbtn_oae_left_SelectedIndexChanged" Height="16px" Width="316px" AutoPostBack="True" style="width:100%">
                                    <asp:ListItem>Pass</asp:ListItem>
                                    <asp:ListItem>Refer</asp:ListItem>
                                    <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtPass1" runat="server" class="form-control" Rows="2">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Hearing Aid</label>
                            </td>
                            <td colspan="3" class="text-center">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                            RepeatDirection="Horizontal" Width="323px">
                                            <asp:ListItem>Applicable</asp:ListItem>
                                            <asp:ListItem Selected="True">Not Applicable</asp:ListItem>
                                        </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                               <%-- <label class="h4">Recommended Hearing Aid</label>--%>
                                <asp:Label ID="Label34" runat="server" Text="Recommended Hearing Aid" 
                                    class="h4" Visible="False"></asp:Label>
                            </td>
                            <td class="text-left" style="width: 436px">
                                        <asp:DropDownList ID="ddl_comp1" runat="server" class="form-control" OnSelectedIndexChanged="ddl_comp1_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_model1" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_model1_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_type1" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_type1_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_mach1" runat="server" class="form-control"></asp:TextBox>
                            </td>
                            <td colspan="2" class="text-left">
                                        <asp:DropDownList ID="ddl_comp2" runat="server" class="form-control" OnSelectedIndexChanged="ddl_comp2_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_model2" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_model2_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_type2" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_type2_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_mach2" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <%--<label class="h4">Selected Hearing Aid</label>--%>
                                <asp:Label ID="Label12" runat="server" Text="Selected Hearing Aid" class="h4" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td class="text-right" style="width: 436px">
                                        <asp:DropDownList ID="ddl_comp3" runat="server" class="form-control" OnSelectedIndexChanged="ddl_comp3_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_model3" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_model3_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_type3" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach3_type_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_mach3" runat="server" class="form-control"></asp:TextBox>
                            </td>
                            <td colspan="2" class="text-left">
                                        <asp:DropDownList ID="ddl_comp4" runat="server" class="form-control" OnSelectedIndexChanged="ddl_comp4_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_model4" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_model4_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_mach_type4" runat="server" class="form-control" OnSelectedIndexChanged="ddl_mach_type4_SelectedIndexChanged"
                                            AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_mach4" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px; height: 51px;">
                                <label class="h4">Diagnostic Details</label>
                            </td>
                            <td style="width: 436px; height: 51px;">
                                <asp:TextBox ID="txth_digno_det" runat="server" class="form-control" MaxLength="2000" Rows="2" ></asp:TextBox>
                            </td>
                            <td class="text-right" style="width:50px; height: 51px;">
                                <label class="h4">Suggestion</label>
                            </td>
                            <td style="width:300px; height: 51px;">
                                <asp:TextBox ID="txtsuggest" runat="server" class="form-control" Rows="2" MaxLength="2000">Dr. Consultation</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td class="text-right" style="width: 133px"><label class="h4">SRS(50dB HL)</label></td>
                        <td colspan="3">
                        <table class="table table-bordered table-responsive">
                        <tr>
                            <td style="width: 2.0em;">
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test I</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test II</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test III</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test IV</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test V</label>
                            </td>                      
                        </tr>
                        <tr>                        
                            <td style="width: 2.0em; color:Red;"><label>R</label></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox11" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox12" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox13" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox14" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox15" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 2.0em; color:blue;"><label>L</label></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox16" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox17" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox18" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox19" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox20" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                        </tr>
                        </table>
                        </td> 
                        <%--<td class="text-right" style="width:50px"></td>--%>
                        </tr>
                         <tr>
                        <td class="text-right" style="width: 133px"><label class="h4">SIN(Speech in Noice Test)</label></td>
                        <td colspan="3">
                        <table class="table table-bordered table-responsive">
                        <tr>
                            <td style="width: 2.0em;">
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test I</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test II</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test III</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test IV</label>
                            </td>
                            <td style="width: 5.0em;">
                                <label>Test V</label>
                            </td>                      
                        </tr>
                        <tr>
                            <td style="width: 2.0em; color:Red;"><label>R</label></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox1" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox2" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox3" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox5" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox4" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 2.0em; color:blue;"><label>L</label></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox6" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox7" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox8" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox9" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                            <td style="width: 2.0em;"><asp:TextBox ID="TextBox10" runat="server" Style="width: 5.0em;" Text=""></asp:TextBox></td>
                        </tr>
                        </table>
                        </td>
                        <%--<td class="text-right" style="width:50px"></td>--%>
                        </tr>
                        <tr>
                            <td class="text-right" style="width:133px">
                                <label class="h4">Additional Test</label>
                            </td>
                            <td style="width: 436px">
                                <asp:DropDownList ID="ddl_Additional" runat="server" class="form-control" 
                                    onselectedindexchanged="ddl_Additional_SelectedIndexChanged" 
                                    AutoPostBack="true" Width="268px">
                                    <asp:ListItem Selected="True">Follow Up</asp:ListItem>
                                    <asp:ListItem>O.A.E Retesting after    Month</asp:ListItem>
                                    <asp:ListItem>Testing for Bera after     Month</asp:ListItem>
                                    <asp:ListItem>MRI / C.T Scan</asp:ListItem>
                                    <asp:ListItem>Free Field Audiometry</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtadd_test" runat="server" class="form-control" MaxLength="100">Follow Up</asp:TextBox>
                            </td>
                            <td class="text-right" style="width:50px">
                                <label class="h4">Next Appointment</label>
                            </td>
                            <td style="width:250px">
                                <asp:DropDownList ID="ddlnxtmeet" runat="server" class="form-control" OnSelectedIndexChanged="ddlnxtmeet_SelectedIndexChanged">
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
                        </tr>
                        <tr>
                            <td class="text-center" colspan="4">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" OnClientClick="checkPrintReq()"></asp:Button>
                                        <asp:Button ID="lblNxt_Apt" runat="server" Text="Next Appiontment" OnClick="lblNxt_Apt_Click" class="btn btn-primary"/>
                                        <asp:Button ID="btn_print" runat="server" Text="Print" class="btn btn-primary" 
                                            onclick="btn_print_Click"/>                                    
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
