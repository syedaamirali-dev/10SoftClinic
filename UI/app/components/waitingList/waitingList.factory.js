(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('waitingListService', waitingListService)

    /** @ngInject */
    function waitingListService(apiCollection, $q, $http) {
        var service = {
            getWaitingListData,
            getDtOptions
        };
        function getDtOptions(data, functions) {
            return {
                data: data.data.table,
                columns: [
                    { title: 'Visit Register', data: 'documentNumber' },
                    { title: 'Doctor Treatment', data: 'documentTypeName' },
                    { title: 'Document Type', data: 'documentTypeName' },
                    { title: 'Visit Date', data: 'visitDate' },
                    { title: 'Start Time', data: 'visitStartTime' },
                    { title: 'End Time', data: 'visitEndTime' },
                    { title: 'Patient Code', data: 'patientCode' },
                    { title: 'Patient Name', data: 'patientName' },
                    { title: 'ID', data: 'civilID', visible: false },
                    { title: 'Doctor Name', data: 'doctorName' },
                    { title: 'Status', data: 'visitStatusText' },
                    { title: 'Is Visit Free?', data: 'isFreeVisit' },
                    // { title: 'Actions', data: 'visitRegisterId' },
                ],
                columnDefs: [
                    {
                        // targets: 12,
                        // render: (data, type, row) => {
                        //     return `
                        //     <button class="btn btn-sm btn-primary">Action</button>
                        //     `;
                        // },
                        targets: 1,
                        render: function (data, type, row) {
                            if (type === 'display') {
                                data ='<a href="#!/docTreatment/adultPatientSheet">Add Treatment</a>'
                            }
                            return data;
                        },
                        fnCreatedCell: (nTd, cellData, rowData, row, col) => {
                            $(nTd).find(".btn").on("click", () => {
                                functions.onClick(cellData)
                            });
                        }
                    }
                ]
            }
        }
        function getWaitingListData() {
            return httpGet(apiCollection.waitingList.GetWaitingList(), true);
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
