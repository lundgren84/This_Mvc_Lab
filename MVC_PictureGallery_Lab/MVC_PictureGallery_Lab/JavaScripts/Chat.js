$('document').ready(function (e) {
    setInterval(reloadChat2, 1000);
});
function reloadChat2() {
    $.ajax({
        dataType: "JSON",
        type: "GET",
        url: "../Chat/List",
        success: function (data) {
         
            var chat = "";
            for (var i = 0; i < data.length; i++) {
               
                chat +='<p>'+ data[i].Text + ' - ' +'<small>'+ data[i].PostTime+'</small>'+'</p>';
                          
            }



            $('#ChatArea').html(chat);
        }
    });
}



