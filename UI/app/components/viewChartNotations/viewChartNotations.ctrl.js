(function(){
    'use strict';

    angular
        .module('10softdental')
        .controller('viewChartNotationsCtrl', viewChartNotationsCtrl)

    /** @ngInject */
    function viewChartNotationsCtrl($scope, viewChartNotationsService){

        function getViewChartList() {
            $scope.viewChartLoaded = false;
            viewChartNotationsService.getViewChartData().then((data) => {
                // $scope.dashboardData = data;
                $scope.dtOptions = viewChartNotationsService.getDtOptions(data, { pageRedirect: $scope.pageRedirect });
                $scope.viewChartLoaded = true;

                // iziToast.success({ title: "Heyyy!", message: "Have you ever seen a toastr like this!" })
            });

        } 
        activate();

        function activate(){
            getViewChartList();
        }
    }

}());
      