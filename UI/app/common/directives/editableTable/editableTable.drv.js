(function () {
    'use strict';

    angular
        .module('10softdental')
        .directive('editableTable', editableTable)

    /** @ngInject */
    function editableTable($window, $timeout) {
        function link(scope, element) {


            scope.options.minRecords = scope.options.minRecords || 0;

            scope.addRow = () => {

                scope.options.currentPage = Math.ceil(scope.data.length + 1 / scope.options.pageLength);
                scope.data.push({});
                $timeout(() => {
                    //console.log(element);
                    element.find("tbody tr:last-child td:first-child").children().focus()
                }, 100);
                if (scope.formInstance) {
                    scope.formInstance.$setDirty();
                }
                /*var dateColumns = scope.options.columns.filter((item) => item.type.name == 'date')
                var datePickerIdList = []
                dateColumns.forEach((item) => {
                    var columnPosition = item.$$hashKey;
                    datePickerIdList.push((scope.data.length-1) + "" + (parseInt(columnPosition.substr(columnPosition.length - 2, 2)) - 11));
                });
                $timeout(
                    () => {
                        datePickerIdList.forEach((datePickerId) => {
                            console.log('#kt_datepicker' + datePickerId);
                            console.log($('#kt_datepicker' + datePickerId));
                            $('#kt_datepicker' + datePickerId).datepicker({
                                rtl: KTUtil.isRTL(),
                                todayHighlight: true,
                                todayBtn: "linked",
                                clearBtn: true,
                                orientation: "bottom left",
                                templates: {
                                    leftArrow: '<i class="la la-angle-left"></i>',
                                    rightArrow: '<i class="la la-angle-right"></i>'
                                }
                            });
                        });
                    }, 500);*/
            };

            scope.removeRow = (index) => {
                index += scope.options.pageLength * (scope.options.currentPage - 1);
                //console.log(scope.data[index]);
                if (scope.data.length > scope.options.minRecords) {
                    scope.data.splice(index, 1);
                    if (scope.formInstance) {
                        scope.formInstance.$setDirty();
                    }
                }
            }

            scope.options.saveGrid = () => {
                return scope.data;
            }

            // /**
            //  * @desc Used when duplicate selections are not allowed on options
            //  * @param option each option of the select
            //  * @param columnProperty property name of the column
            //  */
            // scope.isOptionSelected = (option, columnProperty) => {
            ////     // console.log(option, columnProperty);
            //     return scope.data.map(item => item[columnProperty]).includes(option);
            ////     // console.log(selectedOptions);
            // }

            scope.options.columns.forEach((column, i) => {
                if (column.type.name == "select" && column.type.unique) {
                    column.selectedValues = scope.data.map(item => item[column.data])
                }
            });

            scope.optionChanged = (newValue, oldValue, row, column) => {
                //console.log("Changed: newValue: ", newValue, ", oldValue: ", oldValue);
                if (column.selectedValues) {
                    if (column.selectedValues.includes(newValue)) {
                        row[column.data] = isNaN(oldValue) ? oldValue : Number.parseInt(oldValue);
                        toastr.warning(column.title + " already exists.")
                    }
                    else {
                        column.selectedValues = scope.data.map(item => item[column.data])
                        if (typeof column.onChange == "function") {
                            column.onChange({
                                newValue,
                                oldValue,
                                row,
                                column
                            });
                        }
                    }
                }
                else {
                    if (typeof column.onChange == "function") {
                        column.onChange({
                            newValue,
                            oldValue,
                            row,
                            column
                        });
                    }
                }
            }

            // scope.data.forEach((element, i) => {
            //     scope.$watch(() => { return element }, (newValue, oldValue) => {
            //         if (!_.isEqual(newValue, oldValue)) {
            //             newValue.changed = true;
            ////             console.log("Data changed >>> ", newValue, oldValue);
            //         }
            //     }, true);
            // });

            scope.options.pageLength = 6;

            // bodyHeight = $('.tab-content')[0].offsetHeight;
            let bodyHeight = $window.innerHeight;

            if (bodyHeight <= 864) {
                scope.options.pageLength = 6;
            }
            else if (bodyHeight <= 1080) {
                scope.options.pageLength = 6;
            }
            else if (bodyHeight <= 1440) {
                scope.options.pageLength = 10;
            }
            else if (bodyHeight <= 2160) {
                scope.options.pageLength = 20;
            }

            scope.options.currentPage = 1;

        }

        return {
            // bindToController: true,
            // controller: editableTableController,
            // controllerAs: 'Ctrl',
            link: link,
            restrict: 'AE',
            scope: {
                data: '=',
                options: '=',
                heading: '@',
                formInstance: '=',
            },
            templateUrl: "app/common/directives/editableTable/editableTable.html"

        }
    }

}());