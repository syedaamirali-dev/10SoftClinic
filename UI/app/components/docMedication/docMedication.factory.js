(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('docMedicationService', docMedicationService)

    /** @ngInject */
    function docMedicationService(apiCollection, $q, $http) {
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


        function getMedicationDtOptions($scope) {

            return {
                disableDelete: false,
                columns: [
                    {
                        title: "Medicine",
                        data: "medicineId",
                        type: {
                            name: "typeahead",
                            data: $scope.medicineList,
                            id: "medicineId",
                            value: "medicineName",
                            required: true,
                            // unique: true
                        },
                        onChange: $scope.onMedicineChange
                    },
                    {
                        title: "Medicine Name",
                        data: "medicineName",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        },
                    },
                    {
                        title: "Dosage",
                        data: "dosage",
                        type: {
                            name: "select",
                            data: $scope.dosageList,
                            id: "dosage",
                            value: "dosage",
                            required: true,
                        },
                    },
                    {
                        title: "Method",
                        data: "method",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        }
                    },
                    {
                        title: "Is Vaccine",
                        data: "isVaccine",
                        type: {
                            name: "checkbox",
                            required: false
                        }
                    },
                    {
                        title: "Form",
                        data: "form",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        }
                    },
                    {
                        title: "Start Date",
                        data: "startDate",
                        type: {
                            name: "date"
                        }
                    },
                    {
                        title: "End Date",
                        data: "endDate",
                        type: {
                            name: "date"
                        }
                    },
                    {
                        title: "Is In Specific Case",
                        data: "specificCase",
                        type: {
                            name: "checkbox",
                            required: false
                        },
                        onChange: $scope.onSpificCaseToggleChange
                    },
                    {
                        title: "Specific case",
                        data: "specificCaseText",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false
                        }
                    },
                    {
                        title: "No of Time in Day",
                        data: "noTimeDay",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false
                        },
                        onChange: $scope.onNumTimeChange
                    },
                    {
                        title: "DosageTime",
                        data: "dosageTime",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false
                        },
                        isHidden: true
                    },
                    {
                        title: "Quantity",
                        data: "quantity",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false
                        }
                    },
                    {
                        title: "Preferred Pharmacy",
                        data: "pharmacy",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false
                        }
                    },
                    {
                        title: "Comment",
                        data: "comment",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false
                        }
                    },

                ],
            }
        }

        return service;
    }

}());
