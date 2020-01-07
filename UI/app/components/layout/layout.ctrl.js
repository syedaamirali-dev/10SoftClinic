(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('layoutCtrl', layoutCtrl)

    /** @ngInject */
    function layoutCtrl($scope, $state, layoutService, $rootScope, $window, $cacheFactory, $transitions, $timeout, $uibModal) {

        $scope.$state = $state;

        // $scope.toggleSidebar = () => {
        //     $(".sidebar-offcanvas").toggleClass("active");
        // }
        // $rootScope.logout = function () {
        //     let ls = new SecureLS();
        //     ls.remove("softDentalUserDetails");
        //     $rootScope.userDetails = "";
        //     $cacheFactory.get("$http").removeAll();
        //     $state.go("login");
        //     window.location.reload()
        // }
        // $scope.menuLoaded = false;
        // layoutService.getMenu().then(function (data) {
        //     $scope.menuItems = data;
        //     $scope.menuLoaded = true;
        // });
    }
}());