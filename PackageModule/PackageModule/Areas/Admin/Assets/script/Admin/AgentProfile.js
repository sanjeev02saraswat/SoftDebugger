var LanguageList = [];
var CountryList = [];

var app = angular.module('UpdateAgentApp', ['ejangular', 'ngMessages']).controller('UpdateAgentProfilecontroller', function ($scope, $http) {
    $scope.AgentDetails = {
      
    };
    $scope.Resourcemodel = {
        hdnResources: ''
    }

    $scope.ModelValidator = {
        FirstName: '',
        LastName: '',
        Email: '',
        Phone: '',
        Language: '',
        DefaultPage: '',
        Address: '',
        Country: '',

    }


    $scope.Localization = GetParseResources("hdnResources");

    $scope.GetAgentProfile= function  () {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Admin/GetAgentProfile?CompanyID=" + $("#CompanyID").val() + "&TokenID=" + $("#listenertoken").val() + ""
        }).then(function (success) {
            debugger;
            var data=JSON.parse(success.data);
            $scope.AgentDetails = data;
            if (LanguageList.length == 0) {
                getLanguage(data.Language);
            } else {
                $("#Language").val(GetLanguageName(data.Language, LanguageList));
                $("#hdnPackageLanguage").val(data.Language);
            }
            if (CountryList.length == 0) {
                getCountryList(data.Country);
            } else {
                $("#Country").val(GetCountryName(data.Country, CountryList));
                $("#hdnAgentCountry").val(data.Country);
            }
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    }
  

    $scope.UpdateAgentProfile = function () {
        debugger;
        var validate = true;
        
        validate = ScopeBlankChecker($scope.AgentDetails, $scope.ModelValidator)
       
        if (validate) {
            $http({
                method: "post",
                contentType: "application/json; charset=utf-8",
                headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
                url: "http://localhost:2849/Admin/UpdateAgentProfile",
                data: JSON.stringify($scope.AgentDetails)
            }).then(function (success) {
                alert('Agent details updated successfully.');
            }, function (error) {
                debugger;
                if (error.status == 401) {
                    SessionEndManager();
                }
            });
        }
    }

    function getLanguage(languagecode) {
       
        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetLanguages"
        }).then(function (success) {
            LanguageList = success.data;
            if (languagecode != undefined && languagecode != "") {
                debugger;
                $("#Language").val(GetLanguageName(languagecode, LanguageList));
                $("#hdnPackageLanguage").val(languagecode);
            }
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };

    function getCountryList(countrycode) {
       
        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetCountry"
        }).then(function (success) {
            CountryList = success.data;
            if (countrycode != undefined && countrycode != "") {
                debugger;
                $("#Country").val(GetCountryName(countrycode, CountryList));
                $("#hdnAgentCountry").val(countrycode);

            }
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };


    $scope.AddLanguageCode = function () {

        for (var i = 0; i < LanguageList.length; i++) {
            if ($("#Language").val() == LanguageList[i].languageName) {
                $scope.AgentDetails.Language = LanguageList[i].languageCode;
            }
        }
    }

    $scope.AddCountryCode = function () {

        for (var i = 0; i < CountryList.length; i++) {
            if ($("#Country").val() == CountryList[i].countryName) {
                $scope.AgentDetails.Country = CountryList[i].countryCode;
            }
        }
    }

    $scope.dataList = LanguageList;
    $scope.countryList = CountryList;
    getLanguage();
    getCountryList();

});


$('#Language').ejAutocomplete({
    change: "showLanguageSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "languageCode", key: "languageName" }

})



function showLanguageSearch(args) {

    var data = $("#Language").ejAutocomplete("instance");
    if (LanguageList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(LanguageList));
        data._doneRemaining();
        args.model.dataSource = LanguageList;
    }
}





$('#Country').ejAutocomplete({
    change: "showCountrySearch", enableRTL: false, highlightSearch: true,
    fields: { text: "countryCode", key: "countryName" }

})



function showCountrySearch(args) {

    var data = $("#Country").ejAutocomplete("instance");
    if (CountryList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(CountryList));
        data._doneRemaining();
        args.model.dataSource = CountryList;
    }
}
