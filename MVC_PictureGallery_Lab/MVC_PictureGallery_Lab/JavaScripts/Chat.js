﻿$('document').ready(function (e) {
    setInterval(reloadChat2, 500);
});
function reloadChat2() {
    $.ajax({
        dataType: "JSON",
        type: "GET",
        url: "/Chat/List",
        success: function (data) {
         
            var chat = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i].AccountName.length < 1) 
                    chat += '<p>' + data[i].Text + ' - <small>' + 'Anonym' + '</small>' + '</p>';
                else
                    chat += '<p>' + data[i].Text  + ' - <small>' + data[i].AccountName + '</small>' + '</p>';                          
            }
            $('#ChatArea').html(chat);
        }
    });
}
$('#chatSubmit').click(function () {
    $('#txtBox').val("");
});


