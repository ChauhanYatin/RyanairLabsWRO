using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TycoonFactory.IBuss;
using TycoonFactory.Web.Models;
using TycoonFactory.Utility;

namespace TycoonFactory.Web.Controllers
{
    public class WorkAssignementController : Controller
    {
        // GET: WorkAssignement
        public IWorkAssignementService workAssignementService ;

        public WorkAssignementController(IWorkAssignementService _workAssignementService)
        {
            this.workAssignementService = _workAssignementService;
        }
        public ActionResult WorkAssignement()
        {
            return View();
        }

        public JsonResult GetWorkAssignementList()
        {
            WorkAssignementViewModel model = new WorkAssignementViewModel();
            var returnData = model.GetWorkAssignementList(workAssignementService);
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateWorkAssignment(string WorkerId, string WorkType, string startDate, string endDate)
        {
            WorkAssignementViewModel model = new WorkAssignementViewModel();
            string resultVal = "";
            if(model.ValidateWorkAssignment(WorkerId, WorkType, startDate, endDate, workAssignementService))
            {
                resultVal = Common.Status.Success;
            }
            else
            {
                resultVal = Common.Status.Failed;
            }
            return Json(resultVal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveWorkAssignment(WorkAssignementViewModel waViewModel)
        {
            var returnStatus = "";
            if(ModelState.IsValid)
            {
                if (waViewModel.SaveWorkAssignment(workAssignementService))
                    returnStatus = Common.Status.Success;
            }
            return new JsonResult { Data = new { returnStatus = returnStatus } };
        }
        [HttpPost]
        public JsonResult DeleteWorkAssignement(int workassignementId)
        {
            var returnStatus = "";
            WorkAssignementViewModel model = new WorkAssignementViewModel();
            if (model.DeleteWorkAssignement(workAssignementService, workassignementId))
                returnStatus = Common.Status.Success;
            
            return new JsonResult { Data = new { returnStatus = returnStatus } };
        }
    }
}