'use strict';
angular.module('app.controllers')
// Path: /login
.controller('LoginCtrl', [
    '$scope', '$location', '$window', 'Account', 'Auth', function ($scope, $location, $window, Account, Auth) {
        $scope.$root.title = 'AngularJS SPA | Sign In';
        // TODO: Authorize a user

       /* $scope.login = function() {
            if ($scope.userName === "admin")
                $location.path('/leagues');
            else if ($scope.userName === "user")
                $location.path('/HomeUser');
            return false;
        };*/ 
        $scope.user = {

        };
        $scope.login = function () {
            Auth.login($scope.user, function (response) {
                console.log(response);

                if (response.role.title === 'admin') {
                   
                    $location.path('/leagues');
                } else {
                    $location.path('/HomeUser');
                }
                $scope.isLoading = false;
            }, function (error) {

            });
        };

       
        $scope.$on('$viewContentLoaded', function() {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });

        $scope.register = function() {
            $location.path('/register');
            return false;
        }
    }
]);