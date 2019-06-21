using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
  public interface ITypeItemRepository
    {
        TypeItem Get(int id);
        List<TypeItem> GetSearch(string values);
        List<TypeItem> Get();
        bool Insert(TypeItemVM TypeItemVM);
        bool Update(int id, TypeItemVM TypeItemVM);
        bool Delete(int id);
    }
}
