(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('layoutService', layoutService)

    /** @ngInject */
    function layoutService(apiCollection, $q, $http, $rootScope) {
        var service = {
            getMenu: getMenu
        };

        function getMenu() {
            // let defer = $q.defer();
            // $http.get(apiCollection.user.getMenus($rootScope.userDetails.id)).then(function (response) {
            //     defer.resolve(response.data);
            // });
            // return defer.promise;
        }

        return service;
    }

}());
