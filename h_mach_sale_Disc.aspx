<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_mach_sale_Disc.aspx.cs" Inherits="h_mach_sale_Disc" Title="Hearing Aid Sale Invoice" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Src="~/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function GetSelectedItem() {
        var RB1 = document.getElementById("<%=rbtDisc.ClientID%>");
        var radio = RB1.getElementsByTagName("input");
        var label = RB1.getElementsByTagName("label");
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {
                if (radio[i].value == 0) {
                    document.getElementById("<%=txtVat.ClientID %>").disabled = false;
                    document.getElementById("<%=lblVat.ClientID %>").disabled = false;
                    document.getElementById("<%=lblDisc.ClientID %>").disabled = true;
                    document.getElementById("<%=txtDisc.ClientID %>").disabled = true;
//                    function DueAmt() {
//                        HAPrice = document.getElementById('<%=txtDV.ClientID %>').value;
//                        var AmtRec = document.getElementById('<%=txtrecamt.ClientID %>').value;
//                        var Result = parseInt(HAPrice) - parseInt(AmtRec);
//                        if (!isNaN(Result)) {
//                            document.getElementById('<%=txtdueamt.ClientID %>').value = Result;
//                        }
                    //                    }
                       
                }
                else {
                    document.getElementById("<%=txtVat.ClientID %>").disabled = true;
                    document.getElementById("<%=lblVat.ClientID %>").disabled = true;
                    document.getElementById("<%=lblDisc.ClientID %>").disabled = false;
                    document.getElementById("<%=txtDisc.ClientID %>").disabled = false;
                }
            }
        }
        return false;
    }
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
    function DisVat() {
        var Disc = document.getElementById('<%=txtDisc.ClientID %>').value;
         var Vat = document.getElementById('<%=txtVat.ClientID %>').value;
         var Price = document.getElementById('<%=txtmachprice.ClientID %>').value;
        var Vat_Amt = ((Price / 100) * Vat);
        document.getElementById('<%=txtDV.ClientID %>').value =  (Price + Vat_Amt);
    }
    function DiscVat() {
        var Disc = document.getElementById('<%=txtDisc.ClientID %>').value;
        var Vat = document.getElementById('<%=txtVat.ClientID %>').value;
        var Price = document.getElementById('<%=txtmachprice.ClientID %>').value;
       var Disc_Amt = ((Price / 100) * Disc);
            var  Price1 = ((Price - Disc_Amt));
            var  Vat_Amt = ((Price1 / 100) * Vat);
        document.getElementById('<%=txtDV.ClientID %>').value = (Price1 + Vat_Amt);
    }
    function DueAmt() {
        HAPrice = document.getElementById('<%=txtDV.ClientID %>').value; 
        var AmtRec = document.getElementById('<%=txtrecamt.ClientID %>').value;
        var Result = parseInt(HAPrice) - parseInt(AmtRec);
        if (!isNaN(Result)) {
            document.getElementById('<%=txtdueamt.ClientID %>').value = Result;
        }
    }

    function DocComm() {
        SalePrice = document.getElementById('<%=txtDV.ClientID %>').value;
        var Commi = document.getElementById('<%=txtDocComm.ClientID %>').value;
        var Result = (parseInt(SalePrice) * parseInt(Commi))/100;
        if (!isNaN(Result)) {
            document.getElementById('<%=txtDocRup.ClientID %>').value = Result;
        }
    }

    function DocCommRup() {
        SalePrice = document.getElementById('<%=txtDV.ClientID %>').value;
        var Commi = document.getElementById('<%=txtDocRup.ClientID %>').value;
        var Result = (parseInt(Commi) * 100) / SalePrice;
        if (!isNaN(Result)) {
            document.getElementById('<%=txtDocComm.ClientID %>').value = Result;
        }
    }
    function ABC() {
        var Disc_Amt = document.getElementById('<%=txtDV.ClientID %>').value; 
        var Sale_Price = document.getElementById('<%=txtmachprice.ClientID %>').value;
        var per = ((parseInt(Sale_Price) - parseInt(Disc_Amt)) / parseInt(Sale_Price))*100;
        if (!isNaN(per)) {
            document.getElementById('<%=txtDisc.ClientID %>').value = per;
        } 
    }
        
</script>        
        <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center"><asp:Label runat="server" ID ="lblHeading"></asp:Label></h>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="Server">
         <ContentTemplate>
        <div class="panel-body">
        <div class="col-sm-push-0 col-md-5">           
           <div class="form-group">
               <asp:HiddenField ID="lblsale_id" runat="server" />
           </div>
           <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:98%">
                    <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*"></asp:Label>                    
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                      <asp:TextBox ID="Ptnt_Nm" runat="server" class="form-control"></asp:TextBox>
                        <div id="divwidth" style="display: none">
                        </div>
                        <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="Ptnt_Nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth" UseContextKey="true">
                        </AjaxToolkit:AutoCompleteExtender>
                     </td>
                    <td style="width:2%">                    
                        <asp:HiddenField ID="lblptnt_id" runat="server" />
                        <asp:RequiredFieldValidator runat="server" id="reqPtntNm" controltovalidate="Ptnt_Nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
                    </td>
                    </tr>                    
                    </table>
                    </div>  
                    
                     <div class="form-group">    
          <table style="width: 100%;">
          <tr>
            <td style="width: 30%;">      
              <asp:Label ID="lblDoc_Date" runat="server"></asp:Label>
              <asp:TextBox ID="txtDoc_Date" runat="server" class="form-control"></asp:TextBox> 
               <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomLeft"  OnClientDateSelectionChanged="checkDate" TargetControlID="txtDoc_Date" Format="dd/MM/yyyy" CssClass="ajax__calendar">
               </AjaxToolkit:CalendarExtender>
               <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDoc_Date" ErrorMessage="Can't Select Date which is greater than Todays Date"></asp:RangeValidator> --%>
            </td>
            <td style="width: 2%;">
                <div>
                    <asp:Image ID="calImage" ImageUrl="~/images/calendar.png" runat="server" /></div>
            </td>         
          </div>                   
           <div class="form-group">
           <table style="width: 100%;">
                    <tr>
                    <td style="width: 99%;">
                    <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="*"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Ear Site"></asp:Label>        
         <asp:RadioButtonList ID="rbte_site" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbte_site_SelectedIndexChanged" AutoPostBack="true" style="width:100%">
            <asp:ListItem>Right</asp:ListItem>
            <asp:ListItem>Left</asp:ListItem>
            <asp:ListItem>Both</asp:ListItem>
            <%--<asp:ListItem>Bianaural Fitting</asp:ListItem>--%>
         </asp:RadioButtonList> 
           </td>
           <td style="width: 1%;">
           <asp:RequiredFieldValidator runat="server" id="reqSite" controltovalidate="rbte_site" ErrorMessage="Select Ear Site" Text="*"  SetFocusOnError="true"/>
           </td> 
           </tr> 
          </table>          
        </div>   
           <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Audio Ratio" Visible="false"></asp:Label>
        <asp:TextBox ID="txtaudrat" runat="server" class="form-control" Visible="false" Text="0"></asp:TextBox>
        </div> 
        <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="Ear Mould"></asp:Label>
           <asp:RadioButtonList ID="rbtem" runat="server" RepeatDirection="Horizontal" style="width:100%">
                 <asp:ListItem>In House</asp:ListItem>
                <asp:ListItem>To Company</asp:ListItem>
                 <asp:ListItem>No Mould</asp:ListItem>
           </asp:RadioButtonList>        
        </div> 
        <div class="form-group" >
        <asp:Label ID="Label18" runat="server" Text="Hearing Aid For Right Ear"></asp:Label> 
        <asp:DropDownList ID="ddl_comp" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_model" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_model_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddl_mach_type" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_mach_type_SelectedIndexChanged"></asp:DropDownList>
        <asp:TextBox ID="txt_mach" runat="server" class="form-control"></asp:TextBox>
        <asp:HiddenField ID="lbl_mach_id_rt" runat="server" />
        <asp:Label ID="lblQty" runat="server" Text="Label" class="form-control"></asp:Label>
        <%--<asp:Label ID="lblSale_price" runat="server" Text="0" class="form-control"></asp:Label>--%>
        <asp:HiddenField ID="lblSale_price" runat="server" />       
        </div>        
           <div class="form-group">
        <asp:Label ID="Label8" runat="server" Text="Searial No for Right Ear"></asp:Label>
         <asp:TextBox ID="txtmach_serno_rt" runat="server" class="form-control"></asp:TextBox>
        </div>         
         <div class="form-group" >
            <asp:Label ID="Label17" runat="server" Text="Hearing Aid For Left Ear"></asp:Label>
            <asp:DropDownList ID="ddl_comp1" runat="server" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_comp1_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddl_model1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_model1_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="ddl_type1" runat="server" AppendDataBoundItems="true" AutoPostBack="True" class="form-control" onselectedindexchanged="ddl_type1_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txt_mach1" runat="server" class="form-control"></asp:TextBox>           
            <asp:HiddenField ID="lbl_mach_id_lt" runat="server" />
            <asp:Label ID="lblQty1" runat="server" Text="Label" class="form-control"></asp:Label>
            <asp:HiddenField ID="lblSale_price1" runat="server" />
            </div>       
             <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Searial No for Left Ear"></asp:Label>
            <asp:TextBox ID="txt_srno_lt" runat="server" class="form-control"></asp:TextBox>                    
            </div>
           
        </div>             
        <div class="col-sm-push-0 col-md-5">            
            <div class="form-group">  
                    <asp:Label ID="Label9" runat="server" Text="Discount" ></asp:Label>          
                    <asp:RadioButtonList ID="rbtDisc" runat="server" RepeatDirection="Horizontal" class="form-control"  AutoPostBack="True" onselectedindexchanged="rbtDisc_SelectedIndexChanged"  style="width:100%;" onkeyup="DiscVat()">
                    <asp:ListItem Selected="True" Value="0" >NoDisc</asp:ListItem>
                    <asp:ListItem Value="1">With Disc</asp:ListItem>
                    </asp:RadioButtonList>   
                   <%-- AutoPostBack="True" onselectedindexchanged="rbtDisc_SelectedIndexChanged" onchange="GetSelectedItem()" --%>        
                    <asp:Label ID="lblDisc" runat="server" Text="Discount In %"></asp:Label>
                    <asp:TextBox ID="txtDisc" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" ontextchanged="txtDisc_TextChanged" AutoPostBack="true" >0</asp:TextBox>&nbsp;
                    <asp:Label ID="lblVat" runat="server" Text="GST / Vat In %"></asp:Label>
                    <asp:TextBox ID="txtVat" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" ontextchanged="txtVat_TextChanged" AutoPostBack="true">0</asp:TextBox>                      
            </div>
            <div class="form-group">
             <table style="width:100%">
                        <tr>
                            <td style="width: 50%; margin-left: 40px;">
                              <asp:Label ID="Label11" runat="server" Text="Hearing Aid Price"></asp:Label>
                            <asp:TextBox ID="txtmachprice" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="addPB()"></asp:TextBox>
                            </td>                                    
                            <td style="width: 50%;">
                               <asp:Label ID="Label12" runat="server" Text="Disc &amp; GST / Vat"></asp:Label>
                            <asp:TextBox ID="txtDV" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="ABC()" ></asp:TextBox>
                            </td>
                        </tr>                            
                </table>
            </div>            
            <div class="form-group">
            <table width="100%">
            <tr>
            <td>
            <asp:Label ID="Label13" runat="server" Text="Received Amount"></asp:Label>
            <asp:TextBox ID="txtrecamt" runat="server"  Text="" class="form-control" onkeydown="return isNumeric(event.keyCode);"  onkeyup="DueAmt()"></asp:TextBox>
                <%--ontextchanged="txtrecamt_TextChanged"  AutoPostBack="True"--%>
            </td>
            <td>
            <asp:Label ID="Label1" runat="server" Text="No of H.Aid Quantity"></asp:Label>
            <asp:TextBox ID="txtPurQty" runat="server"  Text="" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
            </td>            
            </tr>
            <tr>
            <td>
            <asp:Label ID="lblDocCom" runat="server" Text="Referral Commission in Percentage"></asp:Label>
            <asp:TextBox ID="txtDocComm" runat="server"  Text="" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="DocComm()"></asp:TextBox>
            </td>
            <td>
            <asp:Label ID="lblDocRup" runat="server" Text="Referral Commission in Rupees"></asp:Label>
            <asp:TextBox ID="txtDocRup" runat="server"  Text="" class="form-control" onkeydown="return isNumeric(event.keyCode);" onkeyup="DocCommRup()"></asp:TextBox>
            </td>
            </tr>
            </table>
            </div>             
            <div class="form-group">
            <asp:Label ID="Label14" runat="server" Text="Due Amount"></asp:Label>
            <asp:TextBox ID="txtdueamt" runat="server" Text="" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>                   
            </div>
            
            <div class="form-group">
                <asp:Label ID="Label15" runat="server" Text="Comment"></asp:Label>
                <asp:TextBox ID="txtcomment" runat="server" Text="" class="form-control" TextMode="MultiLine" ></asp:TextBox>                   
            </div>
            <div class="form-group">
            <table style="width:100%">
            <tr>
            <td style="width:98%">
             <asp:Label ID="Label16" runat="server" Text="Date Of Warranty"></asp:Label>
                    <asp:TextBox ID="txtdate" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" TargetControlID="txtdate"  Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy" CssClass="ajax__calendar">
                    </AjaxToolkit:CalendarExtender>
                    </td>
                    <td style="width:2%">
                    <asp:Image ID="Image" ImageUrl="~/images/calendar.png" runat="server" />
                    </td></tr></table>
                    </div>
            <div class="btn-toolbar list-toolbar"> 
                         <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                         <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false"></asp:Button>       
                         <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" onclick="btnPrint_Click"></asp:Button>                                                                                         
                    </div>
                    <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                    </div> 
                    </div>
        <div class="col-sm-push-0 col-md-5">
        <div class="form-group">
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="hm_sale_id" ForeColor="#333333" GridLines="None" style="width:100%">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="hm_sale_dt" HeaderText="Sale Date" SortExpression="hm_sale_dt" />
                <asp:BoundField DataField="hm_sale_id" HeaderText="Sale Id" InsertVisible="False" ReadOnly="True" SortExpression="hm_sale_id" />
                <asp:BoundField DataField="hm_nm_rt" HeaderText="Machine" SortExpression="hm_nm_rt" />
                <asp:BoundField DataField="hm_nm_lt" HeaderText="Machine" SortExpression="hm_nm_lt" />
                <asp:BoundField DataField="hm_sale_mach_price_rt" HeaderText="Price" SortExpression="hm_sale_mach_price_rt" />
                <asp:BoundField DataField="hm_sale_ear_site" HeaderText="Ear Site" SortExpression="hm_sale_ear_site" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>            
        </asp:GridView>
        </div> 
         </div>
       </div>
       </ContentTemplate>
       </asp:UpdatePanel> 
       </div> 
</asp:Content>

