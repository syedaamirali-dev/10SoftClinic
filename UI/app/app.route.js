(function () {
    'use strict';

    angular
        .module('10softdental')
        .config(routeConfig)

    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider, $locationProvider) {
        $stateProvider

            // login
            .state({
                name: 'login',
                url: '/login',
                controller: 'loginCtrl',
                templateUrl: 'app/components/login/login.html'
            })
            // layout
            .state({
                name: 'main',
                controller: 'layoutCtrl',
                templateUrl: 'app/components/layout/layout.html',
                abstract: true
            })
            // dashboard
            .state({
                name: 'main.dashboard',
                url: '/dashboard',
                controller: 'dashboardCtrl',
                templateUrl: 'app/components/dashboard/dashboard.html'
            })
            // periodontalChart
            .state({
                name: 'main.periodontalChart',
                url: '/periodontalChart',
                controller: 'periodontalChartCtrl',
                templateUrl: 'app/components/periodontalChart/periodontalChart.html'
            })
            // adultPatientSheet
            .state({
                name: 'main.docTreatment.adultPatientSheet',
                url: '/adultPatientSheet',
                controller: 'adultPatientSheetCtrl',
                templateUrl: 'app/components/adultPatientSheet/adultPatientSheet.html'
            })
            // docTreatment
            .state({
                name: 'main.docTreatment',
                url: '/docTreatment',
                controller: 'docTreatmentCtrl',
                templateUrl: 'app/components/docTreatment/docTreatment.html'
            })
            // waitingList
            .state({
                name: 'main.waitingList',
                url: '/waitingList',
                controller: 'waitingListCtrl',
                templateUrl: 'app/components/waitingList/waitingList.html'
            })
            // docTreatPatient
            .state({
                name: 'main.docTreatment.docTreatPatient',
                url: '/docTreatPatient',
                controller: 'docTreatPatientCtrl',
                templateUrl: 'app/components/docTreatPatient/docTreatPatient.html'
            })
            // docTreatmentInfo
            .state({
                name: 'main.docTreatment.docTreatmentInfo',
                url: '/docTreatmentInfo',
                controller: 'docTreatmentInfoCtrl',
                templateUrl: 'app/components/docTreatmentInfo/docTreatmentInfo.html'
            })
            // docVisitHistory
            .state({
                name: 'main.docVisitHistory',
                url: '/docVisitHistory',
                controller: 'docVisitHistoryCtrl',
                templateUrl: 'app/components/docVisitHistory/docVisitHistory.html'
            })
            // docLabReport
            .state({
                name: 'main.docTreatment.docLabReport',
                url: '/docLabReport',
                controller: 'docLabReportCtrl',
                templateUrl: 'app/components/docLabReport/docLabReport.html'
            })
            // docMedication
            .state({
                name: 'main.docTreatment.docMedication',
                url: '/docMedication',
                controller: 'docMedicationCtrl',
                templateUrl: 'app/components/docMedication/docMedication.html'
            })
            // childPatientSheet
            .state({
                name: 'main.docTreatmentchild.childPatientSheet',
                url: '/childPatientSheet',
                controller: 'childPatientSheetCtrl',
                templateUrl: 'app/components/childPatientSheet/childPatientSheet.html'
            })
            // dentalChartNotation
            .state({
                name: 'main.dentalChartNotation',
                url: '/dentalChartNotation',
                controller: 'dentalChartNotationCtrl',
                templateUrl: 'app/components/dentalChartNotation/dentalChartNotation.html'
            })
            // docTreatmentchild
            .state({
                name: 'main.docTreatmentchild',
                url: '/docTreatmentchild',
                controller: 'docTreatmentchildCtrl',
                templateUrl: 'app/components/docTreatmentchild/docTreatmentchild.html'
            })
            // childHistory
            .state({
                name: 'main.docTreatmentchild.childHistory',
                url: '/childHistory',
                controller: 'childHistoryCtrl',
                templateUrl: 'app/components/childHistory/childHistory.html'
            })
            // childClinical
            .state({
                name: 'main.docTreatmentchild.childClinical',
                url: '/childClinical',
                controller: 'childClinicalCtrl',
                templateUrl: 'app/components/childClinical/childClinical.html'
            })
            // childOcclusion
            .state({
                name: 'main.docTreatmentchild.childOcclusion',
                url: '/childOcclusion',
                controller: 'childOcclusionCtrl',
                templateUrl: 'app/components/childOcclusion/childOcclusion.html'
            })
        /** @RouteReplaceForGulp */


        $urlRouterProvider.otherwise("/dashboard");
    }

}());