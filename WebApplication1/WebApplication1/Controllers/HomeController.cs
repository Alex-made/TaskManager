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
            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            ISession session = NHibernateHelper.GetCurrentSession();

            var tasks = session.Query<Task>().ToList().GroupJoin(
                                session.Query<SubTask>().ToList(),
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
                ISessionFactory sessionFactory =
                new Configuration().Configure().BuildSessionFactory();

                ISession session = NHibernateHelper.GetCurrentSession();

                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(task);
                    tx.Commit();
                }           
        }

        public void UpdateTask1(Task task)
        {
            _repository.UpdateTask(task);
        }

        //update SubTasks
        public void UpdateSubTask(SubTask subTask)
        {
            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            ISession session = NHibernateHelper.GetCurrentSession();

            using (ITransaction tx = session.BeginTransaction())
            {
                session.SaveOrUpdate(subTask);
                tx.Commit();
            }
        }


        public void DeleteTask(int TaskId = 0)
        {
            if (TaskId != 0)
            {
                ISessionFactory sessionFactory =
                new Configuration().Configure().BuildSessionFactory();

                ISession session = NHibernateHelper.GetCurrentSession();

                Task task = session.Query<Task>().Where(x => x.TaskId == TaskId).FirstOrDefault();

                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Delete(task);
                    tx.Commit();
                }
            }
        }

        public void DeleteSubTask(int SubTaskId = 0)
        {
            if (SubTaskId != 0)
            {
                ISessionFactory sessionFactory =
                new Configuration().Configure().BuildSessionFactory();

                ISession session = NHibernateHelper.GetCurrentSession();

                SubTask subTask = session.Query<SubTask>().Where(x => x.SubTaskId == SubTaskId).FirstOrDefault();

                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Delete(subTask);
                    tx.Commit();
                }
            }
        }

        public ActionResult Index()
        {
            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {                    
                    
                    SubTask subTask = new SubTask
                    {
                        Description = "Запланировать3",
                        Status = "Выполняется",
                        TaskId = 3006
                    };

                    var task = new Task
                    {
                        Header = "Задача1",
                        Description = "Описание",
                        CompleteDate = DateTime.Now.Date,
                        Status = "Выполнено",
                        Priority = 2,
          

                    };

                    //session.Save(subTask);
                    //tx.Commit();

                }

                using (var tx = session.BeginTransaction())
                {
                    
                    //update
                    var task = new Task
                    {
                        TaskId = 3005,
                        Header = "Задача3005",
                        Description = "Описание",
                        CompleteDate = DateTime.Now.Date,
                        Status = "Выполнено",
                        Priority = 2,


                    };
                    //session.SaveOrUpdate(task);

                    

                    ViewBag.Title = "aaa";
                    
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }           

            return View();
        }
    }
}
