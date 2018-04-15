var CurrencyList = [];
var CountryList = [];

var app = angular.module('CompanyDetailsApp', ['ejangular', 'ngMessages']).controller('AddCompanyDetailscontroller', function ($scope, $http) {
    $scope.CompanyDetails = {
      
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

    $scope.GetCompanyDetails = function () {

        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetCompanyDetails?CompanyID=" + $("#CompanyID").val() + "&TokenID=" + $("#listenertoken").val() + ""
        }).then(function (success) {
           
            var data=JSON.parse(success.data);
            $scope.CompanyDetails = data;
            
            if (CurrencyList.length == 0) {
                getCurrency(data.CurrencyCode);
            } else {
                $("#Currency").val(GetCurrencyName(data.CurrencyCode, CurrencyList));
                $("#hdnCurrencyCode").val(data.CurrencyCode);
            }
            if (CountryList.length == 0) {
                getCountryList(data.Country);
            } else {
                $("#Country").val(GetCountryName(data.Country, CountryList));
                $("#hdnCompanyCountry").val(data.Country);
            }
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    }
  

    $scope.UpdateCompanyDetails = function () {
       
        var validate = true;
        var IDcollection = ['CompanyCode', 'CompanyAddress', 'Email', 'Phone', 'Country', 'Currency', 'CompanyName'];
        validate = ScopeBlankChecker($scope.CompanyDetails, IDcollection)
       
        if (validate) {
            $scope.CompanyDetails.CompanyID = $("#CompanyID").val();
            $scope.CompanyDetails.TokenID = $("#listenertoken").val();
            $http({
                method: "post",
                contentType: "application/json; charset=utf-8",
                headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
                url: "" + $("#listenerurl").val() + "Home/UpdateCompanyDetails",
                data: JSON.stringify($scope.CompanyDetails)
            }).then(function (success) {
                $("#UpdatedCompanyDetailsMessage").removeClass("hiddenmessages");
            }, function (error) {
               
                if (error.status == 401) {
                    SessionEndManager();
                } else {
                    $("#UpdatedCompanyDetailsErrorMessage").removeClass("hiddenmessages");
                }
            });
        }
    }

    function getCurrency(currencycode) {
       
        $http({
            method: "GET",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetCurrency"
        }).then(function (success) {
            
            CurrencyList = success.data;
            if (currencycode != undefined && currencycode != "") {
                
                $("#Language").val(GetCurrencyName(currencycode, CurrencyList));
                $("#hdnPackageLanguage").val(currencycode);
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
                $("#Country").val(GetCountryName(countrycode, CountryList));
                $("#hdnAgentCountry").val(countrycode);

            }
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });

    };


    $scope.AddCurrencyCode = function () {

        for (var i = 0; i < CurrencyList.length; i++) {
            if ($("#Currency").val() == CurrencyList[i].currencyName) {
                $scope.CompanyDetails.CurrencyCode = CurrencyList[i].currencyCode;
            }
        }
    }

    $scope.AddCountryCode = function () {

        for (var i = 0; i < CountryList.length; i++) {
            if ($("#Country").val() == CountryList[i].countryName) {
                $scope.CompanyDetails.Country = CountryList[i].countryCode;
            }
        }
    }

    $scope.dataList = CurrencyList;
    $scope.countryList = CountryList;
    getCurrency();
    getCountryList();

});


$('#Currency').ejAutocomplete({
    change: "showCurrencySearch", enableRTL: false, highlightSearch: true,
    fields: { text: "currencyCode", key: "currencyName" }

})



function showCurrencySearch(args) {

    var data = $("#Currency").ejAutocomplete("instance");
    if (CurrencyList.length > 0) {
        data.suggestionListItems = JSON.parse(JSON.stringify(CurrencyList));
        data._doneRemaining();
        args.model.dataSource = CurrencyList;
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
