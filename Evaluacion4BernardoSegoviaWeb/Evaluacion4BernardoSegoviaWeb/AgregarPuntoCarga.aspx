<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AgregarPuntoCarga.aspx.cs" Inherits="Evaluacion4BernardoSegoviaWeb.AgregarPuntoCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblmensaje" runat="server" CssClass="text-success h3 "></asp:Label>
    </div><br />
    <div class="card">
        <div class="card-header bg-dark text-white">
            Ingresar un nuevo Punto de Carga
        </div>
        <div class="card-body">
            <div class="form-group">
                <label for="idpuntocarga">ID:</label>
                <asp:TextBox ID="idpuntocarga" CssClass="form-control" runat="server"></asp:TextBox>
            </div><br />
            <div class="form-group">
                <label for="tipopunto">Tipo Punto de Carga:</label>
                <asp:DropDownList ID="tipopunto" runat="server" CssClass="form-control">
                    <asp:ListItem Value ="1" Selected ="True" Text="Eléctrico"></asp:ListItem>
                    <asp:ListItem Value ="2" Selected ="False" Text="Dual"></asp:ListItem>
                </asp:DropDownList>
            </div><br />
            <div class="form-group">
                <label for="capmaximaautos">Capacidad de Vehículos Simultáneos:</label>
                <asp:TextBox ID="capmaximaautos" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="validarcapacidadautos" runat="server" ErrorMessage="CustomValidator"
                    ValidateEmpty="true" CssClass="text-danger" ControlToValidate="capmaximaautos"
                    OnServerValidate="validarcapacidadautos_ServerValidate"></asp:CustomValidator>
            </div><br />
            <div class="form-group">
                <label for="estaciondesignada">Estación Designada:</label>
                <asp:DropDownList ID="estaciondesignada" runat="server" CssClass="form-control"></asp:DropDownList>
            </div><br />
            <div class="form-group">
                <label for="vidautil">Funciona hasta (Vida útil):</label>
                <asp:TextBox ID="vidautil" CssClass="form-control" runat="server" Placeholder="Ingrese fecha con formato: dd-mm-aaaa"></asp:TextBox>
                <!--<asp:Calendar ID="Calendar1" runat="server" CssClass="fa fa-cal fa-fw"></asp:Calendar>-->
                <asp:CustomValidator ID="validarvidautil" runat="server" ErrorMessage="CustomValidator"
                    ValidateEmpty="true" CssClass="text-danger" ControlToValidate="vidautil" OnServerValidate="validarvidautil_ServerValidate"></asp:CustomValidator>
            </div><br />
            <div class="form-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Punto de Carga" CssClass="btn btn-success"
                   OnClick="Agregar_BtnClick"/>
            </div>
        </div>
    </div>
</asp:Content>
