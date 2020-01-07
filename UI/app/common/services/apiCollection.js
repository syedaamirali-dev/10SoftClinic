(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('apiCollection', apiCollection);
    /** @ngInject */

    function apiCollection(apiEndPoint) {
        var login = {
            validateUser: function () {
                return apiEndPoint + "UserReg/login";
            },
            studentRegister: function () {
                return apiEndPoint + "UserReg/register";
            },
            forgotPassword: () => apiEndPoint + "UserReg/forgotPassword",
            updatePassword: () => apiEndPoint + "UserReg/updatePassword",
        }

        return {
            login
        }
    }
}());