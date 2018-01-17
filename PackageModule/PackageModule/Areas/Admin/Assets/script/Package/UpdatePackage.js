var LanguageList = [];
var PackageList = [];
var PackageFilterModel = [];
$(document).ready(function () {
    $("#PackageValidityStartDate,#PackageValidityEndDate,#PackageBookingStartDate,#PackageBookingEndDate").datepicker({
        dateFormat: "yy-mm-dd",
        closeText: "Close"
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

});


var app = angular.module('CreateNewPackageapp', ['ejangular']).controller('CreateNewPackagecontroller', function ($scope, $http) {
    $scope.selectedCountries = [];
    //modelvalidator
    $scope.modelvalidator = {
        PackageCode:'',
        hdnSelectLanguage:''
    }
    //end validator
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
                GetPackageImages();
            }
        }
        if (validate) {
            $("#" + showdiv).css("display", "block");
            $("#" + hidediv).css("display", "none");
        } else {
            return false;
        }
    }
    $scope.FilterModel = {
        PackageCode: '',
        PackageName: '',
        PackageLanguage: '',
        CompanyID:''    

    };

    $scope.PackageDetails.BasicPackageDetails = {
        PackageCode: '',
        PackageName: '',
        PackageLanguage: '',
        PackageTitle: '',
        PackageDuration: '',//it will be in Days
        PackageSupplier: '',
        PackageType: ''

    };
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
    //debugger;
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
            alert('Package basic info has been updated successfully.');
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
    $scope.packageList = PackageList;
    //$scope.nameField = { text: "languageName" };

    $scope.SearchFilteredPackage = function (data) {
        data.PackageCode = $("#SelectPackageCode").val();
        data.PackageLanguage = $("#hdnSelectLanguage").val();
        data.CompanyID = $("#CompanyID").val();
        if (data.PackageLanguage == "") {
            $scope.modelvalidator = [];
            $scope.modelvalidator.hdnSelectLanguage = "Kindly select language first.";
            return false;
        } else if (data.PackageCode == "") {
            $scope.modelvalidator = [];
            $scope.modelvalidator.PackageCode = "Kindly select package code or name atleast.";
            return false;
        
        }else {
            $scope.modelvalidator = [];
        }
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/GetPackageDetail",
            data: JSON.stringify(data)
        }).then(function (success) {
        
            var PackageData = JSON.parse(success.data);
            $scope.PackageDetails.BasicPackageDetails = PackageData.BasicPackageDetails[0];
            $("#PackageLanguage").val(GetLanguageName(PackageData.BasicPackageDetails[0].PackageLanguage, LanguageList));
            $("#hdnSelectLanguage").val(PackageData.BasicPackageDetails[0].PackageLanguage);
            $scope.PackageDetails.BasicPackageCreteria = PackageData.BasicPackageCreteria[0];
            $scope.PackageDetails.PackageCancellationPolicy = PackageData.PackageCancellationPolicy[0];
            $("#PackageLanguage").attr("readonly","readonly");
            $("#PackageFilter").css("display", "none"); 
            $("#basicuserdetail").css("display", "block");
            $("#PackageValidityStartDate,#PackageValidityEndDate,#PackageBookingStartDate,#PackageBookingEndDate").datepicker("setDate", "2010/12/12");

        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }

    // Load all countries with capitals
    function getLanguage() {

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
    getLanguage();

});


$('#PackageLanguage').ejAutocomplete({
    change: "showCurrentSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "languageCode", key: "languageName" }

})

function getPackages() {
    PackageFilterModel = {
        query: '' + $("#SelectPackageName").val() + '',
        CompanyID:''+$("#CompanyID").val()+'',
        PackageCode: '' + $("#SelectPackageCode").val() + '',
        PackageLanguage: '' + $("#hdnSelectLanguage").val() + ''
    }
   
    $.ajax({
        type: "POST",
        headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
        url: "" + $("#listenerurl").val() + "Package/GetPackages",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(PackageFilterModel),
        success: function (response) {
            PackageList = JSON.parse(response);

        },
        error: function (response) {
            if (response.status == 401) {
                SessionEndManager();
            }
        }
    });

};
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
            debugger;
            if (response != null && response.length > 0) {
                var divcnt = 0;
                for (var i = 0; i < response.length; i++) {
                    divcnt++;

                    image_holder += "<div class='col-sm-3 col-md-3 col-lg-3'>";
                    image_holder += "<a href='" + $("#listenerurl").val() + "/PackageImages/" + $("#CompanyID").val() + "/" + $("#PackageCode").val() + "/" + response[i].packageImageName + "' download><img src= '" + $("#listenerurl").val() + "/PackageImages/" + $("#CompanyID").val() + "/" + $("#PackageCode").val() + "/" + response[i].packageImageName + "' title='" + response[i].packageImageTitle + "' class='thumb-image'/></a></div>";
                    image_holder += "</div>";
                }
                $("#preattach").css("display", "block");
                $("#preattach").html(image_holder);
                if (image_holder != "") {
                    $("#preattachparent").css("display", "block");
                }
            }
            else if (response.status == 401) {
                SessionEndManager();
            }

        },
        error: function (response) {
            if (response.status == 401) {
                SessionEndManager();
            }
           
        }

    });

}

//for existing or update ticket



//update filter package module

$(document).ready(function () {

    $("#SelectLanguage").change(function () {
        if (LanguageList!=null) {
            for (var i = 0; i < LanguageList.length; i++) {
                if ($("#SelectLanguage").val() == LanguageList[i].languageName) {
                    $("#hdnSelectLanguage").val(LanguageList[i].languageCode);
                }
            }
            $("#hdnSelectLanguage").change();
        }
       
    });

    $("#SelectPackageName").keyup(function () {
        getPackages();

    });
    $("#SelectPackageName").change(function () {
        debugger;
        if (PackageList!=null) {
            for (var i = 0; i < PackageList.length; i++) {
                if ($("#SelectPackageName").val() == PackageList[i].PackageName) {
                    $("#SelectPackageCode").val(PackageList[i].PackageCode);
                }
            }
          //  $("#SelectPackageName").change();
        }
       
       
    });
});

$('#SelectPackageName').ejAutocomplete({
    change: "showFilteredPackageSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "PackageName", key: "PackageCode" }

})

function showFilteredPackageSearch(args) {

    var data = $("#SelectPackageName").ejAutocomplete("instance");
    if (PackageList != null && PackageList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(PackageList));
        data._doneRemaining();
        args.model.dataSource = PackageList;
    }
}

$('#SelectLanguage').ejAutocomplete({
    change: "showFilteredCurrentSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "languageName", key: "languageCode" }

})




function showFilteredCurrentSearch(args) {

    var data = $("#SelectLanguage").ejAutocomplete("instance");
   
    if (LanguageList != null && LanguageList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(LanguageList));
        data._doneRemaining();
        args.model.dataSource = LanguageList;
    }
}