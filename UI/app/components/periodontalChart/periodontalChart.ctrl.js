(function(){
    'use strict';

    angular
        .module('10softdental')
        .controller('periodontalChartCtrl', periodontalChartCtrl)

    /** @ngInject */
    function periodontalChartCtrl($scope, periodontalChartService){
        console.log("Salam");
        
        activate();

        function activate(){
        }
    }

}());
      