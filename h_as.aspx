<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="h_as.aspx.cs" Inherits="Clinical_Forms_h_as" Title="Heasring Assessment Report" MaintainScrollPositionOnPostback="true"   %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script language="javascript" type="text/javascript" >
       function myFunction() {
           window.print();
       }
</script>    
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"  EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" PrintMode="Pdf" EnableViewState="true"   />      
</asp:Content>
