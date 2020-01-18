(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('adultPatientSheetCtrl', adultPatientSheetCtrl)

    /** @ngInject */
    function adultPatientSheetCtrl($scope, $document, adultPatientSheetService) {
        activate();
        var arrows;
        /**
         * @Description Initializing Arrows according to RTL design
         */
        if (KTUtil.isRTL()) {
            arrows = {
                leftArrow: '<i class="la la-angle-right"></i>',
                rightArrow: '<i class="la la-angle-left"></i>'
            }
        } else {
            arrows = {
                leftArrow: '<i class="la la-angle-left"></i>',
                rightArrow: '<i class="la la-angle-right"></i>'
            }
        }
        /**
         * @description Initializing DatePicker options
         */
        function initializeDatePicker() {
            // input group layout 
            $('#kt_datepicker_2, #kt_datepicker_2_validate').datepicker({
                rtl: KTUtil.isRTL(),
                todayHighlight: true,
                todayBtn: "linked",
                clearBtn: true,
                orientation: "bottom left",
                templates: arrows
            });

            // input group layout for modal demo
            $('#kt_datepicker_2_modal').datepicker({
                rtl: KTUtil.isRTL(),
                todayHighlight: true,
                todayBtn: "linked",
                clearBtn: true,
                orientation: "bottom left",
                templates: arrows
            });
        }
        
        function activate() {
            $document.ready(function () {
                initializeDatePicker()
            });
        }
    }

}());
