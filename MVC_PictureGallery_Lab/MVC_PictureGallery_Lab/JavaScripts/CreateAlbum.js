$('ShowAlbumForm').click(function () {
    //The Show form button
    var btn = $('ShowAlbumForm')
    //The formDiv
    var from = $('AlbumFormDiv')
    //txtBox AlbumName
    var txtValue = document.getElementById("txtbox").value;



});

$('AlbumFormSubmit').click(function () {
    //The formDiv
    var from = $('AlbumFormDiv')
    //txtBox AlbumName
    var txtValue = document.getElementById("txtbox").value;


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