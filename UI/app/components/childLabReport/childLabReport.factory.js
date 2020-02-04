(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('childLabReportService', childLabReportService)

    /** @ngInject */
    function childLabReportService(apiCollection, $q, $http) {
        var service = {
            getLabReportData,
            getDtOptions
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
        function getDtOptions(data, functions) {
            return {
                data: data,
                columns: [
                    { title: 'Lab Report Request #', data: 'lrRequest' },
                    { title: 'Report Type', data: 'reportType' },
                    { title: 'Lab Report Type Name', data: 'reportTypeName' },
                    { title: 'Comment', data: 'comments' },
                    { title: 'Preferrd Lab', data: 'preferredLab' },
                    { title: 'Report Status', data: 'reportStatus' },
                    { title: 'Show Report', data: 'report' },

                ],
                columnDefs: []
            }
        }
        function getLabReportData() {
            return httpGet(apiCollection.doctorTreatment.GetVisitHistory(), true);
        }
        return service;
    }

}());
