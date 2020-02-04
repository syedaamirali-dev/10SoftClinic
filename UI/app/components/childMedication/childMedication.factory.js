(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('childMedicationService', childMedicationService)

    /** @ngInject */
    function childMedicationService(apiCollection, $q, $http) {
        var service = {
            getMedicationDtOptions
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


        function getMedicationDtOptions(data, functions) {

            return {
                data: data,
                columns: [
                    { title: "Medicine", data: "medicineId" },
                    { title: "Medicine Name", data: "medicineName" },
                    { title: "Method", data: "method" },
                    { title: "Dosage", data: "dosage" },
                    { title: "No of Time in Day", data: "nTimesDay", class: "text-right" },
                    { title: "Quantity", data: "quantity", class: "text-right" },
                    { title: "Actions", data: "medicineId", class: 'text-center' },

                ],
                columnDefs: [
                    {
                        targets: 6,
                        render: (data, type, row) => {
                            return `
                            <button class="btn btn-edit p-0"><i class="la la-2x la-edit"></i></button>
                            <button class="btn btn-delete p-0"><i class="la la-2x la-trash"></i></button>
                            `;
                        },
                        fnCreatedCell: (nTd, cellData, rowData, row, col) => {
                            $(nTd).find(".btn-edit").on("click", () => {
                                functions.edit(rowData, row);
                            });
                            $(nTd).find(".btn-delete").on("click", () => {
                                functions.delete(row);
                            });
                        }
                    }
                ]
            }
        }
        return service;
    }

}());
