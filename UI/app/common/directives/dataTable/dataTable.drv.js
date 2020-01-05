(function () {
    'use strict';

    angular
        .module('10softdental')
        .directive('customDataTable', customDataTable);

    /** @ngInject */
    function customDataTable($timeout, $window) {

        var directive = {
            link: link,
            restrict: 'A',
            scope: {
                tid: '@',
                options: '=',
                loaded: '='
            },
            templateUrl: "app/common/directives/dataTable/dataTable.html",
            transclude: true
        }

        return directive;

        function link(scope, element) {
            scope.pageLength = 10;

            // scope.resolution = $window.innerHeight;

            // if (scope.resolution <= 1080) {
            //     scope.pageLength = 20;
            // }
            // else if (scope.resolution <= 1440) {
            //     scope.pageLength = 25;
            // }

            // angular.element($window).bind('resize', function () {
            //     // Get heigh of .page-body

            //     console.log("Resized ", $window.innerHeight);
            // });

            scope.$watch('loaded', () => {
                console.log(scope.loaded)
                if (!scope.loaded)
                    return
                $timeout(function () {
                    if ($.fn.DataTable.isDataTable('#' + scope.tid)) {
                        $('#' + scope.tid).dataTable().fnClearTable();
                        if (scope.options.data.length > 0)
                            $('#' + scope.tid).dataTable().fnAddData(scope.options.data);
                        return;
                    }
                    let tableOptions = {
                        data: scope.options.data,
                        columns: scope.options.columns,
                        columnDefs: scope.options.columnDefs,
                        reponsive: true,
                        drawCallback: function () {
                            if (typeof (scope.options.drawCallback) == "function") {
                                scope.options.drawCallback();
                            }
                        },
                        // rowReorder: scope.options.rowReorder
                    };
                    if (scope.options.printButton) {
                        $.extend(tableOptions, {
                            dom: 'Btip',
                            buttons: [
                                {
                                    "extend": 'print',
                                    "text": '',
                                    "className": 'btn float-right',
                                    "exportOptions": {
                                        "columns": scope.options.exportColumns
                                    }
                                }
                            ]
                        })
                    }
                    let table = $('#' + scope.tid).DataTable(tableOptions);
                    table.on('draw', function () {
                        $('[data-toggle="popover"]').popover();
                        // console.log($('[data-toggle="popover"]'));
                    });
                });
            });

            scope.filterTable = () => {
                $('#' + scope.tid).dataTable().api().search(scope.filterTerm).draw();
            }
        }
    }
}());