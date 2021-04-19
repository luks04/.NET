<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"
    CodeBehind="Hola.aspx.cs" Inherits="MiPrimeraAppASP.Hola" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ****************************************** -->
   <!-- ****************************************** -->
   <script lang="JavaScript" type="text/javascript">
       alert("Hola esta es mi primera pagina");
   </script>
   <img src="logo.png" id="logoEan" title="Logo ean" />
   <br />
   <h1>Mi primer formulario ASP.NET 4.5 WebForms</h1>
   <br />
   <p>Hola Bienvenidos a mi app ASP.NET - Hoy es <%=DateTime.Now.ToUniversalTime()%></p>
   <!-- ****************************************** -->
   <!-- ****************************************** -->
</asp:Content>