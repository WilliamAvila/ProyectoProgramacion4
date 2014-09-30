'use strict';
angular.module('app.services')
    .factory('Team', function ($http, Server, $cookieStore) {
        return {
            getAllTeams: function (success, error) {
                $http
                    .get(
                        Server.get() + '/teams', {
                            headers: { 'Authorization': $cookieStore.get('access_token') }
                        })
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
            addNewTeam: function (TeamModel, success, error) {
                $http
                    .post(
                        Server.get() + '/addTeam', TeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, deleteTeam: function (IdTeam, success, error) {
                $http
                    .post(
                        Server.get() + '/deleteTeam', IdTeam)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, editTeam: function (TeamModel, success, error) {
                $http
                    .post(
                        Server.get() + '/editTeam', TeamModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            },
        };
    });