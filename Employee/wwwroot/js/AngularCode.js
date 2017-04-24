var app = angular.module("blogApp", []);
app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.headers.common = {
        'X-Requested-With': 'XMLHttpRequest'
    };
}]);
app.controller("blogController", function ($scope, $http) {
    $scope.Insert = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Blog = {};
            $scope.Blog.Url = $scope.url_text;
            $http({
                method: "post",
                url: "http://localhost:1383/Blogs/Create",
                datatype: "json",
                data: JSON.stringify($scope.Blog)
            }).then(function (response) {
                $scope.ShowSuccessMessage(response.data);
                $scope.url_text = "";
                $scope.List();
            }, function (e) {
                $scope.ShowFailureMessage(e.statusText);
            })
        } else {
            $scope.Blog = {};
            $scope.Blog.Url = $scope.url_text;
            $scope.Blog.BlogId = document.getElementById("BlogID_").value;
            $http({
                method: "post",
                url: "http://localhost:1383/Blogs/Edit",
                datatype: "json",
                data: JSON.stringify($scope.Blog)
            }).then(function (response) {
                $scope.ShowSuccessMessage(response.data);
                $scope.List();
                $scope.url_text = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Blog";
            }, function (e) {
                $scope.ShowFailureMessage(e.statusText);
            })
        }
    }
    $scope.List = function () {
        $http({
            method: "get",
            url: "http://localhost:1383/Blogs/Index"
        }).then(function (response) {
            $scope.blogs = response.data;
        }, function (e) {
            $scope.ShowFailureMessage(e.statusText);
        })
    };
    $scope.Delete = function (Blog) {
        $http({
            method: "post",
            url: "http://localhost:1383/Blogs/Delete",
            datatype: "json",
            data: JSON.stringify(Blog.blogId)
        }).then(function (response) {
            $scope.ShowSuccessMessage(response.data);
            $scope.List();
        }, function (e) {
            $scope.ShowFailureMessage(e.statusText);
        })
    };
    $scope.Update = function (Blog) {
        document.getElementById("BlogID_").value = Blog.blogId;
        $scope.url_text = Blog.url;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Blog Information";
    };
    $scope.switchBool = function (value) {
        $scope[value] = !$scope[value];
    };
    $scope.ShowSuccessMessage = function (messageText) {
        $scope.successTextAlert = messageText;
        $scope.showSuccessAlert = true;
    };
    $scope.ShowFailureMessage = function (messageText) {
        $scope.failureTextAlert = e.statusText;
        $scope.showFailureAlert = true;
    };
})  