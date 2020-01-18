using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            /*myConfiguration = new Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();*/

            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            ISession session = NHibernateHelper.GetCurrentSession();

            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var princess = new Cat
                    {
                        Name = "Princess",
                        Sex = 'F',
                        Weight = 7.4f
                    };

                    session.Save(princess);
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

                using (var tx = session.BeginTransaction())
                {
                    var females = session
                        .Query<Cat>()
                        .Where(c => c.Sex == 'F')
                        .ToList();

                    

                    ViewBag.Title = females.Select(x => x.Name).FirstOrDefault();


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
