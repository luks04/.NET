<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="MiPrimeraAppASP.Calendario" %>
<asp:Content ID="ContentCalendario" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <table style="width: 57%; height: 240px;">
        <tr>
            <td class="modal-lg" style="width: 271px; height: 46px"><h3>Fecha inicial</h3></td>
            <td style="height: 46px"><h3>Fecha final</h3></td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 271px">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td>
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 271px">
                <br />
                <asp:Button ID="btnCalcularDias" runat="server" CssClass="btn btn-primary" OnClick="btnCalcularDias_Click" Text="Calcular Dias" />
            </td>
            <td>
                <asp:Label ID="Comprobar" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
