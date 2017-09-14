<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup="true" CodeFile="acc_bill.aspx.cs"  Inherits="Transaction_acc_bill" Title="Accessories Bill" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReuseParameterValuesOnRefresh="true" ShowAllPageIds="true" EnableParameterPrompt="False" PrintMode="Pdf" EnableViewState="true"/>   
</asp:Content>
