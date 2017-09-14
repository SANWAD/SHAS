<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master"  AutoEventWireup="true" CodeFile="quat.aspx.cs" Inherits="Transaction_quat" Title="Hearing Aid Quatation"  MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="true" ReuseParameterValuesOnRefresh="True" ShowAllPageIds="true" 
    PrintMode="Pdf" EnableViewState="true" EnableParameterPrompt="False"  />     
</asp:Content>
