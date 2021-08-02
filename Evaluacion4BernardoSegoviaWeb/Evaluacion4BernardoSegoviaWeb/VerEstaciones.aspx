<%@ Page Title="VerEstaciones" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerEstaciones.aspx.cs" Inherits="Evaluacion4BernardoSegoviaWeb.VerEstaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-5">
        <asp:GridView AutoGenerateColumns="false" ID="estacionesGrid" runat="server"
            CssClass="table table-hover" EmptyDataText="No hay estaciones de servicio registradas."
            OnRowCommand="estacionesGrid_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID Estación" DataField="idEstacion" />
                <asp:BoundField HeaderText="Dirección" DataField="direccion" />
                <asp:BoundField HeaderText="Horario Atención" DataField="horario" />
                <asp:BoundField HeaderText="Capacidad Puntos Carga" DataField="capPtosCarga" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Quitar Estación" CommandName="eliminar"
                            CssClass="btn btn-danger" CommandArgument='<%# Eval("idEstacion") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
