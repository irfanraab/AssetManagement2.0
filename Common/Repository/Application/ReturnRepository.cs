using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModel;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class ReturnRepository : IReturnRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public Return Get(int id)
        {
            var get = myContext.Returns.Find(id);
            return get;
        }

        public bool Insert(ReturnVM ReturnVM)
        {
            var push = new Return(ReturnVM);
            var getItem = myContext.Items.Find(ReturnVM.Item_Id);
            push.Item = getItem;
            myContext.Returns.Add(push);
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

        public List<Return> Get()
        {
            var get = myContext.Returns.Include("Item").Include("TypeItem").Include("Condition").Include("Item.Location").Where(x => x.Item_Id == x.Item.Id && x.TypeItem_Id == x.TypeItem.Id && x.Condition_Id == x.Condition.Id && x.IsDelete == false).ToList();
            return get;
        }


        public bool Update(int id, ReturnVM ReturnVM)
        {
            var get = Get(id);
            var getItem = myContext.Items.Find(ReturnVM.Item_Id);
            get.Item = getItem;
            if (get != null)
            {
                get.Update(id, ReturnVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
