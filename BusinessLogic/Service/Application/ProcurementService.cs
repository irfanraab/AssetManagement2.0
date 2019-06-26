using Common.Repository;
using DataAccess.Models;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
    public class ProcurementService : IProcurementService
    {
        private readonly IProcurementRepository iProcurementRepository;
        bool status = false;
        public ProcurementService() { }
        public ProcurementService(IProcurementRepository _iProcurementRepository)
        {
            iProcurementRepository = _iProcurementRepository;
        }

        public List<Procurement> Get()
        {
            return iProcurementRepository.Get();
        }

        public List<Procurement> GetSearch(string values)
        {
            return iProcurementRepository.GetSearch(values);
        }

        public Procurement Get(int id)
        {
            return iProcurementRepository.Get(id);
        }

        public bool Insert(ProcurementVM procurementVM)
        {
            if (string.IsNullOrWhiteSpace(procurementVM.Name_Procurement))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(procurementVM.Description))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(procurementVM.Price)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(procurementVM.Date_Procurement)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(procurementVM.Quantity)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(procurementVM.Item_Id)))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(Convert.ToString(procurementVM.TypeItem_Id)))
            {
                return status;
            }
            else
            {
                return iProcurementRepository.Insert(procurementVM);
            }
        }

        public bool Update(int id, ProcurementVM procurementVM)
        {
            if (string.IsNullOrWhiteSpace(procurementVM.Id.ToString()))
            {
                return status;
            }
            else
            {
                return iProcurementRepository.Update(id, procurementVM);
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
                return iProcurementRepository.Delete(id);
            }
        }
    }
}