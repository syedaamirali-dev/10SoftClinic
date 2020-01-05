(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('layoutCtrl', layoutCtrl)

    /** @ngInject */
    function layoutCtrl($scope, $state, layoutService, $rootScope, $window, $cacheFactory, $transitions, $timeout, $uibModal) {

        $scope.$state = $state;

        $scope.toggleSidebar = () => {
            $(".sidebar-offcanvas").toggleClass("active");
        }
        $rootScope.logout = function () {
            let ls = new SecureLS();
            ls.remove("elearningUserDetails");
            $rootScope.userDetails = "";
            $cacheFactory.get("$http").removeAll();
            $state.go("login");
            window.location.reload()
        }
        $scope.menuLoaded = false;
        layoutService.getMenu().then(function (data) {
            $scope.menuItems = data;
            $scope.menuLoaded = true;

            if (isAccessDenied($state.current.name)) {
                $state.go($scope.menuItems.filter(x => x.isVisible == 1)[0].url);
                console.warn("Access denied");
            }
            $transitions.onStart({}, function (trans) {
                if (isAccessDenied(trans.to().name)) {
                    trans.abort();
                    console.warn("Access denied");
                }
            });


            // $timeout(() => {
            //     startIntro()
            // });
        });

        function isAccessDenied(name) {
            if (["login", "main.myProfile"].includes(name)) {
                return false;
            }
            return $scope.menuItems.filter(
                (item) => { return item.isVisible == "1" && name.includes(item.url) }
            ).length == 0;
        }

        // Utility function to open URL in a new tab
        $rootScope.openLink = (url) => {
            $window.open(url, "_blank");
        }

        // $rootScope.origin = window.location.origin;
        $rootScope.origin = "http://10softdental.com";
        $rootScope.isUndefined = (value) => {
            return value === undefined;
        };


        // INTRO
        function startIntro() {
            ngIntroService.clear();
            ngIntroService.setOptions({
                steps: [
                    {
                        element: "#Courses",
                        intro: "Click here to see all courses",
                        position: "right"
                    },
                    {
                        element: "#addCourse",
                        intro: "Click here to add a course",
                        position: "right"
                    },
                ]
            });
            ngIntroService.start();
        }


        // Open video in popup
        $rootScope.openIframeModal = (url) => {
            $scope.modalInstanceReadMore = $uibModal.open({
                animation: true,
                template: `<iframe src="${url}" height="500" allowFullScreen="allowFullScreen"></iframe>`,
                scope: $scope,
                size: 'lg',
                appendTo: undefined,
                resolve: {}
            });

            $scope.modalInstanceReadMore.result.then(function (selectedItem) {
                console.log("Salam")
            }, function () {
                // When modal is closed without using the close button
                console.log("Byee");
            });
        }
    }
}());