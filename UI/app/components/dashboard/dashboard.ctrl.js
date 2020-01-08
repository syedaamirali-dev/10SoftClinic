(function () {
    // 'use strict';

    angular
        .module('10softdental')
        .controller('dashboardCtrl', dashboardCtrl)

    /** @ngInject */
    function dashboardCtrl($scope, dashboardService) {

        function getDashboardData() {
            $scope.dashboardDataLoaded = false;
            dashboardService.getDashboardData().then((data) => {
                // $scope.dashboardData = data;
                $scope.dtOptions = dashboardService.getDtOptions(data, { onClick: $scope.onClick });
                $scope.dashboardDataLoaded = true;

                iziToast.success({ title: "Heyyy!", message: "Have you ever seen a toastr like this!"})
            });

        }

        function activate() {
            getDashboardData();
        }

        $scope.onClick = (param) => {
            alert("You clicked " + param);
        }
        activate();
    }

}());