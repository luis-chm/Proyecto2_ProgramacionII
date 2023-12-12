<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Proyecto2_ProgramacionII.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <div class="mb-4">
                <h4 class="text-uppercase">Catalogo de Usuarios</h4>
                <!-- Solid divider -->
                <hr class="p-1 bg-dark w-100">
    <p>&nbsp;</p>
</div>
<div>
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="center" ItemStyle-Width="100px"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="True"
            style="background-color: #646464; font-family: Arial; color: White; border: none 0px transparent;" >
        </asp:GridView>
        <hr class="p-1 bg-dark w-100">
        <br />
        <br />
    
</div>
        <div class="container text-center" style="background-color: #646464; font-family: Arial; color: White; border: none 0px transparent; width: 1050px;">
        <div class="mb-3">
        <label for="EnterText" class="form-label">Codigo de Usuario: </label>
            <br />
        <asp:TextBox ID="txtUsuarioID" class="form-control form-control-sm d-inline-block w-50" runat="server" ></asp:TextBox>
            <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label">Nombre: </label>
                <br />
        <asp:TextBox ID="txtNombre" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox> 
                <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label">Correo: </label>
                <br />
         <asp:TextBox ID="txtCorreo" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
                <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label">Telefono: </label>
                <br />
        <asp:TextBox ID="txtTelefono" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
        </div>

<div class="container text-center">
    <br />
    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregarUser" />
    <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Borrar" OnClick="btnBorrarUser"  />
    <asp:Button ID="Button3" runat="server" class="btn btn-dark" Text="Modificar" OnClick="btnModificarUser"  />
    <asp:Button ID="Button4" runat="server" class="btn btn-info" Text="Consultar"  style="color: white;" OnClick="btnConsultarUser" />
    <br />
    <br />
</div>
    </div>
    </div>
    </div>
</asp:Content>