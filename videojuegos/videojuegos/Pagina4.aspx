﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina4.aspx.cs" Inherits="videojuegos.Pagina4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <br />
        Selecciona un juego:
        <asp:DropDownList ID="ddJuegos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddJuegos_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Información:<br />
        <br />
        <asp:GridView ID="gvJuegos" runat="server" OnSelectedIndexChanged="gvJuegos_SelectedIndexChanged">
        </asp:GridView>
        <br />
        <asp:Label ID="lbError" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
