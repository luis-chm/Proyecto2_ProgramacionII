<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Preferencias.aspx.cs" Inherits="Proyecto2_ProgramacionII.Menu.Preferencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <br>
<div class="container" style="max-width: 650px; min-width: 400px;">
  <div class="card">
    <h2 class="card-header text-center">Cambiar Contraseña</h2>
    <div class="card-body">
      <form id="myForm" onsubmit="return validar()">
        <label for="email">Correo Electronico:</label>
          <asp:TextBox type="email" class="form-control" ID="tEmail" runat="server" required></asp:TextBox>
        <div class="form-group">
          <label for="NewPass">Nueva Contraseña:</label>
          <asp:TextBox type="password" class="form-control" ID="tNewPassword" runat="server" required></asp:TextBox>
          <label for="Re-type Newpass">Nueva contraseña (de nuevo):</label>
          <asp:TextBox  type="password" class="form-control" ID="tre_NewPassword" runat="server" required></asp:TextBox>
        </div>
        <asp:Button type="submit" ID="btnRegistrar" runat="server" class="btn btn-success" Text="Registrar" OnClick="btnRegistrar_Click" />
       <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" Text="Cancelar" CausesValidation="False" UseSubmitBehavior="False" />
      </form>
    </div>
  </div>
</div>


</asp:Content>
