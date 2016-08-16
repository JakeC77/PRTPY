var app = angular.module('app', ['ngRoute', 'darthwade.loading']);



app.config(['$routeProvider', '$locationProvider',

    function ($routeProvider, $locationProvider) {
        $routeProvider.
            when('/UserAdmin', {
                templateUrl: '/Templates/Controllers/UserAdmin.html',
                controller: 'UserAdmin'
            }).when('/ProjectServices', {
                templateUrl: '/ProjectServices',
                controller: 'PSCtrl'
            }).when('/Invoice', {
                templateUrl: '/InvoiceApproval',
                controller: 'InvoiceApproval'
            }).when('/HRPortal', {
                templateUrl: '/HRPortal',
                controller: 'HRPortalCtrl'
            }).otherwise( {
                templateUrl: '/Templates/Controllers/UserAdmin.html',
                controller: 'UserAdmin'
            })
    }]);


