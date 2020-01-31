using GAPTechTest.Models;
using GoIn.DataAccess.Repositories;
using System.Collections.Generic;

namespace GAPTechTest.Services
{
    public class PolicyService : BaseService
    {
        public PolicyService(UnitOfWork unitOfWork) : 
            base(unitOfWork)
        {
                
        }

        public IEnumerable<Policy> GetAll()
        {
            return UnitOfWork.PolicyRepository.GetAll();
        }

        public Policy GetById(int policyId)
        {

            return UnitOfWork.PolicyRepository.Single(policyId);
        }

        public int Create(Policy policy)
        {
            UnitOfWork.PolicyRepository.Insert(policy);            
            UnitOfWork.Save();
            return policy.Id;
        }

        public int Update(Policy policy)
        {
            UnitOfWork.PolicyRepository.Update(policy);
            UnitOfWork.Save();
            return policy.Id;
        }

        public void Delete(int policyId)
        {
            UnitOfWork.PolicyRepository.Delete(policyId);
            UnitOfWork.Save();
        }
    }
}
