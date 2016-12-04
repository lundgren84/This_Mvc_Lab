//$(document).ready(function () {

//});

var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];

(function () {
    //Getting the form
    var form = document.getElementById("PictureForm");
   

    //Adding a eventListener
    form.addEventListener("submit", function (e) {
      
       
        //$.ajax({
        //    url: "Picture/Create",
        //    data: new FormData(form),
        //    method: 'POST',

        //    // Nedan måste sättas för att det ska fungera! 
        //    contentType: false,
        //    processData: false
        //});


        //Get the file value
        //var fileValue = document.getElementById("file").value;
        var fileValue = $('#file').val();
        var error = document.getElementById("errorDiv")
        var text ="";
        //Check If Value is ok
        var validateFlag = false;
        for (var j = 0; j < _validFileExtensions.length; j++) {
            if (fileValue.toLowerCase().match(_validFileExtensions[j])) {
                validateFlag = true;
                break;
            }
        }
        if (validateFlag) {
            $.growl.notice({ message: "Picture Uploaded!" });
            text = "";

        }
        else {
            e.preventDefault();
            $.growl.error({ message: "Need a (.jpg, .jpeg, .bmp, .gif, .png) file!" });
            text = "Need a (.jpg, .jpeg, .bmp, .gif, .png) file!";
        }
        error.innerHTML = text

    })
})();





