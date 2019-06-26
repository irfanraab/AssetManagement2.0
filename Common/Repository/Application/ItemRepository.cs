using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.Application
{
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();
        bool status;

        public Item Get(int id)
        {
            var get = myContext.Items.Find(id);
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            var push = new Item(itemVM);
            var getTypeItem = myContext.TypeItems.Find(itemVM.TypeItem_Id);
            var getLocation = myContext.Locations.Find(itemVM.Location_Id);
            var getCondition = myContext.Conditions.Find(itemVM.Condition_Id);
            push.TypeItem = getTypeItem;
            push.Location = getLocation;
            push.Condition = getCondition;
            myContext.Items.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {

                status = true;
            }
            else
            {
                return status;
            }
            return status;
        }

        public bool Update(int id, ItemVM itemVM)
        {
            var get = Get(id);
            var getTypeItem = myContext.TypeItems.Find(itemVM.TypeItem_Id);
            var getLocation = myContext.Locations.Find(itemVM.Location_Id);
            var getCondition = myContext.Conditions.Find(itemVM.Condition_Id);
            get.TypeItem = getTypeItem;
            get.Location = getLocation;
            get.Condition = getCondition;
            if (get != null)
            {
                get.Update(id, itemVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Item> GetSearch(string values)
        {
            var get = myContext.Items.Include("TypeItem").Where
                (x => (x.Id.ToString().Contains(values)) || 
                (x.Name_Item.Contains(values)) ||
                (x.Stock.ToString().Contains(values)) ||
                (x.Year_Procurement.ToString().Contains(values)) ||
                (x.Merk.Contains(values)) ||
                (x.TypeItem.Name_TypeItem.Contains(values)) ||
                x.Id.ToString().Contains(values) &&
                x.IsDelete == false).ToList();
            return get;
        }

        public List<Item> Get()
        {
            var get = myContext.Items.Include("TypeItem").Include("Location").Include("Condition").Where(x => x.TypeItem_Id == x.TypeItem.Id && x.Location_Id == x.Location.Id && x.Condition_Id == x.Condition.Id && x.IsDelete == false).ToList();
            return get;
        }

        public List<TypeItem> GetTypeItemByModule(string modulQuery)
        {
            return myContext.TypeItems.Where(x => x.IsDelete == false && x.Name_TypeItem.Contains(modulQuery)).ToList();
        }

        public List<Location> GetLocationByModule(string modulQuery)
        {
            return myContext.Locations.Where(x => x.IsDelete == false && x.Name_Location.Contains(modulQuery)).ToList();
        }

        public List<Condition> GetConditionByModule(string moduleQuery)
        {
            return myContext.Conditions.Where(x => x.IsDelete == false && x.Condition_Name.Contains(moduleQuery)).ToList();
        }
    }
}
