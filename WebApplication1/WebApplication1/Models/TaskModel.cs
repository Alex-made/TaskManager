using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public DateTime CompleteDate { get; set; }

        public List<string> Statuses { get; set; }

        public int Priority { get; set; }

        public List<SubTaskModel> SubTasks;

        //public virtual IList<SubTask> SubTasks
        //{
        //    get { return _subTasks ?? (_subTasks = new List<SubTask>()); }
        //    set { _subTasks = value; }
        //}

        //public TaskModel(int TaskId, string Header, string Description, DateTime CompleteDate, List<string> Status, int Priority, List<SubTask> SubTasks)
        //{
        //    _TaskId = TaskId;
        //    _Header = Header;
        //    _Description = Description;
        //    _CompleteDate = CompleteDate;
        //    _Status = Status;
        //    _Priority = Priority;
        //    _SubTasks = SubTasks;
        //}

    }
}