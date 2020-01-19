(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docTreatmentCtrl', docTreatmentCtrl)

    /** @ngInject */
    function docTreatmentCtrl($scope, docTreatmentService, $state, $document) {
        var currentStep;
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
                "stepUrl": "main.docTreatment.docTreatVisit"
            },
            {
                "stepNo": 6,
                "stepUrl": "main.docTreatment.docMedication"
            },
            {
                "stepNo": 7,
                "stepUrl": "main.docTreatment.docLabReport"
            },
        ];
        /**
         * @description Step Navigation based on stepNumber
         */
        function goToTab() {
            currentStep = wizard.getStep();
            var currentStepUrl = stepUrlInfo.filter((item) => { return item.stepNo == currentStep }).length > 0
                ? stepUrlInfo.filter((item) => { return item.stepNo == currentStep })[0].stepUrl
                : "main.docTreatment.adultPatientSheet";
            $state.go(currentStepUrl);
        }

        /**
         * @description Initialize Current step Object according to state
         */
        function setCurrentStepNumber() {

            currentStep = stepUrlInfo.filter((item) => { return item.stepUrl == $state.current.name }).length > 0
                ? stepUrlInfo.filter((item) => { return item.stepUrl == $state.current.name })[0].stepNo
                : 1;
            wizard.goTo(currentStep, true);
            goToTab();
        }

        /** Start: Stepper Configuration */
        // Base elements
        var wizardEl;
        var formEl;
        var validator;
        var wizard;

        // Private functions
        var initWizard = function (callback) {
            // Initialize form wizard
            wizard = new KTWizard('kt_wizard_v3', {
                startStep: 1, // initial active step number
                clickableSteps: true  // allow step clicking
            });

            // Validation before going to next page
            wizard.on('beforeNext', function (wizardObj) {
                // if (validator.form() !== true) {
                // 	wizardObj.stop();  // don't go to the next step
                // }
            });

            wizard.on('beforePrev', function (wizardObj) {
                // if (validator.form() !== true) {
                // 	wizardObj.stop();  // don't go to the next step
                // }

            });
            // Validation after going to next page
            wizard.on('afterNext', function (wizardObj) {
                goToTab();
            });

            wizard.on('afterPrev', function (wizardObj) {
                goToTab();
            });

            // Change event
            wizard.on('change', function (wizard) {
                KTUtil.scrollTop();
            });
            callback();
        }

        var initValidation = function () {
            validator = formEl.validate({
                // Validate only visible fields
                ignore: ":hidden",

                // Validation rules
                rules: {
                    //= Step 1
                    address1: {
                        required: true
                    },
                    postcode: {
                        required: true
                    },
                    city: {
                        required: true
                    },
                    state: {
                        required: true
                    },
                    country: {
                        required: true
                    },

                    //= Step 2
                    package: {
                        required: true
                    },
                    weight: {
                        required: true
                    },
                    width: {
                        required: true
                    },
                    height: {
                        required: true
                    },
                    length: {
                        required: true
                    },

                    //= Step 3
                    delivery: {
                        required: true
                    },
                    packaging: {
                        required: true
                    },
                    preferreddelivery: {
                        required: true
                    },

                    //= Step 4
                    locaddress1: {
                        required: true
                    },
                    locpostcode: {
                        required: true
                    },
                    loccity: {
                        required: true
                    },
                    locstate: {
                        required: true
                    },
                    loccountry: {
                        required: true
                    },
                },

                // Display error
                invalidHandler: function (event, validator) {
                    KTUtil.scrollTop();

                    swal.fire({
                        "title": "",
                        "text": "There are some errors in your submission. Please correct them.",
                        "type": "error",
                        "confirmButtonClass": "btn btn-secondary"
                    });
                },

                // Submit valid form
                submitHandler: function (form) {

                }
            });
        }

        var initSubmit = function () {
            var btn = formEl.find('[data-ktwizard-type="action-submit"]');

            btn.on('click', function (e) {
                e.preventDefault();

                if (validator.form()) {
                    // See: src\js\framework\base\app.js
                    KTApp.progress(btn);
                    //KTApp.block(formEl);

                    // See: http://malsup.com/jquery/form/#ajaxSubmit
                    formEl.ajaxSubmit({
                        success: function () {
                            KTApp.unprogress(btn);
                            //KTApp.unblock(formEl);

                            swal.fire({
                                "title": "",
                                "text": "The application has been successfully submitted!",
                                "type": "success",
                                "confirmButtonClass": "btn btn-secondary"
                            });
                        }
                    });
                }
            });
        }
        /**  End: Stepper Configuration */

        function activate() {
            $document.ready(function () {
                wizardEl = KTUtil.get('kt_wizard_v3');
                formEl = $('#kt_form');

                initWizard(() => { setCurrentStepNumber(); });
            });
        }

        activate();

    }

}());
