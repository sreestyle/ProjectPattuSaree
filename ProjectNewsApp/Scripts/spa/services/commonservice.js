
(function (app) {
    "use strict";

    app.factory("commonServices", commonServices);

    commonServices.$inject = ["$http", "$state", "$q", "localStorageService"];

    function commonServices($http, $state, $q, localStorageService) {
        var commonService = {};

        

        var getService = function (getUrl, ignoreLoader = false) {
            var deferred = $q.defer();
            var requestOption = {
                headers: { 'Content-Type': 'application/json' }
            };
            if (ignoreLoader === true)
                requestOption.ignoreLoadingBar = true;
            $http.get(getUrl, requestOption).then(function (response) {
                deferred.resolve(response);
            }, function (err) {
                deferred.reject(err);
            });

            return deferred.promise;
        }

        var getServiceparam = function (getUrl, params, ignoreLoader = false) {
            var deferred = $q.defer();
            var requestOption = {
                params: params,
                headers: { 'Content-Type': 'application/json' }
            };
            if (ignoreLoader === true)
                requestOption.ignoreLoadingBar = true;
            $http.get(getUrl, requestOption).then(function (response) {
                deferred.resolve(response);
            }, function (err) {
                deferred.reject(err);
            });

            return deferred.promise;
        }

        var deleteServiceparam = function (getUrl, params) {
            var deferred = $q.defer();
            $http.delete(getUrl, {
                params: params,
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {
                deferred.reject(err);
            });

            return deferred.promise;
        }

        var putService = function (postUrl, postInfo) {

            var deferred = $q.defer();
            $http.put(postUrl, postInfo, {
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {

                deferred.reject(err);
            });

            return deferred.promise;
        }

        var postService = function (postUrl, postInfo, ignoreLoader = false) {
            var deferred = $q.defer();
            var requestOptions = {
                headers: { 'Content-Type': 'application/json' }
            }
            if (ignoreLoader === true)
                requestOptions.ignoreLoadingBar = true;
            $http.post(postUrl, postInfo, requestOptions).then(function (response) {
                deferred.resolve(response);
            }, function (err) {

                deferred.reject(err);
            });

            return deferred.promise;
        }

        var deleteService = function (postUrl, postInfo) {

            var deferred = $q.defer();
            $http.delete(postUrl, postInfo, {
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {

                deferred.reject(err);
            });

            return deferred.promise;
        }

        var changePassword = function (postUrl, postInfo) {

            var deferred = $q.defer();
            $http.post(postUrl, postInfo, {
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {

                deferred.reject(err);
            });

            return deferred.promise;
        }

        var forgetPassword = function (postUrl, postInfo) {

            var deferred = $q.defer();
            $http.post(postUrl, postInfo, {
                headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {

                deferred.reject(err);
            });

            return deferred.promise;
        }

        var login = function (loginData) {
            //localStorageService.remove('authorizationData');
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
            var deferred = $q.defer();
            $http.post('token', data, {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                response.data.isSuccess = true;
                localStorageService.set('authorizationData', { token: response.data.access_token, userName: loginData.userName });
                deferred.resolve(response);
            }, function (err) {
                // _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        }

        var downloadService = function (getUrl) {
            var deferred = $q.defer();
            $http.get(getUrl, {
                //headers: { 'Content-Type': 'application/json' }
            }).then(function (response) {
                deferred.resolve(response);
            }, function (err) {
                deferred.reject(err);
            });

            return deferred.promise;
        }

      

        var logOut = function () {
            localStorageService.remove("authorizationData");
        };

      
        commonService.getService = getService;
        commonService.getServiceparam = getServiceparam;
        commonService.postService = postService;
        commonService.putService = putService;
        commonService.deleteService = deleteService;
        commonService.changePassword = changePassword;
        commonService.forgetPassword = forgetPassword;
        commonService.login = login;
        commonService.logOut = logOut;
        
        commonService.deleteServiceparam = deleteServiceparam;
        commonService.downloadService = downloadService;
        return commonService;
    }
})(angular.module("common.core"));