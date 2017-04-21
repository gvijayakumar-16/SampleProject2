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
                alert(response.data);
                $scope.List();
            }, function (e) {
                alert(e.data);
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
                alert(response.data);
                $scope.List();
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Blog";
            })
        }
    }
    $scope.List = function () {
        $http({
            method: "get",
            url: "http://localhost:1383/Blogs/Index"
        }).then(function (response) {
            $scope.blogs = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.Delete = function (Blog) {
        $http({
            method: "post",
            url: "http://localhost:1383/Blogs/Delete",
            datatype: "json",
            data: JSON.stringify(Blog)
        }).then(function (response) {
            alert(response.data);
            $scope.List();
        })
    };
    $scope.Update = function (Blog) {
        document.getElementById("BlogID_").value = Blog.blogId;
        $scope.url_text = Blog.url;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Blog Information";
    }
})  