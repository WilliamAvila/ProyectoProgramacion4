'use strict';
angular.module('app.services')
    .factory('League', function($http, Server, $cookieStore) {
        return {
            getAvailableLeagues: function(success, error) {
                $http
                    .get(
                        Server.get() + '/leagues/available', {
                            headers: { 'Authorization': $cookieStore.get('access_token') }
                        })
                    .success(function(response) {
                        success(response);
                    })
                    .error(error);
            }, addNewLeague: function (LeagueModel, success, error) {
                $http
                    .post(
                        Server.get() + '/addLeague', LeagueModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, deleteLeague: function (IdLeague, success, error) {
                $http
                    .post(
                        Server.get() + '/deleteLeague', IdLeague)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, editLeague: function (LeagueModel, success, error) {
                $http
                    .post(
                        Server.get() + '/editLeague', LeagueModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            getSuscribedLeagues: function(success, error) {
                $http.get(Server.get() + '/leagues/suscribed', {
                        headers: { 'Authorization': $cookieStore.get('access_token') }

                    })
                    .success(function(response) {
                        success(response);
                    }).error(error);
            }
        };
    });