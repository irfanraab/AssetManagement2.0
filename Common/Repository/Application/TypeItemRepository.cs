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
    public class TypeItemRepository : ITypeItemRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public TypeItem Get(int id)
        {
            var get = myContext.TypeItems.Find(id);
            return get;
        }

        public bool Insert(TypeItemVM TypeItemVM)
        {
            var push = new TypeItem(TypeItemVM);
            myContext.TypeItems.Add(push);
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


        public bool Update(int id, TypeItemVM TypeItemVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, TypeItemVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TypeItem> GetSearch(string values)
        {
            throw new NotImplementedException();
        }

        public List<TypeItem> Get()
        {
            var get = myContext.TypeItems.Where(x => x.IsDelete == false).ToList();
            return get;
        }
    }
}
