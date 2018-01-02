
var LanguageList = [];
var ApplicationList = [];
var PageList = [];

var app = angular.module('AddLocalizationApp', ['ejangular']).controller('CreateNewLocalizationcontroller', function ($scope, $http) {

    $scope.modelvalidator = {
        PackageCode: '',
        hdnSelectLanguage: ''
    }
    $scope.Resourcemodel = {
        hdnResources:''
    }
    debugger;
    $scope.Localization = JSON.parse($("#hdnResources").val());
    $scope.AddLocalization = {
        ApplicationName: '',
        ApplicationID:'',
        PageID: '',
        PageName: '',
        LanguageCode: '',
        ResourceID: '',
        ResourceValue:''

    };

    $scope.HideShowProvider = function (showdiv, hidediv, STEP1) {
        var validate = true;
        if (STEP1 == "STEP1") {
            if ($scope.AddLocalization.ApplicationID == "") {
                validate = false;
            }
            if (validate) {
                getPages();
            }
        } else if (STEP1 == "STEP2") {
            if ($scope.AddLocalization.PageID == "") {
                validate = false;
            }
        }
        if (validate) {
            $("#" + showdiv).css("display", "block");
            $("#" + hidediv).css("display", "none");
        } else {
            return false;
        }
    }

    function getPages() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Localization/GetPageList?CompanyID=" + $("#CompanyID").val() + "&ApplicationID="+$scope.AddLocalization.ApplicationID+""
        }).then(function (success) {
            debugger;
            PageList = JSON.parse(success.data);

        }, function (error) {
            debugger;
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };

    function getApplication() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Localization/GetApplications?CompanyID=" + $("#CompanyID").val() + ""
        }).then(function (success) {
            debugger;
            ApplicationList = JSON.parse(success.data);
          
        }, function (error) {
            debugger;
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };
    $scope.AddApplicationID = function () {
        
        for (var i = 0; i < ApplicationList.length; i++) {
            if ($("#ApplicationName").val() == ApplicationList[i].ApplicationName) {
                $scope.AddLocalization.ApplicationID = ApplicationList[i].ApplicationID;
            }
        }
    }

    $scope.AddPageID = function () {

        for (var i = 0; i < PageList.length; i++) {
            if ($("#ApplicationName").val() == PageList[i].PageName) {
                $scope.AddLocalization.PageID = PageList[i].PageID;
            }
        }
    }
    $scope.applicationList = ApplicationList;
    $scope.pageList = PageList;
    $scope.dataList = LanguageList;
    getApplication();

});
$('#ApplicationName').ejAutocomplete({
    change: "showApplicationSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "ApplicationID", key: "ApplicationName" }

})



function showApplicationSearch(args) {

    var data = $("#ApplicationName").ejAutocomplete("instance");
    if (ApplicationList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(ApplicationList));
        data._doneRemaining();
        args.model.dataSource = ApplicationList;
    }
}

$('#PageName').ejAutocomplete({
    change: "showApplicationSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "PageID", key: "PageName" }

})



function showPagesSearch(args) {

    var data = $("#PageName").ejAutocomplete("instance");
    if (PageList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(PageList));
        data._doneRemaining();
        args.model.dataSource = PageList;
    }
}
