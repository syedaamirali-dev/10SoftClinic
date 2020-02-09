(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('adultPatientSheetCtrl', adultPatientSheetCtrl)

    /** @ngInject */
    function adultPatientSheetCtrl($scope, $document, $timeout, adultPatientSheetService) {
        let periodontalImageObject = {
            clicked: "",
            selected: ""
        };
        $scope.periodontalImg = {
            tb1: [
                "18", "17", "16", "15", "14", "13", "12", "11"
            ],
            tb2: [
                "21", "22", "23", "24", "25", "26", "27", "28"
            ],
            tb3: [
                "18b", "17b", "16b", "15b", "14b", "13b", "12b", "11b"
            ],
            tb4: [
                "21b", "22b", "23b", "24b", "25b", "26b", "27b", "28b"
            ],
            tb5: [
                "48", "47", "46", "45", "44", "43", "42", "41"
            ],
            tb6: [
                "31", "32", "33", "34", "35", "36", "37", "38"
            ],
            tb7: [
                "48b", "47b", "46b", "45b", "44b", "43b", "42b", "41b"
            ],
            tb8: [
                "31b", "32b", "33b", "34b", "35b", "36b", "37b", "38b"
            ]
        }

        $scope.legendInfoObject = {
            showLegend: false,
            hideLegends: () => {
                $scope.legendInfoObject.showLegend = false;
                if (periodontalImageObject.clicked) {
                    periodontalImageObject.clicked.target.classList.remove("periodontal-legend-active");
                }
                periodontalImageObject = {
                    clicked: "",
                    selected: ""
                }
            },
            showLegends: ($event) => {
                // console.log($event.target.src, ", Event ", $event);
                $scope.legendInfoObject.hideLegends();
                $timeout(() => {
                    $scope.legendInfoObject.showLegend = true;
                    periodontalImageObject.clicked = $event;
                    periodontalImageObject.clicked.target.classList.add("periodontal-legend-active");
                }, 200);
            },
            legendInfo: [
                {
                    name: "Metal Crown",
                    image: "assets/media/images/legnd-1.jpeg"
                },
                {
                    name: "Implant",
                    image: "assets/media/images/legnd-2.jpeg"
                },
                {
                    name: "Missing Tooth(NotReq. intevention)",
                    image: "assets/media/images/legnd-3.jpeg"
                },
                {
                    name: "Missing Tooth(Req. intervention)",
                    image: "assets/media/images/legnd-4.jpeg"
                },
                {
                    name: "Composite Restoration",
                    image: "assets/media/images/legnd-5.jpeg"
                },
                {
                    name: "Improper Root Canal Filling",
                    image: "assets/media/images/legnd-6.jpeg"
                },
            ],
            selectImage: (param) => {
                periodontalImageObject.selected = $scope.legendInfoObject.legendInfo[param].image;
            },
            changeImage: () => {
                if (periodontalImageObject.selected) {
                    periodontalImageObject.clicked.target.src = periodontalImageObject.selected;
                }
                $scope.legendInfoObject.hideLegends();
            },
            resetLegend: () => {
                periodontalImageObject.clicked.target.src = `${location.origin}/assets/media/periodontal-Images/${periodontalImageObject.clicked.target.alt}.png`;
            }
        }

        $scope.periodontalData = {};
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

            $document.ready(function () {
                $('#kt_datepicker_2').datepicker({
                    rtl: KTUtil.isRTL(),
                    todayHighlight: true,
                    todayBtn: "linked",
                    clearBtn: true,
                    orientation: "bottom left",
                    templates: {
                        leftArrow: '<i class="la la-angle-left"></i>',
                        rightArrow: '<i class="la la-angle-right"></i>'
                    }
                });
            });
        }

        activate();
    }

}());
