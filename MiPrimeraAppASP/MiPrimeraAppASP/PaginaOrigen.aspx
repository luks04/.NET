<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaOrigen.aspx.cs" Inherits="MiPrimeraAppASP.PaginaOrigen" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<br />
<br />
    <table id="tablaCalculadora" border="1">
        <tr>
            <td>
                <asp:Label ID="lblDato1" runat="server" Text="Dato Texto:"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtCajaTexto" runat="server" Width="207px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNumero2" runat="server" Text="Dato Combo:"></asp:Label>
                </td>
            <td>
                <asp:DropDownList ID="listaProductos" runat="server" DataSourceID="origenDatosASPNET" DataTextField="ProductName" DataValueField="ProductID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="origenDatosASPNET" runat="server" ConnectionString="<%$ ConnectionStrings:CadenaConexionVientoNorte %>" 
                    SelectCommand="SELECT [ProductID], [ProductName] FROM [Alphabetical list of products]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultado" runat="server" Text="Resultado:"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAceptar" runat="server" Text="Guardar Datos" Width="192px" OnClick="btnAceptar_Click"/>
            </td>
        </tr>

        <tr>
            <td>Caja de texto:</td>
            <td>
                <asp:Label ID="lblCajaTextoDigitada" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Item de la lista del combo:</td>
            <td>
                <asp:Label ID="lblItemCombo" runat="server"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
