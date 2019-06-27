using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ILoaningService
    {
        List<Loaning> Get();
        List<Loaning> GetSearch(string values);
        List<Item> GetItemByModule(string modulQuery);
        List<TypeItem> GetTypeItemByModule(string modulQuery);
        Loaning Get(int id);
        bool Insert(LoaningVM loaningVM);
        bool Update(int id, LoaningVM loaningVM);
        bool Delete(int id);
    }
}
