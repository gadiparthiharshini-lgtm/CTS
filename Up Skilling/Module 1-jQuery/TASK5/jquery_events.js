$(document).ready(function () {

    $("#colorBtn").click(function () {

        $("#colorBox").css(
            "background-color",
            "red"
        );

    });

    $("#colorBtn").dblclick(function () {

        $("#colorBox").css(
            "background-color",
            "white"
        );

    });

});