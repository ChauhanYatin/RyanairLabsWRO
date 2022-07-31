using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TycoonFactory.IData;
using TycoonFactory.Db;

namespace TycoonFactory.Data
{
    public class WorkAssignementRepository : IWorkAssignementRepository
    {
        public WorkAssignementRepository()
        {

        }
        public List<WorkAssignement> GetWorkAssignement()
        {
            //TODO : I have create static data for testing 
            //We are Fetch the data from Database by using LINQ model Entity
            List<WorkAssignement> Listworkerassignment = new List<WorkAssignement>();
            Listworkerassignment.AddRange(new List<WorkAssignement>
            {
                new WorkAssignement(1, 1, "A", "Component", DateTime.Now, DateTime.Now.AddHours(1), 60, "Morning"),
                new WorkAssignement(2, 1, "A", "Machine", DateTime.Now.AddDays(4).AddHours(1), DateTime.Now.AddDays(4).AddHours(2), 60, "Morning"),
                new WorkAssignement(3, 1, "A", "Machine", DateTime.Now.AddDays(5).AddHours(2), DateTime.Now.AddDays(5).AddHours(4), 120, "Morning"),
                new WorkAssignement(4, 1, "A", "Component", DateTime.Now.AddHours(3), DateTime.Now.AddHours(7), 240, "Morning"),
                new WorkAssignement(5, 2, "B", "Machine", DateTime.Now, DateTime.Now.AddHours(1), 60, "Evening"),
                new WorkAssignement(6, 2, "B", "Component", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(1), 60, "After 2 day"),
                new WorkAssignement(7, 2, "B", "Component", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddHours(1), 60, "After 2 day"),
                new WorkAssignement(8, 3, "C", "Component", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), 180, "After 2 day"),
                new WorkAssignement(9, 3, "C", "Machine", DateTime.Now.AddDays(2).AddHours(3), DateTime.Now.AddDays(3).AddHours(4), 60, "2 day"),
                new WorkAssignement(10, 3, "C", "Machine", DateTime.Now.AddDays(-2).AddHours(1), DateTime.Now.AddDays(-2).AddHours(2), 60, "2 day"),
                new WorkAssignement(11, 4, "D", "Machine", DateTime.Now.AddDays(-4).AddHours(1), DateTime.Now.AddDays(-4).AddHours(3), 120, "TEST"),
                new WorkAssignement(12, 4, "D", "Machine", DateTime.Now.AddDays(2).AddHours(1), DateTime.Now.AddDays(2).AddHours(3), 120, "TEST"),
                new WorkAssignement(12, 5, "E", "Machine", DateTime.Now.AddHours(6), DateTime.Now.AddHours(8), 120, "TEST"),
                new WorkAssignement(14, 5, "E", "Component", DateTime.Now.AddDays(2).AddHours(6), DateTime.Now.AddDays(2).AddHours(8), 120, "TEST"),
                new WorkAssignement(15, 5, "E", "Machine", DateTime.Now.AddDays(3).AddHours(4), DateTime.Now.AddDays(3).AddHours(8), 240, "TEST"),
                new WorkAssignement(16, 5, "E", "Component", DateTime.Now.AddHours(6), DateTime.Now.AddHours(8), 120, "TEST"),
                new WorkAssignement(17, 6, "F", "Component", DateTime.Now.AddHours(3), DateTime.Now.AddHours(5), 180, "Component"),
                new WorkAssignement(18, 6, "F", "Component", DateTime.Now.AddDays(-1).AddHours(1), DateTime.Now.AddDays(-1).AddHours(2).AddHours(6), 300, "Comments"),
            });
            return Listworkerassignment;
        }

        public bool AddWorkAssignement(WorkAssignement workAssignement)
        {
            //TODO : I have add static data for testing 
            //INSERT We can SAVE the data from Database by using LINQ model Entity
            List<WorkAssignement> Listworkerassignment = new List<WorkAssignement>();
            Listworkerassignment.Add(workAssignement);
            //need to use statement SaveChange Method if we update in Entity LINQ
            
            return true;
        }

        public bool UpdateWorkAssignement(WorkAssignement workAssignement)
        {
            //TODO : I have add static data for testing 
            //We are Fetch the data from Database by using LINQ model Entity
            var exisitingData = GetWorkAssignement().Where(x => x.WorkAssignementId == workAssignement.WorkAssignementId).FirstOrDefault();
            if (exisitingData != null)
            {
                WorkAssignement work = new WorkAssignement();
                work = exisitingData;
                //need to use statement SaveChange Method if we update in Entity LINQ
            }
            return true;
        }
        public bool DeleteWorkAssignement(int workAssignementId)
        {
            try
            {
                //TODO : I have add static data for testing 
                //We are Fetch the data from Database by using LINQ model Entity
                List<WorkAssignement> Listworkerassignment = GetWorkAssignement();
                var content = GetWorkAssignement().Where(x => x.WorkAssignementId == workAssignementId).FirstOrDefault();
                if(content != null)
                {
                    Listworkerassignment.Remove(content);
                    //need to use statement SaveChange Method if we update in Entity LINQ
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
            
        }
    }
}
