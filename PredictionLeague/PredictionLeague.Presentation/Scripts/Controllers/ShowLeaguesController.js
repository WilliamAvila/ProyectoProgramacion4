'use strict';
angular.module('app.controllers')

// All Leagues: /
    .controller('ShowLeaguesCtrl', [
        '$scope', '$location', '$window','League', function($scope, $location, $window ,League) {
            $scope.$root.title = 'AngularJS SPA | Leagues';


            $scope.isEditing = false;
            $scope.NewLeague = {

            };

            $scope.LeaguetoEdit = {

            };

            $scope.editMode = function (League) {

                console.log("editMode");
                $scope.isEditing = true;
                $scope.LeaguetoEdit = League;

            };
            $scope.addNewLeague = function () {
                League.addNewLeague($scope.NewLeague, function (response) {
                    $scope.loadLeagues();
                }, function (error) {
                    alert('Error');
                });
            };

            $scope.deleteLeague = function (IdLeague) {
                League.deleteLeague(IdLeague, function (response) {
                    //$scope.loadLeagues();
                }, function (error) {
                    alert('Error');
                });
            };

            $scope.editLeague = function () {
                League.editLeague($scope.LeaguetoEdit, function (response) {
                    $scope.isEditing = false;
                    $scope.loadLeagues();
                }, function (error) {
                    alert('Error');
                });
            };

           /* $scope.myStyle = "btn-default";
            $scope.ChangeStyle = function() {
                if ($scope.myStyle === "btn-success")
                    $scope.myStyle = "btn-default";
                else
                    $scope.myStyle = "btn-success";

            };
            $scope.myleagues = [];
            var league1 = {
                id: 1,
                name: "MLS",
                type: "Soccer",
                leagueImg: "http://grandstandu.com/wp-content/uploads/2014/03/mls.gif",
                DatenextMatch: new Date(),
                nextMatch: " 1 vs.2 ",
                accerts: 1,
                points: 0,
                subscribed: "btn-default"
            };

            var league2 = {
                id: 2,
                name: "MLB",
                type: "Baseball",
                leagueImg: "http://www.cuantoacuanto.com/wp-content/uploads/2014/04/Mlb-logo-major-league-logo1.jpg",
                DatenextMatch: new Date(),
                nextMatch: " 2 vs.2 ",
                accerts: 1,
                points: 0,
                subscribed: "btn-default"
            };
            var league3 = {
                id: 3,
                name: "NFL",
                type: "Football",
                leagueImg: "https://pbs.twimg.com/profile_images/478956593820618752/kvqPokJj.jpeg",
                DatenextMatch: new Date(),
                nextMatch: " 2 vs.2 ",
                accerts: 1,
                points: 0,
                subscribed: "btn-success"
            };
            var league4 = {
                id: 4,
                name: "NHL",
                type: "Hockey",
                leagueImg: "http://www.loyolaphoenix.com/wp-content/uploads/2013/09/nhl-logo.jpg",
                DatenextMatch: new Date(),
                nextMatch: " 2 vs.2 ",
                accerts: 1,
                points: 0,
                subscribed: "btn-default"
            };
            var league5 = {
                id: 5,
                name: "NBA",
                type: "Basketball",
                leagueImg: "http://www.lapatilla.com/site/wp-content/uploads/2014/07/NBA.jpg",
                DatenextMatch: new Date(),
                nextMatch: " 2 vs.2 ",
                accerts: 1,
                points: 0,
                subscribed: "btn-default"
            };
            $scope.LeagueType = "";
            $scope.LeagueName = "";
            $scope.ImgLeague = "";

            $scope.addNewLeague = function() {
                var league = { name: $scope.LeagueName, id: $scope.myleagues.length + 1, leagueImg: $scope.ImgLeague, type: $scope.LeagueType };
                $scope.myleagues.push(league);
                $scope.LeagueName = "";
                $scope.LeagueName = "";
                $scope.ImgLeague = "";
            };

            $scope.deleteLeague = function(LeagueName) {
                for (var i = 0; i < $scope.myleagues.length; i++) {
                    if ($scope.myleagues[i].name === LeagueName) {
                        $scope.myleagues.splice(i, 1);

                    }
                }
            };
            $scope.misLigas = [
                {
                    id: 3,
                    name: "NFL",
                    type: "Football",
                    leagueImg: "https://pbs.twimg.com/profile_images/478956593820618752/kvqPokJj.jpeg",
                    DatenextMatch: new Date(),
                    nextMatch: " 2 vs.2 ",
                    accerts: 1,
                    points: 0,
                    subscribed: "btn-default"
                }
            ];

            $scope.SubscribeLeague = function(LeagueName) {
                for (var i = 0; i < $scope.myleagues.length; i++) {
                    if ($scope.myleagues[i].name === LeagueName) {
                        if ($scope.myleagues[i].subscribed === "btn-success") {
                            //$scope.myleagues[i].subscribed = "btn-default";
                            // $scope.misLigas.splice(i, 1);
                        } else {
                            $scope.myleagues[i].subscribed = "btn-success";
                            $scope.misLigas.push($scope.myleagues[i]);
                        }
                    }
                }
            };


            $scope.isEditing = false;
            $scope.nombreAnterior = "";
            $scope.NuevoNombre = "";

            $scope.imagenAnterior = "";
            $scope.NuevaImagen = "";

            $scope.tipoAnterior = "";
            $scope.NuevoTipo = "";

            $scope.editLeague = function(LeagueName, LeagueType, LeagueImg) {
                $scope.isEditing = true;
                $scope.nombreAnterior = LeagueName;
                $scope.NuevoNombre = LeagueName;

                $scope.tipoAnterior = LeagueType;
                $scope.NuevoTipo = LeagueType;

                $scope.imagenAnterior = LeagueImg;
                $scope.NuevaImagen = LeagueImg;

            };

            $scope.cancelEdit = function(team) {
                $scope.isEditing = false;
            };

            $scope.finishEditing = function() {
                for (var i = 0; i < $scope.myleagues.length; i++) {
                    if ($scope.myleagues[i].name === $scope.nombreAnterior) {
                        $scope.myleagues[i].name = $scope.NuevoNombre;
                    }
                    if ($scope.myleagues[i].type === $scope.tipoAnterior) {
                        $scope.myleagues[i].type = $scope.NuevoTipo;
                    }
                    if ($scope.myleagues[i].leagueImg === $scope.imagenAnterior) {
                        $scope.myleagues[i].leagueImg = $scope.NuevaImagen;
                    }
                }

                $scope.isEditing = false;
                $scope.otroNombre = "";
                $scope.nombreAnterior = "";

            };
            $scope.myleagues.push(league1);
            $scope.myleagues.push(league2);
            $scope.myleagues.push(league3);
            $scope.myleagues.push(league4);
            $scope.myleagues.push(league5);*/
            $scope.availableLeagues = [];
            $scope.subscribedLeagues = [];

            $scope.loadLeagues = function () {
                League.getAvailableLeagues(function (availableLeagues) {
                    $scope.availableLeagues = availableLeagues;
                }, function (error) {
                    alert('error loading available leagues');
                });

                League.getSuscribedLeagues(function (subscribedLeagues) {
                    $scope.subscribedLeagues = subscribedLeagues;
                }, function (error) {
                    alert('error loading available leagues');
                });


            };

            $scope.$on('$viewContentLoaded', function () {
                $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
            });
           

    }
    ]);