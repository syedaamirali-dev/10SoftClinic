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

            $timeout(function () {
                // if ($.fn.DataTable.isDataTable('#' + scope.tid)) {
                //     $('#' + scope.tid).dataTable().fnClearTable();
                //     if (scope.options.data.length > 0)
                //         $('#' + scope.tid).dataTable().fnAddData(scope.options.data);
                //     return;
                // }
                let tableOptions = {
                    dom: '<"row"<"col-sm-12 col-md-6"f><"col-sm-12 col-md-6"l>>t<"d-flex justify-content-between" <"" i><"d-flex" p>>',
                    // data: scope.options.data,
                    // columns: scope.options.columns,
                    // columnDefs: scope.options.columnDefs,
                    // reponsive: true,
                    // drawCallback: function () {
                    //     if (typeof (scope.options.drawCallback) == "function") {
                    //         scope.options.drawCallback();
                    //     }
                    // },
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
                let table = $('#' + scope.tid).DataTable($.extend(true, tableOptions, scope.options));
                table.on('draw', function () {
                    $('[data-toggle="popover"]').popover();
                    // console.log($('[data-toggle="popover"]'));
                });
            });
            // scope.$watch('loaded', () => {
            //     console.log(scope.loaded)
            //     if (!scope.loaded)
            //         return
            // });

            scope.filterTable = () => {
                $('#' + scope.tid).dataTable().api().search(scope.filterTerm).draw();
            }
        }
    }
}());