app.controller("TaskCtrl", function ($scope, angularService) {

    GetTasks();

    var date = new Date();

    Task = {
        TaskId: 0,
        Header: "",
        Description: "",
        CompleteDate: date,
        Status: "",
        Priority: 0
    };

    NewSubTask = {
        SubtaskId: 0,
        Description: "",
        Status: "",
        TaskId: 0
    };


    //Read Tasks
    function GetTasks() {
        angularService.getTasks()
            .then(function successCallback(response) {
                $scope.Tasks = response;
                //get Date object from CompleteDate JSON String (JSON ASP.NET Date)                
                for (let i = 0; i < $scope.Tasks.data.length; i++) {
                    let stringDate = $scope.Tasks.data[i].CompleteDate;
                    //let date = new Date(parseInt(stringDate.replace('/Date(', '')));
                    //let month = date.getMonth();
                    $scope.Tasks.data[i].CompleteDate = formatDateToString(stringDate);//date.getDate() + '-' + date.getMonth() + '-' + date.getFullYear();                    
                };
            }, function errorCallback(response) {
                alert(response);
            });
    }   
    //format Date object to string
    function formatDateToString(stringDate) {
        return date = new Date(parseInt(stringDate.replace('/Date(', '')));        
    }
    //Update Task
    $scope.UpdateTask = function (Task) {        
        if (Task !== undefined) {
            //if (Task.Header != undefined && Task.Status != undefined && Task.Priority != undefined) {
                angularService.updateTask(Task)
                    .then(function successCallback(response) {
                        GetTasks();
                        $scope.Task = [];
                        alert(response.data);
                    }, function errorCallback(response) {
                        alert(response);
                        });
            //}
        } else {
            alert("Enter data!!!")
        }        
    }
    //Update SubTask
    $scope.UpdateSubTask = function (SubTask, taskId) {
        NewSubTask = SubTask;
        NewSubTask.TaskId = taskId;
        angularService.updateSubTask(NewSubTask)
            .then(function successCallback(response) {
                GetTasks();
                $scope.subtask = undefined;
                alert("Updated!")
            }, function errorCallback(response) {
                //ловить коды ошибок
                alert(response);
            });
    }
    //Delete Task 
    $scope.DeleteTask = function (taskId) {
        angularService.deleteTask(taskId)
            .then(function successCallback(response) {
                GetTasks();
                alert("Deleted!")
            }, function errorCallback(response) {
                alert(response);
            });
    }
    //Delete SubTask 
    $scope.DeleteSubTask = function (SubTaskId) {
        angularService.deleteSubTask(SubTaskId)
            .then(function successCallback(response) {
                GetTasks();
                alert("Deleted!")
            }, function errorCallback(response) {
                alert(response);
            });
    }

    

})