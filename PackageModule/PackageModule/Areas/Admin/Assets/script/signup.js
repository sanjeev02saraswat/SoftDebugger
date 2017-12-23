$(document).ready(function () {

    $('.form').find('input, textarea').on('keyup blur focus', function (e) {

        var $this = $(this),
            label = $this.prev('label');

        if (e.type === 'keyup') {
            if ($this.val() === '') {
                label.removeClass('active highlight');
            } else {
                label.addClass('active highlight');
            }
        } else if (e.type === 'blur') {
            if ($this.val() === '') {
                label.removeClass('active highlight');
            } else {
                label.removeClass('highlight');
            }
        } else if (e.type === 'focus') {

            if ($this.val() === '') {
                label.removeClass('highlight');
            }
            else if ($this.val() !== '') {
                label.addClass('highlight');
            }
        }

    });

    $('.tab a').on('click', function (e) {
        debugger;
        e.preventDefault();

        $(this).parent().addClass('active');
        $(this).parent().siblings().removeClass('active');

        target = $(this).attr('href');

        $('.tab-content > div').not(target).hide();

        $(target).fadeIn(600);

    });
   
});



var app = angular.module('Signupapp', []).controller('signupcontroller', function ($scope, $http) {

    $scope.User = {
        FirstName: '',
        LastName: '',
        FullName: '',
        Email: '',
        Password: ''
    };

    debugger
    $scope.SignUpuser = function (data) {
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:2849/Home/PostSignupuser",
            data: JSON.stringify(data)
        }).then(function (success) {
            debugger;
            alert(success.data);
        }, function (error) {
            debugger;
            alert(error.data);
        });
    }

}).controller('logincontroller', function ($scope, $http) {

    $scope.Loginuser = {

        Email: '',
        Password: ''
    };
    debugger;
    $scope.Login = function (data) {
        debugger;
        var request = $http({
            method: "post",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:2849/Home/Loginuser",
            data: JSON.stringify(data)
        }).then(function (success) {
            debugger;
            if (success.status === 200 && success.data.tokenid != '' && success.data.tokenid!=null) {
                $http({
                    method: "Get",
                    contentType: "application/json; charset=utf-8",
                    url: "CreateTokenCookie?TokenID=" + success.data.tokenid,

                }).then(function (success) {
                    window.location.href = "/Admin/Package/CreateNewPackage";

                }, function (error) {

                });

            }
            else if(success.status==401){
                SessionEndManager();
            }
            else {
                alert('Login attempt Failed....');
            }
        }, function (error) {
            debugger;
            alert(error.data);
        });
    }


});



//var loginapp = angular.module('Signupapp', [])

