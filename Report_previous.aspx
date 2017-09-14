<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Report_previous.aspx.cs" Inherits="Clinical_Forms_Report_previous"
    Title="Previous Hearing Assesment Report" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%--
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:updatepanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="panel-heading">
        <h class="text-muted text-center">Previous Hearing Assesment Report</h>
    </div>
    <div class="panel-body">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="Server">
                <ContentTemplate>
                    <div class="form-group">
                        <label>
                            Patient Name</label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtptntNm" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                <div id="divwidth" style="display: none">
                                </div>
                                <AjaxToolkit:AutoCompleteExtender ID="PtntNm" runat="server" TargetControlID="txtptntNm"
                                    FirstRowSelected="true" ServiceMethod="GetEmpCode" ServicePath="WebService1.asmx"
                                    MinimumPrefixLength="3" EnableCaching="true" CompletionInterval="10" CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="divwidth">
                                </AjaxToolkit:AutoCompleteExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:GridView ID="GridView1" runat="server" class="table table-bordered " AutoGenerateColumns="False"
                            CellPadding="4">
                            <%--OnSelectedIndexChanged="GridView1_SelectedIndexChanged">--%>
                            <Columns>
                                <asp:BoundField DataField="h_as_dt" HeaderText="Assesment Date" SortExpression="h_as_dt" />
                                <asp:BoundField DataField="h_as_id" HeaderText="Assesment Id" InsertVisible="False"
                                    ReadOnly="True" SortExpression="h_as_id" />
                                <asp:BoundField DataField="ptnt_id" HeaderText="Patient Id" SortExpression="ptnt_id" />
                                <asp:BoundField DataField="h_comp" HeaderText="Hearing Complaints" SortExpression="h_comp" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </ContentTemplate> 
</asp:updatepanel> 
</asp:Content>
