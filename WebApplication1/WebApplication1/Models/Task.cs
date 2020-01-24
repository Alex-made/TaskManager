using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class Task
    {
        public virtual int TaskId { get; set; }

        public virtual string Header { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CompleteDate { get; set; }

        public virtual string Status { get; set; }

        public virtual int Priority { get; set; }

        //private IList<SubTask> _subTasks;

        //public virtual IList<SubTask> SubTasks
        //{
        //    get { return _subTasks ?? (_subTasks = new List<SubTask>()); }
        //    set { _subTasks = value; }
        //}

        
}