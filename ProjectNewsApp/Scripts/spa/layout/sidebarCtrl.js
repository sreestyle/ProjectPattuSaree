(function (app) {
    "use strict";
    app.controller("sidebarCtrl", sidebarCtrl);
    sidebarCtrl.$inject = ['$scope'];
    function sidebarCtrl($scope) {
        $scope.sidebarVm = {

        };
        $scope.sidebarVm.tiles = ["POPULAR","INDIA","TAMIL NADU","CINEMA","POLITICS","ENTERTAINMENT","SPORTS","TRAVEL"]
        $scope.sidebarVm.hideMenu = function(){
            document.getElementById('side-bar').className = "side-bar side-menu-close";
        };
        $scope.login = function () {
            document.getElementById('modalbackground').style.display = 'block';
            document.getElementById('login').className = "login login-slide-in";
        }
    }
})(angular.module("ddcNews"))