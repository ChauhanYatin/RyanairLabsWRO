using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TycoonFactory.Db;
using TycoonFactory.IData;
namespace TycoonFactory.Data
{
    public class WorkerRepository : IWorkerRepository
    {
        public WorkerRepository()
        {

        }

        public IQueryable<Worker> GetWorker()
        {
            List<Worker> Listworkers = new List<Worker>();
            Listworkers.AddRange(new List<Worker>
            {
                new Worker(1,"A"),
                new Worker(2,"B"),
                new Worker(3,"C"),
                new Worker(4,"D"),
                new Worker(5,"E"),
                new Worker(6,"F"),
            });
            return Listworkers.AsQueryable();
        }
    }
}
