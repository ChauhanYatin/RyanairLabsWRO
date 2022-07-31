using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TycoonFactory.Db
{
    public class WorkAssignement
    {
        public int WorkAssignementId { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string WorkType { get; set; }
        public System.DateTime Startdatetime { get; set; }
        public System.DateTime Enddatetime { get; set; }
        public int TotalDuration { get; set; }
        public string Description { get; set; }

        public WorkAssignement()
        { }
        public WorkAssignement(int workassignementId, int workerId, string workername, string worktype, DateTime startdt, DateTime enddt, int totalduration, string desc) => (WorkAssignementId, WorkerId, WorkerName, WorkType, Startdatetime, Enddatetime, TotalDuration, Description) = (workassignementId, workerId, workername, worktype, startdt, enddt, totalduration, desc);
    }
}
