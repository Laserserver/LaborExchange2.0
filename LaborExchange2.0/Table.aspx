<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="LaborExchange2._0.DPP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-3.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/table.js" type="text/javascript"></script>
    <title>Листание выборки</title>
</head>
<body>
    <a href="Index.aspx">Index</a>
    <h1>10. Листание выборки</h1>
    <div id="progress">Loading...</div>
    <div id="results">
        <table>
            <thead>
                <tr>
                    <th id="ID">ID
                    </th>
                    <th id="Company">Название
                    </th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <hr />
    <div id="paging">
        <span id="moveLeft"><</span>
        <span id="pagesText">1 из 1</span>
        <span id="moveRight">></span>
    </div>
    <hr />
    <div id="pages">
        <span class="nb" num="5">5</span>
        <span class="nb" num="10">10</span>
        <span class="nb" num="20">20</span>
    </div>

</body>
</html>
