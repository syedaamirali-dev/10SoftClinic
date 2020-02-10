(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('childPatientSheetCtrl', childPatientSheetCtrl)

    /** @ngInject */
    function childPatientSheetCtrl($scope, $document, $timeout, childPatientSheetService) {
        $scope.periodontalImg = {
            tb1: [
                "17", "16", "15", "14", "13", "12", "11"
            ],
            tb2: [
                "21", "22", "23", "24", "25", "26", "27"
            ],
            tb3: [
                "5_1", "5_2", "55", "54", "53", "52", "51"
            ],
            tb4: [
                "61", "62", "63", "64", "65", "6_6", "6_7"
            ],
            tb5: [
                "47", "46", "45", "44", "43", "42", "41"
            ],
            tb6: [
                "31", "32", "33", "34", "35", "36", "37"
            ],
            tb7: [
                "8_1", "8_2", "85", "84", "83", "82", "81"
            ],
            tb8: [
                "71", "72", "73", "74", "75", "7_6", "7_7"
            ]
        }
        let periodontalImageObject = {
            clicked: "",
            selected: ""
        };
        $scope.legendInfoObject = {
            showLegend: false,
            hideLegends: () => {
                $scope.legendInfoObject.showLegend = false;
                if (periodontalImageObject.clicked) {
                    periodontalImageObject.clicked.currentTarget.classList.remove("periodontal-legend-active");
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
                    console.log($event);
                    periodontalImageObject.clicked.currentTarget.classList.add("periodontal-legend-active");
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
                    periodontalImageObject.clicked.currentTarget.innerHTML = `<img src="${periodontalImageObject.selected}" class="img-fluid" />`;
                }
                $scope.legendInfoObject.hideLegends();
            },
            resetLegend: () => {
                periodontalImageObject.clicked.currentTarget.innerHTML = `${periodontalImageObject.clicked.currentTarget.title}`;
            }
        }
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
