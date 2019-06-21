using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
   public interface ILocationService
    {
        List<Location> Get();
        Location Get(int id);
        bool Insert(LocationVM locationVM);
        bool Update(int id, LocationVM locationVM);
        bool Delete(int id);
    }
}
