<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup="true" CodeFile="Noof_Ptnt_RefBy_Doc.aspx.cs"  Inherits="Noof_Ptnt_RefBy_Doc" Title="Refered Patient By Doctor" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReuseParameterValuesOnRefresh="true" ShowAllPageIds="true" EnableParameterPrompt="False" PrintMode="Pdf" EnableViewState="true"/>   
</asp:Content>
