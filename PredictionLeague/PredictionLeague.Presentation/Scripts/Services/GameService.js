'use strict';
angular.module('app.services')
    .factory('Game', function ($http, Server, $cookieStore) {
        return {
            getGames: function (success, error) {
                $http
                    .get(
                        Server.get() + '/getGames', {
                            headers: { 'Authorization': $cookieStore.get('access_token') }
                        })
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, addGame: function (GameModel, success, error) {
                $http
                    .post(
                        Server.get() + '/addGame', GameModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, deleteGame: function (IdGame, success, error) {
                $http
                    .post(
                        Server.get() + '/deleteGame', IdGame)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, editGame: function (GameModel, success, error) {
                $http
                    .post(
                        Server.get() + '/editGame', GameModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }, makePrediction: function (AccountGameModel, success, error) {
                $http
                    .post(
                        Server.get() + '/makePrediction', AccountGameModel)
                    .success(function (response) {
                        success(response);
                    })
                    .error(error);
            }
        };
    });