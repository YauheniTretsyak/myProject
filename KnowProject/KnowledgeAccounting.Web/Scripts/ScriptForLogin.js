$(document).ready(function () {

    $("#trigger").click(function () {
        var x = $("#box2");

        if ((x.css("display") == "none")) {
            $("#box").toggle(500);
        }
        else {
            $("#box2").toggle(500);
            $("#box").toggle(500);
        }
    });

    $("#trigger2").click(function () {
        var x = $("#box");

        if ((x.css("display") == "none")) {
            $("#box2").toggle(500);
        }
        else {
            $("#box").toggle(500);
            $("#box2").toggle(500);
        }
    });


});