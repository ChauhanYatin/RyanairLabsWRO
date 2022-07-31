using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TycoonFactory.Db;

namespace TycoonFactory.IData
{
    public interface IWorkAssignementRepository
    {
        List<WorkAssignement> GetWorkAssignement();
        bool AddWorkAssignement(WorkAssignement workAssignement);
        bool UpdateWorkAssignement(WorkAssignement workAssignement);
        bool DeleteWorkAssignement(int workAssignementId);
    }
}
