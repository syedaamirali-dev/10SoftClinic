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
    gulp.src('./assets/sass/style.scss')
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
    return gulp.src(getScripts("app/"))
        .pipe(concat('app.js'))
        .pipe(babel({
            presets: ['@babel/preset-env']
        }))
        .pipe(ngAnnotate({
            add: true
        }))
        .pipe(uglify())
        .pipe(gulp.dest('public'));
})

gulp.task('prod-node-modules-js', function () {

    // // Create new directory
    // .pipe(gulp.dest(componentPath))

    gulp.src([
        "./node_modules/ckeditor/adapters/**/*.*",
        "./node_modules/ckeditor/lang/en.js",
        "./node_modules/ckeditor/plugins/scayt/**/*.*",
        "./node_modules/ckeditor/plugins/tableselection/**/*.*",
        "./node_modules/ckeditor/plugins/wsc/**/*.*",
        "./node_modules/ckeditor/skins/moono-lisa/**/*.*",
        "./node_modules/ckeditor/ckeditor.js",
        "./node_modules/ckeditor/config.js",
        "./node_modules/ckeditor/contents.css",
        "./node_modules/ckeditor/styles.js",
    ], { base: './' })
        .pipe(gulp.dest('public'))

    return gulp.src(getScripts("node_modules").filter(x => !x.includes("ckeditor")))
        .pipe(concat('index.js'))
        .pipe(uglify())
        .pipe(gulp.dest('public/node_modules'))
})

gulp.task('prod-assets-js', function () {
    return gulp.src(getScripts("assets/"))
        .pipe(concat('script.js'))
        .pipe(uglify())
        .pipe(gulp.dest('public/assets/js'))
})

var uglifycss = require('gulp-uglifycss');

gulp.task('prod-node-modules-css', function () {
    gulp.src(["node_modules/@mdi/font/fonts/*.**"])
        .pipe(gulp.dest('public/node_modules/fonts'));

    return gulp.src(getStyles("node_modules"))
        .pipe(concat('index.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('public/node_modules/style'))
})

gulp.task('prod-app-css', function () {

    gulp.src(getStyles("assets/").filter(item => item.includes("portal.css")))
        .pipe(concat('portal.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('public/assets/css'))

    return gulp.src(getStyles("assets/").filter(item => !item.includes("portal.css")))
        .pipe(concat('style.css'))
        .pipe(uglifycss())
        .pipe(gulp.dest('public/assets/css'))
})

gulp.task('images', function () {
    return gulp.src(['assets/images/*'])
        .pipe(gulp.dest('public/assets/images/'));
});

gulp.task('templates', function () {
    let randomString = new Date().getTime();

    gulp.src(['confetti.html'])
        .pipe(gulp.dest('public/'))

    return gulp.src(['app/**/*.html'])
        .pipe(gulp.dest('public/app/'))
        .pipe(tap(function (file) {
            return newfile('index.html', `
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Islamic eLearning</title>
    <link rel="stylesheet" href="assets/css/style.css?${randomString}">
    <link rel="stylesheet" href="node_modules/style/index.css?${randomString}">
    <link rel="stylesheet" href="assets/css/portal.css?${randomString}">
</head>
<body ng-app="10softdental">
    <div ng-show="$root.initialLoading" class="initial-loader">
        <img src="/assets/images/logo-blue.png" alt="">
    </div>
    <ui-view></ui-view>
    <script src="node_modules/index.js?${randomString}"></script>
    <script src="node_modules/ckeditor/ckeditor.js?${randomString}"></script>
    <script src="node_modules/ckeditor/adapters/jquery.js?${randomString}"></script>
    <script src="assets/js/script.js?${randomString}"></script>
    <script src="app.js?${randomString}"></script>
</body>
</html>
            `)
                .pipe(gulp.dest('public'));
        }));
});


gulp.task('prod', gulp.series(
    "prod-app-js",
    "prod-node-modules-js",
    "prod-assets-js",
    "prod-node-modules-css",
    "prod-app-css",
    "images",
    "templates"
));


gulp.task('test', function () {


    console.log(new Date().getTime())


    // return gulp.src('index.1.html')
    //     .pipe(resources({
    //         skipNotExistingFiles: true
    //     }))
    //     .pipe(gulp.dest('./tmp'));
});