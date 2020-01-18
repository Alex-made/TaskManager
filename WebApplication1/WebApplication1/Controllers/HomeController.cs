using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var princess = new Cat
                    {
                        Name = "Prince",
                        Sex = 'M',
                        Weight = 7.64f
                    };

                    //session.Save(princess);
                    //tx.Commit();

                    var task = new Task
                    {
                        Header = "Задача"
                    };

                    
                    /* task.Description = "Описание задачи";
                    task.CompleteDate = DateTime.Now;
                    task.Status = "Запланирована";
                    task.Priority = 1;
                   task.SubTasks.Add(new SubTask
                                    {
                                        Description = "Запланировать",
                                        Status = "Выполнено"
                                    });*/

                    session.Save(task);
                    tx.Commit();
                    

                }

                using (var tx = session.BeginTransaction())
                {
                    var females = session
                        .Query<Cat>()
                        .Where(c => c.Sex == 'F')
                        .ToList();

                    ViewBag.Title = females.Select(x=>x.Name).FirstOrDefault();


                    tx.Commit();
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
