app.controller("UserAdmin", ['$scope', function ($scope) {
    $scope.mode = "User Admin";
    $scope.breadcrumb = [{ title: 'Users', link: "#/main" }];
    $scope.headername = 'Zimt User Administration';

}]);