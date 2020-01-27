(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docTreatmentCtrl', docTreatmentCtrl)

    /** @ngInject */
    function docTreatmentCtrl($scope, docTreatmentService, $state) {

        var stepUrlInfo = [
            {
                "stepNo": 1,
                "stepUrl": "main.docTreatment.adultPatientSheet"
            },
            {
                "stepNo": 2,
                "stepUrl": "main.docTreatment.docTreatmentInfo"
            },
            {
                "stepNo": 3,
                "stepUrl": "main.docTreatment.docTreatPatient"
            },
            {
                "stepNo": 4,
                "stepUrl": "main.docTreatment.docTreatInsEmpl"
            },
            {
                "stepNo": 5,
                "stepUrl": "main.docTreatment.docMedication"
            },
            {
                "stepNo": 6,
                "stepUrl": "main.docTreatment.docLabReport"
            }
        ];
        /**
         * @description Step Navigation based on stepNumber
         */
        function goToTab(stepNumber) {

            var currentStepUrl = stepUrlInfo.filter((item) => { return item.stepNo == stepNumber }).length > 0
                ? stepUrlInfo.filter((item) => { return item.stepNo == stepNumber })[0].stepUrl
                : "main.docTreatment.adultPatientSheet";
            $state.go(currentStepUrl);
        }


        function activate() {

        }

        activate();

    }

}());
