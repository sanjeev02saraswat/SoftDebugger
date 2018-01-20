var LocalizationResources = [];
$(document).ready(function () {
    $("#PackageBookingEndDate").datepicker({
        dateFormat: "yy-mm-dd",
        closeText: "Close",
        changeYear: true,
        changeMonth: true,
        autoSize: true,
        onSelect: function (selected) {
            $("#PackageBookingStartDate").datepicker("option", "maxDate", selected);
            $("#PackageValidityEndDate").datepicker("option", "minDate", selected);
        }

    });

    $("#PackageBookingStartDate").datepicker({
        numberOfMonths: 2,
        dateFormat: "yy-mm-dd",
        closeText: "Close",
        changeYear: false,
        changeMonth: false,
        autoSize: true,
        minDate: new Date(),
        onSelect: function (selected) {
            $("#PackageBookingEndDate").datepicker("option", "minDate", selected)
        }

    });

    $("#PackageValidityStartDate").datepicker({
        numberOfMonths: 2,
        dateFormat: "yy-mm-dd",
        closeText: "Close",
        changeYear: false,
        changeMonth: false,
        autoSize: true,
        minDate: new Date(),
        onSelect: function (selected) {
            $("#PackageValidityEndDate").datepicker("option", "minDate", selected)
        }

    });



    $("#PackageValidityEndDate").datepicker({
        numberOfMonths: 2,
        dateFormat: "yy-mm-dd",
        closeText: "Close",
        changeYear: false,
        changeMonth: false,
        autoSize: true,
            onSelect: function(selected) {
                $("#PackageValidityStartDate").datepicker("option", "maxDate", selected)
            }

    });
    $("li").removeClass("active");
    $("#CreateNewPackageli").addClass("active");
    $("#removeattachment").click(function () {
        //Do stuff when clicked
        RemoveImageTile();

    });
    $("#PackageLanguage").change(function () {
        for (var i = 0; i < LanguageList.length; i++) {
            if ($("#PackageLanguage").val() == LanguageList[i].languageName) {
                $("#hdnPackageLanguage").val(LanguageList[i].languageCode);
            }
        }
        $("#hdnPackageLanguage").change();
    });
    $("#crmfileattach").on('change', function () {

        var view = false;
        var filename = $("#crmfileattach")[0].files[0].name;
        fileExtension = filename.split('.').pop();
        if (fileExtension == "jpg" || fileExtension == "png" || fileExtension == "PNG" || fileExtension == "gif") {
            view = true;
        }
        if (typeof (FileReader) != "undefined" && view) {

            var image_holder = $("#image-holder");
            image_holder.empty();

            var reader = new FileReader();
            reader.onload = function (e) {
                $("<img />", {
                    "src": e.target.result,
                    "class": "thumb-image",
                    "height": "200",
                    "width": "200"
                }).appendTo(image_holder);

            }
            image_holder.show();
            reader.readAsDataURL($(this)[0].files[0]);
            $("#removeattachment").css("display", "block");
        } else {
            var image_holder = $("#image-holder");
            image_holder.empty();
            $("#removeattachment").css("display", "none");
        }
    });
    LocalizationResources = GetParseResources("hdnResources");
});

var LanguageList = [];
var app = angular.module('CreateNewPackageapp', ['ejangular']).controller('CreateNewPackagecontroller', function ($scope, $http) {
    $scope.selectedCountries = [];
    $scope.Localization = GetParseResources("hdnResources");
    $scope.PackageDetails = {
        CompanyID: '' + $("#CompanyID").val() + ''
    }
    $scope.HideShowProvider = function (showdiv, hidediv, STEP1) {
        var validate = true;
        if (STEP1 == "STEP1") {
            validate = ValidateStep1();
        } else if (STEP1 == "STEP2") {
            validate = ValidateStep2();
            if (validate) {
                this.SavePackage(this.PackageDetails);
            }
        }
        if (validate) {
            $("#" + showdiv).css("display", "block");
            $("#" + hidediv).css("display", "none");
        } else {
            return false;
        }
    }
    $scope.PackageDetails.BasicPackageDetails = {
        PackageCode: '',
        PackageName: '',
        PackageLanguage: '',
        PackageTitle: '',
        PackageMarket: '',
        PackageDuration: '',//it will be in Days
        PackageSupplier: '',
        PackageType: ''

    };

    //$scope.PackageDetails.CancellationPolicy = {
    //    CancellationPolicyText: ''

    //};

    $scope.PackageDetails.BasicPackageCreteria = {
        PackageMarket: '',
        PackageSaleMarket: '',
        PackageValidityStartDate: '',
        PackageValidityEndDate: '',
        PackageBookingStartDate: '',
        PackageBookingEndDate: '',//it will be in Days
        PackageDuration: '',
        ChildMinAge: '',
        ChildMaxAge: '',
        PackageLastPaymentDue: '',
        PackagePaymentCutOffDay: '',
        DiscountonFullPayment: ''

    };
  
    $scope.SavePackage = function (data) {
        data.BasicPackageDetails.PackageCode = $("#PackageCode").val();
        data.BasicPackageDetails.PackageLanguage = $("#hdnPackageLanguage").val();
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/CreateNewPackage",
            data: JSON.stringify(data)
        }).then(function (success) {
            alert('Package create successfully.');
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }
 
    $scope.SaveCancellationPolicy = function (data) {
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/InsertPackageCancellationPolicy",
            data: JSON.stringify(data)
        }).then(function (success) {
            alert('Package cancellation policy saved successfully.');
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }
    $scope.dataList = LanguageList;
    //$scope.nameField = { text: "languageName" };


    // Load all countries with capitals
    function getCountries() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetLanguages"
        }).then(function (success) {
            LanguageList = success.data;
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };
    function getPackageCode() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/GetPackageCode"
        }).then(function (success) {

            $("#PackageCode").val(success.data);
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };
    getPackageCode();
    getCountries();

});


$('#PackageLanguage').ejAutocomplete({
    change: "showCurrentSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "languageCode", key: "languageName" }

})


function showCurrentSearch(args) {

    var data = $("#PackageLanguage").ejAutocomplete("instance");
    if (LanguageList.length > 0)
        data.suggestionListItems = JSON.parse(JSON.stringify(LanguageList));
    data._doneRemaining();
    args.model.dataSource = LanguageList;
}

//Validation Logic

function ValidateStep1() {
    var status = true;
    var IDCollection = ['PackageTitle', 'PackageName', 'PackageLanguage'];
    status = BlankChecker(IDCollection);
    return status;


}


function ValidateStep2() {
    var status = true;
    if ($("#PackageMarket")[0].selectedIndex == 0) {
        $("#PackageMarket").addClass("errorClass");
        status = false;
    }
    if ($("#PackageSaleMarket")[0].selectedIndex == 0) {
        $("#PackageSaleMarket").addClass("errorClass");
        status = false;
    }
    var IDCollection = ['PackageValidityStartDate', 'PackageValidityEndDate', 'PackageBookingStartDate', 'PackageBookingEndDate', 'PackageDuration', 'ChildMinAge', 'ChildMaxAge', 'PackageLastPaymentDue', 'PackagePaymentCutOffDay', 'DiscountonFullPayment'];
    status = BlankChecker(IDCollection);
    return status;
}

//remove error class from controls

//Package Images Content
$("#AddPackageImage").click(function () {
    var response = filesizecheck();
    if (response == false) {
        return false;
    }
    var fileData = new FormData();
    if (window.FormData !== undefined) {

        var fileUpload = $("#crmfileattach").get(0);
        var files = fileUpload.files;



        for (var i = 0; i < files.length; i++) {
            if (files[i].size) {

            }
            fileData.append("UploadedImage", files[i]);
        }
    }
    fileData.append('CompanyID', $("#CompanyID").val());
    fileData.append('Browser', $("#CompanyID").val());
    fileData.append('PackageCode', $("#PackageCode").val());
    fileData.append('PackageImageName', $("#ImageName").val());
    fileData.append('PackageImageTitle', $("#ImageTitle").val());

    $.ajax({
        type: "POST",
        headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
        url: "" + $("#listenerurl").val() + "Package/UploadPackageImage",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (response) {           
                alert('Image Uploaded Successfully...');
                RemoveImageTile();
                GetPackageImages();
           
        },
        error: function (response) {
            if (response.status == 401) {
                SessionEndManager();
            }
        }

    });
});



$("#crmfileattach").change(function () {
    filesizecheck();

});

function RemoveImageTile() {
    $("#removeattachment").css("display", "none");
    $("#filesize").val('');
    $("#crmfileattach").length = 0;
    var image_holder = $("#image-holder");
    image_holder.empty();
}

function SetDefaultImage(imagename) {
    debugger;
    var data = {
        PackageVirtualImage: true,
        PackageImageName: imagename,
        CompanyID: "" + $("#CompanyID").val() + "",
        PackageCode: "" + $("#PackageCode").val() + ""
    }

    $.ajax({
        type: "POST",
        headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
        url: "" + $("#listenerurl").val() + "Package/SetDefaultVirtualImage",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function (response) {
            alert('Package Default Image selected successfully.');
            GetPackageImages();
        },
        error: function (response) {
            if (response.status == 401) {
                SessionEndManager();
            }
        }

    });

}

function filesizecheck() {
    if (window.FormData !== undefined) {

        var fileUpload = $("#crmfileattach").get(0);
        var files = fileUpload.files;
        for (var i = 0; i < files.length; i++) {

            var iSize = ($("#crmfileattach")[0].files[0].size / 1024);
            var chksize = iSize;
            var filename = $("#crmfileattach")[0].files[0].name;
            if (iSize / 1024 > 1) {
                if (((iSize / 1024) / 1024) > 1) {
                    iSize = (Math.round(((iSize / 1024) / 1024) * 100) / 100);
                    $("#filesize").val(filename + "(" + iSize + "Gb)");
                }
                else {
                    iSize = (Math.round((iSize / 1024) * 100) / 100)
                    $("#filesize").val(filename + "(" + iSize + "Mb)");
                }
            }
            else {
                iSize = (Math.round(iSize * 100) / 100)
                $("#filesize").val(filename + "(" + iSize + "Kb)");
            }
            chksize = (Math.round((chksize / 1024) * 100) / 100)
            if (chksize > 2) {
                $("#servermessage").css("display", "block");
                $("#servermessage").text("File size is too large.you can select up too 2 Mb.");
                $("#servermessage").css("color", "red");
                return false;
            } else {
                $(".remove").css("display", "block");
                $(".remove1").css("display", "block");
            }
        }
    }
    return true;
}

function GetPackageImages() {

    $.ajax({
        type: "GET",
        headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
        url: "" + $("#listenerurl").val() + "Package/GetPackageImages?PackageCode=" + $("#PackageCode").val() + "&CompanyID=" + $("#CompanyID").val() + "&PackageLanguage=" + $("#hdnPackageLanguage").val() + "",
        contentType: "application/json; charset=utf-8",

        success: function (response) {
            var image_holder = "";
            
            if (response != null && response.length > 0) {
                var divcnt = 0;
                for (var i = 0; i < response.length; i++) {
                    divcnt++;

                    image_holder += "<div class='col-sm-3 col-md-3 col-lg-3'>";
                    image_holder += "<a href='" + $("#listenerurl").val() + "/PackageImages/" + $("#CompanyID").val() + "/" + $("#PackageCode").val() + "/" + response[i].packageImageName + "' download><img src= '" + $("#listenerurl").val() + "/PackageImages/" + $("#CompanyID").val() + "/" + $("#PackageCode").val() + "/" + response[i].packageImageName + "' title='" + response[i].packageImageTitle + "' class='thumb-image'/></a>";
                    if (!response[i].packageVirtualImage) {
                        image_holder += "<input style='margin-top:10px;' type='button' class='Defaultimageselector' onClick='SetDefaultImage(\"" + response[i].packageImageName + "\")' value='DefaultImage'>";
                        image_holder += "<input style='margin-top:10px;' type='button' class='Defaultimageselector' onClick='DeletePackageImage(\"" + response[i].packageImageName + "\")' value='Delete Image'></div>";
                    } else {
                        image_holder += "<span style='margin-top:10px;color:green'>This is your Default Image</span>";
                        image_holder += "<input style='margin-top:10px;' type='button' class='Defaultimageselector' onClick='DeletePackageImage(\"" + response[i].packageImageName + "\")' value='Delete Image'></div>";
                    }
                    image_holder += "</div>";
                }
                $("#preattach").css("display", "block");
                $("#preattach").html(image_holder);
                if (image_holder != "") {
                    $("#preattachparent").css("display", "block");
                }
            }
            else if (response == "" && response.status != 401) {
                $("#preattach").css("display", "none");
                $("#preattach").html("");
            }
            else if (response.status == 401) {
                SessionEndManager();
            }

        },
        error: function (response) {
            SessionEndManager();
        }

    });

}

//for existing or update ticket

//$(function () {
//    //$(".is-empty, .form-control").addClass("is-focused");

//})
//$body = $("body");
//$(document).on({
//    ajaxStart: function () { $body.addClass("loading"); },
//    ajaxStop: function () { $body.removeClass("loading"); }
//});

//$(function () {
//    var ObjLogInDto = new Object();
//    ObjLogInDto.TicketNumber = 'TIX-03251-F2Q6';
//    var StringifiedData = JSON.stringify(ObjLogInDto);
//    $body.addClass("loading");
//    $.ajax({
//        url: '/QuadLabsTicketRepository/Home/GetExistingticket',
//        async: true,
//        type: "POST",
//        data: StringifiedData,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            debugger;
//            $body.removeClass("loading");
//            if (response == "session expired") {
//                $("#servermessage").css("display", "block");
//                $("#servermessage").text("Dear user,Your Session has been expired.we are redirecting to you on login.Please be patience.QuadLabs");
//                $("#servermessage").css("color", "Green");
//                setTimeout(
//function () {
//    window.location.href = "/QuadLabsTicketRepository/Home/Login";
//}, 5000);

//            } else {
//                var data = JSON.parse(response);
//                $("#spnTicketNumber").html("<b style='font-size:20px;'>Ticket Number: " + data.ticketnumber + "</b>");
//                $("#ticketTitle").val(data.Title);
//                $("#casetypecode").val(data.casetypecode);
//                $("#severitycode").val(data.severitycode);
//                $("#crmDescription").val(data.description);
//                $("#hdnincidentcode").val(data.incidentid);
//                $("#ticketstatus").val(data.status);
//                if (data.status == 1) {
//                    $("#submitarea").css("display", "none");
//                    $("#attachmentarea").css("display", "none");
//                    $("#ticketstatus").css("disabled", true);
//                    $("#ClosedTicketArea").css("display", "block");
//                    $(".crmRemarkdiv").css("display", "none");
//                } else {
//                    var image_holder = "";
//                    for (var i = 0; i < data.AnnotationData.length; i++) {
//                        var view = false;
//                        //if (data.AnnotationData[i].notetext!=null) {
//                        //    $("#crmDescription").val($("#crmDescription").val() + "<br>" + data.AnnotationData[i].notetext)
//                        //}

//                        var filename = data.AnnotationData[i].filename;
//                        if (filename != null) {
//                            fileExtension = filename.split('.').pop();
//                            if (fileExtension == "jpg" || fileExtension == "png" || fileExtension == "PNG" || fileExtension == "gif") {
//                                view = true;
//                            }
//                            if (typeof (FileReader) != "undefined" && view) {

//                                image_holder += "<div id='" + filename + "' class='attachment_listing'> ";//$("#image-holder");</div>
//                                //image_holder.empty();

//                                image_holder += "<a href='/Areas/QuadLabsTicketRepository/Assets/Downloads/" + data.incidentid + "/" + data.ticketnumber + "/" + filename + "' download><img src= '/Areas/QuadLabsTicketRepository/Assets/Downloads/" + data.incidentid + "/" + data.ticketnumber + "/" + filename + "' class='thumb-image'/></a></div>";
//                                //reader.onload = function (e) {
//                                //    $("<img />", {
//                                //        "src": e.target.result,
//                                //        "class": "thumb-image",
//                                //        "height": "200",
//                                //        "width": "200"
//                                //    }).appendTo(image_holder);
//                                //    image_holder +='<img src="/Areas/QuadLabsTicketRepository/Assets/Downloads/'+data.sessionid+'/'+filename+'/>';
//                                //}
//                                // image_holder.show();
//                                // reader.readAsDataURL($(this)[0].files[0]);

//                                $("#preattach").css("display", "block");
//                            } else {
//                                image_holder += "<div id='" + filename + "' class='attachment_listing'> ";
//                                image_holder += "<a href='/Areas/QuadLabsTicketRepository/Assets/Downloads/" + data.sessionid + "/" + data.ticketnumber + "/" + filename + "' download> <img border='0' src= '/Areas/QuadLabsTicketRepository/Assets/Image/Common/downloadicon.jpg' alt='" + filename + "' class='thumb-image'/></a></div>";
//                                //<a href="/images/myw3schoolsimage.jpg" download>
//                                //<img border="0" src="/images/myw3schoolsimage.jpg" alt="W3Schools" width="104" height="142">
//                            }
//                        }

//                    }
//                    $("#preattach").html(image_holder);
//                    if (image_holder != "") {
//                        $("#preattachparent").css("display", "block");
//                    }



//                }
//            }
//        },
//        error: function (response) {
//            $body.removeClass("loading");
//            if (response == "session expired") {
//                $("#servermessage").css("display", "block");
//                $("#servermessage").text("Dear user,Your Session has been expired.we are redirecting to you on login.Please be patience.QuadLabs");
//                $("#servermessage").css("color", "Green");
//                setTimeout(
//function () {
//    window.location.href = "/QuadLabsTicketRepository/Home/Login";
//}, 5000);

//            }
//        }

//    });
//});


//$("#removeattachment").click(function () {
//    //Do stuff when clicked
//    $("#removeattachment").css("display", "none");
//    $("#filesize").val('');
//    $("#crmfileattach").length = 0;
//    var image_holder = $("#image-holder");
//    image_holder.empty();

//});


//$("#btnsubmit").click(function () {
//    var response = filesizecheck();
//    if (response == false) {
//        return false;
//    }
//    var ObjLogInDto = new Object();
//    var fileData = new FormData();
//    if (window.FormData !== undefined) {

//        var fileUpload = $("#crmfileattach").get(0);
//        var files = fileUpload.files;



//        for (var i = 0; i < files.length; i++) {
//            fileData.append(files[i].name, files[i]);
//        }
//    }
//    fileData.append('crmRemark', $("#crmRemark").val());
//    fileData.append('title', $("#ticketTitle").val());
//    fileData.append('description', $("#crmDescription").val());
//    fileData.append('severitycode', $("#severitycode").val());
//    fileData.append('casetypecode', $("#casetypecode").val());
//    fileData.append('incidentid', $("#hdnincidentcode").val());
//    fileData.append('ticketnumber', $("#hdnticketnumber").val());
//    fileData.append('status', $("#ticketstatus").val());
//    $body.addClass("loading");
//    //  ObjLogInDto.companyname = "quadlabs";//$("#companyname").val();crmRemark

//    //   ObjLogInDto.title = $("#ticketTitle").val();
//    // ObjLogInDto.accountidname = "quadlabs";// $("#accountidname").val();
//    //  ObjLogInDto.description = $("#crmDescription").val();
//    //  ObjLogInDto.severitycode = $("#severitycode").val();
//    // ObjLogInDto.casetypecode = $("#casetypecode").val();
//    //ObjLogInDto.incidentid = $("#hdnincidentcode").val();//ticketnumber
//    //ObjLogInDto.ticketnumber = $("#hdnticketnumber").val()
//    //ObjLogInDto.status = $("#ticketstatus").val()

//    // var StringifiedData = JSON.stringify(ObjLogInDto)
//    $.ajax({
//        url: '/QuadLabsTicketRepository/Home/UpdateTicket',
//        type: "POST",
//        contentType: false, // Not to set any content header
//        processData: false, // Not to process data
//        data: fileData,
//        //type: "POST",
//        //data: fileData,
//        dataType: "json",
//        //contentType: "application/json; charset=utf-8",
//        success: function (response) {
//            $body.removeClass("loading");
//            if ($("#ticketstatus").val() == 1) {
//                $("#submitarea").css("display", "none");
//                $("#attachmentarea").css("display", "none");
//                $("#ticketstatus").css("disabled", true);
//            }
//            $("#servermessage").css("display", "block");
//            $("#servermessage").text(response.statusText);
//            $("#servermessage").css("color", "green");

//        },
//        error: function (response) {
//            $body.removeClass("loading");
//            if (response.statusText == "session expired") {

//                $("#servermessage").css("display", "block");
//                $("#servermessage").text("Dear user,Your Session has been expired.we are redirecting to you on login.Please be patience.QuadLabs");
//                $("#servermessage").css("color", "Red");
//                setTimeout(
//function () {
//    window.location.href = "/QuadLabsTicketRepository/Home/Login";
//}, 5000);

//            } else {
//                if ($("#ticketstatus").val() == 1) {
//                    $("#submitarea").css("display", "none");
//                    $("#attachmentarea").css("display", "none");
//                    $("#ticketstatus").css("disabled", true);
//                    $("#ClosedTicketArea").css("display", "block");
//                }
//                $("#servermessage").css("display", "block");
//                $("#servermessage").text(response.statusText);
//                $("#servermessage").css("color", "Green");
//            }
//        }

//    });
//});

//$("#crmfileattach").change(function () {
//    filesizecheck();

//});
//$("#crmfileattach").on('change', function () {

//    var view = false;
//    var filename = $("#crmfileattach")[0].files[0].name;
//    fileExtension = filename.split('.').pop();
//    if (fileExtension == "jpg" || fileExtension == "png" || fileExtension == "PNG" || fileExtension == "gif") {
//        view = true;
//    }
//    if (typeof (FileReader) != "undefined" && view) {

//        var image_holder = $("#image-holder");
//        image_holder.empty();

//        var reader = new FileReader();
//        reader.onload = function (e) {
//            $("<img />", {
//                "src": e.target.result,
//                "class": "thumb-image",
//                "height": "200",
//                "width": "200"
//            }).appendTo(image_holder);

//        }
//        image_holder.show();
//        reader.readAsDataURL($(this)[0].files[0]);
//        $("#removeattachment").css("display", "block");
//    } else {
//        var image_holder = $("#image-holder");
//        image_holder.empty();
//        $("#removeattachment").css("display", "none");
//    }
//});

//function filesizecheck() {
//    if (window.FormData !== undefined) {

//        var fileUpload = $("#crmfileattach").get(0);
//        var files = fileUpload.files;
//        for (var i = 0; i < files.length; i++) {
//            var iSize = ($("#crmfileattach")[0].files[0].size / 1024);
//            var chksize = iSize;
//            var filename = $("#crmfileattach")[0].files[0].name;
//            if (iSize / 1024 > 1) {
//                if (((iSize / 1024) / 1024) > 1) {
//                    iSize = (Math.round(((iSize / 1024) / 1024) * 100) / 100);
//                    $("#filesize").val(filename + "(" + iSize + "Gb)");
//                }
//                else {
//                    iSize = (Math.round((iSize / 1024) * 100) / 100)
//                    $("#filesize").val(filename + "(" + iSize + "Mb)");
//                }
//            }
//            else {
//                iSize = (Math.round(iSize * 100) / 100)
//                $("#filesize").val(filename + "(" + iSize + "Kb)");
//            }
//            chksize = (Math.round((chksize / 1024) * 100) / 100)
//            if (chksize > 2) {
//                $("#servermessage").css("display", "block");
//                $("#servermessage").text("File size is too large.you can select up too 2 Mb.");
//                $("#servermessage").css("color", "red");
//                return false;
//            }
//        }
//    }
//    return true;
//}


//$('html').click(function () {
//    $("#servermessage").css("display", "none");
//});
//$("#btncancel,#btnClosedcancel").click(function () {
//    var type = 'Active'
//    window.location.href = "/QuadLabsTicketRepository/Home/Index?type=" + type;
//});