(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docVisitHistoryCtrl', docVisitHistoryCtrl)

    /** @ngInject */
    function docVisitHistoryCtrl($scope, docVisitHistoryService) {
        $scope.visitHistory = {
            dtOptions: [],
            isLoaded: false
        };

        /**
         * @description Get Visit History Grid Data
         */
        function getvisitHistorytData() {
            $scope.visitHistory.isLoaded = false;
            docVisitHistoryService.getvisitHistorytData().then((data) => {
                $scope.visitHistory.dtOptions = docVisitHistoryService.getDtOptions(data, {});
                $scope.visitHistory.isLoaded = true;
            });
        }


        function activate() {
            getvisitHistorytData();
        }
        activate();

    }

}());
