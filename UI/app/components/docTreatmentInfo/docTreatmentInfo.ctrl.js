(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docTreatmentInfoCtrl', docTreatmentInfoCtrl)

    /** @ngInject */
    function docTreatmentInfoCtrl($scope, docTreatmentInfoService) {
        $scope.Submit = () => {
            swal.fire({
                title: "Data Submitted",
                text: "Data Saved Successfully!",
                type: "success",
                showConfirmButton: false,
                timer: 2000
            });
        }

        function setDiagnosisGrid() {
            $scope.diagnosisInfoObject = {
                isLoaded: false,
                data: [
                    {
                        diagnosisId: null,
                        diagnosisName: null,
                        level: null,
                        comments: null
                    }
                ],
                options: docTreatmentInfoService.getDiagnosisDtOptions($scope),
            }
            $scope.illnessInfoObject = {
                isLoaded: false,
                data: [
                    {
                        illnessId: null,
                        illnessName: null,
                        level: null,
                        comments: null
                    }
                ],
                options: docTreatmentInfoService.getIllnessDtOptions($scope),

            }
            $scope.symptomInfoObject = {
                isLoaded: false,
                data: [
                    {
                        symptomId: null,
                        symptomName: null,
                        level: null,
                        comments: null
                    }
                ],
                options: docTreatmentInfoService.getSymptomDtOptions($scope),

            }
            $scope.problemInfoObject = {
                isLoaded: false,
                data: [
                    {
                        problemName: null,
                        level: null,
                        comments: null
                    }
                ],
                options: docTreatmentInfoService.getProblemDtOptions($scope),

            }

        }

        $scope.onDiagnosisChange = (cell) => {
            cell.row.diagnosisName = $scope.diagnosisList.filter((item) => item.diagnosisId == cell.row.diagnosisId)[0].diagnosisName;
        }
        $scope.onIllnessChange = (cell) => {
            cell.row.illnessName = $scope.illnessList.filter((item) => item.illnessId == cell.row.illnessId)[0].illnessName;
        }
        $scope.onSymptomChange = (cell) => {
            cell.row.symptomName = $scope.symptomList.filter((item) => item.symptomId == cell.row.symptomId)[0].symptomName;
        }


        function GetDiagnosisDetails() {
            $scope.diagnosisList = [
                {
                    diagnosisId: "A00",
                    diagnosisName: "Cholera"
                },
                {
                    diagnosisId: "A01",
                    diagnosisName: "Typhoid and Paratyphoid fevers"
                },
                {
                    diagnosisId: "A02",
                    diagnosisName: "Other Salmonella Infections"
                },
            ];
            $scope.illnessList = [
                {
                    illnessId: "Arthritis",
                    illnessName: "Arthritis"
                },
                {
                    illnessId: "Lupus",
                    illnessName: "Lupus"
                },
                {
                    illnessId: "Spinabifida",
                    illnessName: "Spinabifida"
                },
            ];
            $scope.symptomList = [
                {
                    symptomId: "Allergy",
                    symptomName: "Allergy symptoms"
                },
                {
                    symptomId: "Diabetes",
                    symptomName: "Diabetes symptoms"
                },
                {
                    symptomId: "Stroke",
                    symptomName: "Stroke symptoms"
                }
            ];
            $scope.levelList = [
                {
                    level: 1
                },
                {
                    level: 2
                },
                {
                    level: 3
                },
                {
                    level: 4
                },
                {
                    level: 5
                },
            ]
            setDiagnosisGrid();
            // docTreatmentInfoService.getDiagnosisIDetails().then((res) => {
            //     if (res.status == "Success") {

            //     }
            // });
            $scope.diagnosisInfoObject.isLoaded = true;
            $scope.illnessInfoObject.isLoaded = true;
            $scope.symptomInfoObject.isLoaded = true;
            $scope.problemInfoObject.isLoaded = true;
        }
        function activate() {
            GetDiagnosisDetails()
        }
        activate();

    }

}());
