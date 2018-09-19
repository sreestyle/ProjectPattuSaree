(function () {
    'use strict';
    angular.module('PattuSaree', ["common.core", "common.ui", "LocalStorageModule"])
        .config(config)
        .run(run);

    config.$inject = ["$stateProvider", "$urlRouterProvider", "$httpProvider","$locationProvider"];
    function config($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
<<<<<<< HEAD
        
=======
        $urlRouterProvider.otherwise("/home");
        $stateProvider
            .state("login",
                {
                    url: "/login",
                    templateUrl: "/scripts/spa/TimesZquare/login/login.html",
                    controller: "loginCtrl"

                }).state("singup",
                {
                    url: "/singup",
                    templateUrl: "/scripts/spa/TimesZquare/singup/singup.html",
                    controller: "singupCtrl"

                }).state("layout", {
                    abstract: true,
                    views: {
                        '@': {
                            templateUrl:"/scripts/spa/layout/layout.html",
                        },
                        'header@layout': {
                            templateUrl: "/scripts/spa/layout/header.html",
                            controller:"headerCtrl"
                        },
                        'sidebar@layout': {
                            templateUrl: "/scripts/spa/layout/sidebar.html",
                            controller: "sidebarCtrl"
                        },
                        'body@layout': {
                            templateUrl:"/scripts/spa/layout/content.tpl.html"
                        },
                        'footer@layout': {
                            templateUrl:"/scripts/spa/layout/footer.html"
                        }
                    }
                }).state("layout.Home", {
                    url: "/home",
                    templateUrl: "/scripts/spa/TimesZquare/News/news.html",
                    controller:"newsCtrl"

                });
>>>>>>> 0079a9f40f46eb2964a9b2cc49f5628b686dff8c
    };

    run.$inject = ["$http", "$state", "$window", "$rootScope"];
    function run($http, $state, $window, $rootScope) {
        $rootScope.ShowUnderWorkMsg = function () {
            swal({
                title: "Sorry!",
                text: "Work in progress!",
                imageUrl: "/Content/img/Work_In_Progress.png"
            });
        };
    }

})();