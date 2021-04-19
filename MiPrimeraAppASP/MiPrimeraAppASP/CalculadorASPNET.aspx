<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculadorASPNET.aspx.cs" Inherits="MiPrimeraAppASP.CalculadorASPNET" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script lang="JavaScript" type="text/javascript">
        function mostrarAcercaDe()
        {
            var copyright = "Mi calculadora en CSharp con Windows Forms hecha por\n" +
                "Jaime Gutierrez\n" +
                "<%=DateTime.Now.ToString()%>";

           console.log(copyright);

           alert(copyright); 
        }
    </script>
    <br />
    <h1>Mi Calculadora en Web Forms ASPX</h1>
    <br />
    <br />
    <table id="tablaCalculadora" border="1">
        <tr>
            <td>
                <asp:Label ID="lblNumero1" runat="server" Text="Número 1:"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtNumero1" runat="server" Width="207px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="btnSumar" runat="server" Text="Sumar" Width="202px" OnClick="btnSumar_Click" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="btnRestar" runat="server" Text="Restar" Width="198px" OnClick="btnRestar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNumero2" runat="server" Text="Número 2:"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtNumero2" runat="server" Width="207px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="btnMultiplicar" runat="server" Text="Multiplicar" Width="202px" OnClick="btnMultiplicar_Click" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="btnDividir" runat="server" Text="Dividir" Width="198px" OnClick="btnDividir_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResultado" runat="server" Text="Resultado:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtResultado" runat="server" Width="204px"></asp:TextBox>
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnReestablecer" runat="server" Text="Limpiar" Width="198px" OnClick="btnReestablecer_Click" />
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnAcercaDe" runat="server" Text="Acerca De" Width="192px" OnClick="btnAcercaDe_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <span style="align-content:center">
    <asp:LinkButton ID="enlaceRegresar" runat="server" OnClick="enlaceRegresar_Click">Regresar al Menú Principal</asp:LinkButton>
    </span>
</asp:Content>

