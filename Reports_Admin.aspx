<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Reports_Admin.aspx.cs" Inherits="Admin_Reports" Title="Reports Main Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:updatepanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">Reports's</h>            
        </div>
        <div class="panel-body">
         <div class="form-group">
    <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="0" style="width:100%; height:50px;">  
    <table style="width:100%">
    <tr>   
     <td style="width:30%">
     <div>
            <asp:Label ID="lblFr_dt" runat="server" Text="From Date"></asp:Label>  
            <asp:TextBox ID="txtFr_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
            <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupButtonID="txtFr_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtFr_Dt"  CssClass="ajax__calendar">
            </AjaxToolkit:CalendarExtender>
     </div>
     <td style="width:2%">
     <div>
         <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
     </div>
     </td> 
    </td>  
    <td style="width:30%">  
    <div>
        <asp:Label ID="lblTo_Dt" runat="server" Text="To Date"></asp:Label>                           
        <asp:TextBox ID="txtTo_Dt" runat="server" class="form-control" AutoCompleteType="Disabled" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"></asp:TextBox>
        <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtTo_Dt_OnTextChanged" Format="dd/MM/yyyy" PopupPosition="BottomLeft" TargetControlID="txtTo_Dt"  CssClass="ajax__calendar">
        </AjaxToolkit:CalendarExtender>
    </div>
    </td>
    <td>
        <div style="width:2%">
            <asp:Image ID="Image1" ImageUrl="~/images/calendar.png" runat="server" />
        </div>     
    </td>   
    <td style="width:30%">
    <div>
        <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label> 
    </div> 
    <div>  
        <asp:TextBox ID="txtDesc" runat="server" class="form-control"></asp:TextBox>
    </div>
    </td>
   <%-- <td valign="bottom" > 
    <div></div>                         
       <div> <asp:Button ID="btnSerch" runat="server" Text="Search" 
               class="btn btn-primary" onclick="btnSerch_Click"/></div>
    </td> --%>
    </tr>
    </table>
    </asp:Panel>
    </div>
        </div>
        <div class="panel-body">
             <div class="col-sm-push-0 col-md-3">             
                    <div class="form-group">             
                    <asp:LinkButton ID="btnAcc" runat="server" Text="Accessories List / Stock" onclick="btnAcc_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>                      
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnAccSale" runat="server" Text="Accessories Sale" onclick="btnAccSale_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnAdvert" runat="server"  
                             Text="Advertising" onclick="btnAdvert_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">  
                        <asp:LinkButton ID="btnApp" runat="server" Text="Appointments" onclick="btnApp_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton> 
                    </div>                    
                     <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>                     
                     <div class="form-group">
                    <asp:LinkButton ID="btnCamp" runat="server" Text="Camp's" onclick="btnCamp_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>     
                     <div class="form-group">
                     <asp:LinkButton ID="btnCenter" runat="server" Text="Center List" onclick="btnCenter_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>          
                    </div>
                    <div class="form-group">
                     <asp:LinkButton ID="btnCompany" runat="server" Text="Company Master" onclick="btnCompany_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                     <div class="form-group">
                    <asp:LinkButton ID="btnCoch" runat="server" Text="Cochlear Implant" onclick="btnCoch_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                     <div class="form-group">
                     <asp:LinkButton ID="lbtnDoc" runat="server" Text="Doctor's List" onclick="lbtnDoc_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>                                          
                    </div>
                     <div class="form-group">
                    <asp:LinkButton ID="lblDueAmt" runat="server" Text="Due Amount" onclick="lblDueAmt_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                    </div>
                    <div class="col-sm-push-0 col-md-3">
                    <div class="form-group">
                    <asp:LinkButton ID="btnEnq" runat="server" Text="Enquiry" onclick="btnEnq_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                     <div class="form-group">
                    <asp:LinkButton ID="btnEarM" runat="server" Text="Earmould" onclick="btnEarM_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnMoldSt" runat="server" Text="Earmould Status" 
                            Font-Bold="True" Font-Size="Large" ForeColor="#666666" 
                            onclick="btnMoldSt_Click"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                     <div class="form-group">
                    <asp:LinkButton ID="btnFun" runat="server" Text="Function & Meeting" onclick="btnFun_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnFut" runat="server" Text="Future Appointment" 
                            Font-Bold="True" Font-Size="Large" ForeColor="#666666" onclick="btnFut_Click"></asp:LinkButton>
                    </div>
                     <div class="form-group">
                     <asp:LinkButton ID="btnHAid" runat="server" Text="Hearing Aid List / Stock" onclick="btnHAid_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>           
                    </div>
                    <div class="form-group">
                     <asp:LinkButton ID="btnProg" runat="server" Text="Hearing Aid Programming" onclick="btnProg_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666" ></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnHAid_Trial" runat="server" Text="Hearing Aid Trial Only" onclick="btnHAid_Trial_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnH_Hom_Trial" runat="server" Text="Hearing Aid Home Trial" onclick="btnH_Hom_Trial_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnHAid_Repair" runat="server" Text="Hearing Aid Repair" onclick="btnHAid_Repair_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnHAid_Sale" runat="server" Text="Hearing Aid Sale" onclick="btnHAid_Sale_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnHAid_Sale_Proc" runat="server" Text="Hearing Aid Sale In Process" onclick="btnHAid_Sale_Proc_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                   
                    </div>  
                    <div class="col-sm-push-0 col-md-3">
                      <div class="form-group">
                    <asp:LinkButton ID="btnQuat" runat="server" Text="Hearing Aid Quotation" onclick="btnQuat_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div> 
                     <div class="form-group">
                    <asp:LinkButton ID="btnHAss" runat="server" Text="Hearing Assesment" onclick="btnHAss_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                     <div class="form-group">
                    <asp:LinkButton ID="lblInwd" runat="server" Text="Inward" onclick="lblInwd_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                    <div class="form-group">
                    <asp:LinkButton ID="lblOutwd" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#666666" Text="Outward" onclick="lblOutwd_Click" ></asp:LinkButton>
                    </div>
                     <div class="form-group">
                    <asp:LinkButton ID="btnOrderForm" runat="server" Font-Bold="True" Font-Size="Large" 
                             ForeColor="#666666" Text="Order By Mail" onclick="btnOrderForm_Click"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                     <div class="form-group">  
                        <asp:LinkButton ID="lbtnptntList" runat="server" onclick="lbtnptntList_Click" Text="Patient Register" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton> 
                    </div>  
                    <div class="form-group" visible="false">
                    <%--<asp:LinkButton ID="btnPitty" runat="server" Text="Petty Cash" onclick="btnPitty_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>--%>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="lblPtnt_CompModel" runat="server" Text="Patient,Hearing,Company Search" onclick="lblPtnt_CompModel_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="lblPtntAll" runat="server" Text="Patient Data All" onclick="lblPtntAll_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnPCRpt" runat="server" Text="Petty Cash Report" Font-Bold="True" Font-Size="Large" ForeColor="#666666" onclick="btnPCRpt_Click"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                    <asp:LinkButton ID="btnPurHAList" runat="server" Text="Purchase List Of Hearing Aid" 
                            Font-Bold="True" Font-Size="Large" ForeColor="#666666" 
                            onclick="btnPurHAList_Click"></asp:LinkButton>
                    </div> 
                     <div class="form-group">
                    <asp:LinkButton ID="btnPurAccList" runat="server" Text="Purchase List Of Accessories" 
                            Font-Bold="True" Font-Size="Large" ForeColor="#666666" 
                             onclick="btnPurAccList_Click"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>                    
                    </div> 
                    <div class="col-sm-push-0 col-md-3">
                    <div class="form-group">
                    <asp:LinkButton ID="btnQuot" runat="server" Text="Quotation" onclick="btnQuot_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666" Visible="false"></asp:LinkButton>
                    </div>
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnRptPend" runat="server" Text="Report Pending" onclick="btnRptPend_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>
                    <div class="form-group">
                    <asp:LinkButton ID="btnSAss" runat="server" Text="Speech Assesment" onclick="btnSAss_Click" Font-Bold="True" Font-Size="Large" ForeColor="#666666"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                    <asp:LinkButton ID="btnWarr" runat="server" Text="Warranty Card Data"  
                            Font-Bold="True" Font-Size="Large" ForeColor="#666666" onclick="btnWarr_Click"></asp:LinkButton>
                    </div> 
                    <div class="form-group">
                     <label>--------------------------------------</label>
                     </div>             
                    </div>     
                     <div class="form-group">                    
                    </div>
                  
                    </div>
    </div>    
    </ContentTemplate> 
</asp:updatepanel>      
</asp:Content>
