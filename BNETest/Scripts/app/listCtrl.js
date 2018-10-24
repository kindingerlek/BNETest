var app = angular.module("myApp", []);
app.controller("listCtrl", function ($scope, $http) {

    $scope.Init = function () {
        $scope.selected = {}
        $scope.GetAllStudents();
        $scope.GetAllFreeSubjects();
    }

    $scope.Add = function () {
        $scope.student.Subjects.push($scope.selected);

        alert("Unfortunately this feature is not working properly yet. Sorry about that");
        console.log(JSON.stringify($scope.student));

        $scope.updatingStudent = false;

        /*
        $http({
            method: "post",
            url: "http://localhost:62037/Students/Update",
            datatype: "json",
            data: JSON.stringify($scope.student)
        }).then(function (response) {
            $scope.Init();
        })*/

    }

    $scope.Update = function (student) {
        document.getElementById("StudentID").value = student.Id;

        $scope.updatingStudent = true;
        $scope.student = student;

        $http({
            method: "post",
            url: "http://localhost:62037/List",
            datatype: "json",
            data: JSON.stringify($scope.student)
        }).then(function (response) {
            $scope.GetAllStudents();
            $scope.Name = "";
        })
    }

    $scope.GetAllStudents = function () {
        $http({
            method: "get",
            url: "http://localhost:62037/Students/GetAll"
        }).then(function (response) {
            $scope.students = response.data;
        }, function () {
        })
    };

    $scope.GetAllSubjects = function () {
        $http({
            method: "get",
            url: "http://localhost:62037/Subjects/GetAll"
        }).then(function (response) {
            $scope.subjects = response.data;
        }, function () {
        })
    };

    $scope.GetAllFreeSubjects = function () {
        $http({
            method: "get",
            url: "http://localhost:62037/Subjects/GetAllFree"
        }).then(function (response) {
            $scope.freeSubjects = response.data;
        }, function () {
        })
    };
})  