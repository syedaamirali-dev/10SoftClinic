(function () {
    'use strict';

    angular
        .module('10softdental')
        .config(routeConfig)

    /** @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider, $locationProvider) {
        $stateProvider

            // login
            // .state({
            //     name: 'login',
            //     url: '/login',
            //     controller: 'loginCtrl',
            //     templateUrl: 'app/components/login/login.html'
            // })
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
            // docTreatInsEmpl
            .state({
                name: 'main.docTreatment.docTreatInsEmpl',
                url: '/docTreatInsEmpl',
                controller: 'docTreatInsEmplCtrl',
                templateUrl: 'app/components/docTreatInsEmpl/docTreatInsEmpl.html'
            })
            // docTreatVisit
            .state({
                name: 'main.docTreatment.docTreatVisit',
                url: '/docTreatVisit',
                controller: 'docTreatVisitCtrl',
                templateUrl: 'app/components/docTreatVisit/docTreatVisit.html'
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
            /** @RouteReplaceForGulp */


        $urlRouterProvider.otherwise("/dashboard");
    }

}());