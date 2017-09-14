<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="SelMach.aspx.cs" Inherits="Master_SelMach" Title="Hearing Aid Selection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="panel panel-default">  
    <div class="panel-heading">
        <h class="text-muted text-center">Hearing Aid Selection</h>
    </div>    
    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="Server">
        <ContentTemplate>
    <div class="panel-body">
    <div class="col-sm-push-0 col-md-5"> 
        <div class="form-group">
            <asp:Label ID="label1" runat="server" Text="Patient Name"></asp:Label>                    
                                <asp:TextBox ID="txtptntNm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                <div id="divwidth" style="display:list-item">
                                </div>
                                <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptntNm"
                                    FirstRowSelected="true" ServiceMethod="PatientSearch" ServicePath="WebService.asmx"
                                    MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="1000" CompletionListElementID="divwidth">
                 </AjaxToolkit:AutoCompleteExtender>                         
        </div>
        <div class="form-group">
                <asp:Label ID="label2" runat="server" Text="From Price Range"></asp:Label>
                    <asp:DropDownList ID="ddlFrom_Price" runat="server" onselectedindexchanged="ddlFrom_Price_SelectedIndexChanged" class="form-control">
                    </asp:DropDownList>
                   
        </div>
        <div class="form-group">
        <asp:Label ID="label6" runat="server" Text="To Price Range"></asp:Label>
         <asp:DropDownList ID="ddlTo_Price" runat="server" class="form-control">
         </asp:DropDownList>
        </div>
        <div class="form-group">
                <asp:Label ID="label3" runat="server" Text="Type"></asp:Label>
                    <asp:DropDownList ID="ddlType" runat="server" class="form-control">
                    </asp:DropDownList>                   
        </div>
        </div> 
        <div class="col-sm-push-0 col-md-5"> 
        <div class="form-group">
         <asp:RadioButtonList ID="rbtStock" runat="server" class="form-control" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Text="Available Stock"></asp:ListItem>
                        <asp:ListItem Text="NotAvailable Stock"></asp:ListItem>
                    </asp:RadioButtonList>
                    </div> 
        <div class="form-group">
            <asp:Label ID="label4" runat="server" Text="Technology"></asp:Label>
                    <asp:DropDownList ID="ddlTech" runat="server" class="form-control">
                        <asp:ListItem>Analog</asp:ListItem>
                        <asp:ListItem Selected="true">Trimer Digital</asp:ListItem>
                        <asp:ListItem>Programmable Digital</asp:ListItem>
                        <asp:ListItem>FM</asp:ListItem>
                    </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="label5" runat="server" Text="Machine Company"></asp:Label> 
        </div>
        <div class="form-group">
              <%--  <asp:Button ID="btnSelCom" runat="server" Text="Specific Company Search" class="btn btn-primary" onclick="btnSelCom_Click"/>--%>
            <asp:TextBox ID="txtComp" runat="server" class="form-control"></asp:TextBox>
            <div id="div1" style="display:list-item">
            </div>            
                 <AjaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtComp"
                                    FirstRowSelected="true" ServiceMethod="HearingCompNm" ServicePath="WebService.asmx"
                                    MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="1000" CompletionListElementID="div1">
                 </AjaxToolkit:AutoCompleteExtender> 
            </div>
        <div class="form-group">
                    <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Hearing Aid Search" OnClick="btnSearch_Click" />
        </div>
        </div>
        </div>
        <div class="panel-body" >
        <asp:Panel ID="panel" ScrollBars="Auto" runat="server">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CellPadding="3" class="table table-bordered table-striped">                   
                </asp:GridView>
                </asp:Panel>
        </div> 
    </ContentTemplate> 
    </asp:UpdatePanel> 
</div> 
</asp:Content>
