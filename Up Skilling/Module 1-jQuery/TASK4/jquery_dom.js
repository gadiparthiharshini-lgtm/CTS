$(document).ready(function () {

    $("#addBtn").click(function () {

        let item =
        $("#itemInput").val();

        if(item.trim() !== ""){

            $("#itemList").append(
                "<li>" + item + "</li>"
            );

            $("#itemInput").val("");

        }

    });

    $("#removeBtn").click(function () {

        $("#itemList").empty();

    });

});