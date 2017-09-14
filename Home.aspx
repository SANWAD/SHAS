<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<html>
<head>
<title>CLIENTEL</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css" />
<link href="style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="lib/cufon-yui.js"></script>
<script type="text/javascript" src="lib/arial.js"></script>
<script type="text/javascript" src="lib/cuf_run.js">
</script>
 <link rel="stylesheet" type="text/css" href="jQuery-slideshow-plugin/plugin.css" />
</head>
<body>
<div class="main">
<asp:UpdatePanel>
<ContentTemplate>
  <div class="header">
    <div class="header_resize">
      <div class="logo"><img id="Img1" runat="server" src="~/images/CLIENTEL_white1.png" alt=""/>
        <h3><a href="index.html" ><span style=" color:Red;">WELCOME TO HEARING AND SPEECH ADMIN ONLINE SOFTWARE</span><span style=" color: Blue;"> (Version 2.0)</span></a></h3>
        <h4><a href="index.html" ><span style="font-style:oblique; color:Purple">"A Paperless Office"</span></a></h4>        
      </div>
      <div class="menu_nav">
        <ul>
          <li class="active"><a href="#">Home</a></li>
          <li><a href="#">Support</a></li>
          <li><a href="#">About Us</a></li>          
          <li><a href="#">Contact Us</a></li>
          <%--<li><a href="blog.html">Employee Login</a></li>--%>
        </ul>
      </div>
      <div class="clr"></div>
    </div>
  </div>
  <div class="content">
    <div class="content_resize">
      <div class="mainbar">
        <div class="article_vert">
          <h2>Hearing Section</h2>  
          <br />         
          <img src="images/Audroom1.jpg" data-slideshow='images/Audroom2.jpg|images/Receip1.jpg|images/Receip2.jpg|images/Receip11.jpg|images/Waittingroom.jpg' width="287" height="160" alt="" onclick="return activate_onclick()"/>
             <div >
    <button id="activate" type="button"  onclick="return activate_onclick()"> &nbsp;Photos</button>
</div>
          
          <strong style="color:Red;"> Key Features of Software</strong><br />
          <strong>1)&nbsp; Patient Registration</strong><br />
          <strong>2)&nbsp; Appointments</strong><br />
          <strong>3)&nbsp; Hearing Section</strong>
          <li><a href="#">Cochlear Implant</a></li>                
          <li><a href="#">Hearing Aid Invoice</a></li>
          <li><a href="#">Hearing Aid Repair</a></li>          
          <li><a href="#">Hearing Aid Trial</a></li>
          <li><a href="#">Hearing Aid Assesment </a><b>......</b></li>
         <strong>4) Masters</strong><br />
          <li class="active"><a href="#"> Hearing Aid Master</a></li>
          <li><a href="#"> Accesories Master</a></li>     
          <li><a href="#"> Company Master</a></li>  
          <li><a href="#"> Doctor Master</a><b>......</b></li>
        </div>
        <div class="article_vert">
          <h2>Speech Section</h2>  
          <br />       
          <img src="images/Receip21.jpg" width="260" height="160" alt="" /><br />
          <strong>5)&nbsp; Others</strong><br />
                  <li class="active"><a href="#"> Ear Mould</a></li>
                  <li><a href="#">Enquiry</a></li>
                  <li><a href="#">Inward</a></li>          
                  <li><a href="#">Outward</a></li>
                  <li><a href="#">Order By Mail</a></li>
                  <li><a href="#">Petty Cash Billing</a><b>......</b></li>
          <strong>6)&nbsp; Various Reports</strong><br />
                  <li><a href="#">Analysis</a></li>
                  <li><a href="#">Back Up</a></li>
                  <li><a href="#">Change Password</a></li>          
                  <li><a href="#">Authorisation</a><b>......</b></li>  
                      <strong>7) Speech Section</strong><br />
                  <li><a href="#">Speech Assessment</a><b>......</b></li> 
                  <strong>8) SMS Facility</strong><br />
                  <strong>9) So Many Instersting Features</strong> <b>......</b><br /> 
        </div>
         <div class="article_vert">
          <h2>Login</h2>
          <br />
      <div class="dialog">        
        <form runat="server" >
         <div class="panel panel-default">
                <p class="panel-heading no-collapse" style="width:100%">Login</p>
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
                </form>       
       </div> 
        </div> 
        
        <div class="clr"></div>
               
      </div>
      
      <div class="clr"></div>
    </div>
  </div>
  <div class="fbg">
    <div class="fbg_resize">
      <div class="col c1">
        <h2>Hearing Aid Gallery</h2>
        <a href="#"><img src="images/cros.jpg" width="66" height="66" alt="" class="ad" /></a> <a href="#"><img src="images/Imgher.jpg" width="66" height="66" alt="" class="ad" /></a> <a href="#"><img src="images/Imghr2.jpg" width="66" height="66" alt="" class="ad" /></a> <a href="#"><img src="images/imghr3.jpg" width="66" height="66" alt="" class="ad" /></a> <a href="#"><img src="images/Imghr4.jpg" width="66" height="66" alt="" class="ad" /></a> <a href="#"><img src="images/herImag.jpg" width="66" height="66" alt="" class="ad" /></a>
        <div class="clr"></div>
      </div>
      <div class="col c2">
        <h2>About</h2>
        <img src="images/imghr5.jpg" width="66" height="66" alt="" />
        <p><br />
          <a href="#"></a></p>
      </div>
      <div class="col c3">
        <h2>Contact</h2>
        <p></p>
        <p><strong>Phone:</strong> +02312541071<br />
           <strong>Mobile No:</strong> 919822522480<br />
          <strong>Address:</strong> 318, C, Bhende Lane, Shivaji Chowk,Kolhapur(Maharashtra)<br />
          <strong>E-mail:</strong> <a href="#"> sanwadsoftwares@gmail.com</a></p>
      </div>
      <div class="clr"></div>
    </div>
  </div>
  </ContentTemplate>
  </asp:UpdatePanel>
  <div class="footer">
    <div class="footer_resize">
      <ul class="fmenu">
        <li class="active"><a href="#">Home</a></li>
        <li><a href="#">Support</a></li>
        <!--<li><a href="blog.html">Blog</a></li>-->
        <li><a href="#">About Us</a></li>
        <li><a href="#">Contacts</a></li>
        <li><a href="#">Login</a></li>
      </ul>
      <p class="lf">&copy; Copyright MyWebSite. Designed by  <a href="#">Sanwad Softwares</a></p>
      <div class="clr"></div>
    </div>
  </div>
</div>
<script src="lib/jquery-1.11.1.min.js"></script>
<script src="lib/jquery.hammer-full.min.js"></script>
<script src="jQuery-slideshow-plugin/plugin.js"> </script>
<script src="lib/demo.js">    function activate_onclick() {
        (function($) {
            $('#btnSpeech').on('click', function() {
                $('div, img').slideShow({
                    timeOut: 2000,
                    showNavigation: true,
                    pauseOnHover: true,
                    swipeNavigation: true
                });

                var navbar = $('.navbar')

                navbar.animate({ top: '-100px' }, function() {
                    navbar.hide();
                });

            })
        } (jQuery));

    }


</script>
</body> 
</html>
