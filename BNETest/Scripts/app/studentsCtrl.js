var app = angular.module("myApp", []);
app.controller("studentsCtrl", function ($scope, $http) {

    $scope.Insert = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {

            $scope.Student = {};
            $scope.Student.Name = $scope.Name;

            $http({
                method: "post",
                url: "http://localhost:62037/Students/Insert",
                datatype: "json",
                data: JSON.stringify($scope.Student)
            }).then(function (response) {
                $scope.GetAll();
                $scope.Name = "";
            })

        } else {
            $scope.Student = {};
            $scope.Student.Name = $scope.Name;
            $scope.Student.Id = document.getElementById("StudentID").value;
            $http({
                method: "post",
                url: "http://localhost:62037/Students/Update",
                datatype: "json",
                data: JSON.stringify($scope.Student)
            }).then(function (response) {
                $scope.GetAll();
                $scope.Name = "";
                document.getElementById("btnSave").classList.add("btn-primary");
                document.getElementById("btnSave").classList.remove("btn-success");
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("spn").innerHTML = "Add New Student";
            })
        }
    }

    $scope.GetAll = function () {
        $http({
            method: "get",
            url: "http://localhost:62037/Students/GetAll"
        }).then(function (response) {
            $scope.Students = response.data;
        }, function () {
        })
    };

    $scope.Delete = function (Emp) {
        $http({
            method: "post",
            url: "http://localhost:62037/Students/Delete",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            $scope.GetAll();
        })
    };

    $scope.Update = function (student) {
        document.getElementById("StudentID").value = student.Id;
        $scope.Name = student.Name;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").classList.remove("btn-primary");
        document.getElementById("btnSave").classList.add("btn-success");
        document.getElementById("spn").innerHTML = "Update Student Information";
    }
})  