using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ITypeItemService
    {
        TypeItem Get(int id);
        List<TypeItem> GetSearch(string values);
        List<TypeItem> Get();
        bool Insert(TypeItemVM typeItemVM);
        bool Update(int id, TypeItemVM typeItemVM);
        bool Delete(int id);
    }
}
