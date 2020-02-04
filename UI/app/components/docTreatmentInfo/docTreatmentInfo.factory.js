(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('docTreatmentInfoService', docTreatmentInfoService)

    /** @ngInject */
    function docTreatmentInfoService(apiCollection, $q, $http) {
        var service = {
            getDiagnosisDtOptions,
            getIllnessDtOptions,
            getSymptomDtOptions,
            getProblemDtOptions,
            saveDiagnosisIDetails,
            getDiagnosisIDetails,
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


        function getDiagnosisDtOptions($scope) {

            return {
                disableDelete: false,
                columns: [
                    {
                        title: "Chief Complaint",
                        data: "diagnosisId",
                        type: {
                            name: "typeahead",
                            data: $scope.diagnosisList,
                            id: "diagnosisId",
                            value: "diagnosisName",
                            required: true,
                            // unique: true
                        },
                        onChange: $scope.onDiagnosisChange
                    },
                    {
                        title: "Chief Complaint Name",
                        data: "diagnosisName",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        },
                    },
                    {
                        title: "Teeth",
                        data: "teeth",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false,
                        },
                    },
                    {
                        title: "Comments",
                        data: "comments",
                        type: {
                            name: "textarea",
                            // required: true
                        }
                    }

                ],
            }
        }
        function getIllnessDtOptions($scope) {

            return {
                disableDelete: false,
                columns: [
                    {
                        title: "Illness",
                        data: "illnessId",
                        type: {
                            name: "typeahead",
                            data: $scope.illnessList,
                            id: "illnessId",
                            value: "illnessName",
                            required: true,
                            // unique: true
                        },
                        onChange: $scope.onIllnessChange
                    },
                    {
                        title: "Illness Name",
                        data: "illnessName",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        },
                    },
                    {
                        title: "Teeth",
                        data: "teeth",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false,
                        },
                    },
                    {
                        title: "Comments",
                        data: "comments",
                        type: {
                            name: "textarea",
                            // required: true
                        }
                    }

                ],
            }
        }
        function getSymptomDtOptions($scope) {

            return {
                disableDelete: false,
                columns: [
                    {
                        title: "Symptom",
                        data: "symptomId",
                        type: {
                            name: "typeahead",
                            data: $scope.symptomList,
                            id: "symptomId",
                            value: "symptomName",
                            required: true,
                            // unique: true
                        },
                        onChange: $scope.onSymptomChange
                    },
                    {
                        title: "Symptom Name",
                        data: "symptomName",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: false,
                            disabled: true
                        },
                    },
                    {
                        title: "Teeth",
                        data: "teeth",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false,
                        },
                    },
                    {
                        title: "Comments",
                        data: "comments",
                        type: {
                            name: "textarea",
                            // required: true
                        }
                    }
                    // {
                    //     title: "Created Date",
                    //     data: "createdDate",
                    //     type: {
                    //         name: "date",
                    //         disabled: true
                    //     }
                    // },

                ],
            }
        }
        function getProblemDtOptions($scope) {

            return {
                disableDelete: false,
                columns: [

                    {
                        title: "Problem",
                        data: "problem",
                        type: {
                            name: "input",
                            inputType: "text",
                            required: true
                        },
                    },
                    {
                        title: "Teeth",
                        data: "teeth",
                        type: {
                            name: "input",
                            inputType: "number",
                            required: false,
                        },
                    },
                    {
                        title: "Comments",
                        data: "comments",
                        type: {
                            name: "textarea",
                            // required: true
                        }
                    }

                ],
            }
        }
        function saveDiagnosisIDetails(data) {
            return httpPost(apiCollection.doctorTreatment.SaveDiagnosis(), data);
        }
        function getDiagnosisIDetails() {
            return httpGet(apiCollection.doctorTreatment.GetDiagnosisDetails());
        }
        return service;
    }

}());
