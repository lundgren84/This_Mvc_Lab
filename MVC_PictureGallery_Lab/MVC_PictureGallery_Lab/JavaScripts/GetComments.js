$(document).ready(function () {
 
    $.ajax({
        method: "GET",
        url: "/Picture/GetComments",
        data: new FormData(form[0]),
        success: function (data) {
               
            $("#result").html(data);
            form[0].reset();
            $('#CommentsHereThx').html(data);
        },
        error: function () {
               
        },
        processData: false,
        contentType: false
    });
});

