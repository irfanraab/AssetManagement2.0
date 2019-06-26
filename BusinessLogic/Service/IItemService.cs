using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IItemService
    {
        List<Item> Get();
        List<Item> GetSearch(string values);
        Item Get(int id);
        bool Insert(ItemVM itemVM);
        bool Update(int id, ItemVM itemVM);
        bool Delete(int id);
        List<TypeItem> GetTypeItemByModule(string modulQuery);
        List<Location> GetLocationByModule(string modulQuery);
        List<Condition> GetConditionByModule(string modulQuery);
    }
}
