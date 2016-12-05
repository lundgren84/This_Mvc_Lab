

var form = $('#PictureEditFrom').hide();
var btn = $('#ShowEditPictureForm')
btn.prop('value', 'Edit Picture');

$('#ShowEditPictureForm').click(function () {

    if (btn.val() == "Edit Picture") {
        form.fadeIn("slow");
        btn.prop('value', 'Hide');
        btn.html('Hide');
    }
    else {
        btn.prop('value', 'Edit Picture');
        btn.html('Edit Picture');
        form.fadeOut("slow");
    }
    
});

$('#PictureEditSubmit').click(function () {
    btn.prop('value', 'Edit Picture');
    btn.html('Edit Picture');
    form.fadeOut("slow");

})
