<html>
<head>
<link href="style.css" rel="stylesheet" type="text/css" />
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
<script type="text/javascript" src="lib/cufon-yui.js"></script>
<script type="text/javascript" src="lib/arial.js"></script>
<script type="text/javascript" src="lib/cuf_run.js">
</script>
 <link rel="stylesheet" type="text/css" href="jQuery-slideshow-plugin/plugin.css" />
<title></title>
</head>
<body>
<div class="panel-body"> 
<table width="100%"><tr valign="middle"><td colspan="2" align="center" style="" 
        valign="middle" bgcolor="#333333"><div style=""><img runat="server" alt="" src="images/CLIENTELE final PNG1.png" /></div></td></tr>
<tr><td colspan="2" align="center" ><h3><a href="index.html" ><span style=" color:Red;">WELCOME TO HEARING AND SPEECH ADMIN SOFTWARE</span></a></h3></td></tr>
<tr><td colspan="2" align="center" ><h4><a href="index.html" ><span style="font-style:oblique; color:Purple">"Nearly Paperless Office"</span></a></h4></td></tr>
<tr><td align="center" width="50%" valign="top"> <div class="article_vert">
          <h2>Hearing Section</h2> 
          <div class="panel-body"> </div> 
          <div></div>         
          <img src="images/Audroom1.jpg" data-slideshow='images/Audroom2.jpg|images/Receip1.jpg|images/Receip2.jpg|images/Receip11.jpg|images/Waittingroom.jpg' width="287" height="160" alt=""/>
             <div >
    <button id="activate" type="button"  onclick="return activate_onclick()"> Clinic&nbsp; Photos</button>
</div>          
        </div></td><td  align="right" width="50%" valign="top">
        <form runat="server">
        <%--<div class="article_vert">--%>
         <%-- <div class="dialog">  --%>     
         <div class="panel panel-default" style="width:50%">
                <p class="panel-heading no-collapse" >Login</p>
            <div class="panel-body">               
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
               <asp:Button ID="btnlogin" runat="server" OnClientClick="regvalidate();" class="btn btn-primary pull-right" Text="Login" />                        
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" EnableClientScript="true"  />
                    </div>
                </div>
            </div>
            <p class="pull-right" class="text-sm text-muted">
                <small> Sanwad Software's</small> </p>
           <!-- <p>
                <a href="reset-password.html" >Forgot our password?</a></p>-->       
       <%--</div>--%>
       <%-- </div>--%>
        </form> </td></tr></table>
</div> 
</body>
</html>