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
                    { title: 'Is Visit Free?', data: 'isFreeVisitk', class: 'text-center'},
                    // { title: 'Actions', data: 'visitRegisterId' },
                ],
                columnDefs: [
                    {
                        targets: 1,
                        render: function (data, type, row) {
                            if (type === 'display') {
                                data = '<a class="kt-link kt-link--brand kt-font-bolder btn-redirect">Add Treatment</a>'
                            }
                            return data;
                        },
                        fnCreatedCell: (nTd, cellData, rowData, row, col) => {
                            $(nTd).find(".btn-redirect").on("click", () => {
                                functions.pageRedirect(cellData)
                            });
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
