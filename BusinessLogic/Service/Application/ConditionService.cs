using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository.Application;
using DataAccess.Models;
using DataAccess.ViewModel;

namespace BusinessLogic.Service.Application
{
    public class ConditionService : IConditionService
    {
        private readonly IConditionRepository iConditionRepository;
        bool status = false;
        public ConditionService() { }
        public ConditionService(IConditionRepository _iConditionRepository)
        {
            iConditionRepository = _iConditionRepository;
        }

        public List<Condition> Get()
        {
            return iConditionRepository.Get();
        }

        public Condition Get(int id)
        {
            return iConditionRepository.Get(id);
        }

        public bool Insert(ConditionVM conditionVM)
        {
            if (string.IsNullOrWhiteSpace(conditionVM.Condition_Name))
            {
                return status;
            }
            else
            {
                return iConditionRepository.Insert(conditionVM);
            }
        }

        public bool Update(int id, ConditionVM conditionVM)
        {
            if (string.IsNullOrWhiteSpace(conditionVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iConditionRepository.Update(id, conditionVM);
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                return iConditionRepository.Delete(id);
            }
        }
    }
}
