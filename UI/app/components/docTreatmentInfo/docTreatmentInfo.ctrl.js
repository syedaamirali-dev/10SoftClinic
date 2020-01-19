(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docTreatmentInfoCtrl', docTreatmentInfoCtrl)

    /** @ngInject */
    function docTreatmentInfoCtrl($scope, docTreatmentInfoService) {
        activate();
        $scope.Submit = () => {
            swal.fire({
                title: "Data Submitted",
                text: "Data Saved Successfully!",
                type: "success",
                showConfirmButton: false,
                timer: 2000
            });
        }
        function activate() {
        }
    }

}());
