(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docMedicationCtrl', docMedicationCtrl)

    /** @ngInject */
    function docMedicationCtrl($scope, docMedicationService, $timeout) {
        $scope.Submit = () => {
            swal.fire({
                title: "Data Submitted",
                text: "Data Saved Successfully!",
                type: "success",
                showConfirmButton: false,
                timer: 2000
            });
        }

       
        function setMedicatonGrid() {
            $scope.medicationInfoObject = {
                isLoaded: false,
                data: [
                    {
                        medicineId: null,
                        medicineName: null,
                        method: null,
                        isVaccine: true,
                        startDate: new Date(),
                        endDate: new Date(),
                        specificCase: false,
                        specificCaseText: null,
                        noTimeDay: null,
                        dosageTime: null,
                        quantity: 0,
                        pharmacy: null,
                        comment: null,
                    }
                ],
                options: docMedicationService.getMedicationDtOptions($scope),
            }

        }

        $scope.onMedicineChange = (cell) => {
            cell.row.medicineName = $scope.medicineList.filter((item) => item.medicineId == cell.row.medicineId)[0].medicineName;
        }
        $scope.onSpificCaseToggleChange = (cell) => {
            console.log(JSON.stringify(cell));
        }
        $scope.onNumTimeChange = (cell) => {
            console.log(JSON.stringify(cell));
        }


        function GetMedicationDetails() {
            $scope.medicineList = [
                {
                    medicineId: "M001",
                    medicineName: "M001"
                },
                {
                    medicineId: "Medicine2",
                    medicineName: "Medicine 2"
                },
                {
                    medicineId: "Medicine 3",
                    medicineName: "Medicine 3"
                },
            ];
            $scope.dosageList = [
                {
                    dosage: "amp"
                },
                {
                    dosage: "bag"
                },
                {
                    dosage: "bottle"
                },
                {
                    dosage: "card"
                },
                {
                    dosage: "syringe"
                },
            ]
            setMedicatonGrid();
            // docMedicationService.getDiagnosisIDetails().then((res) => {
            //     if (res.status == "Success") {

            //     }
            // });
            $scope.medicationInfoObject.isLoaded = true;
            
        }
        function activate() {
            GetMedicationDetails()
        }
        activate();
    }

}());
