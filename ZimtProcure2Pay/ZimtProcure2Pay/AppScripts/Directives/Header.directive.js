    app.directive('appHeader', [function () {
        return {
            scope: {
                headername: '=',
                breadcrumb: '=',
                mode: '=',
                onSubmit: '&',
                onEdit: '&',
                onCancel: '&',
                showSubmit: '=',
                showEdit: '=',
                showCancel: '=',
                logoUrl: '='

            },  
            translude: true,
            restrict: 'E',
            templateUrl: '/Templates/Directives/Header.html',
            link: function (scope) {
                scope.settingsClick = function () {
                    $(document).trigger('open-settings');   
                }

                scope.nintexClick = function () {
                    $(document).trigger('show-nintex-modal');
                }
                scope.socialClick = function () {
                    $(document).trigger('show-social');
                }
                scope.helpClick = function () {
                    zE.show();
                }
                scope.onCancel = function () {
                    window.history.back();
                }
                scope.salesForceClick = function(){
                    window.location.href = "/home/sflogin";
                }
            }
        }
    }]);