<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery.aspx.cs" Inherits="LaborExchange2._0.JQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>jQuery</title>
    <script src="Scripts/jquery-3.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
</head>
<body>
    <h1>JQuery Control</h1>
<div id="progress">Loading...</div>
<div id="results">
<table>
    <thead>
    <tr>
        <th id="ID" class="clickableTH sortedAsc">
            ID
        </th>
        <th id="Company" class="clickableTH">
            Название
        </th>
    </tr>
    </thead>
    <tbody>
    </tbody>
</table>
    </div>

<script type="text/javascript">
    //var serverURL = 'https:/localhost:44350';

    function loadTemplates() {
        $.get("tmpl/ctitem.html", function f(data) {
            $.template("CTitem", data);
        });
    }

    $(window).on('load', function () {
        loadTemplates();

        var url = "https://localhost:44350/api/companytype";
        $.getJSON(url, function (obj) {
            $.tmpl("CTitem", obj.Page).appendTo("#results>table>tbody");
            console.log(obj);
            $("#progress").hide();
        });

	});
</script>    
</body>
</html>
