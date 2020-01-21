<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery.aspx.cs" Inherits="LaborExchange2._0.JQuery1" %>
<%@ Register Assembly="Controls" Namespace="Controls" TagPrefix="lec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>JQuery test control</title>
    <script src="Scripts/jquery-3.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
</head>
<body>
    <a href="Index.aspx">Index</a>
    <h1>JQuery test control</h1>
    <form id="form1" runat="server">
        <asp:Label runat="server">Кнопка 1</asp:Label>
        <hr/>
        <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
        <hr/>
        <asp:Label runat="server">Кнопка 2</asp:Label>
        <hr/>
        <asp:PlaceHolder ID="PH2" runat="server"></asp:PlaceHolder>
        <lec:NewNameBox runat="server" ID="nameBox"></lec:NewNameBox>
    </form>
</body>
</html>
