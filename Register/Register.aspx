<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Proyecto2_ProgramacionII.Sign_Up.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
      <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="fonts/icomoon/style.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    
    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">
    <title>Register</title>
</head>
 <body>
   <div class="content">
     <div class="container">
       <div class="row align-items-center" style="margin-right: 50px; margin-left: -300px; transform: scale(1.1);">
         <div class="col-lg-5">
         </div>
         <div class="col-lg-5 contents">
           <div class="form-block">
           <div class="mb-4 text-center">
                 <h3>Registrarte</h3>
                 <p class="mb-4">Regístrate ahora para recibir asistencia técnica personalizada. Únete a nuestra comunidad de expertos en reparación.</p>
               </div>
               <form action="#" method="post" id="form1" runat="server">
                 <div class="form-group first">
                   <label for="name">Nombre Completo</label>
                   <asp:TextBox type="text" ID="tNombre" class="form-control" runat="server" required></asp:TextBox>
                 </div>
                 <div class="form-group">
                   <label for="email">Email</label>
                   <asp:TextBox type="email" class="form-control" ID="tEmail" runat="server" required></asp:TextBox>
                 </div>
                   <div class="form-group" style="margin-top: 25px;">
                   <label for="email" style="font-size:13px;">Seleccione Rol:</label>
                 </div>
                    <div class="form-check form-check-inline" style="margin-top: 42px; font-size:12px; display: block; color:#b3b3b3; margin-bottom: 10px;">
                       <asp:RadioButton class="form-check-input" ID="rbAdmin" runat="server" Text="Admin" GroupName="Roles"/>
                        <asp:RadioButton class="form-check-input" ID="rbTecnico" runat="server" Text="Técnico" GroupName="Roles"/>
                     </div>
                 <div class="form-group">
                   <label for="password">Password</label>
                   <asp:TextBox type="password" class="form-control" ID="tpassword" runat="server" required></asp:TextBox>
                 </div>
                 <div class="form-group last mb-4">
                   <label for="re-password">Re-type Password</label>
                   <asp:TextBox  type="password" class="form-control" ID="tre_password" runat="server" required></asp:TextBox>
                 </div>
                 <div class="d-flex mb-5 align-items-center">
                   <label class="control control--checkbox mb-3 mb-sm-0"><span class="caption"><a href="#">Términos y Condiciones</a></span>
                   <asp:TextBox type="checkbox" checked="checked" ID="tcheckbox" runat="server"></asp:TextBox>
                   <div class="control__indicator"></div>
                 </label>
                     <br />
                   <span class="ml-auto"><a href="../Login/Login.aspx" class="forgot-pass">Iniciar sesión</a></span> 
                 </div>
                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-pill text-white btn-block btn-primary" Text="Registrarse" OnClick="btnRegistrar_Click" />
               </form>
             </div>
         </div>
       </div>
     </div>
   </div>
   <script src="js/jquery-3.3.1.min.js"></script>
   <script src="js/popper.min.js"></script>
   <script src="js/bootstrap.min.js"></script>
   <script src="js/main.js"></script>
 </body>
</html>
