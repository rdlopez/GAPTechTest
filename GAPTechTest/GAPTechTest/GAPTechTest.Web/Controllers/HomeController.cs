using GAPTechTest.Tests.Controllers.API;
using GAPTechTest.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAPTechTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var PolicyController = new PolicyController();

            //var policies = PolicyController.GetAll();

            //List<PolicyViewModel> polViewModelList = new List<PolicyViewModel>();

            //foreach(var policy in policies)
            //{
            //    polViewModelList.Add(new PolicyViewModel {
            //        Name = policy.Name
            //    });
            //}

            //return View(polViewModelList);
            return View();
        }
    }
}
