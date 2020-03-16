(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('visitRegisterCtrl', visitRegisterCtrl)

    /** @ngInject */
    function visitRegisterCtrl($scope, $state, visitRegisterService) {
        $scope.visitRegisterInfo = {}

        function activate() {

            $scope.visitRegisterInfo = {
                data: {},
                patientCodeList: [
                    {
                        patientId: 1
                        , patientCode: "PC1"
                        , patientName: "Abdullah"
                    },
                    {
                        patientId: 2
                        , patientCode: "PC2"
                        , patientName: "Alyami"
                    },
                    {
                        patientId: 3
                        , patientCode: "PC3"
                        , patientName: "Bamukhair"
                    },
                ],
                save: () => {
                    // visitRegisterService.AddVisitRegister($scope.visitRegisterInfo.data).then((result) => {

                    // });
                    iziToast.success({ message: "Visit Register Added Successfully!" });
                    $state.go("main.waitingList");
                }
            }
        }

        activate();
    }

}());
