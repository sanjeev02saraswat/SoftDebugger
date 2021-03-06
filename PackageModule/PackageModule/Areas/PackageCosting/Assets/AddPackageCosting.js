﻿var LocalizationResources = [];
var AirportList = [];
var app = angular.module('AddPackageCostingApp', ['ejangular']).controller('AddPackageCostingController', function ($scope, $http,$window) {

    $scope.airportList = AirportList;
    $scope.FlightCosting = {

    }

    function HotelProduct() {

        var HotelCostingRequest = {
            PackageCode: $("#hdnPackageCode").val(),
            PackageLanguage: $("#hdnPackageLanguage").val(),
            CompanyID: $("#CompanyID").val()
        }
        $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/GetHotelCosting",
            data: JSON.stringify(HotelCostingRequest)
        }).then(function (success) {

            $scope.HotelData = success.data;
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }

   
    $scope.addHotel = function () {
        debugger;
        //Add the new item to the Array.
        var HotelDetail = {
            id: $scope.HotelData.length + 1,
            HotelName: $scope.HotelName,
            HotelCityName: $scope.HotelCityName,
            RoomType: $scope.RoomType,
            AdultCost: $scope.AdultCost,
            ChildCost: $scope.ChildCost,
            PackageCode: $("#hdnPackageCode").val(),
            CompanyID: $("#CompanyID").val(),
            PackageLanguage: $("#hdnPackageLanguage").val()

        };
        $scope.HotelData.push(HotelDetail);
    }
    $scope.removeRow = function (index) {
        debugger;
        //Find the record using Index from Array.
        var name = $scope.HotelData[index].HotelName;
        if ($window.confirm("Do you want to delete: " + name)) {
            //Remove the item from Array using Index.
            $scope.HotelData.splice(index, 1);
        }
    }
    //$scope.AddHotelCosting = function (HotelData) {
    //    debugger;
    //    var data = JSON.parse(HotelData);
    //}
    $scope.GetAirportList = function () {
        AirportListmodel = {
            query: '' + $("#DepartureAirport").val() + '',
            CompanyID: '' + $("#CompanyID").val() + ''
        }

        $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Home/GetAirports",
            data: JSON.stringify(AirportListmodel)
        }).then(function (success) {

            AirportList = JSON.parse(success.data);
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }


    $scope.AddHotelsCosting = function () {       
        debugger;
        $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            headers: { "tokenid": "" + $("#listenertoken").val() + "", "CompanyID": "" + $("#CompanyID").val() + "" },
            url: "" + $("#listenerurl").val() + "Package/AddHotelCosting",
            data: JSON.stringify($scope.HotelData)
        }).then(function (success) {

            AirportList = JSON.parse(success.data);
        }, function (error) {
            if (error.status == 401) {
                SessionEndManager();
            }
        });
    }
    HotelProduct();
});
$('#DepartureAirport').ejAutocomplete({
    change: "showDepartureAirportSearch", enableRTL: false, highlightSearch: true,
    fields: { text: "airportCode", key: "airportText" },
    emptyResultText: 'No Airport Found',
    filterType: 'contains',
    animateType: "fade"

});
var today = new Date(), year = today.getFullYear(), month = today.getMonth();
var specialDays = [
           { date: new Date(year, month, 8), tooltip: "In Australia", iconClass: "flags sprite-Australia" },
           { date: new Date(year, month, 21), tooltip: "In France", iconClass: "flags sprite-France" },
           { date: new Date(year, month, 17), tooltip: "In USA", iconClass: "flags sprite-USA" },
           { date: new Date(year, month + 1, 15), tooltip: "In Germany", iconClass: "flags sprite-Germany" },
           { date: new Date(year, month - 1, 22), tooltip: "In India", iconClass: "flags sprite-India" },
]
$("#DepartureDate").ejDatePicker({
    cssClass: "gradient-lime",
    dateFormat: "dd/MMM/yyyy",
    specialDates: specialDays,
    highlightSection: "week",
    highlightWeekend: true,
    minDate: new Date()
});
$("#DepartureAirport").change(function () {
    if (AirportList != null) {
        for (var i = 0; i < AirportList.length; i++) {
            if ($("#DepartureAirport").val() == AirportList[i].airportText) {
                $("#hdnDepartureAirport").val(AirportList[i].airportCode);
            }
        }
        $("#hdnDepartureAirport").change();
    }

});

function showDepartureAirportSearch(args) {
    debugger;
    var data = $("#DepartureAirport").ejAutocomplete("instance");
    if (AirportList != null && AirportList.length > 0) {
        data.suggestionListItems = AirportList;
        data._doneRemaining();
        args.model.dataSource = AirportList;
    }
}