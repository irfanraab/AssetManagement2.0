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
    public class LocationRepository : ILocationRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public Location Get(int id)
        {
            var get = myContext.Locations.Find(id);
            return get;
        }

        public bool Insert(LocationVM LocationVM)
        {
            var push = new Location(LocationVM);
            myContext.Locations.Add(push);
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


        public bool Update(int id, LocationVM LocationVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, LocationVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Location> Get()
        {
            var get = myContext.Locations.Where(x => x.IsDelete == false).ToList();
            return get;
        }
    }
}
