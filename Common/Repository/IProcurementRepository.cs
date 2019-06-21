using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IProcurementRepository
    {
        List<Procurement> Get();
        List<Procurement> GetSearch(string values);
        Procurement Get(int id);
        bool Insert(ProcurementVM procurementVM);
        bool Update(int id, ProcurementVM procurementVM);
        bool Delete(int id);
    }
}
