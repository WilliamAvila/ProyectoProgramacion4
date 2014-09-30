'use strict';
angular.module('app.controllers')
//Path: /Matches
.controller('MatchesCtrl', [
    '$scope', '$location', '$window', '$stateParams','Game', function($scope, $location, $window, $stateParams,Game) {
        $scope.$root.title = 'AngularJS SPA | Games';

       
        $scope.isGuessing = false;
        $scope.isEditing = false;
        $scope.availableGames = [];
        $scope.guessGame = {
        };
        $scope.localScore = 0;
        $scope.visitorScore=0;
        $scope.guessMatch = function (Match) {
            
                $scope.isGuessing = true;
                console.log($scope.isGuessing);
                $scope.guessGame = Match;
            
        };

        $scope.makePrediction = function () {
            $scope.guessGame.Score = $scope.localScore + "-" + $scope.visitorScore;
            $scope.cancelEdit();
            Game.makePrediction( $scope.guessGame,function (response) {
            }, function (error) {
                alert('error loading available Games');
            });
            }
       
        $scope.getGames = function () {
            Game.getGames(function (availableGames) {
                console.log("Llego");
                $scope.availableGames = availableGames;
                console.log(availableGames[0].Id);
            }, function (error) {
                alert('error loading available Games');
            });
        }

            $scope.NewGame = {

            };
            $scope.addNewGame = function () {
                Game.addGame($scope.NewGame, function (response) {
                    $location.path('/leagues');
                }, function (error) {
                    alert('Error');
                });
            };
            $scope.GametoEdit = {

            };


            $scope.deleteGame = function (IdGame) {
                console.log(IdGame);
                Game.deleteGame(IdGame, function (response) {
                    $scope.getGames();
                }, function (error) {
                    alert('Error');
                });
            };

            $scope.editGame = function () {
                Game.editGame($scope.GametoEdit, function (response) {
                    $scope.isEditing = false;
                    $scope.getGames();
                }, function (error) {
                    alert('Error');
                });
            };

            $scope.editMode = function (Game) {

                console.log("editMode");
                $scope.isEditing = true;
                $scope.GametoEdit = Game;

            };

            $scope.cancelEdit = function () {
                $scope.isEditing = false;
                $scope.isGuessing = false;
            };

            
        }
        ]);