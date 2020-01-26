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
            forgotPassword: () => apiEndPoint + "UserReg/forgotPassword",
            updatePassword: () => apiEndPoint + "UserReg/updatePassword",
        }
        var waitingList = {
            GetWaitingList: function () {
                return apiEndPoint + "Common/GetAllWaitingList";
            },

        }
        var doctorTreatment = {
            GetVisitHistory: function () {
                return apiEndPoint + "Common/GetAllVisitList";
            },
            SaveDiagnosis: () => apiEndPoint + "Common/SaveDiagnosis",
            GetDiagnosisDetails: () => apiEndPoint + "Common/GetDiagnosisDetails"
        }

        return {
            login,
            waitingList,
            doctorTreatment
        }
    }
}());