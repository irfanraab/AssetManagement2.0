using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IHandoverService
    {
        Handover Get(int id);
        List<Handover> GetSearch(string values);
        List<Handover> Get();
        bool Insert(HandoverVM handoverVM);
        bool Update(int id, HandoverVM handoverVM);
        bool Delete(int id);
    }
}
