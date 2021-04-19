<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CapturaDatos.aspx.cs" Inherits="MiPrimeraAppASP.CapturaDatos" %>
<asp:Content ID="ContentCapturaDatos" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                <h3>Seleccione plataforma favorita</h3>
                <asp:DropDownList ID="DropDownListPlataformasMusica" runat="server" Height="30px" Width="142px">
                    <asp:ListItem Selected="True" Value="-1">Seleccione una plataforma</asp:ListItem>
                    <asp:ListItem>Spotify</asp:ListItem>
                    <asp:ListItem>Deezer</asp:ListItem>
                    <asp:ListItem>Claro Musica</asp:ListItem>
                    <asp:ListItem>Apple Music</asp:ListItem>
                     <asp:ListItem>Amazon Music</asp:ListItem>
                     <asp:ListItem>Google Music</asp:ListItem>
                     <asp:ListItem>Youtube Music</asp:ListItem>
                     <asp:ListItem>iTunes</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="col">
                <h3>Seleccione sus generos preferidos</h3>
                <asp:CheckBoxList ID="CheckBoxListGenerosMusica" runat="server" Height="87px" Width="218px">
                    <asp:ListItem>&nbsp Rock</asp:ListItem>
                    <asp:ListItem>&nbsp Reggaeton</asp:ListItem>
                    <asp:ListItem>&nbsp Salsa</asp:ListItem>
                    <asp:ListItem>&nbsp Popular</asp:ListItem>
                    <asp:ListItem>&nbsp Electronica</asp:ListItem>
                    <asp:ListItem>&nbsp Pop</asp:ListItem>
                    <asp:ListItem>&nbsp Merengue</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
        <br />
        <asp:Button ID="btnCapturarDatos" runat="server" CssClass="btn btn-success" OnClick="btnCapturarDatos_Click" Text="Capturar Datos" />
        <br />
        <br />
        <asp:Label ID="LabelCapturaPlataforma" runat="server" Text=""></asp:Label>
        <asp:Label ID="LabelCapturaGeneros" runat="server" Text=""></asp:Label>
    </div>    
</asp:Content>
