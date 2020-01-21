<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cors.aspx.cs" Inherits="LaborExchange2._0.JQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cors + service</title>
    <script src="Scripts/jquery-3.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="Scripts/cdpp.js" type="text/javascript"></script>
</head>
<body>
    <a href="Index.aspx">Index</a>
    <h1>Cors + service + jquery</h1>
    <div id="progress">Loading...</div>
    <div id="results">
        <table>
            <thead>
                <tr>
                    <th id="ID" class="clickableTH sortedAsc">ID
                    </th>
                    <th id="Company" class="clickableTH">Название
                    </th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <hr />
    <div id="editable">
        <h4>Старое название:</h4>
        <span id="oldName"></span>
        <h4>Новое название:</h4>
        <input type="text" id="newNameBox" />
        <span id="btnSave">Сохранить</span>
        <hr />
    </div>
    <hr />
    <h4>Новый элемент:</h4>
    <input type="text" id="nameBox" />
    <span id="btnNew">Добавить</span>
    <hr />

</body>
</html>
