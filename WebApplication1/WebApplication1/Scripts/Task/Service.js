app.service("angularService", function ($http) {
    //ReadTasks
    this.getTasks = function () {
        return $http.get("/home/GetTasks");
    }    
    //Update Task
    this.updateTask = function (Task) {
        var response = $http({
            url: "/home/UpdateTask",
            method: "POST",
            data: JSON.stringify(Task),
            dataType: "json"
        });
        return response;
    }
    //Update SubTask
    this.updateSubTask = function (SubTask) {
        var response = $http({
            url: "/home/UpdateSubTask",
            method: "POST",
            data: JSON.stringify(SubTask),
            dataType: "json"
        });
        return response;
    }
    //Delete Task 
    this.deleteTask = function (taskId) {
        return $http.get("/home/DeleteTask?TaskId=" + taskId);
    }    
    //Delete SubTask 
    this.deleteSubTask = function (SubTaskId) {
        return $http.get("/home/DeleteSubTask?SubTaskId=" + SubTaskId);
    }
    
})