(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('dashboardService', dashboardService)

    /** @ngInject */
    function dashboardService(apiCollection, $http, $q) {
        var service = {
            getDashboardData
        };

        function getDashboardData() {
            return httpGet(apiCollection.user.getDashboardData());
        }

        function httpPost(url, data) {
            let defer = $q.defer();
            $http.post(url, data).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
        }

        function httpGet(url, isRefresh) {
            let defer = $q.defer();
            // if (isRefresh) {
            //     $cacheFactory.get("$http").remove(url);
            // }
            $http.get(url, { cache: false }).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
        }

        return service;
    }

}());
