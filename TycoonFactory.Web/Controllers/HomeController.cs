using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TycoonFactory.Web.Models;
using TycoonFactory.IBuss;

namespace TycoonFactory.Web.Controllers
{
    public class HomeController : Controller
    {
        public IWorkerService workerService;
        public IWorkAssignementService workAssignementService;
        public HomeController(IWorkerService _workerService, IWorkAssignementService _workAssignementService)
        {
            this.workerService = _workerService;
            this.workAssignementService = _workAssignementService;
        }
        public ActionResult Index()
        {
            WorkerViewModel model = new WorkerViewModel();
            return View(model);
        }

        public JsonResult GetWorkerList()
        {
            WorkerViewModel model = new WorkerViewModel();
            var returnData = model.GetWorkerList(workerService);
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTopWorkers()
        {
            WorkAssignementViewModel modelVM = new WorkAssignementViewModel();
            var returnData = modelVM.GetTopListWorker(workAssignementService);
            return Json(returnData, JsonRequestBehavior.AllowGet);
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