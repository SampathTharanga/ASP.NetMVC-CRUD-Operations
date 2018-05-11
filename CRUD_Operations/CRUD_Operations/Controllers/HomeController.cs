using CRUD_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var employees = dc.EmployeesTables.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.EmployeesTables.Where(a => a.EmployeeID == id).FirstOrDefault();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Save(EmployeesTable emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (emp.EmployeeID > 0)
                    {
                        //Save
                        var v = dc.EmployeesTables.Where(a => a.EmployeeID == emp.EmployeeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = emp.FirstName;
                            v.LastName = emp.LastName;
                            v.EmailID = emp.EmailID;
                            v.City = emp.City;
                            v.Country = emp.Country;
                        }
                    }
                    else
                    {
                        //Edit
                        dc.EmployeesTables.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {

        }
    }
}