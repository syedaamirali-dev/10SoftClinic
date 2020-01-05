(function () {
    'use strict';

    angular
        .module('10softdental')
        .filter('customDateTime', ['$filter', function ($filter) {
            return function (input) {
                return $filter('date')(new Date(input), 'MMM d, y h:mm a')
            }
        }])
        .filter('customDate', ['$filter', function ($filter) {
            return function (input) {
                return $filter('date')(new Date(input), 'MMM d, y')
            }
        }]);
}());