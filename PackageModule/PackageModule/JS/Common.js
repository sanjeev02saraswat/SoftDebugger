//This function will call when session or Token will finish
function SessionEndManager() {
    window.location.href = "/Admin/Home/Signup";
}
//this function will check textbox blank value
function BlankChecker(IDCollection) {
    
    var status = true;
    for (var i = 0; i < IDCollection.length; i++) {
        if ($("#" + IDCollection[i]).val() == "") {
            status = false;
            $("#" + IDCollection[i]).addClass("errorClass");
        }
    }
    return status;
}


$('html').click(function (e) {
    
    if ($(e.target).hasClass('btn-block') || $(e.target).hasClass('button-block')) {
        return;
    }
    $("#spnValidationError").css("display", "none");
    $("#spnSignUPValidationError").css("display", "none");
    $('input').removeClass('errorClass');
});


function GetLanguageName(LanguageCode, LanguageList) {
    if (LanguageList != null) {
        for (var i = 0; i < LanguageList.length; i++) {
            if (LanguageCode == LanguageList[i].languageCode) {
                return LanguageList[i].languageName;
            }
        }
       
    }

}
//this function will return to JSOn object of resource files and blanck in case of empty resources

function GetParseResources(elementID) {
    if ($("#" + elementID).val() == "") {
        return [];
    }
 return JSON.parse($("#" + elementID).val())
}

$(document).ready(function () {

    $("#ChildMinAge,#ChildMaxAge,#PackageLastPaymentDue,#PackageDuration,#PackagePaymentCutOffDay,#PopupISD2,#PopupISD3,#PopupPhoneNo1,#PopupPhoneNo2,#PopupPhoneNo3").keydown(function (e) {
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
});