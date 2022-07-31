using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TycoonFactory.Db;
using TycoonFactory.IBuss;
using TycoonFactory.Utility;

namespace TycoonFactory.Web.Models
{
    public class WorkAssignementViewModel
    {
        public int WorkAssignementId { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string WorkType { get; set; }
        public System.DateTime Startdatetime { get; set; }
        public System.DateTime Enddatetime { get; set; }
        public int TotalDuration { get; set; }
        public string TotalDurationHHMM { get; set; }
        public string s_Startdatetime { get; set; }
        public string s_Enddatetime { get; set; }
        public string Description { get; set; }
        public int SrNo { get; set; }
        public string SelectedWorkerId { get; set; }
        public List<WorkAssignementViewModel> GetWorkAssignementList(IWorkAssignementService workAssignementService)
        {
            var works = workAssignementService.GetWorkAssignement();

            var workassignmentList = (from w in works
                              select new WorkAssignementViewModel
                              {
                                  WorkAssignementId = w.WorkAssignementId,
                                  WorkerId = w.WorkerId,
                                  WorkerName = w.WorkerName,
                                  WorkType = w.WorkType,
                                  Startdatetime = w.Startdatetime,
                                  Enddatetime = w.Enddatetime,
                                  s_Startdatetime = String.Format("{0:f}", w.Startdatetime),
                                  s_Enddatetime = String.Format("{0:f}", w.Enddatetime),
                                  TotalDuration = w.TotalDuration,
                                  Description = w.Description
                              }).ToList();

            return workassignmentList;
        }

        public List<WorkAssignementViewModel> GetTopListWorker(IWorkAssignementService workAssignementService)
        {
            List<WorkAssignementViewModel> workAssignementViewModels = new List<WorkAssignementViewModel>();
            workAssignementViewModels = this.GetWorkAssignementList(workAssignementService).Where(x => x.Startdatetime >= DateTime.Now).ToList();
            if (workAssignementViewModels.Count > 0)
            {
                workAssignementViewModels = workAssignementViewModels
                                            .GroupBy(w => w.WorkerName)
                                            .Select(x => new WorkAssignementViewModel
                                            {
                                                WorkerName = x.Select(n => n.WorkerName).FirstOrDefault(),
                                                TotalDuration = x.Sum(t => t.TotalDuration),
                                            }).OrderByDescending(x => x.TotalDuration).Take(10).ToList();
            }

            int i = 1;
            foreach (var item in workAssignementViewModels)
            {
                item.SrNo = i;
                item.TotalDurationHHMM = Common.GetHHMM(item.TotalDuration);
                i++;
            }
            
            return workAssignementViewModels;
        }

        public bool ValidateWorkAssignment(string WorkerId, string WorkType, string startDate, string endDate, IWorkAssignementService workAssignementService)
        {
            bool returnVal = true;
            CultureInfo culture = new CultureInfo("en-US");
            if(WorkType.ToUpper() == Common.WorkType.Component.ToUpper())
            {
                var works = workAssignementService.GetWorkAssignement().Where(x => x.WorkerId == Convert.ToInt32(WorkerId) && x.WorkType == WorkType).ToList();
                if(works.Count() > 0)
                {
                    foreach (var items in works)
                    {
                        DateTime eddateTimeOne = items.Enddatetime;
                        DateTime eddateTimeTwo = Convert.ToDateTime(startDate, culture);

                        TimeSpan newDbdatetime = new TimeSpan(eddateTimeOne.Day, eddateTimeOne.Hour, eddateTimeOne.Minute, 0);
                        TimeSpan newActualdatetime = new TimeSpan(eddateTimeTwo.Day, eddateTimeTwo.Hour, eddateTimeTwo.Minute, 0);
                        TimeSpan ts = new TimeSpan();

                        if (eddateTimeTwo.Day >= eddateTimeOne.Day)
                        {
                            ts = eddateTimeTwo - eddateTimeOne;
                        }
                        else if (eddateTimeTwo.Day <= eddateTimeOne.Day)
                        {
                            ts = eddateTimeOne - eddateTimeTwo;
                        }

                        if (ts.TotalHours <= 2)
                        {
                            returnVal = false;
                        }
                    }
                }
            }
            else if (WorkType.ToUpper() == Common.WorkType.Machine.ToUpper())
            {
                string[] WorkerIds = WorkerId.Split(',');
                foreach (var worker in WorkerIds)
                {
                    var works = workAssignementService.GetWorkAssignement().Where(x => x.WorkerId == Convert.ToInt32(worker) && x.WorkType == WorkType).ToList();
                    if(works.Count() > 0)
                    {
                        foreach (var items in works)
                        {
                            DateTime eddateTimeOne = items.Enddatetime;
                            DateTime eddateTimeTwo = Convert.ToDateTime(startDate, culture);

                            TimeSpan newDbdatetime = new TimeSpan(eddateTimeOne.Day, eddateTimeOne.Hour, eddateTimeOne.Minute, 0);
                            TimeSpan newActualdatetime = new TimeSpan(eddateTimeTwo.Day, eddateTimeTwo.Hour, eddateTimeTwo.Minute, 0);
                            TimeSpan ts = new TimeSpan();

                            if (eddateTimeTwo.Day >= eddateTimeOne.Day)
                            {
                                ts = eddateTimeTwo - eddateTimeOne;
                            }
                            else if (eddateTimeTwo.Day <= eddateTimeOne.Day)
                            {
                                ts = eddateTimeOne - eddateTimeTwo;
                            }

                            if (ts.TotalHours <= 4)
                            {
                                returnVal = false;
                            }
                        }
                    }
                }
            }
            return returnVal;
        }

        public bool SaveWorkAssignment(IWorkAssignementService workAssignementService)
        {
            bool returnVal = false;
            if(WorkAssignementId == 0)
            {
                if(WorkType == Common.WorkType.Component)
                {
                    returnVal = workAssignementService.AddWorkAssignement(GetWorkAssignementDB());
                }
                else if(WorkType == Common.WorkType.Machine)
                {
                    string[] WorkerIds = SelectedWorkerId.Split(',');
                    foreach(var items in WorkerIds)
                    {
                        WorkAssignement workAss = new WorkAssignement();
                        workAss.WorkAssignementId = WorkAssignementId;
                        workAss.WorkerId = Convert.ToInt32(items);
                        workAss.WorkerName = WorkerName;
                        workAss.WorkType = WorkType;
                        workAss.Startdatetime = Startdatetime;
                        workAss.Enddatetime = Enddatetime;
                        workAss.Description = Description;

                        returnVal = workAssignementService.AddWorkAssignement(workAss);
                    }
                }
            }
            else
            {
                returnVal = workAssignementService.UpdateWorkAssignement(GetWorkAssignementDB());
            }
            return returnVal;

        }

        public bool DeleteWorkAssignement(IWorkAssignementService workAssignementService, int workassignementId)
        {
            bool returnVal = false;
            returnVal = workAssignementService.DeleteWorkAssignement(workassignementId);
            return returnVal;
        }

        public WorkAssignement GetWorkAssignementDB()
        {
            WorkAssignement workAss = new WorkAssignement();
            workAss.WorkAssignementId = WorkAssignementId;
            workAss.WorkerId = WorkerId;
            workAss.WorkerName = WorkerName;
            workAss.WorkType = WorkType;
            workAss.Startdatetime = Startdatetime;
            workAss.Enddatetime = Enddatetime;
            workAss.Description = Description;
            return workAss;
        }
    }
}