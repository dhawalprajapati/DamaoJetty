$(document).ready(function () {


    $("#SendContactForm").on("click", function (e) {
        e.preventDefault();
        alert("Ok");
        if (ValidateContact())
            SendMail();
    });

});


function SendMail() {
    var btnSave = $("#SendContactForm");
    var MVCController = btnSave.attr("data-controller");
    var MVCAction = btnSave.attr("data-action");
    var URLString = btnSave.attr("data-url");

    $.ajax({
        type: "POST",
        url: URLString,
        async: false,
        data: {
            Name: $("#name").val(),
            Message: $("#message").val(),
            Email: $("#email").val()           
        },
        success: function (data) {
            if (data != null) {
                alert("Thank you, your feedback is received.");
                var url = "/Home/Index";
                window.location.href = url;
            }
        },
    });
}

function ValidateContact() {
    var flag = true;
    var MessageText = '';

    if ($('#message').val() == "") {
        MessageText += 'Please enter Message. <br/>'; flag = false;
    }

    if ($('#name').val() == "") {
        MessageText += 'Please enter your full Name. <br/>'; flag = false;
    }

    if (IsEmail($('#email').val()) == false) {
        MessageText += 'Please enter valid Email. <br/>'; flag = false;
    }

    var html = '';
    html += '<div class="alert alert-danger" role="alert">';
    html += MessageText;
    html += '</div >';

    if (MessageText == '') {
        $('#messageBox').html('');
    }
    else {
        $('#messageBox').html('');
        $('#messageBox').append(html);
    }

    return flag;
}

function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}