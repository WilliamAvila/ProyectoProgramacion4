'use strict';
angular.module('app.controllers')
//Path: /forgot-password
    .controller('ForgotPasswordCtrl', [
        '$scope', '$location', '$window', 'Account', function ($scope, $location, $window, Account) {
            $scope.$root.title = 'AngularJS SPA | Forgot Password';
            // TODO: Register a new user
           /* $scope.RecoverPassword = function() {
                $scope.ShowMessage = true;

                return false;
            };*/


            $scope.user = {

            };

            $scope.forgotPassword = function () {
                Account.forgotPassword($scope.user, function (response) {
                    $scope.ShowMessage = true;
                }, function (error) {
                    alert('error');
                });
            };
        }
    ]);