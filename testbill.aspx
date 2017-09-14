<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup="true" CodeFile="testbill.aspx.cs" Inherits="Bill_testbill" Title="Pitty Cash"  MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div align="right" style="text-align: left">
     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" PrintMode="Pdf" EnableViewState="true"/> 
  </div>
</asp:Content>

