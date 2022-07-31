using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TycoonFactory.IBuss;
using TycoonFactory.IData;
using TycoonFactory.Db;

namespace TycoonFactory.Buss
{
    public class WorkerService : IWorkerService
    {
        IWorkerRepository workerRepository;
        public WorkerService(IWorkerRepository _workerRepository)
        {
            this.workerRepository = _workerRepository;
        }

        public IQueryable<Worker> GetWorker()
        {
            try
            {
                return workerRepository.GetWorker();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
