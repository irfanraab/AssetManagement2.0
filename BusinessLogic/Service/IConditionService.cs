using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IConditionService
    {
        List<Condition> Get();
        Condition Get(int id);
        bool Insert(ConditionVM conditionVM);
        bool Update(int id, ConditionVM conditionVM);
        bool Delete(int id);
    }
}
