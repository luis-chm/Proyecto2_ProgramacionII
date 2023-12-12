<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto2_ProgramacionII.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet">

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	
	<link rel="stylesheet" href="css/style.css">
</head>
<body>
	<section class="ftco-section">
<div class="container" style="margin-top:-75px;">
	<div class="row justify-content-center">
		<div class="col-md-6 text-center mb-5">
			<h2 class="heading-section">Bienvenido</h2>
		</div>
	</div>
	<div class="row justify-content-center" style="transform: scale(1.1);">
		<div class="col-md-7 col-lg-5">
			<div class="wrap">
				<div class="img" style="background-image: url(images/bg-1.jpg);"></div>
				<div class="login-wrap p-4 p-md-5">
	      	<div class="d-flex">
	      		<div class="w-100">
	      			<h3 class="mb-4">Iniciar sesión</h3>
	      		</div>
	      	</div>
					<form action="#" class="signin-form" id="form2" runat="server">
	      		<div class="form-group mt-3">
					<asp:TextBox ID="tcorreo" class="form-control" runat="server" required></asp:TextBox>
	      			<asp:Label ID="LCorreo" class="form-control-placeholder" runat="server" for="correo">Email</asp:Label>
	      		</div>
            <div class="form-group">
				  <asp:TextBox ID="tclave" class="form-control" TextMode="Password" runat="server" required></asp:TextBox>
				  <asp:Label ID="LPassword" class="form-control-placeholder" runat="server" for="Password">Password</asp:Label>
				  <span toggle="#tclave" class="fa fa-fw fa-eye field-icon toggle-password"></span>
            </div>
            <div class="form-group">
				<asp:Button ID="btnLogin" runat="server" class="form-control btn btn-primary rounded submit px-3" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
            </div>
            <div class="form-group d-md-flex">
							<div class="w-4 text-md-right">
								<a href="../Reset Password/ResetPassword.aspx">¿Olvidó su contraseña?</a> 
							</div>
            </div>
          </form>
          <p class="text-center">¿No tienes cuenta? <a href="../Register/Register.aspx">Regístrate</a></p>
        </div>
      </div>
		</div>
	</div>
</div>
	</section>
	<script src="js/jquery.min.js"></script>
<script src="js/popper.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/main.js"></script>
	</body>
</html>
