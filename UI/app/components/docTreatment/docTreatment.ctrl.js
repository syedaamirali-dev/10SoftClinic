(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('docTreatmentCtrl', docTreatmentCtrl)

    /** @ngInject */
    function docTreatmentCtrl($scope, docTreatmentService, $state, $document) {
        $scope.currentStepNumber = null;
        /**
         * @description Initializing Dynamic array to set active class on breadcrumb
         */
        $scope.activeStepClass = []
        /**
         * @description Step Navigation based on stepNumber
         */
        function goToTab() {
            $scope.currentStepNumber = wizard.getStep();
            switch (parseInt($scope.currentStepNumber)) {
                case 1:
                    $state.go('main.docTreatment.adultPatientSheet');
                    break;
                case 2:
                    $state.go('main.docTreatment.docTreatPatient');
                    break;
                case 3:
                    $state.go('main.docTreatment.docTreatInsEmpl');
                    break;
                case 4:
                    $state.go('main.docTreatment.docTreatVisit');
                    break;
                default:
                    $state.go('main.docTreatment.adultPatientSheet');
                    break;
            }
            $scope.activeStepClass = [
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 1
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 2
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 3
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 4
                }
            ];
        }

        /**
         * @description Initialize Current step Object according to state
         */
        function setCurrentStepNumber() {
            switch ($state.current.name) {
                case "main.docTreatment.adultPatientSheet":
                    $scope.currentStepNumber = 1;
                    break;
                case "main.docTreatment.docTreatPatient":
                    $scope.currentStepNumber = 2;
                    break;
                case "main.docTreatment.docTreatInsEmpl":
                    $scope.currentStepNumber = 3;
                    break;
                case "main.docTreatment.docTreatVisit":
                    $scope.currentStepNumber = 4;
                    break;
                default:
                    $scope.currentStepNumber = 1;
                    break;
            }
            $scope.activeStepClass = [
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 1
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 2
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 3
                },
                {
                    'kt-subheader__breadcrumbs-link--active': $scope.currentStepNumber == 4
                }
            ];
            wizard.goTo($scope.currentStepNumber, true);
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
