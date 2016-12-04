var form = $('#AlbumFormDiv').hide();
var txt = $('#txtbox');

$('#ShowAlbumForm').click(function () {
    //The Show form button
    var btn = $('#ShowAlbumForm')

    if (btn.html() == "Hide") {
        //btn.prop('value', 'Add new Album');
        btn.html("Add new Album");
        form.fadeOut("slow");
        txt.val("");
    }
    else {
        //btn.prop('value', 'Hide');
        btn.html("Hide");
        form.fadeIn("slow");
        txt.val("");
    }
  

   

});

$('#AlbumFormSubmit').click(function () {
    //The formDiv
    var form = $('#AlbumFormDiv');
    var btn = $('#ShowAlbumForm')
  
    var txtValue = document.getElementById("txtbox").value;
    var text = "";

    if (txtValue == 0) {

        $.growl.error({ message: "You need a name!" });
        text = "You need a name!";
    }
    else {
        $.growl.notice({ message: "Album created!" });
        text = "Album created!";
        form.fadeOut("slow");
        btn.html("Add new Album");
    }
    document.getElementById("JSValidation").innerHTML = text;



});


//(function () {
//    //Getting the form
//    var form = document.getElementById("AlbumForm");

//    //Adding a eventListener
//    form.addEventListener("submit", function (e) {

//        var text = "";

//        var txtValue = document.getElementById("txtbox").value;

//        if (txtValue == 0) {
//            e.preventDefault();
//            $.growl.error({ message: "You need a name!" });
//            text = "You need a name!";
//        }
//        else {
//            $.growl.notice({ message: "Album created!" });
//            text = "Album created!";
//        }
//        document.getElementById("JSValidation").innerHTML = text;
//    })
//})();











//$(document).ready(function () {
//    var form = $("form");
//    form.addEventListener("submit", function (e) {

//        var albumName = $('#txtbox');

//        if(albumName ==""){
//            e.preventDefault();
//            $.growl.error({ message: "You need a name!" });       
//        }
//        else{
//            $.growl.notice({ message: "Album created!" });
//        }
//    }
//});