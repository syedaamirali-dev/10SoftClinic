(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('childMedicationCtrl', childMedicationCtrl)

    /** @ngInject */
    function childMedicationCtrl($scope, childMedicationService, $timeout) {
        $scope.medicationInfoObject = {
            medicineList: [],
            dosageList: [],
            dtTable: {
                isLoaded: false,
                data: [],
                dtOptions: {}
            },
            save: () => {
                var rowNum = $scope.medicationInfoObject.rowNum + 1;
                if (rowNum) {
                    rowNum -= 1;
                    $scope.medicationInfoObject.dtTable.data[rowNum].medicineId = $scope.medicationInfoObject.medicine;
                    $scope.medicationInfoObject.dtTable.data[rowNum].medicineName = $scope.medicationInfoObject.medicineList
                        .filter((item) => {
                            return item.medicineId == $scope.medicationInfoObject.medicine
                        })[0].medicineName;
                    $scope.medicationInfoObject.dtTable.data[rowNum].method = $scope.medicationInfoObject.method;
                    $scope.medicationInfoObject.dtTable.data[rowNum].dosage = $scope.medicationInfoObject.dosage;
                    $scope.medicationInfoObject.dtTable.data[rowNum].nTimesDay = $scope.medicationInfoObject.nTimesDay;
                    $scope.medicationInfoObject.dtTable.data[rowNum].quantity = $scope.medicationInfoObject.quantity;
                    $scope.medicationInfoObject.rowNum = null;
                } else {
                    $scope.medicationInfoObject.dtTable.data.push(
                        {
                            "medicineId": $scope.medicationInfoObject.medicine,
                            "medicineName": $scope.medicationInfoObject.medicineList
                                .filter((item) => {
                                    return item.medicineId == $scope.medicationInfoObject.medicine
                                })[0].medicineName,
                            "method": $scope.medicationInfoObject.method,
                            "dosage": $scope.medicationInfoObject.dosage,
                            "nTimesDay": $scope.medicationInfoObject.nTimesDay,
                            "quantity": $scope.medicationInfoObject.quantity
                        }
                    );
                }
                swal.fire({
                    title: "Data Submitted",
                    text: "Data Saved Successfully!",
                    type: "success",
                    showConfirmButton: false,
                    timer: 2000
                });
                $scope.medicationInfoObject.reset();
                GetMedicationDetails();
            },
            reset: () => {
                $scope.medicationInfoObject.medicine = null;
                $scope.medicationInfoObject.method = null;
                $scope.medicationInfoObject.dosage = null;
                $scope.medicationInfoObject.nTimesDay = null;
                $scope.medicationInfoObject.quantity = null;
            },
            edit: (data, row) => {
                $scope.medicationInfoObject.rowNum = row;
                $scope.medicationInfoObject.medicine = data.medicineId;
                $scope.medicationInfoObject.method = data.method;
                $scope.medicationInfoObject.dosage = data.dosage;
                $scope.medicationInfoObject.nTimesDay = parseInt(data.nTimesDay);
                $scope.medicationInfoObject.quantity = parseInt(data.quantity);
            },
            delete: (data) => {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#d33',
                    cancelButtonColor: '#74788d',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.value) {
                        swal.fire({
                            title: "Data Submitted",
                            text: "Data Saved Successfully!",
                            type: "success",
                            showConfirmButton: false,
                            timer: 2000
                        });
                        $timeout(() => {
                            $scope.medicationInfoObject.dtTable.data.splice(data, 1);
                            GetMedicationDetails();
                        }, 500);
                    }
                });
            }
        }


        function GetMedicationDetails() {
            // childMedicationService.getDiagnosisIDetails().then((res) => {
            //     if (res.status == "Success") {

            //     }
            // });
            $scope.medicationInfoObject.dtTable.isLoaded = false;
            // $scope.medicationInfoObject.dtTable.data = [];
            $timeout(() => {
                $scope.medicationInfoObject.medicineList = [
                    {
                        medicineId: "M001",
                        medicineName: "Medicine1"
                    },
                    {
                        medicineId: "M002",
                        medicineName: "Medicine 2"
                    },
                    {
                        medicineId: "M003",
                        medicineName: "Medicine 3"
                    },

                ];
                $scope.medicationInfoObject.dosageList = [
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
                ];
                $scope.medicationInfoObject.dtTable.dtOptions =
                    childMedicationService.getMedicationDtOptions(
                        $scope.medicationInfoObject.dtTable.data,
                        {
                            edit: $scope.medicationInfoObject.edit,
                            delete: $scope.medicationInfoObject.delete
                        }
                    );
                $scope.medicationInfoObject.dtTable.isLoaded = true;
            }, 1500);
        }
        function activate() {
            GetMedicationDetails();
        }
        activate();
    }

}());
