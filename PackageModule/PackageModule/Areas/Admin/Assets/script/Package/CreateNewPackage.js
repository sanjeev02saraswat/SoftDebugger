$(document).ready(function () {

    $("li").removeClass("active");
    $("#CreateNewPackageli").addClass("active");
});

var LanguageList = [];
var app = angular.module('CreateNewPackageapp', ['ejangular']).controller('CreateNewPackagecontroller', function ($scope, $http) {
    $scope.selectedCountries = [];
  
    $scope.PackageDetails = {

    }
    $scope.HideShowProvider = function (showdiv, hidediv, STEP1) {
        var validate = true;
        if (STEP1 == "STEP1") {
           validate=  ValidateStep1();
        } else if (STEP1 == "STEP2") {
            //validate = ValidateStep2();
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
        debugger;
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:2849/Package/CreateNewPackage",
            data: JSON.stringify(data)
        }).then(function (success) {
            debugger;
            alert(success.data);
        }, function (error) {
            debugger;
            alert(error.data);
        });
    }
    $scope.dataList = LanguageList;
    //$scope.nameField = { text: "languageName" };


    // Load all countries with capitals
    function getCountries() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            url: "" + $("#listenerurl").val() + "Home/GetLanguages"
        }).then(function (success) {
            LanguageList = success.data;
        }, function (error) {
            debugger;
            alert(error.data);
        });

    };
    function getPackageCode() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            url: "" + $("#listenerurl").val() + "Package/GetPackageCode"
        }).then(function (success) {
            $("#PackageCode").val(success.data);
        }, function (error) {
            debugger;
            alert(error.data);
        });

    };
    getPackageCode();
    getCountries();

});


$('#PackageLanguage').ejAutocomplete({
    change: "showCurrentSearch",enableRTL:true,highlightSearch:true,
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
    if ($("#PackageTitle").val()=="") {
        $("#PackageTitle").addClass("errorClass");
        status = false;
    }

    if ($("#PackageName").val() == "") {
        $("#PackageName").addClass("errorClass");
        status = false;
    }

    //if ($("#PackageCode").val() == "") {
    //    $("#PackageCode").addClass("errorClass");
    //}

    if ($("#PackageLanguage").val() == "") {
        $("#PackageLanguage").addClass("errorClass");
        status = false;
    }
    return status;

    
}




//remove error class from controls


