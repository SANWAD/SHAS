<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default1.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Untitled Page</title>
<script type="text/javascript">
    function ShowProcessImage() {
        var autocomplete = document.getElementById('txtCountry');
        autocomplete.style.backgroundImage = 'url(loading1.gif)';
        autocomplete.style.backgroundRepeat = 'no-repeat';
        autocomplete.style.backgroundPosition = 'right';
    }
    function HideProcessImage() {
     var autocomplete = document.getElementById('txtCountry');
     autocomplete.style.backgroundImage  ='none';
     }
</script>
<script language="javascript" type="text/javascript" >
    var month = ("January");
    var month1=("Februvary");
    var month2 = month.concat(month1);
    document.write(month2.toString());    
</script>
<script language="javascript" type="text/javascript" >
    function sum() 
{
    var a = 5, b = 5, n3;
    n3 = a + b;
    document.write("Result=" + n3);
}
sum();
</script>
<script language="javascript" type="text/javascript" >
    function Max(n1, n2) {
        if (n1 > n2)
            return n1;
        else
            return n2;
    }
    //Max(10, 9)
    document.write("Max=" + Max(9, 9));
</script>
<script language="javascript" type="text/javascript" >
    var result = 100 / "10";
    if (result = NaN) {
        document.write("Result=NaN");
    }
    else
    {
    document.write("Result=" + result);
    }
</script>
<script type="text/javascript" language="javascript" >
    function loadDoc() 
    {
        var obj;
            if (window.XMLHttpRequest)
            {
                obj = new XMLHttpRequest();
            }
            else 
            {
                obj = new ActiveXObject("Microsoft.XMLHTTP");
            }
            obj.onreadystatechange = function() 
            {
                if (obj.readyState == 4 && obj.status == 200)
                 {
                    document.getElementById("MyDiv").innerHTML = obj.responseText;
                 }
             }
             obj.open("GET", "text.txt", true);
             obj.send();
     }
 </script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div>
<asp:TextBox ID="txtCountry" runat="server" onchange="ShowProcessImage"></asp:TextBox>
<ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCountry" ServicePath="WebService.asmx" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" ServiceMethod="PatientSearch" OnClientPopulating="ShowProcessImage" OnClientPopulated="HideProcessImage" >
</ajax:AutoCompleteExtender> 
</div>
<div id="MyDiv">
Let AJAX Change this text
</div>
<button type="button" onclick="loadDoc()">Change Content</button>
</form>
</body>
</html>
