using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModel;
using Common.Repository;
using BusinessLogic.Service;

namespace BusinessLogic.Service.Application
{
    public class HandoverService : IHandoverService
    {
        private readonly IHandoverRepository iHandoverRepository;
        bool status = false;
        public HandoverService() { }
        public HandoverService(IHandoverRepository _iHandoverRepository)
        {
            iHandoverRepository = _iHandoverRepository;
        }

        public Handover Get(int id)
        {
            return iHandoverRepository.Get(id);
        }

        public List<Handover> GetSearch(string values)
        {
            throw new NotImplementedException();
        }

        public List<Handover> Get()
        {
            return iHandoverRepository.Get();
        }

        public bool Insert(HandoverVM handoverVM)
        {
            if (string.IsNullOrWhiteSpace(handoverVM.Description))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.Date_Handover)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.TypeItem_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.Item_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.User_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.Divhead_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.Loaning_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(handoverVM.Return_Id)))
            {
                return status;
            }
            else
            {
                return iHandoverRepository.Insert(handoverVM);
            }
        }

        public bool Update(int id, HandoverVM handoverVM)
        {
            if (string.IsNullOrWhiteSpace(handoverVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iHandoverRepository.Update(id, handoverVM);
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
                return iHandoverRepository.Delete(id);
            }
        }
    }
}
