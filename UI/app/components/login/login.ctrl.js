(function () {
    'use strict';

    angular
        .module('10softdental')
        .controller('loginCtrl', loginCtrl)

    /** @ngInject */
    function loginCtrl($scope, $rootScope, $state, $timeout, loginService) {
        let ls = new SecureLS();
        $scope.loginPage = "signIn";

        $scope.userInfo = {
            validateUser: () => {
                $scope.loadingLogin = true;
                loginService.validateUser($scope.userInfo).then((result) => {
                    if (result.access_token) {
                        $rootScope.userDetails = result;
                        $scope.loadingLogin = false;
                        ls.set('softDentalUserDetails', $rootScope.userDetails);
                    if ($scope.rememberMe) {
                        ls.set('softDentalLoginDetails', { userName: $scope.userInfo.userName, password: $scope.userInfo.password });
                    }
                    else {
                        ls.remove('softDentalLoginDetails');
                    }
                    $rootScope.isLayout = true;
                    $state.go("main.dashboard");
                    }
                });
                // $timeout(() => {
                //     $scope.loadingLogin = false;
                //     // $rootScope.userDetails = {
                //     //     "accessTocken": "54f86s1fas68fsf6f4f54sa6f6asfds6f6",
                //     //     "userName": "abdullah",
                //     //     "FirstName": "Abdullah",
                //     //     "LastName": "Bin Ahmed",
                //     //     "Role": "Admin"
                //     // }
                //     ls.set('softDentalUserDetails', $rootScope.userDetails);
                //     if ($scope.rememberMe) {
                //         ls.set('softDentalLoginDetails', { userName: $scope.userInfo.userName, password: $scope.userInfo.password });
                //     }
                //     else {
                //         ls.remove('softDentalLoginDetails');
                //     }
                //     $rootScope.isLayout = true;
                //     $state.go("main.dashboard");
                // }, 3000);

            },
            forgotPassword: () => {
                if ($scope.userInfo.forgotEmail) {
                    iziToast.success({ message:"Password recovery instruction has been sent to your email."});
                }
                $scope.loginPage = "signIn";
            }
        }

        function activate() {
            let userlogin = ls.get('softDentalLoginDetails');
            if (userlogin) {
                $scope.userInfo.userName = userlogin.userName;
                $scope.userInfo.password = userlogin.password;
                $scope.rememberMe = true;
            }
        }

        activate();
    }


}());