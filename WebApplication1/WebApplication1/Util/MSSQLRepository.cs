using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using NHibernate;
using NHibernate.Cfg;
using WebApplication1.Models;

namespace WebApplication1.Util
{
    public class MSSQLRepository : IRepository
    {
        private ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();

        private ISession session = NHibernateHelper.GetCurrentSession();

        public IQueryable<Task> Tasks
        {
            get { return session.Query<Task>(); }
        }

        public IQueryable<SubTask> SubTasks
        {
            get { return session.Query<SubTask>(); }
        }

        //create and update task
        public void UpdateTask(Task task)
        {
            using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(task);
                    tx.Commit();
                }                  
        }

        public void UpdateSubTask(SubTask subTask)
        {
            if (subTask.Status != null)
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(subTask);
                    tx.Commit();
                }
            }
        }
        //delete Task
        public void DeleteTask(Task task)
        {
            List<SubTask> subTasks = SubTasks.Where(x => x.TaskId == task.TaskId).ToList();

            foreach (SubTask sub in subTasks)
            {
                DeleteSubTask(sub);
            }

            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(task);
                tx.Commit();
            }
        }
        //delete subTask
        public void DeleteSubTask(SubTask subTask)
        {
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(subTask);
                tx.Commit();
            }
        }

    }
}