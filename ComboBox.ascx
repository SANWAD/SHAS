<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComboBox.ascx.cs" Inherits="ComboBox" %>

<script language="javascript" src="../AjaxCallBack.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    function getValue(txtSearch) {
        var ddl = document.getElementById("<%=lstComboBox.ClientID%>");

        FillCombo(ddl, txtSearch);
    }

</script>

<div >
    <asp:TextBox ID="txtComboBox" onkeyup="getValue(this.value)" runat="server" class="form-control"></asp:TextBox>
    <asp:ListBox ID="lstComboBox" Style="display: none"  runat="server">
    </asp:ListBox>
</div>
