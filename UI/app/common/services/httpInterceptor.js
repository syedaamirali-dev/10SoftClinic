(function () {
    'use strict';

    angular
        .module('10softdental')
        .service('httpInterceptor', httpInterceptor)

    /** @ngInject */
    function httpInterceptor($rootScope, $log, $q, $state, $cacheFactory) {

        var xhrCreations = 0;
        var xhrResolutions = 0;

        $rootScope.pageLoading = false;
        $rootScope.inProgress = false;
        $rootScope.notificationsNumber = 0;
        $rootScope.notifications = false;
        $rootScope.initialLoading = false;

        function isLoading() {
            // console.log(xhrResolutions, " ", xhrCreations)
            return xhrResolutions < xhrCreations;
            // if (xhrResolutions < xhrCreations) {
            //     return true;
            // }
            // else {
            //     xhrCreations = 0;
            //     xhrResolutions = 0;
            //     return false;
            // }
        }

        function updateStatus() {
            $rootScope.pageLoading = isLoading();
        }

        return {
            request: function (config) {

                if ($rootScope.userDetails) {
                    config.headers.Authorization = $rootScope.userDetails.accessToken;
                    config.headers.userId = $rootScope.userDetails.userId;
                }
                if (!config.url.includes('showLoader=false')) {
                    xhrCreations++;
                    updateStatus();
                }

                if (config.url == "app/components/layout/layout.html") {
                    $rootScope.initialLoading = true;
                }

                return config;
            },
            requestError: function (rejection) {
                xhrResolutions++;
                updateStatus();
                $log.error('Request error:', rejection);
                return $q.reject(rejection);
            },
            response: function (response) {
                xhrResolutions++;
                updateStatus();

                if (response.data == "Access Denied") {
                    $rootScope.logout();
                    // toastr.warning("Login to continue");
                }

                if (response.data.status == "success" && response.data.data) {
                    iziToast.success({ title: response.data.dataTitle || "", message: response.data.data })
                }
                else if (response.data.status == "failed" && response.data.data) {
                    iziToast.error({ title: response.data.dataTitle || "", message: response.data.data })
                }
                else if (response.data.status == "warning" && response.data.data) {
                    iziToast.warning({ title: response.data.dataTitle || "", message: response.data.data });
                }

                if (response.config.url == "app/components/layout/layout.html") {
                    $rootScope.initialLoading = false;
                }
                return response;
            },
            responseError: function (rejection) {
                xhrResolutions++;
                updateStatus();
                if (rejection.data) {
                    iziToast.error({ message: rejection.data });
                }

                $log.error('Response error:', rejection);
                return $q.reject(rejection);
            }
        };
    }

}());