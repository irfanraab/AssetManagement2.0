using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.Application
{
    public interface IConditionRepository
    {
        List<Condition> Get();
        Condition Get(int id);
        bool Insert(ConditionVM itemVM);
        bool Update(int id, ConditionVM itemVM);
        bool Delete(int id);
    }
}
