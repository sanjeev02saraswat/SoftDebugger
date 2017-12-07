$(document).ready(function () {

    $("li").removeClass("active");
    $("#CreateNewPackageli").addClass("active");
});

var LanguageList = [];
var app = angular.module('CreateNewPackageapp', ['ejangular']).controller('CreateNewPackagecontroller', function ($scope, $http) {
    $scope.selectedCountries = [];
  
    $scope.BasicPackageDetails = {
        PackageCode: '',
        PackageName: '',
        PackageLanguage: '',
        PackageTitle: '',
        PackageMarket: '',
        PackageDuration: '',//it will be in Days
        PackageSupplier: '',
        PackageType: ''

    };
    $scope.BasicPackageCreteria = {
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
        PackagePaymentCutOffDate: '',
        DiscountonFullPayment: ''

    };
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

    getCountries();

});


$('#autocomplete').ejAutocomplete({
    change: "showCurrentSearch",
    fields: { text: "languageCode", key: "languageName" }

})


function showCurrentSearch(args) {
    debugger;
    var data = $("#autocomplete").ejAutocomplete("instance");
    if (LanguageList.length > 0)
        data.suggestionListItems = JSON.parse(JSON.stringify(LanguageList));
    data._doneRemaining();
    args.model.dataSource = LanguageList;
}