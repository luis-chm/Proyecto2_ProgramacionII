<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Proyecto2_ProgramacionII.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <div class="mb-4">
               <h4 class="text-uppercase">Catalogo de Equipos</h4>
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
        <label for="EnterText" class="form-label">Codigo de Equipo</label>
            <br />
        <asp:TextBox ID="txtEquipoID" class="form-control form-control-sm d-inline-block w-50" runat="server" ></asp:TextBox>
            <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label">Tipo de Equipo</label>
                <br />
        <asp:TextBox ID="txtTipoEquipo" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox> 
                <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label">Modelo</label>
                <br />
         <asp:TextBox ID="txtModelo" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
                <br />
            <div class="mb-3">
        <label for="EnterText" class="form-label"> Usuario: </label>
                <br />
                <asp:DropDownList ID="DropUsuarios" class="form-control form-control-sm d-inline-block w-50" runat="server">
                </asp:DropDownList>
        </div>
        </div>

<div class="container text-center">
    <br />
    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregar"/>
    <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Borrar" OnClick="btnBorrar" />
    <asp:Button ID="Button3" runat="server" class="btn btn-dark" Text="Modificar" OnClick="btnModificar" />
    <asp:Button ID="Button4" runat="server" class="btn btn-info" Text="Consultar" OnClick="btnConsultar" style="color: white;" />
    <br />
    <br />
</div>
    </div>
    </div>
</asp:Content>

