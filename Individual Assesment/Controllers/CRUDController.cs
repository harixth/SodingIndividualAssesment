using Individual_Assesment.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Individual_Assesment.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                var tasks = session.QueryOver<Task>().List();
                return View(tasks);
            }
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                var task = session.Get<Task>(id);
                return View(task);
            }
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(Task task)
        {
            try
            {
                using (ISession session = NhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(task);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                var task = session.Get<Task>(id);
                return View(task);
            }
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Task task)
        {
            try
            {
                using (ISession session = NhibernateHelper.OpenSession())
                {
                    var TasktoUpdate = session.Get<Task>(id);

                    TasktoUpdate.Name = task.Name;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(TasktoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Task task)
        {
            try
            {
                using (ISession session = NhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(task);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
