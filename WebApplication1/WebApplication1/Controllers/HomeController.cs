using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }       
        //read Tasks
        public JsonResult GetTasks()
        {
            var tasks = _repository.Tasks.ToList().GroupJoin(
                _repository.SubTasks.ToList(),
                x => x.TaskId,
                y => y.TaskId,
                (t, subt) => new
                {
                  Task = t,
                  SubTask = subt
                }).ToList();

            return Json(tasks, JsonRequestBehavior.AllowGet);
        }
        //update Taks
        public void UpdateTask(Task task)
        {
            _repository.UpdateTask(task);
        }
        //update SubTasks
        public void UpdateSubTask(SubTask subTask)
        {
            _repository.UpdateSubTask(subTask);
        }
        //delete Tasks
        public void DeleteTask(int TaskId = 0)
        {
            if (TaskId != 0)
            {
                Task task = _repository.Tasks.Select(x => x).FirstOrDefault();

                _repository.DeleteTask(task);
            }
        }
        //delete subTasks
        public void DeleteSubTask(int SubTaskId = 0)
        {
            if (SubTaskId != 0)
            {
                SubTask subTask = _repository.SubTasks.Where(x => x.SubTaskId == SubTaskId).FirstOrDefault();

                _repository.DeleteSubTask(subTask);
            }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
