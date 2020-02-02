(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('docVisitService', docVisitService)

    /** @ngInject */
    function docVisitService(apiCollection, $q, $http) {
        var service = {
            getvisitHistorytData,
            getDtOptions
        };
        function getDtOptions(data, functions) {
            return {
                data: data.data.table,
                columns: [
                    { title: 'Visit Register', data: 'documentNumber' },
                    { title: 'Doctor Treatment', data: 'doctorTreatmentNumber' },
                    { title: 'Document Type', data: 'documentTypeName' },
                    { title: 'Visit Date', data: 'visitDate' },
                    { title: 'Start Time', data: 'visitStartTime' },
                    { title: 'End Time', data: 'visitEndTime' },
                    { title: 'Patient Code', data: 'patientCode' },
                    { title: 'Patient Name', data: 'patientName' },
                    { title: 'ID', data: 'civilID', visible: false },
                    { title: 'Doctor Name', data: 'doctorName' },
                    { title: 'Status', data: 'visitStatusText' },
                    { title: 'Is Visit Free?', data: 'isFreeVisit', class: 'text-center' },
                    // { title: 'Actions', data: 'visitRegisterId' },
                ],
                columnDefs: [
                    {
                        targets: 1,
                        render: function (data, type, row) {
                            var treatmentNum = data == null ? "" : data;
                            if (type === 'display') {
                                data = `<a href="#!/docTreatment/adultPatientSheet">${treatmentNum}</a>`
                            }
                            return data;
                        }
                    }
                    , {
                        targets: 3,
                        render: function (data, type, row) {
                            if (data != null) {
                                let dateObj = new Date(data);
                                return `${dateObj.getDate()}/${dateObj.getMonth() + 1}/${dateObj.getFullYear()}`;
                            }
                            return "";
                        }
                    }

                    , {
                        targets: 11,
                        render: function (data, type, row) {
                            if (data != null) {
                                return `${data == true ? "Yes" : "No"}`;
                            }
                            return "";
                        }
                    }
                ]
            }
        }
        function getvisitHistorytData() {
            return httpGet(apiCollection.doctorTreatment.GetVisitHistory(), true);
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
