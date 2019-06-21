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
    public class HandoverRepository : IHandoverRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public Handover Get(int id)
        {
            var get = myContext.Handovers.Find(id);
            return get;
        }

        public bool Insert(HandoverVM HandoverVM)
        {
            var push = new Handover(HandoverVM);
            var getLoaning = myContext.Loanings.Find(HandoverVM.Loaning_Id);
            var getReturn = myContext.Returns.Find(HandoverVM.Return_Id);
            push.Loaning = getLoaning;
            push.Return = getReturn;
            myContext.Handovers.Add(push);
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


        public bool Update(int id, HandoverVM HandoverVM)
        {
            var get = Get(id);
            var getLoaning = myContext.Loanings.Find(HandoverVM.Loaning_Id);
            var getReturn = myContext.Returns.Find(HandoverVM.Return_Id);
            get.Loaning = getLoaning;
            get.Return = getReturn;
            if (get != null)
            {
                get.Update(id, HandoverVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Handover> Get()
        {
            var get = myContext.Handovers.Include("Loaning").Include("Return").Include("Loaning.Item").Include("Loaning.TypeItem").Include("Loaning.Item.Location").Where(x => x.Loaning_Id == x.Loaning.Id && x.Return_Id == x.Return.Id && x.IsDelete == false).ToList();
            return get;
        }
    }
}
