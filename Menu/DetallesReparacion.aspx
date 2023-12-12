<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" AutoEventWireup="true" CodeBehind="DetallesReparacion.aspx.cs" Inherits="Proyecto2_ProgramacionII.DetallesReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <div class="mb-4">
               <h4 class="text-uppercase">Catalogo de Detalles Reparación</h4>
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
        <label for="EnterText" class="form-label">Codigo del Detalle</label>
            <br />
        <asp:TextBox ID="txtDID" class="form-control form-control-sm d-inline-block w-50" runat="server" ></asp:TextBox>
            <br />

        <div class="mb-3">
        <label for="EnterText" class="form-label"> Codigo de Reparación: </label>
            <br />
            <asp:DropDownList ID="DropReparacion" class="form-control form-control-sm d-inline-block w-50" runat="server">
            </asp:DropDownList>
         </div>



        <div class="mb-3">
        <label for="EnterText" class="form-label">Descripción</label>
                <br />
        <asp:TextBox ID="txtdes" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox> 
                <br />
    
            <div class="mb-3">
        <label for="EnterText" class="form-label">Hora</label>
                <br />

        <asp:DropDownList ID="ddlHora" runat="server" CssClass="form-control form-control-sm d-inline-block w-50">
        <asp:ListItem Text="-- Selecciona una hora --" Value="" Selected="True"></asp:ListItem>
        <asp:ListItem Text="08:00 AM" Value="08:00:00"></asp:ListItem>
        <asp:ListItem Text="08:30 AM" Value="08:30:00"></asp:ListItem>
        <asp:ListItem Text="09:00 AM" Value="09:00:00"></asp:ListItem>
        <asp:ListItem Text="09:30 AM" Value="09:30:00"></asp:ListItem>
        <asp:ListItem Text="10:00 AM" Value="10:00:00"></asp:ListItem>
        <asp:ListItem Text="10:30 AM" Value="10:30:00"></asp:ListItem>
        <asp:ListItem Text="11:30 AM" Value="11:30:00"></asp:ListItem>
        <asp:ListItem Text="01:00 PM" Value="13:00:00"></asp:ListItem>
        <asp:ListItem Text="01:30 PM" Value="13:30:00"></asp:ListItem>
        <asp:ListItem Text="02:00 PM" Value="14:00:00"></asp:ListItem>
        <asp:ListItem Text="02:30 PM" Value="14:30:00"></asp:ListItem>
        <asp:ListItem Text="03:00 PM" Value="15:00:00"></asp:ListItem>
        <asp:ListItem Text="03:30 PM" Value="14:30:00"></asp:ListItem>
        </asp:DropDownList>
        </div>



         <div class="mb-3">
        <label for="EnterText" class="form-label">Fecha Inicio</label>
        <br />
        <asp:TextBox ID="txtfechaI" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
        <asp:Calendar ID="calFechaInicio" runat="server" OnSelectionChanged="calFechaInicio_SelectionChanged" Visible="false"></asp:Calendar>
        <br />
        <asp:Button ID="btnFechaInicio" runat="server" Text="Seleccionar Fecha" OnClick="btnFechaInicio_Click" />
         </div>




        <div class="mb-3">
        <label for="EnterText" class="form-label">Fecha Fin</label>
                <br />
         <asp:TextBox ID="txtfechaF" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
                <br />   
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
