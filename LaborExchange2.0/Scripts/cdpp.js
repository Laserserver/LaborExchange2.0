//var serverURL = 'https:/localhost:44350';

var url = "https://localhost:44350/api/companytype";

function loadTemplates() {
    $.get("tmpl/ctitem.html", function f(data) {
        $.template("CTitem", data);
    });
}
$(document).ready(function () {
    $("#btnNew").click(function (e) {
        var name = $("#nameBox").val();
        //alert(name);
        $.post(
            url,
            {
                newName: name
            },
            function (e) {
                alert(e);
                console.log(e);
                loadData();
            }
        );
    });
});

function deleteEntity(id) {
    alert("Удалено " + id);
}

function editEntity(id) {
    alert("Исправление " + id);
}


function loadData() {
    loadTemplates();
    $("#results>table>tbody").empty();
    $.getJSON(url, function (obj) {
        $.tmpl("CTitem", obj.Page).appendTo("#results>table>tbody");
        console.log(obj);
        $(".mbutton").click(function (e) {
            console.log(e);
            var id = $(e.target).attr("entityID");
            var op = $(e.target).attr("opcode");
            if (op === "1") {
                editEntity(id);
            } else {
                if (confirm("Удалить запись " + id + " ?")) {
                    deleteEntity(id);
                }
            }
            
        });
        $("#progress").hide();
    });
}


$(window).on('load', function () {
    loadData();

});