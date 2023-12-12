<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Proyecto2_ProgramacionII.Menu.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br>

<div class="container" style="max-width: 650px; min-width: 400px;">
  <div class="card">
    <h3 class="card-header text-center">Información Personal</h3>
    <div class="card-body">
      <form id="myForm" onsubmit="return validar()">
        <div class="form-group">
          <legend>Datos de la Cuenta</legend>
          <label for="codigo">Codigo:</label>
            <asp:Label type="text" class="form-control" ID="lCodigo" runat="server" Text="Label"></asp:Label>
          <label for="user">Nombre Completo:</label>
          <br>
            <asp:Label class="form-control" for="user" ID="lNombre" runat="server" Text=""></asp:Label>
          <label for="email">Correo Electronico:</label>
            <asp:Label type="email" class="form-control" ID="lCorreo" runat="server" Text="Label"></asp:Label>
          <label for="pass">Rol:</label>
            <asp:Label type="text" class="form-control" ID="lRol" runat="server" Text="Label"></asp:Label>
        </div>
      </form>
    </div>
  </div>
</div>


</asp:Content>
