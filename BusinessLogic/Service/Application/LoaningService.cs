using Common.Repository;
using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
    public class LoaningService : ILoaningService
    {
        private readonly ILoaningRepository iLoaningRepository;
        bool status = false;
        public LoaningService() { }
        public LoaningService(ILoaningRepository _iLoaningRepository)
        {
            iLoaningRepository = _iLoaningRepository;
        }

        public List<Loaning> Get()
        {
            return iLoaningRepository.Get();
        }

        public List<Loaning> GetSearch(string values)
        {
            return iLoaningRepository.GetSearch(values);
        }

        public Loaning Get(int id)
        {
            return iLoaningRepository.Get(id);
        }

        public bool Insert(LoaningVM loaningVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(loaningVM.User_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(loaningVM.Date_Loaning)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(loaningVM.Date_Return)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(loaningVM.Item_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(loaningVM.TypeItem_Id)))
            {
                return status;
            }
            else
            {
                return iLoaningRepository.Insert(loaningVM);
            }
        }

        public bool Update(int id, LoaningVM loaningVM)
        {
            if (string.IsNullOrWhiteSpace(loaningVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iLoaningRepository.Update(id, loaningVM);
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
                return iLoaningRepository.Delete(id);
            }
        }
    }
}
