<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AgregarEstacion.aspx.cs" Inherits="Evaluacion4BernardoSegoviaWeb.AgregarEstacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblmensaje" runat="server" CssClass="text-success h3 "></asp:Label>
    </div><br />
    <div class="card">
        <div class="card-header bg-dark text-white">
            Ingresar una nueva Estación de Servicio
        </div>
        <div class="card-body">
            <div class="form-group">
                <label for="idestacion">ID:</label>
                <asp:TextBox ID="idestacion" CssClass="form-control" runat="server"></asp:TextBox>
            </div><br />
            <div class="form-group">
                <label for="direccion">Dirección:</label>
                <asp:TextBox ID="direccion" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ERROR: 
                    Se debe ingresar la dirección." ControlToValidate="direccion" CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="region">Región:</label>
                <asp:DropDownList ID="region" runat="server" CssClass="form-control"></asp:DropDownList>
            </div><br />
            <div class="form-group">
                <label for="horario">Horario Atención:</label>
                <asp:DropDownList ID="diainicio" runat="server" CssClass="form-control">
                    <asp:ListItem Value ="0" Selected ="True" Text="Seleccione día inicio..."></asp:ListItem>
                    <asp:ListItem Value ="Lunes" Selected ="False" Text="Lunes"></asp:ListItem>
                    <asp:ListItem Value ="Martes" Selected ="False" Text="Martes"></asp:ListItem>
                    <asp:ListItem Value ="Miércoles" Selected ="False" Text="Miércoles"></asp:ListItem>
                    <asp:ListItem Value ="Jueves" Selected ="False" Text="Jueves"></asp:ListItem>
                    <asp:ListItem Value ="Viernes" Selected ="False" Text="Viernes"></asp:ListItem>
                    <asp:ListItem Value ="Sábado" Selected ="False" Text="Sábado"></asp:ListItem>
                    <asp:ListItem Value ="Domingo" Selected ="False" Text="Domingo"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="diatermino" runat="server" CssClass="form-control">
                    <asp:ListItem Value ="0" Selected ="True" Text="Seleccione día término..."></asp:ListItem>
                    <asp:ListItem Value ="Lunes" Selected ="False" Text="Lunes"></asp:ListItem>
                    <asp:ListItem Value ="Martes" Selected ="False" Text="Martes"></asp:ListItem>
                    <asp:ListItem Value ="Miércoles" Selected ="False" Text="Miércoles"></asp:ListItem>
                    <asp:ListItem Value ="Jueves" Selected ="False" Text="Jueves"></asp:ListItem>
                    <asp:ListItem Value ="Viernes" Selected ="False" Text="Viernes"></asp:ListItem>
                    <asp:ListItem Value ="Sábado" Selected ="False" Text="Sábado"></asp:ListItem>
                    <asp:ListItem Value ="Domingo" Selected ="False" Text="Domingo"></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="horainicio" runat="server" CssClass="form-control" Placeholder="Ingrese hora de apertura (HH:MM)"></asp:TextBox>
                <asp:CustomValidator ID="validarhorainicio" runat="server" ErrorMessage="CustomValidator" 
                    CssClass="text-danger" ControlToValidate="horainicio" OnServerValidate="ValidarHoraInicio">
                </asp:CustomValidator>
                <asp:TextBox ID="horacierre" runat="server" CssClass="form-control" Placeholder="Ingrese hora de cierre (HH:MM)"></asp:TextBox>
                <asp:CustomValidator ID="validarhoracierre" runat="server" ErrorMessage="CustomValidator" 
                    CssClass="text-danger" ControlToValidate="horacierre" OnServerValidate="ValidarHoraCierre">
                </asp:CustomValidator>
            </div><br />
            <div class="form-group">
                <label for="capacidad">Capacidad Máxima de Puntos de Carga:</label>
                <asp:TextBox ID="capacidad" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CustomValidator ID="validarcapacidad" runat="server" ErrorMessage="CustomValidator"
                    CssClass="text-danger" ControlToValidate="capacidad" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </div><br /><br />
            <div class="form-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Estación" CssClass="btn btn-success"
                   OnClick="Agregar_BtnClick"/>
            </div>
        </div>
    </div>
</asp:Content>
