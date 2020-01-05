(function () {
    // 'use strict';

    angular
        .module('10softdental')
        .controller('dashboardCtrl', dashboardCtrl)

    /** @ngInject */
    function dashboardCtrl($scope,dashboardService) {

        function getDashboardData() {
            $scope.dashboardDataLoaded = false;
            dashboardService.getDashboardData().then((data) => {
                $scope.dashboardData = data;
                $scope.dashboardDataLoaded = true;
            });
        }

        function activate(){
            getDashboardData();
        }
        // activate();
    }

}());