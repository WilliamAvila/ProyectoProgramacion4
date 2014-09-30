'use strict';
angular.module('app.controllers')
    .controller('LeaguesCtrl', [
        '$scope', '$location', '$window', 'Team','$stateParams', function ($scope, $location, $window, Team,$stateParams) {
            $scope.$root.title = 'AngularJS SPA | Leagues';

            
            $scope.idMyLeague2 = $location.url()[$location.url().length - 1];

            $scope.isEditing = false;
        $scope.NewTeam = {
           
         };
            $scope.addNewTeam = function () {
                Team.addNewTeam($scope.NewTeam, function (response) {
                    $location.path('/leagues');
                }, function (error) {
                    alert('Error');
                });
            };
            $scope.TeamtoEdit = {

            };


            $scope.deleteTeam = function (IdTeam) {
                console.log(IdTeam);
                Team.deleteTeam(IdTeam, function (response) {
                    $scope.loadTeams();
                }, function (error) {
                    alert('Error');
                });
            };

            $scope.editTeam = function () {
                Team.editTeam($scope.TeamtoEdit, function (response) {
                    $scope.isEditing = false;
                    $scope.loadTeams();
                }, function (error) {
                    alert('Error');
                });
            };

           /* $scope.NombreEquipo = "";

            $scope.addNewTeam = function() {
                var team = { nombre: $scope.NombreEquipo, id_liga: parseInt($stateParams.id) };
                $scope.teams.push(team);
                inicio();
                $scope.NombreEquipo = "";
            };
            */
           
            $scope.AllTeams = [];

            $scope.loadTeams = function () {
                Team.getAllTeams(function (AllTeams) {
                    $scope.AllTeams = AllTeams;
                }, function (error) {
                    alert('error loading Current Teams');
                });
            };

            var il = $stateParams.id;
            $scope.idMyLeague = document.URL[document.URL.length - 1];
        $scope.idMyLeague2 = $location.url()[$location.url().length - 1];
            console.log($scope.idMyLeague);
            $scope.FilterTeams = [];



             /*$scope.deleteTeam = function(nombre) {
                for (var i = 0; i < $scope.teams.length; i++) {
                    if ($scope.teams[i].nombre === nombre) {
                        $scope.teams.splice(i, 1);
                       
                    }
                }
            };

            $scope.isEditing = false;
            $scope.nombreAnterior = "";
            $scope.NuevoNombre = "";

            $scope.editTeam = function(TeamName) {
                $scope.isEditing = true;
                $scope.nombreAnterior = TeamName;
                $scope.NuevoNombre = TeamName;

            };*/

            $scope.cancelEdit = function(team) {
                $scope.isEditing = false;
            };



            $scope.editMode = function (Team) {

                console.log("editMode");
                $scope.isEditing = true;
                $scope.TeamtoEdit = Team;

            };


     
    }
    ]);