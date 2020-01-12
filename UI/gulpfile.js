var gulp = require('gulp'),
    tap = require('gulp-tap'),
    newfile = require('gulp-file'),
    replace = require('gulp-replace'),
    gap = require('gulp-append-prepend');

var rename = require('gulp-rename');


/*
 * 
 * CONSTANTS
 * 
 */

var componentPath = "./app/components/";
var moduleName = '10softdental';

/*
 * 
 * TASK: Creates a new component ( with controller, view, factory & SASS files) and adds references as well :D
 * 
 */

gulp.task('gen-page', function () {
    var componentName = process.argv[process.argv.length - 1];
    componentName = componentName.substr(2, componentName.length - 1);
    componentPath = componentPath + componentName;
    gulp.src('*.*', { read: false })

        // Create new directory
        .pipe(gulp.dest(componentPath))

        // Create Controller
        .pipe(tap(function (file) {
            return newfile(componentName + '.ctrl.js', controllerContent(moduleName, componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create View
        .pipe(tap(function (file) {
            return newfile(componentName + '.html', viewContent(componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create Factory
        .pipe(tap(function (file) {
            return newfile(componentName + '.factory.js', factoryContent(moduleName, componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create SASS
        .pipe(tap(function (file) {
            return newfile('_' + componentName + '.scss', sassContent(componentName))
                .pipe(gulp.dest(componentPath));
        }));

    // update style.scss
    gulp.src('./assets/sass/app.scss')
        .pipe(gap.appendText(mainSassContent(componentName)))
        .pipe(gulp.dest('./assets/sass'))

    // Add route for the component
    gulp.src('./app/app.route.js')
        .pipe(replace('/** @RouteReplaceForGulp */', routeReplaceContent(componentName)))
        .pipe(gulp.dest('./app/'))

    // Add script tags in index.html
    return gulp.src(['index.html'])
        .pipe(replace('</body>', indexReplaceContent(componentName)))
        .pipe(gulp.dest('./'));
});

/*
 * 
 * TASK: Creates a new directive ( with controller, view, factory & SASS files) and adds references as well :D
 * ** Incomplete!!! **
 */

gulp.task('gen-drv', function () {
    var componentName = process.argv[process.argv.length - 1];
    componentName = componentName.substr(2, componentName.length - 1);
    componentPath = componentPath + componentName;
    gulp.src('*.*', { read: false })

        // Create new directory
        .pipe(gulp.dest(componentPath))

        // Create Controller
        .pipe(tap(function (file) {
            return newfile(componentName + '.ctrl.js', controllerContent(moduleName, componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create View
        .pipe(tap(function (file) {
            return newfile(componentName + '.html', viewContent(componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create Factory
        .pipe(tap(function (file) {
            return newfile(componentName + '.factory.js', factoryContent(moduleName, componentName))
                .pipe(gulp.dest(componentPath));
        }))

        // Create SASS
        .pipe(tap(function (file) {
            return newfile('_' + componentName + '.scss', sassContent(componentName))
                .pipe(gulp.dest(componentPath));
        }));

    // update main.scss
    gulp.src('./assets/sass/main.scss')
        .pipe(gap.appendText(mainSassContent(componentName)))
        .pipe(gulp.dest('./assets/sass'))

    // Add route for the component
    gulp.src('./app/app.route.js')
        .pipe(replace('/** @RouteReplaceForGulp */', routeReplaceContent(componentName)))
        .pipe(gulp.dest('./app/'))

    // Add script tags in index.html
    return gulp.src(['index.html'])
        .pipe(replace('</body>', indexReplaceContent(componentName)))
        .pipe(gulp.dest('./'));
});


/*
 * 
 * FUNCTIONS
 * 
 */

controllerContent = function (moduleName, componentName) {
    return `(function(){
    'use strict';

    angular
        .module('${moduleName}')
        .controller('${componentName}Ctrl', ${componentName}Ctrl)

    /** @ngInject */
    function ${componentName}Ctrl($scope, ${componentName}Service){
        activate();

        function activate(){
        }
    }

}());
      `;
}

factoryContent = function (moduleName, componentName) {
    return `(function(){
    'use strict';

    angular
        .module('${moduleName}')
        .factory('${componentName}Service', ${componentName}Service)

    /** @ngInject */
    function ${componentName}Service(apiCollection, $q, $http){
        var service = {

        };

        return service;
    }

}());
    `;
}

routeReplaceContent = function (componentName) {
    return `// ${componentName}
            .state({
                name: 'main.${componentName}',
                url: '/${componentName}',
                controller: '${componentName}Ctrl',
                templateUrl: 'app/components/${componentName}/${componentName}.html'
            })
            /** @RouteReplaceForGulp */`;
}

indexReplaceContent = function (componentName) {
    return `
    <!-- Page - ${componentName} -->
    <script src="./app/components/${componentName}/${componentName}.ctrl.js"></script>
    <script src="./app/components/${componentName}/${componentName}.factory.js"></script>

</body>`;
}

viewContent = function (componentName) {
    return `
    <div id="${componentName}" class="kt-container kt-container--fluid  kt-grid__item kt-grid__item--fluid">
</div>`;
}

sassContent = function (componentName) {
    return `#${componentName} {
    border: 5px solid green; 
}`;
}

mainSassContent = function (componentName) {
    return `
// ${componentName}
@import "../.${componentPath + '/' + componentName}";
`;
}





/**
 * @TASK MINIFY
 */


var concat = require('gulp-concat');
var babel = require('gulp-babel');
var ngAnnotate = require('gulp-ng-annotate');
var uglify = require('gulp-uglify');

function getScripts(type) {
    let fs = require('fs');
    let DomParser = require('dom-parser');
    let parser = new DomParser();

    let fileContent = fs.readFileSync("index.html", "utf8");
    fileContent = fileContent.replace(/<!--(.*?)-->/gm, "");
    let indexFile = parser.parseFromString(fileContent);

    let scriptTags = indexFile.getElementsByTagName("script");


    let nodeModules = scriptTags.filter((element) => {
        return element.getAttribute("src") && element.getAttribute("src").includes(type);
    });

    return nodeModules.map((item => item.getAttribute("src")));
}

function getStyles(type) {
    let fs = require('fs');
    let DomParser = require('dom-parser');
    let parser = new DomParser();

    let fileContent = fs.readFileSync("index.html", "utf8");
    fileContent = fileContent.replace(/<!--(.*?)-->/gm, "");
    let indexFile = parser.parseFromString(fileContent);

    let scriptTags = indexFile.getElementsByTagName("link");

    let nodeModules = scriptTags.filter((element) => {
        return element.getAttribute("href").includes(type);
    });

    return nodeModules.map((item => item.getAttribute("href")));
}

gulp.task('prod-app-js', function () {
    return gulp.src(getScripts("app/"), { allowEmpty: true })
        .pipe(concat('app.js'))
        .pipe(babel({
            presets: ['@babel/preset-env']
        }))
        .pipe(ngAnnotate({
            add: true
        }))
        .pipe(uglify())
        .pipe(gulp.dest('dist'));
})

gulp.task('prod-node-modules-js', function () {

    // // Create new directory
    // .pipe(gulp.dest(componentPath))

    // gulp.src([
    //     "./node_modules/ckeditor/adapters/**/*.*",
    //     "./node_modules/ckeditor/lang/en.js",
    //     "./node_modules/ckeditor/plugins/scayt/**/*.*",
    //     "./node_modules/ckeditor/plugins/tableselection/**/*.*",
    //     "./node_modules/ckeditor/plugins/wsc/**/*.*",
    //     "./node_modules/ckeditor/skins/moono-lisa/**/*.*",
    //     "./node_modules/ckeditor/ckeditor.js",
    //     "./node_modules/ckeditor/config.js",
    //     "./node_modules/ckeditor/contents.css",
    //     "./node_modules/ckeditor/styles.js",
    // ], { base: './' })
    //     .pipe(gulp.dest('dist'))

    return gulp.src(getScripts("node_modules"))
        .pipe(concat('index.js'))
        .pipe(uglify())
        .pipe(gulp.dest('dist/node_modules'))
})

gulp.task('prod-assets-js', function () {

    return gulp.src("assets/**/*.*")
        // .pipe(concat('index.js'))
        // .pipe(uglify())
        .pipe(gulp.dest('dist/assets/'))
})

var uglifycss = require('gulp-uglifycss');

gulp.task('prod-node-modules-css', function () {
    gulp.src(["node_modules/@mdi/font/fonts/*.**"])
        .pipe(gulp.dest('dist/node_modules/fonts'));

    return gulp.src(getStyles("node_modules"))
        .pipe(concat('index.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('dist/node_modules/style'))
})

gulp.task('prod-app-css', function () {

    gulp.src(getStyles("assets/").filter(item => item.includes("portal.css")))
        .pipe(concat('portal.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('dist/assets/css'))

    return gulp.src(getStyles("assets/").filter(item => !item.includes("portal.css")))
        .pipe(concat('style.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('dist/assets/css'))
})

gulp.task('app-templates', function () {
    let randomString = new Date().getTime();

    // gulp.src(['index.html'])
    //     .pipe(gulp.dest('dist/'))

    return gulp.src(['app/**/*.html'])
        .pipe(gulp.dest('dist/app/'))
        .pipe(tap(function (file) {
            return newfile('index.html', `
            <!DOCTYPE html>

<!--
Template Name: Metronic - Responsive Admin Dashboard Template build with Twitter Bootstrap 4 & Angular 8
Author: KeenThemes
Website: http://www.keenthemes.com/
Contact: support@keenthemes.com
Follow: www.twitter.com/keenthemes
Dribbble: www.dribbble.com/keenthemes
Like: www.facebook.com/keenthemes
Purchase: http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes
Renew Support: http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes
License: You must have a valid license purchased only from themeforest(the above link) in order to legally use the theme for your project.
-->
<html lang="en">

<!-- begin::Head -->

<head>
    <base href="">
    <meta charset="utf-8" />
    <title>10 Soft Dental</title>
    <meta name="description" content="Updates and statistics">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--begin::Fonts -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700">

    <!--end::Fonts -->

    <!--begin::Page Vendors Styles(used by this page) -->

    <!--end::Page Vendors Styles -->

    <!--begin::Global Theme Styles(used by all pages) -->

    <!--begin:: Vendor Plugins -->
    <link href="assets/plugins/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/tether/dist/css/tether.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-datetime-picker/css/bootstrap-datetimepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-select/dist/css/bootstrap-select.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/select2/dist/css/select2.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/ion-rangeslider/css/ion.rangeSlider.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/nouislider/distribute/nouislider.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/owl.carousel/dist/assets/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/owl.carousel/dist/assets/owl.theme.default.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/dropzone/dist/dropzone.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/quill/dist/quill.snow.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/@yaireo/tagify/dist/tagify.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/summernote/dist/summernote.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/bootstrap-markdown/css/bootstrap-markdown.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/general/animate.css/animate.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/toastr/build/toastr.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/dual-listbox/dist/dual-listbox.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/morris.js/morris.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/sweetalert2/dist/sweetalert2.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/plugins/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/plugins/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/plugins/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet"
        type="text/css" />

    <!--end:: Vendor Plugins -->
    <link href="assets/css/style.bundle.css" rel="stylesheet" type="text/css" />

    <!--begin:: Vendor Plugins for custom pages -->
    <link href="assets/plugins/custom/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/@fullcalendar/core/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/@fullcalendar/daygrid/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/@fullcalendar/list/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/@fullcalendar/timegrid/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/datatables.net-bs4/css/dataTables.bootstrap4.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-buttons-bs4/css/buttons.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-autofill-bs4/css/autoFill.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-colreorder-bs4/css/colReorder.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-fixedcolumns-bs4/css/fixedColumns.bootstrap4.min.css"
        rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/datatables.net-fixedheader-bs4/css/fixedHeader.bootstrap4.min.css"
        rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/datatables.net-keytable-bs4/css/keyTable.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-rowgroup-bs4/css/rowGroup.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-rowreorder-bs4/css/rowReorder.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-scroller-bs4/css/scroller.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/datatables.net-select-bs4/css/select.bootstrap4.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/custom/jstree/dist/themes/default/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/jqvmap/dist/jqvmap.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/uppy/dist/uppy.min.css" rel="stylesheet" type="text/css" />

    <!--end:: Vendor Plugins for custom pages -->

    <!--end::Global Theme Styles -->

    <!--begin::Layout Skins(used by all pages) -->
    <link href="assets/css/skins/header/base/light.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/skins/header/menu/light.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/skins/brand/dark.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/skins/aside/dark.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="./node_modules/style/index.css">

    <!--end::Layout Skins -->
    <link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
</head>

<!-- end::Head -->

<!-- begin::Body -->

<body ng-app="10softdental"
    class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--fixed kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-page--loading">

    <ui-view></ui-view>
    <div class="main-loader-wrapper" ng-show="$root.pageLoading">
        <div class="lds lds-hourglass"></div>
    </div>
    <!--ENd:: Chat-->

    <!-- begin::Global Config(global config for global JS sciprts) -->
    <script>
        var KTAppOptions = {
            "colors": {
                "state": {
                    "brand": "#5d78ff",
                    "dark": "#282a3c",
                    "light": "#ffffff",
                    "primary": "#5867dd",
                    "success": "#34bfa3",
                    "info": "#36a3f7",
                    "warning": "#ffb822",
                    "danger": "#fd3995"
                },
                "base": {
                    "label": [
                        "#c5cbe3",
                        "#a1a8c3",
                        "#3d4465",
                        "#3e4466"
                    ],
                    "shape": [
                        "#f0f3ff",
                        "#d9dffa",
                        "#afb4d4",
                        "#646c9a"
                    ]
                }
            }
        };
    </script>

    <!-- end::Global Config -->

    <!--begin::Global Theme Bundle(used by all pages) -->

    <!--begin:: Vendor Plugins -->
    <script src="./assets/plugins/general/jquery/dist/jquery.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/wnumb/wNumb.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/bootstrap-datepicker.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-timepicker/js/bootstrap-timepicker.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/bootstrap-timepicker.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-maxlength/src/bootstrap-maxlength.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/plugins/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/bootstrap-switch.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/select2/dist/js/select2.full.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/handlebars/dist/handlebars.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/inputmask/dist/inputmask/inputmask.date.extensions.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/inputmask/dist/inputmask/inputmask.numeric.extensions.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/nouislider/distribute/nouislider.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/autosize/dist/autosize.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/dropzone/dist/dropzone.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/dropzone.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/quill/dist/quill.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/@yaireo/tagify/dist/tagify.polyfills.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/@yaireo/tagify/dist/tagify.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/summernote/dist/summernote.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/markdown/lib/markdown.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/bootstrap-markdown.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/bootstrap-notify.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/jquery-validation.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/toastr/build/toastr.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/dual-listbox/dist/dual-listbox.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/raphael/raphael.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/morris.js/morris.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/plugins/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/plugins/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/counterup/jquery.counterup.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/js/global/integration/plugins/sweetalert2.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery.repeater/src/lib.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/jquery.repeater/src/repeater.js" type="text/javascript"></script>
    <script src="./assets/plugins/general/dompurify/dist/purify.js" type="text/javascript"></script>

    <!--end:: Vendor Plugins -->
    <script src="./assets/js/scripts.bundle.js" type="text/javascript"></script>

    <!--begin:: Vendor Plugins for custom pages -->
    <script src="./assets/plugins/custom/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/core/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/daygrid/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/google-calendar/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/interaction/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/list/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/@fullcalendar/timegrid/main.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/gmaps/gmaps.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/dist/es5/jquery.flot.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.resize.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.categories.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.pie.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.stack.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.crosshair.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/flot/source/jquery.flot.axislabels.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net/js/jquery.dataTables.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-bs4/js/dataTables.bootstrap4.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/js/global/integration/plugins/datatables.init.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-autofill/js/dataTables.autoFill.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-autofill-bs4/js/autoFill.bootstrap4.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/jszip/dist/jszip.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/pdfmake/build/pdfmake.min.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/pdfmake/build/vfs_fonts.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons/js/dataTables.buttons.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons/js/buttons.colVis.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons/js/buttons.flash.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons/js/buttons.html5.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-buttons/js/buttons.print.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-colreorder/js/dataTables.colReorder.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-fixedcolumns/js/dataTables.fixedColumns.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-keytable/js/dataTables.keyTable.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-responsive/js/dataTables.responsive.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-rowgroup/js/dataTables.rowGroup.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-rowreorder/js/dataTables.rowReorder.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-scroller/js/dataTables.scroller.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/datatables.net-select/js/dataTables.select.min.js"
        type="text/javascript"></script>
    <script src="./assets/plugins/custom/jstree/dist/jstree.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/jquery.vmap.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/maps/jquery.vmap.world.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/maps/jquery.vmap.russia.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/maps/jquery.vmap.usa.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/maps/jquery.vmap.germany.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/jqvmap/dist/maps/jquery.vmap.europe.js" type="text/javascript"></script>
    <script src="./assets/plugins/custom/uppy/dist/uppy.min.js" type="text/javascript"></script>

    <!--end:: Vendor Plugins for custom pages -->

    <!--end::Global Theme Bundle -->

    <!--begin::Page Vendors(used by this page) -->
    <script src="//maps.google.com/maps/api/js?key=AIzaSyBTGnKT7dt597vo9QgeQ7BFhvSRP4eiMSM"
        type="text/javascript"></script>

    <!--end::Page Vendors -->

    <!--begin::Page Scripts(used by this page) -->
    <script src="./assets/js/pages/dashboard.js" type="text/javascript"></script>

    <!--end::Page Scripts -->


    <!-- NODE MODULES -->
    <script src="./node_modules/index.js"></script>
    <!-- /. NODE MODULES -->
    
    <!-- ASSETS -->
    <!-- <script src="./assets/js/script.js"></script> -->
    <!-- /. ASSETS -->
    
    <!-- App -->
    <script src="app.js"></script>
    
</body>

<!-- end::Body -->

</html>
            `)
                .pipe(gulp.dest('dist'));
        }));
});


gulp.task('prod', gulp.series(
    "prod-app-js", //
    "prod-node-modules-js", //
    "prod-assets-js", //
    "prod-node-modules-css", //
    "app-templates" //
));


gulp.task('test', function () {


    console.log(new Date().getTime())


    // return gulp.src('index.1.html')
    //     .pipe(resources({
    //         skipNotExistingFiles: true
    //     }))
    //     .pipe(gulp.dest('./tmp'));
});