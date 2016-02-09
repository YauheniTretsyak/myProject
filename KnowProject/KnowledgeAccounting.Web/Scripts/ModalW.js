


function PopUpShow(id) {
    $.ajax({
        url: "/Users/Details/"+id,
        dataType: "HTML",
        success: function (result) {
            $("#popup1").show(500);
            $("#AjaxContent").html(result);
        }})
   
}

function PopUpHide() {
    $("#AjaxContent").html('');
    $("#popup1").hide(100);
}