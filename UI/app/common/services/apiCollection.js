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
        var waitingList = {
            GetWaitingList: function () {
                return apiEndPoint + "Common/GetAllWaitingList";
            },
            GetVisitHistory: function () {
                return apiEndPoint + "Common/GetAllVisitList";
            },
        }

        return {
            login,
            waitingList
        }
    }
}());