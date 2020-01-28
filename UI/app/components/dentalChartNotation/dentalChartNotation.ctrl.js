(function(){
    'use strict';

    angular
        .module('10softdental')
        .controller('dentalChartNotationCtrl', dentalChartNotationCtrl)

    /** @ngInject */
    function dentalChartNotationCtrl($scope, dentalChartNotationService){
        activate();

        $scope.chartObject = {
            dzOptions: {
                url: "http://www.mocky.io/v2/5d1f251e310000026aebeb03", //apiCollection.organizationSetup.saveOneTimeSetupDetails(),
                // url: "http://www.mocky.io/v2/5d1f251e310000026aebeb03",
                paramName: 'file',
                maxFilesize: '10',
                acceptedFiles: '.jpg',
                addRemoveLinks: true,
                dictDefaultMessage: 'Drag a file here or click to browse (Only .jpg)',
                dictRemoveFile: 'Remove item',
                dictResponseError: 'Could not upload this item',
                maxFiles: '1',
                autoProcessQueue: false,
                headers: {
                    userId: 1,
                    organizationID: 1
                },
            },
            dzCallbacks: {
                addedfile: function (file) {
                    console.log(file);
                    $scope.chartObject.isFileAdded = true;
                },
                removedfile: function (file) {
                    console.log(file);
                    $scope.chartObject.isFileAdded = false;
                },
                sending: (file, xhr, formData) => {
                    $scope.chartObject.fileUploadLoading = true;

                    if (!formData.has("chartID"))
                        formData.append("chartID", 1);
                    // $scope.entityObject.orgnizationID || 0
                },
                success: function (file, response) {
                    $scope.chartObject.fileUploadLoading = false;

                    console.log(file, response);
                    if (response.status == "Success") {
                        toastr.success(response.data);
                        $scope.chartObject.showUploadForm = false;
                        setOneTimeSetupInGrid();
                        successCallback(4);
                    } else {
                        toastr.error(response.data);
                    }
                },
            },
            dzMethods: {},
            upload: () => {
                if (!$scope.chartObject.isFileAdded) {
                    $scope.chartObject.showFileValidationMsg = true;
                }
                $scope.chartObject.dzMethods.processQueue();
            }            
        }
        function activate(){
        }
    }

}());
      