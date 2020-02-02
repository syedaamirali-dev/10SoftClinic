(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docVisitCtrl', docVisitCtrl)

    /** @ngInject */
    function docVisitCtrl($scope, docVisitService) {
        $scope.visitHistory = {
            dtOptions: [],
            isLoaded: false
        };

        /**
         * @description Get Visit History Grid Data
         */
        function getvisitHistorytData() {
            $scope.visitHistory.isLoaded = false;
            docVisitService.getvisitHistorytData().then((data) => {
                $scope.visitHistory.dtOptions = docVisitService.getDtOptions(data, {});
                $scope.visitHistory.isLoaded = true;
            });
        }


        function activate() {
            getvisitHistorytData();
        }
        activate();

    }

}());
