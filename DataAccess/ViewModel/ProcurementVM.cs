using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ProcurementVM
    {
        public ProcurementVM() { }

        public ProcurementVM(string name_Procurement, string description, double price, DateTimeOffset date_procurement, int quantity, int item_Id, int typeItem_Id )
        {
            this.Name_Procurement = name_Procurement;
            this.Description = description;
            this.Price = price;
            this.Date_Procurement = date_procurement;
            this.Quantity = quantity;
            this.Item_Id = item_Id;
            this.TypeItem_Id = typeItem_Id;
        }

        public void Update(int id, string name_Procurement, string description, double price, DateTimeOffset date_procurement, int quantity, int item_Id, int typeItem_Id)
        {
            this.Id = id;
            this.Name_Procurement = name_Procurement;
            this.Description = description;
            this.Price = price;
            this.Date_Procurement = date_procurement;
            this.Quantity = quantity;
            this.Item_Id = item_Id;
            this.TypeItem_Id = typeItem_Id;
        }

        public int Id { get; set; }
        public string Name_Procurement { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date_Procurement { get; set; }
        public int Quantity { get; set; }

        public int Item_Id { get; set; }
        public int TypeItem_Id { get; set; }
    }
}
