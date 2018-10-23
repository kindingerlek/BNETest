var app = angular.module("myApp", []);
app.controller("subjectsCtrl", function ($scope, $http) {

    $scope.Add = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {

            $scope.subject = {};
            $scope.subject.Name = $scope.Name;

            $http({
                method: "post",
                url: "http://localhost:62037/Subjects/Add",
                datatype: "json",
                data: JSON.stringify($scope.subject)
            }).then(function (response) {
                $scope.GetAll();
                $scope.Name = "";
            })

        } else {
            $scope.subjects = {};
            $scope.subjects.Name = $scope.Name;
            $scope.subjects.Id = document.getElementById("SubjectID").value;
            $http({
                method: "post",
                url: "http://localhost:62037/Subjects/Update",
                datatype: "json",
                data: JSON.stringify($scope.subjects)
            }).then(function (response) {
                $scope.GetAll();
                $scope.Name = "";
                document.getElementById("btnSave").classList.add("btn-primary");
                document.getElementById("btnSave").classList.remove("btn-success");
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("spn").innerHTML = "Add New Subject";
            })
        }
    }

    $scope.GetAll = function () {
        $http({
            method: "get",
            url: "http://localhost:62037/Subjects/GetAll"
        }).then(function (response) {
            $scope.subjects = response.data;
        }, function () {
        })
    };

    $scope.Delete = function (subject) {
        $http({
            method: "post",
            url: "http://localhost:62037/Subjects/Delete",
            datatype: "json",
            data: JSON.stringify(subject)
        }).then(function (response) {
            $scope.GetAll();
        })
    };

    $scope.Update = function (subject) {
        document.getElementById("SubjectID").value = subject.Id;
        $scope.Name = subject.Name;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").classList.remove("btn-primary");
        document.getElementById("btnSave").classList.add("btn-success");
        document.getElementById("spn").innerHTML = "Update Subject Information";
    }
})  