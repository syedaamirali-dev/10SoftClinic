(function () {
    'use strict';

    angular
        .module('10softdental')
        .factory('dashboardService', dashboardService)

    /** @ngInject */
    function dashboardService(apiCollection, $http, $q) {
        var service = {
            getDashboardData,
            getDtOptions
        };

        function getDtOptions(data, functions) {
            return {
                data,
                columns: [
                    { title: 'id', data: 'id' },
                    { title: 'first_name', data: 'first_name' },
                    { title: 'last_name', data: 'last_name' },
                    { title: 'email', data: 'email' },
                    { title: 'gender', data: 'gender' },
                    { title: 'ip_address', data: 'ip_address' },
                    { title: 'Actions', data: 'id' },
                ],
                columnDefs: [
                    {
                        targets: 6,
                        render: (data, type, row) => {
                            return `
                            <button class="btn btn-sm btn-primary">Action</button>
                            `;
                        },
                        fnCreatedCell: (nTd, cellData, rowData, row, col) => {
                            $(nTd).find(".btn").on("click", () => {
                                functions.onClick(cellData)
                            });
                        }
                    }
                ]
            }
        }
        function getDashboardData() {
            return httpGet("http://www.mocky.io/v2/5e16275034000084ea406a12");
        }

        function httpPost(url, data) {
            let defer = $q.defer();
            $http.post(url, data).then(function (response) {
                defer.resolve(response.data);
            });
            return defer.promise;
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
