using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class SubTask
    {
        public virtual int SubTaskId { get; set; }

        public virtual string Description { get; set; }

        public virtual string Status { get; set; }

        public virtual int TaskId { get; set; }

        //public virtual Task Task { get; set; }
    }

}