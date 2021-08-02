<%@ Page Title="VerPuntosCarga" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerPuntosCarga.aspx.cs" Inherits="Evaluacion4BernardoSegoviaWeb.VerPuntosCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblmensaje" runat="server" CssClass="text-success h3 "></asp:Label>
    </div><br />
    <div>
        <asp:Label ID="filtro" runat="server" CssClass="text-dark h5 ">Filtrar por Tipo:</asp:Label>
        <asp:DropDownList ID="filtropornivel" runat="server" OnSelectedIndexChanged="filtropornivel_SelectedIndexChanged"
            AutoPostBack="true" CssClass="form-control">
            <asp:ListItem Value="1" Text="Eléctrico"></asp:ListItem>
            <asp:ListItem Value="2" Text="Sistema Dual"></asp:ListItem>
            <asp:ListItem Value="3" Selected="true" Text="TODOS"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="mt-5">
        <asp:GridView ID="puntoscargaGrid" runat="server" CssClass="table table-hover" AutoGenerateColumns="false"
            EmptyDataText="NO hay Puntos de Carga registrados." OnRowCommand="puntoscargaGrid_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID Punto Carga" DataField="idPtoCarga" />
                <asp:BoundField HeaderText="Tipo Punto Carga" DataField="TipoTxt" />
                <asp:BoundField HeaderText="Capacidad Vehículos" DataField="capMaxAutos" />
                <asp:BoundField HeaderText="Vida Útil hasta..." DataField="vidaUtil" />
                <asp:BoundField HeaderText="ID Estación" DataField="idEstacion" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Actualizar Punto de Carga" CommandName="actualizar"
                            CssClass="btn btn-primary" CommandArgument='<%# Eval("idPtoCarga") %>'/>
                    </ItemTemplate>
                 </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
