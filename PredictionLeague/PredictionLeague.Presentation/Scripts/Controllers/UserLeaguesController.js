'use strict';
angular.module('app.controllers')
    //User Leagues 
    .controller('UserLeaguesCtrl', [
        '$scope', '$location', '$window', function($scope, $location, $window) {
            $scope.$root.title = 'User Leagues';

        }
    ]);