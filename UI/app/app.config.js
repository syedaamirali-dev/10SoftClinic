(function () {
    'use strict';

    angular
        .module('10softdental')
        .config(appConfig)
        .run(runConfig)
        .filter('smartSearch', ['$filter', function ($filter) {
            return function (collection, keywords) {
                if (!keywords) {
                    return collection;
                } else {
                    keywords = keywords.split(" ");
                    $.each(keywords, function (k, v) {
                        collection = $filter('filter')(collection, { $: v });
                    });
                    return collection;
                }
            }
        }]);

    /** @ngInject */
    function appConfig($httpProvider, $logProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
        $logProvider.debugEnabled(true);
    }

    /** @ngInject */
    function runConfig($transitions, $state, $rootScope) {
        let ls = new SecureLS();

        $rootScope.userDetails = ls.get('softDentalUserDetails');

        iziToast.settings({
            timeout: 8000,
            position: "topRight",
            progressBarEasing: "ease-out",
            transitionOut: "flipOutX"
        });

        // $transitions.onStart({}, function (trans) {
        //     // If user is not logged in, redirect to login page
        //     if ($rootScope.userDetails == "" && !["login", "updatePassword"].includes(trans.to().name)) {
        //         iziToast.warning({ message: "You must login to continue." });
        //         $state.go("login");
        //     }
        // });

        $rootScope.util = utilities;
    }

}());