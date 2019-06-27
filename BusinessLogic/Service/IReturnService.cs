using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IReturnService
    {
        Return Get(int id);
        List<Return> Get();
        List<Item> GetItemByModule(string modulQuery);
        List<TypeItem> GetTypeItemByModule(string modulQuery);
        List<Condition> GetConditionByModule(string modulQuery);
        bool Insert(ReturnVM returnVM);
        bool Update(int id, ReturnVM returnVM);
        bool Delete(int id);
    }
}
