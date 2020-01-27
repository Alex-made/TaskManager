using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Util
{
    public interface IRepository
    {
        IQueryable<Task> Tasks { get; }

        IQueryable<SubTask> SubTasks { get; }

        void UpdateTask(Task task);

        void UpdateSubTask(SubTask subTask);

        void DeleteTask(Task task);

        void DeleteSubTask(SubTask subTask);
    }
}
