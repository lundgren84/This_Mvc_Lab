$('document').ready(function (e) {
    setInterval(reloadComments, 5000);
});

var commentsContainer = $('#commentcontainer');
var reloadComments = function (e) {

    $.ajax({
        type: "GET",
        url: "../../Comment/List?pictureID=" + $('#pictureID').val(),
        success: function (data) {
            $('#CommentsTest').html(data);
        }
    });
};