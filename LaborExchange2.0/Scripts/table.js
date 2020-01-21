
var url = "https://localhost:44350/api/companytype";
var page = 1;
var pageCount = 5;
var allPages = 1;
function loadTemplates() {
    $.get("tmpl/ctind.html", function f(data) {
        $.template("CTitem", data);
    });
}

function moveLeft() {
    if (page > 1) {
        page--;
        loadData();
    }
}
function moveRight() {
    if (page < allPages) {
        page++;
        loadData();
    }
}

function setTexts() {
    $("#pagesText").text(page + " из " + allPages);
}

function loadData() {
    loadTemplates();
    tempId = -1;
    $("#moveLeft").unbind();
    $("#moveRight").unbind();
    $(".nb").unbind();
    $("#results>table>tbody").empty();
    $.getJSON(url + "?page=" + page + "&pagecount=" + pageCount, function (obj) {
        $.tmpl("CTitem", obj.Page).appendTo("#results>table>tbody");
        allPages = obj.PageCount;
        setTexts();
        console.log(obj);
        $("#moveLeft").click(function (e) {
            moveLeft();
        });
        $("#moveRight").click(function (e) {
            moveRight();
        });

        $(".nb").click(function (e) {
            if (pageCount !== $(e.target).attr("num") * 1) {
                page = 1;
                pageCount = $(e.target).attr("num") * 1;
                loadData();
            }
        });
        $("#progress").hide();
    });
}


$(window).on('load', function () {
    loadData();

});