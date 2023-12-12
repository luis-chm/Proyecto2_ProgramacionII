<%@ Page Title="" Language="C#" MasterPageFile="~/Menu/Menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Proyecto2_ProgramacionII.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
    <div class="mb-4">
               <h4 class="text-uppercase">Catalogo de Asignaciones</h4>
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

        <div id="miContenedor" runat="server" class="container text-center" style="background-color: #646464; font-family: Arial; color: White; border: none 0px transparent; width: 1050px; height:500px;">
        

        <label for="EnterText" class="form-label">Codigo de Asignación</label>
            <br />
        <asp:TextBox ID="txtAID" class="form-control form-control-sm d-inline-block w-50" runat="server" ></asp:TextBox>
            <br />

            <div class="mb-3">
            <label for="EnterText" class="form-label"> Codigo de Reparación: </label>
            <br />
            <asp:DropDownList ID="DropReparacion" class="form-control form-control-sm d-inline-block w-50" runat="server">
            </asp:DropDownList>
            </div>



           <div class="mb-3">
          <label for="EnterText" class="form-label"> Codigo Técnico: </label>
          <br />
          <asp:DropDownList ID="DropTecnico" class="form-control form-control-sm d-inline-block w-50" runat="server">
          </asp:DropDownList>
          </div>


         <div class="mb-3">
         <label for="EnterText" class="form-label">Fecha de Asignación</label>
         <br />
         <asp:TextBox ID="txtfecha" class="form-control form-control-sm d-inline-block w-50" runat="server"></asp:TextBox>
         <asp:Calendar ID="calFechaInicio" runat="server" OnSelectionChanged="calFechaInicio_SelectionChanged" Visible="false"></asp:Calendar>
         <br />
         <asp:Button ID="btnFechaInicio" runat="server" Text="Seleccionar Fecha" OnClick="btnFechaInicio_Click" />
         </div>
            <div class="container text-center">
                <br />
                <asp:Button ID="Button5" class="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregar"/>
                <asp:Button ID="Button6" class="btn btn-danger" runat="server" Text="Borrar" OnClick="btnBorrar" />
                <asp:Button ID="Button7" runat="server" class="btn btn-dark" Text="Modificar" OnClick="btnModificar" />
                <asp:Button ID="Button8" runat="server" class="btn btn-info" Text="Consultar" OnClick="btnConsultar" style="color: white;" />
                <br />
                <br />
                <br />
            </div>

            </div>



</asp:Content>
