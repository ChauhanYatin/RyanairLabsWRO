using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TycoonFactory.Db;

namespace TycoonFactory.IBuss
{
    public interface IWorkerService
    {
        IQueryable<Worker> GetWorker();
    }
}
