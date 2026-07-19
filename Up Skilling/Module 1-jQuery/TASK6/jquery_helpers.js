$(document).ready(function () {

    $("#box").click(function () {

        $("#message").text(
            "Box Clicked"
        );

    });

    $("#box").dblclick(function () {

        $("#message").text(
            "Box Double Clicked"
        );

    });

    $("#box").mouseenter(function () {

        $(this).css(
            "background-color",
            "lightgreen"
        );

    });

    $("#box").mouseleave(function () {

        $(this).css(
            "background-color",
            "white"
        );

    });

    $("#textInput").keypress(function () {

        $("#message").text(
            "Key Pressed"
        );

    });

});