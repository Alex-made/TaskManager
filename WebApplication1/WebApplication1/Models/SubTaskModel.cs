using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SubTaskModel
    {
        public int SubTaskId { get; set; }

        public string Description { get; set; }

        public int TaskId { get; set; }

        public List<string> Statuses { get; set; }
    }
}