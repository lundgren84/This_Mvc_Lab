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



function validateComment() {
    var error = document.getElementById("error")

    $.growl.notice({ message: "Olle was here!Olle was here!Olle was here!Olle was here!Olle was here!" });
    error.innerHTML = "Olle was here!";
}