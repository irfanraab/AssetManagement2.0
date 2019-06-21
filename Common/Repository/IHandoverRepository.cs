using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IHandoverRepository
    {
        List<Handover> Get();
        Handover Get(int id);
        bool Insert(HandoverVM HandoverVM);
        bool Update(int id, HandoverVM HandoverVM);
        bool Delete(int id);
    }
}
