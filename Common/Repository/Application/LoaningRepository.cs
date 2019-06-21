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
    public class LoaningRepository : ILoaningRepository
    {
        MyContext myContext = new MyContext();
        bool status;

        public Loaning Get(int id)
        {
            var get = myContext.Loanings.Find(id);
            return get;
        }

        public bool Insert(LoaningVM loaningVM)
        {
            var push = new Loaning(loaningVM);
            var getTypeItem = myContext.TypeItems.Find(loaningVM.TypeItem_Id);
            var getItem = myContext.Items.Find(loaningVM.Item_Id);
            push.TypeItem = getTypeItem;
            push.Item = getItem;
            myContext.Loanings.Add(push);
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

        public bool Update(int id, LoaningVM loaningVM)
        {
            var get = Get(id);
            var getTypeItem = myContext.TypeItems.Find(loaningVM.TypeItem_Id);
            var getItem = myContext.Items.Find(loaningVM.Item_Id);
            get.TypeItem = getTypeItem;
            get.Item = getItem;
            if (get != null)
            {
                get.Update(id, loaningVM);
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

        public List<Loaning> GetSearch(string values)
        {
            var get = myContext.Loanings.Include("Item").Where
                (x => (x.Item_Id.ToString().Contains(values)) ||
                (x.Item.Name_Item.Contains(values)) ||
                (x.Quantity.ToString().Contains(values)) ||
                x.Id.ToString().Contains(values) &&
                x.IsDelete == false).ToList();
            return get;
        }

        public List<Loaning> Get()
        {
            var get = myContext.Loanings.Include("Item").Include("TypeItem").Include("Item.Location").Where(x => x.Item_Id == x.Item.Id && x.TypeItem_Id == x.TypeItem.Id && x.IsDelete == false).ToList();
            return get;
        }
    }
}
