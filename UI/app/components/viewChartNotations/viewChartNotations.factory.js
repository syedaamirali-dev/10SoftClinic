(function(){
    'use strict';

    angular
        .module('10softdental')
        .factory('viewChartNotationsService', viewChartNotationsService)

    /** @ngInject */
    function viewChartNotationsService(apiCollection, $q, $http){
        var service = {
            getViewChartData,
            getDtOptions
        };
        function getDtOptions(data, functions) {
            return {
                data: data.table,
                columns: [
                    { title: 'Notation Name', data: 'iconNameEn' },
                    { title: 'Descripition', data: 'descriptionEn' },
                    { title: 'Icon', data: 'imageUrl' }                    
                    // { title: 'Actions', data: 'visitRegisterId' },
                ],
                columnDefs: [
                    {
                        targets: 2,
                            render: function(data) {
                              return '<img src="'+data+'">'
                            },
                         
                        // targets: 1,
                        // render: function (data, type, row) {
                        //     if (type === 'display') {
                        //         data = '<a class="kt-link kt-link--brand kt-font-bolder btn-redirect">Add Treatment</a>'
                        //     }
                        //     return data;
                        // },
                        fnCreatedCell: (nTd, cellData, rowData, row, col) => {
                            $(nTd).find(".btn-redirect").on("click", () => {
                                functions.pageRedirect(cellData)
                            });
                        }
                    }
                ]
            }
        }
        function getViewChartData() {
            return httpGet(apiCollection.viewChartList.GetViewChartNotationList(), true);
        }
        function httpGet(url, isRefresh) {
            let defer = $q.defer();
            // if (isRefresh) {
            //     $cacheFactory.get("$http").remove(url);
            // }
            $http.get(url, { cache: false }).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
        }
        return service;
    }

}());
    