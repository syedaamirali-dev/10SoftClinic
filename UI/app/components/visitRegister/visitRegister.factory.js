(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('visitRegisterService', visitRegisterService)

    /** @ngInject */
    function visitRegisterService(apiCollection, $q, $http) {
        var service = {
            AddVisitRegister
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
        function AddVisitRegister(dataToSend) {
            return httpPost(apiCollection.doctorTreatment.AddVisitRegister(), dataToSend);
        }
        return service;
    }

}());
