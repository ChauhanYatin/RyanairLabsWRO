using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TycoonFactory.IBuss;

namespace TycoonFactory.Web.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<WorkerViewModel> GetWorkerList(IWorkerService workerService)
        {
            var works = workerService.GetWorker();

            var workerList = (from w in works
                              select new WorkerViewModel
                              {
                                  Id = w.Id,
                                  Name = w.Name
                              }).ToList();

            return workerList;
        }
    }
}