(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('loginService', loginService)

    /** @ngInject */
    function loginService(apiCollection, $q, $http, ) {

        var service = {
            validateUser
        };
        function httpGet(url) {
            let defer = $q.defer();
            $http.get(url).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
        }

        function httpPost(url, data) {
            let defer = $q.defer();
            $http.post(url, data).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
        }
        function validateUser(userObject) {
            return httpPost(apiCollection.login.validateUser(), userObject);
        }
        return service;
    }

}());