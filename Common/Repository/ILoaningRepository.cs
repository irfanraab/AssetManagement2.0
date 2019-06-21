using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface ILoaningRepository
    {
        List<Loaning> Get();
        List<Loaning> GetSearch(string values);
        Loaning Get(int id);
        bool Insert(LoaningVM loaningVM);
        bool Update(int id, LoaningVM loaningVM);
        bool Delete(int id);
    }
}
