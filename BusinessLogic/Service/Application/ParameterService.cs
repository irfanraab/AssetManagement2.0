using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModel;
using Common.Repository;

namespace BusinessLogic.Service.Application
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository iParameterRepository;
        bool status = false;
        public ParameterService() { }
        public ParameterService(IParameterRepository _iParameterRepository)
        {
            iParameterRepository = _iParameterRepository;
        }

        public List<Parameter> Get()
        {
            return iParameterRepository.Get();
        }

        public Parameter Get(int id)
        {
            return iParameterRepository.Get(id);
        }

        public bool Insert(ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Name_Validation)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(parameterVM.Punishment)))
            {
                return status;
            }
            else
            {
                return iParameterRepository.Insert(parameterVM);
            }
        }

        public bool Update(int id, ParameterVM parameterVM)
        {
            if (string.IsNullOrWhiteSpace(parameterVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iParameterRepository.Update(id, parameterVM);
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
                return iParameterRepository.Delete(id);
            }
        }
    }
}
