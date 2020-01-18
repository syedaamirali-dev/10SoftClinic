(function(){
    'use strict';

    angular
        .module('10softdental')
        .controller('waitingListCtrl', waitingListCtrl)

    /** @ngInject */
    function waitingListCtrl($scope, waitingListService){

        function getWaitingList() {
            $scope.waitingDataLoaded = false;
            waitingListService.getWaitingListData().then((data) => {
                // $scope.dashboardData = data;
                $scope.dtOptions = waitingListService.getDtOptions(data, { onClick: $scope.onClick });
                $scope.waitingDataLoaded = true;

                iziToast.success({ title: "Heyyy!", message: "Have you ever seen a toastr like this!"})
            });

        }

        activate();

        function activate(){
            getWaitingList();
        }
        $scope.onClick = (param) => {
            alert("You clicked " + param);
        }
    }

}());
      