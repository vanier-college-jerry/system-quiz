using AddressBookDB.Model;
using AddressBookDB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        IAddressBookRepository _Repo;
        ModelMapping _ModelMapping;

        public HomeController(IAddressBookRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists();
            ddlFilter.AddressList = new SelectList((
                from a in _Repo.GetAddress() select new {
                    Value = a.ID,
                    Text = a.Type
                }).Distinct(), "Value", "Text");
            return View(ddlFilter);
        }

        [HttpGet]
        public ActionResult GetAddress(int pageIndex, int pageSize, string sortField = "Type", string sortOrder = "desc")
        {
            SelectLists ddlFilter = new SelectLists();
            IEnumerable<AddressBookDB.Address> AddressList = null;
            IQueryable<AddressBookDB.Address> Query = null;
            IEnumerable<AddressBookDB.Model.Address2> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(AddressBookDB.Address).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {

                    Query = _Repo.GetAddress();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "FirstName":
                            if (sortOrder == "asc")
                            {
                                AddressList = Query.OrderBy(S => S.FirstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                AddressList = Query.OrderByDescending(S => S.FirstName);
                            }
                            break;
                        case "LastName":
                            if (sortOrder == "asc")
                            {
                                AddressList = Query.OrderBy(S => S.LastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                AddressList = Query.OrderByDescending(S => S.LastName);
                            }
                            break;

                        default:
                            AddressList = Query.OrderByDescending(S => S.ID);
                            break;
                    }
                    // CommentsList = Query.OrderByDescending(S => S.CommentDate);

                    ResultList = AddressList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadAddress(T));

                    var res = AddressList.GroupBy(x => x.ID).Select(y => y.First());
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