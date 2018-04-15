var app = angular.module('CreateUserapp', []).controller('CreateNewUsercontroller', function ($scope, $http) {

    $scope.CreateNewuser = {
        FirstName: '',
        LastName: '',       
        Email: '',
        Password: '',
        Mobile: '',
        EmployeeID:''
    };
    $scope.RegisterNewuser = function (data) {
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "" + $("#listenerurl").val() + "Home/PostSignupuser",
            data: JSON.stringify(data)
        }).then(function (success) {
            debugger;
            alert(success.data);
        }, function (error) {
            debugger;
            alert(error.data);
        });
    }
    

    
});
$(document).ready(function () {

    CheckSession();
});
function CheckSession() {

    if ($("#listenertoken").val() == "" || $("#listenertoken").val()==undefined) {
        SessionEndManager();

    }
}
