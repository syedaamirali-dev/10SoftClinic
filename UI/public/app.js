(function () {
  'use strict';

  angular.module('10softdental', ['ui.router', 'ui.bootstrap', // 'ngAnimate',
  // 'ngSweetAlert',
  // 'ui.sortable',
  // 'angular-intro',
  'ngSanitize' // 'angularjs-dropdown-multiselect'
  ]);
})();

(function () {
  'use strict';

  routeConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider"];
  angular.module('10softdental').config(routeConfig);
  /** @ngInject */

  function routeConfig($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider // login
    // .state({
    //     name: 'login',
    //     url: '/login',
    //     controller: 'loginCtrl',
    //     templateUrl: 'app/components/login/login.html'
    // })
    // layout
    .state({
      name: 'main',
      controller: 'layoutCtrl',
      templateUrl: 'app/components/layout/layout.html',
      abstract: true
    }) // dashboard
    .state({
      name: 'main.dashboard',
      url: '/dashboard',
      controller: 'dashboardCtrl',
      templateUrl: 'app/components/dashboard/dashboard.html'
    }) // periodontalChart
    .state({
      name: 'main.periodontalChart',
      url: '/periodontalChart',
      controller: 'periodontalChartCtrl',
      templateUrl: 'app/components/periodontalChart/periodontalChart.html'
    });
    /** @RouteReplaceForGulp */

    $urlRouterProvider.when("/my-courses", "/my-courses/");
    $urlRouterProvider.otherwise("/dashboard");
  }
})();

(function () {
  'use strict';

  appConfig.$inject = ["$httpProvider", "$logProvider"];
  runConfig.$inject = ["$transitions", "$state", "$rootScope"];
  angular.module('10softdental').config(appConfig).run(runConfig);
  /** @ngInject */

  function appConfig($httpProvider, $logProvider) {
    $httpProvider.interceptors.push('httpInterceptor');
    $logProvider.debugEnabled(true);
  }
  /** @ngInject */


  function runConfig($transitions, $state, $rootScope) {
    let ls = new SecureLS();
    $rootScope.userDetails = ls.get('softDentalUserDetails');
    iziToast.settings({
      timeout: 8000,
      position: "topRight",
      progressBarEasing: "ease-out",
      transitionOut: "flipOutX"
    }); // $transitions.onStart({}, function (trans) {
    //     // If user is not logged in, redirect to login page
    //     if ($rootScope.userDetails == "" && !["login", "updatePassword"].includes(trans.to().name)) {
    //         iziToast.warning({ message: "You must login to continue." });
    //         $state.go("login");
    //     }
    // });

    $rootScope.util = utilities;
  }
})();

(function () {
  'use strict';

  httpInterceptor.$inject = ["$rootScope", "$log", "$q", "$state", "$cacheFactory"];
  angular.module('10softdental').service('httpInterceptor', httpInterceptor);
  /** @ngInject */

  function httpInterceptor($rootScope, $log, $q, $state, $cacheFactory) {
    var xhrCreations = 0;
    var xhrResolutions = 0;
    $rootScope.pageLoading = false;
    $rootScope.inProgress = false;
    $rootScope.notificationsNumber = 0;
    $rootScope.notifications = false;
    $rootScope.initialLoading = false;

    function isLoading() {
      // console.log(xhrResolutions, " ", xhrCreations)
      return xhrResolutions < xhrCreations; // if (xhrResolutions < xhrCreations) {
      //     return true;
      // }
      // else {
      //     xhrCreations = 0;
      //     xhrResolutions = 0;
      //     return false;
      // }
    }

    function updateStatus() {
      $rootScope.pageLoading = isLoading();
    }

    return {
      request: function (config) {
        if ($rootScope.userDetails) {
          config.headers.Authorization = $rootScope.userDetails.accessToken;
          config.headers.userId = $rootScope.userDetails.userId;
        }

        if (!config.url.includes('showLoader=false')) {
          xhrCreations++;
          updateStatus();
        }

        if (config.url == "app/components/layout/layout.html") {
          $rootScope.initialLoading = true;
        }

        return config;
      },
      requestError: function (rejection) {
        xhrResolutions++;
        updateStatus();
        $log.error('Request error:', rejection);
        return $q.reject(rejection);
      },
      response: function (response) {
        xhrResolutions++;
        updateStatus();

        if (response.data == "Access Denied") {
          $rootScope.logout(); // toastr.warning("Login to continue");
        }

        if (response.data.status == "success" && response.data.data) {
          iziToast.success({
            title: response.data.dataTitle || "",
            message: response.data.data
          });
        } else if (response.data.status == "failed" && response.data.data) {
          iziToast.error({
            title: response.data.dataTitle || "",
            message: response.data.data
          });
        } else if (response.data.status == "warning" && response.data.data) {
          iziToast.warning({
            title: response.data.dataTitle || "",
            message: response.data.data
          });
        }

        if (response.config.url == "app/components/layout/layout.html") {
          $rootScope.initialLoading = false;
        }

        return response;
      },
      responseError: function (rejection) {
        xhrResolutions++;
        updateStatus();

        if (rejection.data) {
          iziToast.error({
            message: rejection.data
          });
        }

        $log.error('Response error:', rejection);
        return $q.reject(rejection);
      }
    };
  }
})();

(function () {
  'use strict';

  angular.module('10softdental').constant('apiEndPoint', "http://localhost/be-10softdental/api/"); // .constant('apiEndPoint', "http://localhost:3000/api/")
  // .constant('apiEndPoint', "http://dev-api.10softdental.com/api/")
  // BEWARE USING THIS. PRODUCTION API
  //  .constant('apiEndPoint', "http://api.10softdental.com/api/")
})();

(function () {
  'use strict';

  apiCollection.$inject = ["apiEndPoint"];
  angular.module('10softdental').factory('apiCollection', apiCollection);
  /** @ngInject */

  function apiCollection(apiEndPoint) {
    var login = {
      validateUser: function () {
        return apiEndPoint + "UserReg/login";
      },
      studentRegister: function () {
        return apiEndPoint + "UserReg/register";
      },
      forgotPassword: () => apiEndPoint + "UserReg/forgotPassword",
      updatePassword: () => apiEndPoint + "UserReg/updatePassword"
    };
    return {
      login
    };
  }
})();

var utilities = {
  formatDate: dateStr => {
    let date = new Date(dateStr);
    date = date.toString().split(" ");
    return date[1] + " " + date[2] + ", " + date[3];
  },
  formatTime: dateTimeStr => {
    let date = new Date(dateTimeStr);
    date = date.toString().split(" ");
    return date[4];
  },
  formatDateTime: dateTimeStr => {
    return `${utilities.formatDate(dateTimeStr)} @ ${utilities.formatTime(dateTimeStr)}`;
  },
  slugify: text => {
    if (!text) {
      return "";
    }

    return text.toString().toLowerCase().replace(/\s+/g, '-') // Replace spaces with -
    .replace(/[^\w\-]+/g, '') // Remove all non-word chars
    .replace(/\-\-+/g, '-') // Replace multiple - with single -
    .replace(/^-+/, '') // Trim - from start of text
    .replace(/-+$/, ''); // Trim - from end of text
  },
  viewDriveImage: url => {
    if (url.startsWith("https://drive.google.com")) {
      return url.replace("open", "uc");
    }

    return url;
  }
};

(function () {
  'use strict';

  angular.module('10softdental').filter('customDateTime', ['$filter', function ($filter) {
    return function (input) {
      return $filter('date')(new Date(input), 'MMM d, y h:mm a');
    };
  }]).filter('customDate', ['$filter', function ($filter) {
    return function (input) {
      return $filter('date')(new Date(input), 'MMM d, y');
    };
  }]);
})();

(function () {
  // 'use strict';
  dashboardCtrl.$inject = ["$scope", "dashboardService"];
  angular.module('10softdental').controller('dashboardCtrl', dashboardCtrl);
  /** @ngInject */

  function dashboardCtrl($scope, dashboardService) {
    function getDashboardData() {
      $scope.dashboardDataLoaded = false;
      dashboardService.getDashboardData().then(data => {
        $scope.dashboardData = data;
        $scope.dashboardDataLoaded = true;
      });
    }

    function activate() {
      getDashboardData();
    } // activate();

  }
})();

(function () {
  'use strict';

  dashboardService.$inject = ["apiCollection", "$http", "$q"];
  angular.module('10softdental').factory('dashboardService', dashboardService);
  /** @ngInject */

  function dashboardService(apiCollection, $http, $q) {
    var service = {
      getDashboardData
    };

    function getDashboardData() {
      return httpGet(apiCollection.user.getDashboardData());
    }

    function httpPost(url, data) {
      let defer = $q.defer();
      $http.post(url, data).then(function (response) {
        defer.resolve(response.data);
      });
      return defer.promise;
    }

    function httpGet(url, isRefresh) {
      let defer = $q.defer(); // if (isRefresh) {
      //     $cacheFactory.get("$http").remove(url);
      // }

      $http.get(url, {
        cache: false
      }).then(function (response) {
        defer.resolve(response.data);
      });
      return defer.promise;
    }

    return service;
  }
})();

(function () {
  'use strict';

  layoutCtrl.$inject = ["$scope", "$state", "layoutService", "$rootScope", "$window", "$cacheFactory", "$transitions", "$timeout", "$uibModal"];
  angular.module('10softdental').controller('layoutCtrl', layoutCtrl);
  /** @ngInject */

  function layoutCtrl($scope, $state, layoutService, $rootScope, $window, $cacheFactory, $transitions, $timeout, $uibModal) {
    $scope.$state = $state; // $scope.toggleSidebar = () => {
    //     $(".sidebar-offcanvas").toggleClass("active");
    // }
    // $rootScope.logout = function () {
    //     let ls = new SecureLS();
    //     ls.remove("softDentalUserDetails");
    //     $rootScope.userDetails = "";
    //     $cacheFactory.get("$http").removeAll();
    //     $state.go("login");
    //     window.location.reload()
    // }
    // $scope.menuLoaded = false;
    // layoutService.getMenu().then(function (data) {
    //     $scope.menuItems = data;
    //     $scope.menuLoaded = true;
    // });
  }
})();

(function () {
  'use strict';

  layoutService.$inject = ["apiCollection", "$q", "$http", "$rootScope"];
  angular.module('10softdental').factory('layoutService', layoutService);
  /** @ngInject */

  function layoutService(apiCollection, $q, $http, $rootScope) {
    var service = {
      getMenu: getMenu
    };

    function getMenu() {// let defer = $q.defer();
      // $http.get(apiCollection.user.getMenus($rootScope.userDetails.id)).then(function (response) {
      //     defer.resolve(response.data);
      // });
      // return defer.promise;
    }

    return service;
  }
})();

(function () {
  'use strict';

  periodontalChartCtrl.$inject = ["$scope", "periodontalChartService"];
  angular.module('10softdental').controller('periodontalChartCtrl', periodontalChartCtrl);
  /** @ngInject */

  function periodontalChartCtrl($scope, periodontalChartService) {
    console.log("Salam");
    activate();

    function activate() {}
  }
})();

(function () {
  'use strict';

  periodontalChartService.$inject = ["apiCollection", "$q", "$http"];
  angular.module('10softdental').factory('periodontalChartService', periodontalChartService);
  /** @ngInject */

  function periodontalChartService(apiCollection, $q, $http) {
    var service = {};
    return service;
  }
})();