using EmployeeDB.Interface;
using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IEmployeeRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.EmployeeList = new SelectList((from a in _Repo.GetEmployee()
                                                        select new
                                                        {
                                                            Value = a.ID,
                                                            Text = a.firstName.Trim()+""+a.lastName.Trim()
                                                        }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }

        [HttpGet]
        public ActionResult GetEmployee(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {
            SelectLists ddlFilter = new SelectLists();
            IEnumerable<EmployeeDB.Employee> EmployeeList = null;
            IQueryable<EmployeeDB.Employee> Query = null;
            IEnumerable<EmployeeDB.Model.Employee> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(EmployeeDB.Employee).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {

                    Query = _Repo.GetEmployee();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "FirstName":
                            if (sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.firstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.firstName);
                            }
                            break;
                        case "LastName":
                            if (sortOrder == "asc")
                            {
                                EmployeeList = Query.OrderBy(S => S.lastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                EmployeeList = Query.OrderByDescending(S => S.lastName);
                            }
                            break;

                        default:
                            EmployeeList = Query.OrderByDescending(S => S.ID);
                            break;
                    }
                    // CommentsList = Query.OrderByDescending(S => S.CommentDate);

                    ResultList = EmployeeList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadEmployee(T));

                    var res = EmployeeList.GroupBy(x => x.ID).Select(y => y.First());
                }
            }
            catch (Exception ex)
            {
                //
            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if (Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public class ResultNames
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}