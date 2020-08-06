var paymentType = 'card';

$(document).ready(function () {
    

    $("#btnPlaceOrder").on("click", function (e) {
        e.preventDefault();
        if (ValidatePayment(paymentType))
                SaveOrder();
    });

    $("#pills-card-tab").on("click", function (e) {
        e.preventDefault();
        paymentType = 'card';
        $('#messageBox').html('');
    });

    $("#pills-cash-tab").on("click", function (e) {
        e.preventDefault();
        paymentType = 'cash';
        $('#messageBox').html('');
    });

    $('#totalAmount').append($('#hdnTotalBill').val());

});

function ValidatePayment(paymentType) {
    
    var flag = true;
    var MessageText = '';

    if (paymentType === 'card') {

        if ($('#firstName').val() == "") {
            MessageText += 'Please enter First Name. <br/>'; flag = false;
        }

        if ($('#lastName').val() == "") {
            MessageText += 'Please enter Last Name. <br/>'; flag = false;
        }

        if (IsEmail($('#email').val()) == false) {
            MessageText += 'Please enter valid Email. <br/>'; flag = false;
        }

        if (IsNumber($('#contactNumber').val()) == false || $('#contactNumber').val().length < 11) {
            MessageText += 'Please enter valid Phone Number. <br/>'; flag = false;
        }

        if ($('#cardHolderName').val() == "") {
            MessageText += 'Please enter Valid Card Holder Name. <br/>'; flag = false;
        }

        if (IsNumber($('#cardNumber').val()) == false || $('#cardNumber').val().length < 16) {
            MessageText += 'Please enter valid Card Number. <br/>'; flag = false;
        }

        if ($('#ExpMonth').val() === "0") {
            MessageText += 'Please select Valid Expiry Month. <br/>'; flag = false;
        }

        if ($('#ExpYear').val() === "0") {
            MessageText += 'Please select Valid Expiry Year. <br/>'; flag = false;
        }

        if (IsNumber($('#cvcNumber').val()) == false || $('#cvcNumber').val().length < 3) {
            MessageText += 'Please enter valid Card CVC Number. <br/>'; flag = false;
        }
    }
    else {
        if ($('#chfirstName').val() == "") {
            MessageText += 'Please enter First Name. <br/>'; flag = false;
        }

        if ($('#chlastName').val() == "") {
            MessageText += 'Please enter Last Name. <br/>'; flag = false;
        }

        if (IsEmail($('#chemail').val()) == false) {
            MessageText += 'Please enter valid Email. <br/>'; flag = false;
        }

        if (IsNumber($('#chcontactNumber').val()) == false || $('#chcontactNumber').val().length < 11) {
            MessageText += 'Please enter valid Phone Number. <br/>'; flag = false;
        }
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

function IsNumber(number) {
    var regex = /([0-9]{10})|(\([0-9]{3}\)\s+[0-9]{3}\-[0-9]{4})/;

    if (number.length == 3)
        var regex = /^\d+$/;
    
    if (!regex.test(number))
        return false;
    else
        return true;
}

function SaveOrder() {
    var btnSave = $("#btnPlaceOrder");
    var MVCController = btnSave.attr("data-controller");
    var MVCAction = btnSave.attr("data-action");
    var URLString = btnSave.attr("data-url");

    $.ajax({
        type: "POST",
        url: URLString,
        async: false,
        data: {
            FirstName: paymentType == 'card' ? $("#firstName").val() : $("#chfirstName").val(),
            LastName: paymentType == 'card' ? $("#lastName").val() : $("#chlastName").val(),
            Email: paymentType == 'card' ? $("#email").val() : $("#chemail").val(),
            Phone: paymentType == 'card' ? $("#contactNumber").val() : $("#chcontactNumber").val(),
            CardNumber: paymentType == 'card' ? $("#cardNumber").val() : "0",
            PaymentType: paymentType
        },
        success: function (data) {
            if (data != null) {
                var url = "/Payment/Success/" + data;
                window.location.href = url;
            }
        },
    });
}