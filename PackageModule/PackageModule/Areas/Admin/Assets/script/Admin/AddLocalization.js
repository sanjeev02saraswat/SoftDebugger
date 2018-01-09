
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
    $scope.Localization = GetParseResources("hdnResources");
    $scope.AddLocalization = {
        ApplicationName: '',
        ApplicationID:'',
        PageID: '',
        PageName: '',
        LanguageCode: '',
        LanguageName:'',
        ResourceID: '',
        ResourceValue: '',
        CompanyID: '' + $("#CompanyID").val() + ''

    };
    $scope.AddNewResource = function () {
        debugger;
        var validate = true;        
        var IDcollection = ['ResourceID', 'ResourceValue'];
        validate = ScopeBlankChecker($scope.AddLocalization, IDcollection)
        if (validate) {
            $http({
                method: "post",
                contentType: "application/json; charset=utf-8",
                headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
                url: "http://localhost:2849/Localization/AddNewResource",
                data: JSON.stringify($scope.AddLocalization)
            }).then(function (success) {
                if (success.data==true) {
                    alert($scope.Localization.RecordExistKey);
                } else {
                    alert($scope.Localization.RecordAlreadyExist);
                }
                $scope.AddLocalization.ResourceID = '';
                $scope.AddLocalization.ResourceValue = '';
                
            }, function (error) {
                if (error.status == 401) {
                    SessionEndManager();
                }
            });
        }
    }
    $scope.HideShowProvider = function (showdiv, hidediv, STEP1) {
        var validate = true;
        if (STEP1 == "STEP1") {           
            var IDcollection = ['ApplicationID'];
            validate = ScopeBlankChecker($scope.AddLocalization, IDcollection)
            if (validate) {
                getPages();
            }
        } else if (STEP1 == "STEP2") {
            var IDcollection = ['PageName'];
            validate = ScopeBlankChecker($scope.AddLocalization, IDcollection)
            if (validate) {
                getLanguage();
            }
        } else if (STEP1 == "STEP3") {
            var IDcollection = ['LanguageCode'];
            validate = ScopeBlankChecker($scope.AddLocalization, IDcollection)
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
    function getApplication() {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Localization/GetApplications?CompanyID=" + $("#CompanyID").val() + ""
        }).then(function (success) {
            
            ApplicationList = JSON.parse(success.data);
          
        }, function (error) {
            
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
            if ($("#PageName").val() == PageList[i].PageName) {
                $scope.AddLocalization.PageID = PageList[i].PageID;
            }
        }
    }
    $scope.AddLanguageCode = function () {

        for (var i = 0; i < LanguageList.length; i++) {
            if ($("#PackageLanguage").val() == LanguageList[i].languageName) {
                $scope.AddLocalization.LanguageCode = LanguageList[i].languageCode;
                $scope.AddLocalization.LanguageName = LanguageList[i].languageName;
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

$('#PackageLanguage').ejAutocomplete({
    change: "showLanguageSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "languageCode", key: "languageName" }

})



function showLanguageSearch(args) {

    var data = $("#PackageLanguage").ejAutocomplete("instance");
    if (LanguageList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(LanguageList));
        data._doneRemaining();
        args.model.dataSource = LanguageList;
    }
}


$('#PageName').ejAutocomplete({
    change: "showPagesSearch", enableRTL: false, highlightSearch: true,
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
