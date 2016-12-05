//$(document).ready(function () {

//});

var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];

//(function () {
//    //Getting the form
//    var form = document.getElementById("PictureForm");


//    //Adding a eventListener
//    form.addEventListener("submit", function (e) {

//        var fileValue = $('#file').val();
//        var error = document.getElementById("errorDiv")
//        var text = "";
//        //Check If Value is ok
//        var validateFlag = false;
//        for (var j = 0; j < _validFileExtensions.length; j++) {
//            if (fileValue.toLowerCase().match(_validFileExtensions[j])) {
//                validateFlag = true;
//                break;
//            }
//        }
//        if (validateFlag) {
//            $.growl.notice({ message: "Picture Uploaded!" });
//            text = "";

//        }
//        else {
//            e.preventDefault();
//            $.growl.error({ message: "Need a (.jpg, .jpeg, .bmp, .gif, .png) file!" });
//            text = "Need a (.jpg, .jpeg, .bmp, .gif, .png) file!";
//        }
//        error.innerHTML = text

//    })
//})();


//$.ajax({
//    url: "Picture/Create",
//    data: new FormData(form),
//    method: 'POST',

//    // Nedan måste sättas för att det ska fungera! 
//    contentType: false,
//    processData: false
//});
$(document).ready(function () {
    var form = $("#PictureForm");







    form.submit(function (e) {



        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "/Album/AddPictures",
            data: new FormData(form[0]),
            success: function (data) {
                $.growl.notice({ message: "Picture Uploaded!" });
                $("#result").html(data);
                form[0].reset();
            },
            error: function () {
                $.growl.error({ message: "Need a (.jpg, .jpeg, .bmp, .gif, .png) file!" });
            },
            processData: false,
            contentType: false
        });
    });
})

