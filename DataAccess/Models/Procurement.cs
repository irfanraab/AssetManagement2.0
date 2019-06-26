using Core.Base;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_T_Procurement")]
    public class Procurement : BaseModel
    {
        public Procurement() { }

        public string Name_Procurement { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date_Procurement { get; set; }
        public int Quantity { get; set; }
        
        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        public Item Item { get; set; }

        [ForeignKey("TypeItem")]
        public int TypeItem_Id { get; set; }
        public TypeItem TypeItem { get; set; }

        public Procurement(ProcurementVM procurementVM)
        {
            this.Name_Procurement = procurementVM.Name_Procurement;
            this.Description = procurementVM.Description;
            this.Price = procurementVM.Price;
            this.Date_Procurement = procurementVM.Date_Procurement;
            this.Quantity = procurementVM.Quantity;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, ProcurementVM procurementVM)
        {
            this.Name_Procurement = procurementVM.Name_Procurement;
            this.Description = procurementVM.Description;
            this.Price = procurementVM.Price;
            this.Date_Procurement = procurementVM.Date_Procurement;
            this.Quantity = procurementVM.Quantity;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
