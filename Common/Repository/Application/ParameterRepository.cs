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
    public class ParameterRepository : IParameterRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public Parameter Get(int id)
        {
            var get = myContext.Parameters.Find(id);
            return get;
        }

        public bool Insert(ParameterVM ParameterVM)
        {
            var push = new Parameter(ParameterVM);
            myContext.Parameters.Add(push);
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

        public bool Update(int id, ParameterVM ParameterVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, ParameterVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Parameter> Get()
        {
            var get = myContext.Parameters.Where(x => x.IsDelete == false).ToList();
            return get;
        }
    }
}
