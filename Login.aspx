<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css" />
    <link rel="shortcut icon" href="../assets/ico/favicon.ico"/>
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="../assets/ico/apple-touch-icon-57-precomposed.png"/>
    <script src="lib/jquery-1.11.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css" />
    <link rel="stylesheet" type="text/css" href="stylesheets/premium.css"/>
</head>
<body class=" theme-blue">
  <form id="registerationform" runat="server">
    <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </AjaxToolkit:ToolkitScriptManager>                 
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
   <%-- <style type="text/css">
            #line-chart
            {
                height: 300px;
                width: 800px;
                margin: 0px auto;
                margin-top: 1em;
            }
            .navbar-default .navbar-brand, .navbar-default .navbar-brand:hover
            {
                color: #fff;
            }
        </style>--%>
    <script type="text/javascript">
            $(function() {
                var match = document.cookie.match(new RegExp('color=([^;]+)'));
                if (match) var color = match[1];
                if (color) {
                    $('body').removeClass(function(index, css) {
                        return (css.match(/\btheme-\S+/g) || []).join(' ')
                    })
                    $('body').addClass('theme-' + color);
                }
                $('[data-popover="true"]').popover({ html: true });
            });
    </script>
    <script type="Text/JavaScript">
            function regvalidate() {
                if (document.registerationform.txtUsrNm.value == "") {
                    document.getElementById('txtUsrNm').innerHTML = "Please enter User Name";
                    registerationform.txtUsrNm.focus();                    
                    return (false);                    
                }
                if (document.registerationform.txtPwd.value == "") {
                    document.getElementById('txtPwd').innerHTML = "Please enter a password";
                    registerationform.txtPwd.focus();
                    return (false);
                }
                else {
                    return (true);
                }
            }
        </script>
    <script type="text/javascript">
            $(function() {
                var uls = $('.sidebar-nav > ul > *').clone();
                uls.addClass('visible-xs');
                $('#main-menu').append(uls.clone());
            });
    </script>
        <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
        <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
        <!-- Le fav and touch icons -->
        
        <!--[if lt IE 7 ]> <body class="ie ie6"> <![endif]-->
        <!--[if IE 7 ]> <body class="ie ie7 "> <![endif]-->
        <!--[if IE 8 ]> <body class="ie ie8 "> <![endif]-->
        <!--[if IE 9 ]> <body class="ie ie9 "> <![endif]-->
        <!--[if (gt IE 9)|!(IE)]><!-->
        <!--<![endif]-->
    <div class="navbar navbar-default" role="navigation">
            <div class="navbar-header">
                <span class="navbar-brand">ORGANISER</span></div>
            <div class="navbar-collapse collapse" style="height: 1px;">
            </div>
        </div>  
    <div class="dialog">
        <div>
         <div class="panel panel-default">
                <p class="panel-heading no-collapse" style="width:100%">Login</p>
            <div class="panel-body">
               <%-- <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                <asp:Label ID="Label3" runat="server" text="Center"></asp:Label>
                                <asp:DropDownList ID="ddlCenter_Nm" runat="server" class="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>                                
                    </div>
                <div>
                        <asp:RequiredFieldValidator ID="ReqCenter" runat="server" ErrorMessage="Select Center " ControlToValidate="ddlCenter_Nm" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>--%>
                <div class="form-group">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <label>Username</label>
                        <asp:TextBox ID="txtu_nm" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div>
                        <asp:RequiredFieldValidator ID="reqUse_Nm" runat="server" ErrorMessage="Required User Name" ControlToValidate="txtu_nm" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                    </div>
                <div class="form-group">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label><label>Password</label>
                        <asp:TextBox ID="txtpwd" type="password" class="form-controlspan12 form-control" runat="server" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="reqPwd" runat="server" ErrorMessage="Required User Password" ControlToValidate="txtpwd" Text="*" EnableClientScript="true" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>              
               <asp:Button ID="btnlogin" runat="server" OnClientClick="regvalidate();" class="btn btn-primary pull-right" Text="Login" onclick="btnlogin_Click" />                        
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                    </div>
                </div>
            </div>
            <p class="pull-right" class="text-sm text-muted">
                <small> Sanwad Software's</small> </p>
           <%-- <p>
                <a href="reset-password.html" >Forgot our password?</a></p>--%>
       </div> 
       </div> 
       </ContentTemplate> 
       </asp:UpdatePanel> 
    <script src="lib/bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
            $("[rel=tooltip]").tooltip();
            $(function() {
                $('.demo-cancel-click').click(function() { return false; });
            });
    </script>
    </form>
</body>
</html>
