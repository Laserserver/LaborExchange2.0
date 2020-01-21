//var serverURL = 'https:/localhost:44350';

var url = "https://localhost:44350/api/companytype";
var tempId;
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
    $.ajax({
        url: url + "/" + id,
        type: 'DELETE',
        success: function (result) {
            alert("Удалена запись " + id);
            loadData();
        },
        error: function (body, status, errorThrown) {
            switch (body.status) {
                case 500: showError("Ошибка на сервере");
                    return;
                case 409:
                    if (confirm("От этого типа зависят некоторые компании. Удалить вместе с ними?")) {
                        alert("Приехали");
                    }
                break;
            }
        }
    });
}

function editEntity(id) {
    $("#editable").show();
    $.getJSON(url + "?id=" + id, function (obj) {
        var tt = obj.Page[0].Company;
        $("#oldName").text(tt);
    });
    tempId = id;
}

function editEntity2() {

    var newname = $("#newNameBox").val();

    $.ajax({
        url: url + "/" + tempId,
        type: 'PUT',
        data: "newName=" + newname,
        success: function (result) {
            if (tempId !== -1) {
                alert("Обновлена запись " + tempId);
                loadData();
            }
        },
        error: function (body, status, errorThrown) {
            switch (body.status) {
            case 500: showError("Ошибка на сервере");
                return;
            }
        }
    });
}


function loadData() {
    loadTemplates();
    tempId = -1;
    $("#results>table>tbody").empty();
    $("#editable").hide();
    $("#nameBox").val("");
    $("#newNameBox").val("");
    $(".mbutton").click(function(e) {});
    $("#btnSave").click(function(e) {});
    $.getJSON(url, function (obj) {
        $.tmpl("CTitem", obj.Page).appendTo("#results>table>tbody");
        console.log(obj);
        $(".mbutton").click(function (e) {
            var id = $(e.target).attr("entityID");
            var op = $(e.target).attr("opcode");
            if (op === "1") {
                editEntity(id);
            } else {
                if (confirm("Удалить запись " + id + "?")) {
                    deleteEntity(id);
                }
            }
            
        });
        $("#btnSave").click(function(e) {
            editEntity2();
        });
        $("#progress").hide();
    });
}


$(window).on('load', function () {
    loadData();

});