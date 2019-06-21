using Common.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ViewModel;

namespace BusinessLogic.Service.Application
{
   public class LocationService : ILocationService
    {
        private readonly ILocationRepository iLocationRepository;
        bool status = false;
        public LocationService() { }
        public LocationService(ILocationRepository _iLocationRepository)
        {
            iLocationRepository = _iLocationRepository;
        }

        public List<Location> Get()
        {
            return iLocationRepository.Get();
        }

        public Location Get(int id)
        {
            return iLocationRepository.Get(id);
        }

        public bool Insert(LocationVM locationVM)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(locationVM.Name_Location)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(locationVM.Floor)))
            {
                return status;
            }
            else
            {
                return iLocationRepository.Insert(locationVM);
            }
        }

        public bool Update(int id, LocationVM locationVM)
        {
            if (string.IsNullOrWhiteSpace(locationVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iLocationRepository.Update(id, locationVM);
            }
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                return iLocationRepository.Delete(id);
            }
        }
    }
}
