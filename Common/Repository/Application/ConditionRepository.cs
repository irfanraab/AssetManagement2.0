using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModel;

namespace Common.Repository.Application
{
    public class ConditionRepository : IConditionRepository
    {
        MyContext myContext = new MyContext();
        bool status;

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

        public List<Condition> Get()
        {
            var get = myContext.Conditions.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Condition Get(int id)
        {
            var get = myContext.Conditions.Find(id);
            return get;
        }

        public bool Insert(ConditionVM conditionVM)
        {
            var push = new Condition(conditionVM);
            myContext.Conditions.Add(push);
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

        public bool Update(int id, ConditionVM conditionVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, conditionVM);
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
