//$(document).ready(function () {
  
//    $.growl.notice({ message: "btn Pressed" });

//    form.submit(function (e) {
//        e.preventDefault();
//        $.ajax({
//            method: "POST",
//            url: "/Comment/Create",
//            data: new FormData(form),
//            beforeSend: function () { },
//            success: function (data) { $('#JSTEST').html(data); },
//            processData: false,
//            contentType: false,
//        });
//    });
//});

(function () {
    //Getting the form
    var form = document.getElementById("ThisForm");

    //Adding a eventListener
    form.addEventListener("submit", function (e) {

        var text = "";

        var txtValue = document.getElementById("CommentTxt").value;
    
        if (txtValue == 0) {
            e.preventDefault();
            $.growl.error({ message: "You need a Comment!" });
            text = "You need a Comment!";
        }
        else {           
            $.growl.notice({ message: "Comment created!" });
            text = "Comment created!";
        }
    })
})();



