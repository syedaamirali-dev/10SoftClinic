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
            /** @RouteReplaceForGulp */

        $urlRouterProvider.when("/my-courses", "/my-courses/");
        $urlRouterProvider.otherwise("/dashboard");
    }

}());