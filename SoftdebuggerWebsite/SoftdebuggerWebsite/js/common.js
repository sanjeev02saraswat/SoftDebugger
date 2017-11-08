//added  for form

function isEmail(email) {
    // var regex = /^([a-zA-Z0-9_.+-])+\@@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //    var emailReg = /^([\w-\.]+@@([\w-]+\.)+[\w-]{2,8})?$/;
    var emailReg = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
    return emailReg.test(email);
}



function emptyvalues() {
    $("#CustomerName").val('');
    $("#CustomerCompany").val('');
    $("#CustomerMobile").val('');
    $("#Email").val('');
    $("#RequestType").val('');
    $("#Website").val('');
    $("#CustomerMessage").val('');
    $("#ISD").val('');
    $("#ddlCountry").val('');
    $("#PopupFullName").val('');
    $("#PopupCompanyName").val('');
    $("#PopupPhoneNo").val('');
    $("#PopupEmailAddress").val('');
    $("#PopupRequestType").val('');
    $("#PopupWebsite").val('');
    $("#PopupDetails").val('');
    $("#PopupISD").val('');
    $("#PopupDesignation").val('');
    $("#PopupddlCountry").selectedIndex = 0;
    $("#PopupddlBusiness").selectedIndex = 0;
}

$('html').click(function (e) {
    debugger;
    if ($(e.target).hasClass('btn-block')) {
        return;
    }
    $("#CustomerName").removeClass("errorClass");
    $("#CustomerMobile").removeClass("errorClass");
    $("#CustomerCompany").removeClass("errorClass");
    $("#ddlCountry").removeClass("errorClass");
    $("#CustomerMessage").removeClass("errorClass");
    $("#Email").removeClass("errorClass");
    $("#Designation").removeClass("errorClass");
    $("#ddlBusiness").removeClass("errorClass");
    $("#EmailAddress").removeClass("errorClass");
    $("#spnerrormessage").css("display", "none");
    $("#spnemailmessage").css("display", "none");
    $("#PopupFullName").removeClass("errorClass");
    $("#PopupCompanyName").removeClass("errorClass");
    $("#PopupDesignation").removeClass("errorClass");
    $("#PopupddlBusiness").removeClass("errorClass");
    $("#PopupPhoneNo").removeClass("errorClass");
    $("#PopupddlCountry").removeClass("errorClass");
    $("#PopupISD").removeClass("errorClass");
    $("#PopupDetails").removeClass("errorClass");
    $("#PopupEmailAddress").removeClass("errorClass");
    $("#Popupspnerrormessage").css("display", "none");
    $("#Popupspnemailmessage").css("display", "none");
    $("#popupenquiryConfirmationmessage").css("display", "none");
    $("#contactusspnerrormessage").css("display", "none");
    $("#contactusspnemailmessage").css("display", "none");
    $("#ContactusenquiryConfirmationmessage").css("display", "none");
    //  $("#subscribermessage").text('');
    //  $("#enquiryConfirmationmessage").css("display", "none");
});



function ValidatePopupEnquiryForm() {
    var flag = true;
    if ($("#PopupFullName").val() == "") {
        $("#PopupFullName").addClass("errorClass");
        flag = false;
    }

    if ($("#PopupCompanyName").val() == "") {
        $("#PopupCompanyName").addClass("errorClass");
        flag = false;
    }

    if ($("#PopupPhoneNo").val() == "") {
        $("#PopupPhoneNo").addClass("errorClass");
        flag = false;
    }

    if ($("#PopupEmailAddress").val() == "") {
        $("#PopupEmailAddress").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupISD").val() == "") {
        $("#PopupISD").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupDesignation").val() == "") {
        $("#PopupDesignation").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupDetails").val() == "") {
        $("#PopupDetails").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupddlCountry")[0].selectedIndex == 0) {
        $("#PopupddlCountry").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupddlBusiness")[0].selectedIndex == 0) {
        $("#PopupddlBusiness").addClass("errorClass");
        flag = false;
    }
    var validemail = true;
    if ($("#PopupEmailAddress").val() != "") {
        var email = $("#PopupEmailAddress").val();
        validemail = isEmail(email);
    }

    if (validemail == false && flag == false) {
        $("#Popupspnerrormessage").css("display", "block");
        $("#Popupspnemailmessage").css("display", "block");
    }
    else if (validemail == false) {
        flag = false;
        $("#Popupspnemailmessage").css("display", "block");
    }
    else if (flag == false) {
        $("#Popupspnerrormessage").css("display", "block");
    }

    var requesttype = window.location.href;
    requesttype = requesttype.split('/');
    $("#PopupRequestType").val(requesttype[requesttype.length - 1]);
    return flag;

}




