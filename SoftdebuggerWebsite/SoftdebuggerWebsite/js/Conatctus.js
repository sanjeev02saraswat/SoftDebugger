
$(document).ready(function () {

    $("#CustomerMobile,#ISD,#PopupPhoneNo,#PopupISD,#PopupISD1,#PopupISD2,#PopupISD3,#PopupPhoneNo1,#PopupPhoneNo2,#PopupPhoneNo3").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A, Command+A
             (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
             (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }



    });

    $("#btnsubmitresult,#btnsubmitresult1").click(function (e) {
        debugger;
        //e.preventdefault();
        SaveEnquiry();
    });
});
//var ContactUsApp = angular.module("ContactUsApp", []);
//ContactUsApp.controller("ConatctUsController", ["$scope", function ($scope) {


//    $scope.InsertEnquiry = function ($scope, $http) {
//        debugger;
//        $http.post('../Home/InsertCustomerEnquiry').data($scope).then(function () {
//            alert('Inserted Successfully');
//        });
//    };

//}]);

function ValidatePopupEnquiryForm() {
    var flag = true;
    debugger;
    if ($("#CustomerName").val() == "") {
        $("#CustomerName").addClass("errorClass");
        flag = false;
    }

    if ($("#CustomerCompany").val() == "") {
        $("#CustomerCompany").addClass("errorClass");
        flag = false;
    }

    if ($("#CustomerMobile").val() == "") {
        $("#CustomerMobile").addClass("errorClass");
        flag = false;
    }

    if ($("#Email").val() == "") {
        $("#Email").addClass("errorClass");
        flag = false;
    }
    if ($("#PopupISD").val() == "") {
        $("#PopupISD").addClass("errorClass");
        flag = false;
    }
    //if ($("#PopupDesignation").val() == "") {
    //    $("#PopupDesignation").addClass("errorClass");
    //    flag = false;
    //}
    if ($("#CustomerMessage").val() == "") {
        $("#CustomerMessage").addClass("errorClass");
        flag = false;
    }
    if ($("#ddlCountry")[0].selectedIndex == 0) {
        $("#ddlCountry").addClass("errorClass");
        flag = false;
    }
    //if ($("#PopupddlBusiness")[0].selectedIndex == 0) {
    //    $("#PopupddlBusiness").addClass("errorClass");
    //    flag = false;
    //}
    var validemail = true;
    if ($("#Email").val() != "") {
        var email = $("#Email").val();
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

    //var requesttype = window.location.href;
    //requesttype = requesttype.split('/');
    //$("#PopupRequestType").val(requesttype[requesttype.length - 1]);
    return flag;

}

function isEmail(email) {
    // var regex = /^([a-zA-Z0-9_.+-])+\@@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //    var emailReg = /^([\w-\.]+@@([\w-]+\.)+[\w-]{2,8})?$/;
    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i
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
    //  $("#subscribermessage").text('');
    //  $("#enquiryConfirmationmessage").css("display", "none");
});
