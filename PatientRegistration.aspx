<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="PatientRegistration.aspx.cs" Inherits="PatientRegistratioon" Title="Patient Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" language="javascript">
    function BirthDay() {
        var dt = new Date();      
        var date = dt.getDate();
        var month = dt.getMonth() + 1;
        var Year = dt.getFullYear();        
        var Birth_Date = new Date((document.getElementById('<%=txtdate.ClientID %>').value));
        
        var BYear;
        if (Birth_Date.getFullYear() < Year) 
        {
            BYear = (Year - Birth_Date.getFullYear());
        }
        else 
        {
            BYear = 0
        }
        var BMonth;
        if (Birth_Date.getMonth() < month) {
            if (Birth_Date.getDate() > date)
         {
         BMonth = (month - (Birth_Date.getMonth()+2));
         }
         else{
                BMonth = (month - (Birth_Date.getMonth()+1));  
                }         
         }
        else if(Birth_Date.getMonth() > month) {
        if (month==1)
        {
        BMonth = (((month)+1) - (Birth_Date.getMonth()));
    }
    if (month == 2) {
        BMonth = (((month) + 2) - (Birth_Date.getMonth()));
    }
    if (month == 3) {
        BMonth = (((month) + 3) - (Birth_Date.getMonth()));
    }
    if (month == 4) {
        BMonth = (((month) + 4) - (Birth_Date.getMonth()));
    }
    if (month == 5) {
        BMonth = (((month) + 5) - (Birth_Date.getMonth()));
    }
    if (month == 6) {
        BMonth = (((month) + 6) - (Birth_Date.getMonth()));
    }
    if (month == 8) {
        BMonth = (((month) + 8) - (Birth_Date.getMonth()));
    }
    if (month == 9) {
        BMonth = (((month) + 9) - (Birth_Date.getMonth()));
    }
    if (month == 10) {
        BMonth = (((month) + 10) - (Birth_Date.getMonth()));
    }
    if (month == 11) {
        BMonth = (((month) + 11) - (Birth_Date.getMonth()));
    }
    if (month == 12) {
        BMonth = (((month) + 12) - (Birth_Date.getMonth()));
    }
        }
        else
        {
            BMonth = 0;
        }
        var BDate;
        if(Birth_Date.getDate() < date)
        {
            BDate = (date - (Birth_Date.getDate()));
        }
        else if(Birth_Date.getDate() > date)
        {
            if(month==1)
            {
            BDate = ((date+31) - (Birth_Date.getDate()));
            }
            else if(month==2)
            {
                BDate = ((date+28) - (Birth_Date.getDate()));
            }
            else if(month==3)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
             else if(month==4)
            {
                BDate = ((date+30) - (Birth_Date.getDate()));
            }
             else if(month==5)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
             else if(month==6)
            {
                BDate = ((date+30) - (Birth_Date.getDate()));
            }
             else if(month==7)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
             else if(month==8)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
             else if(month==9)
            {
                BDate = ((date+30) - (Birth_Date.getDate()));
            }
             else if(month==10)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
             else if(month==11)
            {
                BDate = ((date+30) - (Birth_Date.getDate()));
            }
             else if(month==12)
            {
                BDate = ((date+31) - (Birth_Date.getDate()));
            }
        }
        else
        {
        BDate=0;
        }
         
//        //var BYear = BYear = (Year - Birth_Date.getFullYear());
//        //var BDate = (date - (Birth_Date.getDate()));
//        //var BMonth = (month - (Birth_Date.getMonth() + 1));
//        if (BDate<0) {
//            //BMonth = BMonth - 1;
//            
//            BDate = (30 + date) - (BDate+1);
//        }
//        else
//        {
//            BDate = BDate
//        }
//        if (BMonth < 0) {
//            // BYear = BYear - 1;           
//            BMonth = (12 + month)- (BMonth+2);
//        }
//        if (BMonth == 0) {
//            BMonth = BMonth;
//        }
////        else {
////            BMonth = BMonth;
////        }
//        if (BYear == 0) {
//            BYear = BYear;
//        }
        var Result = (BDate + "Days" + BMonth + "Months" + BYear + "Years");
        document.getElementById('<%=lbl_age.ClientID %>').innerHTML = Result;
        document.getElementById('<%=txt_age.ClientID %>').value = Result;
             
    }
</script>
<asp:UpdatePanel runat="server" >
<ContentTemplate>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h class="text-muted text-center">New Patient Registration</h>
        </div>
        <div class="panel-body">
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                    <asp:HiddenField ID="lblptnt_id" runat="server" />
                </div>
                 <div class="form-group">
                <table style="width:100%">
                    <tr>
                    <td style="width:99%">                  
                        <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:Label ID="Label3" runat="server" text="Patient Name"></asp:Label> 
                    <asp:TextBox ID="txtptnt_nm" runat="server" class="form-control" ontextchanged="txtptnt_nm_TextChanged" AutoPostBack="true" ></asp:TextBox>
                   <%-- <div id="divwidth" style="display: none">
                     </div>
                     <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptnt_nm" FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="~/WebService.asmx" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" CompletionListElementID="divwidth">
                     </AjaxToolkit:AutoCompleteExtender>--%>
                    </td>
                    <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqPtNm" controltovalidate="txtptnt_nm" ErrorMessage="Required Patient Name" Text="*"  SetFocusOnError="true"/>
                    </tr> 
                    </table> 
                </div>
                <div>
                    <asp:Label ID="lblMsg" runat="server" Text="Patient Already Exists" 
                        ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <div class="form-group">                   
                        <asp:Label ID="Label2" runat="server" text="Patient Type"></asp:Label> 
                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <asp:DropDownList ID="ddlptnt_Type" runat="server" class="form-control">
                                </asp:DropDownList>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
               
                <div class="form-group">
                    <table style="width: 100%;">
                            <tr>
                                <td style="width: 40%;">
                                   <asp:Label ID="Label4" runat="server" text="Date Of Birth "></asp:Label><asp:Label ID="labelfor"  runat="server" text="Format(MM/dd/yyyy)" ForeColor="Red"></asp:Label>
                                    <asp:TextBox ID="txtdate" runat="server" class="form-control" 
                                        AutoCompleteType="Disabled"  onchange="BirthDay();"    
                                        onkeyup="FormatIt(this);" ontextchanged="txtdate_TextChanged1"></asp:TextBox>
                                       <%--  onchange="BirthDay()" ontextchanged="txtdate_TextChanged" onchange="dateValidate(this.id);" onchange="BirthDay()" AutoPostBack="true" ontextchanged="txtdate_TextChanged" onchange="dateValidate(this.id);" onkeyup="FormatIt(this);"--%>
                                    <AjaxToolkit:CalendarExtender ID="calExtender4" runat="server" PopupPosition="BottomLeft" TargetControlID="txtdate" Format="MM/dd/yyyy"  OnClientDateSelectionChanged="checkDate" CssClass="ajax__calendar" TodaysDateFormat="MM/dd/yyyy">
                                    </AjaxToolkit:CalendarExtender>
                                </td>
                                <td style="width: 2%;">
                                    <div>
                                        <asp:Image ID="calImage" ImageUrl="~/images/calendar.png" runat="server" /></div>
                                </td>
                                <td style="width: 30%;">
                                <div>
                                    <asp:Label ID="Label5" runat="server" text="Age" Visible="false"></asp:Label> 
                                    </div>
                                    <div>
                                    <asp:Label ID="lbl_age" runat="Server" Text="" ></asp:Label>
                                        <asp:TextBox ID="txt_age" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                    </table>
                </div>
                <div class="form-group">
                   
                    <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td> 
                    <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label6" runat="server" text="Gender"></asp:Label> 
                        <asp:RadioButtonList ID="rdbtngender" runat="server" RepeatDirection="Horizontal" style="width:100%">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqGen" controltovalidate="rdbtngender" ErrorMessage="Required To Select Gender" Text="*"  SetFocusOnError="true"/>
                    </td> 
                    </tr> 
                    </table> 
                    </div>
                    
                </div>
                <div class="form-group">                    
                    <asp:Label ID="Label7" runat="server" text="Profession"></asp:Label> 
                    <asp:TextBox ID="txtprof" runat="server" class="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label8" runat="server" text="Address"></asp:Label>
                    <asp:TextBox ID="txtptntadd" runat="server" class="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                </div>
                
            </div>
            <div class="col-sm-push-0 col-md-5">
                <div class="form-group">
                </div>             
                <div class="form-group">                    
                        <asp:Label ID="Label9" runat="server" text="Phone No"></asp:Label> 
                    <asp:TextBox ID="txtphno" runat="server" class="form-control" onkeydown="return isNumeric(event.keyCode);"></asp:TextBox>
                </div>
                <div class="form-group">                    
                 <asp:Label ID="lblVIP" runat="server" text="Patient Status" ></asp:Label> 
                 <asp:RadioButtonList ID="rbtVIP" runat="server" RepeatDirection="Horizontal" style="width:100%">
                    <asp:ListItem Selected="True" Text="Regular" ></asp:ListItem>
                    <asp:ListItem Text="VIP"></asp:ListItem>
                    <asp:ListItem Text="V VIP"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group">
                    <table style="width:100%">
                    <tr>
                    <td style="width:99%">
                        <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
                    <asp:Label ID="Label10" runat="server" text="Mobile No"></asp:Label> 
                    <asp:TextBox ID="txtmobno" runat="server" class="form-control" 
                            onkeydown="return isNumeric(event.keyCode);" MaxLength="12"></asp:TextBox>
                     </td>
                    <td style="width:1%">
                    <asp:RequiredFieldValidator runat="server" id="reqMob" controltovalidate="txtmobno" ErrorMessage="Required Mobile No" Text="*"  SetFocusOnError="true"/>
                    </td> 
                    </tr> 
                    </table> 
                </div>
                <div class="form-group">
                        <asp:Label ID="Label11" runat="server" text="Refered By"></asp:Label> 
                  <%--  <asp:TextBox ID="ddl_ref_by" runat="server" class="form-control"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddl_ref_by" runat="server"  class="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                        <asp:Label ID="Label12" runat="server" text="Brif History"></asp:Label> 
                    <asp:TextBox ID="txtBrief" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
               <%-- <div class="form-group">
                    <table style="width: 100%" border="0">
                        <tr>
                            <th style="width: 20%">
                                    <asp:Label ID="Label13" runat="server" text="Enquiry"></asp:Label> 
                            </th>
                            <th style="width: 80%">
                            <div class="checkbox">
                                <asp:CheckBox ID="chkenq" runat="server" />
                                </div>
                            </th>
                        </tr>
                    </table>
                </div>--%>
                <div class="form-group">
                <table style="width:100%">
                <tr>
                <td style="width:50%">
                 <asp:Label ID="Label18" runat="server"  Text="Patient Photo"></asp:Label>
                  <asp:FileUpload ID="uploadphoto" runat="server" class="form-control" 
                        style="width:100%" BorderStyle="Solid" BorderWidth="1px"/>                  
                  <asp:Image ID="Image1" runat="server" Height="88px" Width="86px"/>
                </td>
                <td style="width:50%">
                <asp:Label ID="lblBackHist" runat="server"  
                        Text="Scan Patient Document"></asp:Label>
                  <asp:FileUpload ID="uploadBackHist" runat="server" class="form-control" style="width:100%" BorderStyle="Solid" BorderWidth="1px"/>                  
                  <asp:Image ID="Image2" runat="server" Height="88px" Width="86px"/>
                  <asp:HyperLink ID="HyperLink3" runat="server" Font-Underline="True" ForeColor="#0000CC" Target="_blank">Show Document</asp:HyperLink>
                </td>
                </tr>
                </table>                
                </div> 
                 <div class="form-group">
                </div> 
                <div class="btn-toolbar list-toolbar"> 
                <%--<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                  <ContentTemplate> --%>                 
                    <asp:Button ID="btnsave" runat="server" Text="Save"  OnClick="btnsave_Click" class="btn btn-primary"></asp:Button>
                    <asp:Button ID="btnCan" runat="server" Text="Cancel" class="btn btn-primary" onclick="btnCan_Click" CausesValidation="false" ></asp:Button>                                       
                    <asp:Button ID="btnApt" runat="server" Text="Get Appointment" 
                        class="btn btn-primary" onclick="btnApt_Click"></asp:Button>
                 <%-- </ContentTemplate> 
               </asp:UpdatePanel> --%>
                </div>
                <div class="form-group">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"/>
                </div> 
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
