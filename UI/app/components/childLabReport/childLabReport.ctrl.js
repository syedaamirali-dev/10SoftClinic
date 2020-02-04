(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('childLabReportCtrl', childLabReportCtrl)

    /** @ngInject */
    function childLabReportCtrl($scope, $timeout, childLabReportService) {
        $scope.labReport = {
            dtOptions: [],
            isLoaded: false
        };
        $scope.labReportInfo =
        {
            labRequestList: [],
            reportTypeList: [],
            prefferedLabList: [],
            gridData: [],
            reset: () => {
                $scope.labReportInfo.lrRequest = null;
                $scope.labReportInfo.reportType = null;
                $scope.labReportInfo.preferredLab = null;
                $scope.labReportInfo.comments = null;
            },
            Submit: () => {

                $scope.labReportInfo.gridData.push({
                    lrRequest: $scope.labReportInfo.lrRequest,
                    reportType: $scope.labReportInfo.reportType,
                    reportTypeName: $scope.labReportInfo.reportTypeList.filter((item) => { return item.id == $scope.labReportInfo.reportType })[0].name,
                    preferredLab: $scope.labReportInfo.preferredLab,
                    comments: $scope.labReportInfo.comments,
                    reportStatus: "Requested",
                    report: null
                });
                $scope.labReportInfo.reset();
                getLabReportData();
                swal.fire({
                    title: "Data Submitted",
                    text: "Data Saved Successfully!",
                    type: "success",
                    showConfirmButton: false,
                    timer: 2000
                });
            }
        }

        /**
         * @description Get Lab Report Grid Data
         */
        function getLabReportData() {
            $scope.labReport.isLoaded = false;
            // childLabReportService.getLabReportData().then((data) => {
            $timeout(() => {
                $scope.labReportInfo.labRequestList = [
                    {
                        id: "LR"
                    },
                ];
                $scope.labReportInfo.reportTypeList = [
                    {
                        id: "BR",
                        name: "Blood Report"
                    },
                    {
                        id: "Dental",
                        name: "Dental Report"
                    },
                    {
                        id: "Inventory",
                        name: "Inventory Report"
                    },
                ];
                $scope.labReportInfo.prefferedLabList = [
                    {
                        id: "Instrument",
                    },
                    {
                        id: "Medical Laboratory",
                    },
                    {
                        id: "Pathology Lab",
                    },
                ];
                $scope.labReport.dtOptions = childLabReportService.getDtOptions($scope.labReportInfo.gridData, {});
                $scope.labReport.isLoaded = true;
            }, 1500);

            // });
        }


        function activate() {
            getLabReportData();
        }
        activate();
    }

}());
