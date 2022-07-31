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
    public class WorkAssignementService : IWorkAssignementService
    {
        IWorkAssignementRepository workAssignementRepository; 

        public WorkAssignementService(IWorkAssignementRepository _workAssignementRepository)
        {
            workAssignementRepository = _workAssignementRepository;
        }
        public List<WorkAssignement> GetWorkAssignement()
        {
            try
            {
                return workAssignementRepository.GetWorkAssignement();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddWorkAssignement(WorkAssignement workAssignement)
        {
            try
            {
                return workAssignementRepository.AddWorkAssignement(workAssignement);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateWorkAssignement(WorkAssignement workAssignement)
        {
            try
            {
                return workAssignementRepository.UpdateWorkAssignement(workAssignement);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteWorkAssignement(int workAssignementId)
        {
            try
            {
                return workAssignementRepository.DeleteWorkAssignement(workAssignementId);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
