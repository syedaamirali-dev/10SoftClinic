(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('waitingListCtrl', waitingListCtrl)

    /** @ngInject */
    function waitingListCtrl($scope, $state, waitingListService) {

        function getWaitingList() {
            $scope.waitingDataLoaded = false;
            waitingListService.getWaitingListData().then((data) => {
                // $scope.dashboardData = data;
                $scope.dtOptions = waitingListService.getDtOptions(data, { pageRedirect: $scope.pageRedirect });
                $scope.waitingDataLoaded = true;

                // iziToast.success({ title: "Heyyy!", message: "Have you ever seen a toastr like this!" })
            });

        }

        $scope.pageRedirect = (rowParam) => {
            Swal.fire({
                title: "",
                text: "",
                type: "question",
                showCancelButton: true,
                confirmButtonColor: "#5d78ff",
                cancelButtonColor: "#5d78ff",
                confirmButtonText: "Adult",
                cancelButtonText: "Child"
            }).then(result => {
                if (result.value) {
                    $state.go("main.docTreatment.adultPatientSheet");
                }
                else {
                    $state.go("main.childPatientSheet");
                }
                return;
            });
        }

        function activate() {
            getWaitingList();
        }

        activate();

    }

}());
