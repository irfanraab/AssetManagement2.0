using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ItemVM
    {
        public ItemVM() { }

        public ItemVM(string name_Item, string merk, string description, string photo_Item, DateTimeOffset year_Procurement, int stock, double price, int typeItem_Id, int location_Id, int condition_Id)
        {
            this.Name_Item = name_Item;
            this.Merk = merk;
            this.Description = description;
            this.Photo_Item = photo_Item;
            this.Year_Procurement = year_Procurement;
            this.Stock = stock;
            this.Price = price;
            this.TypeItem_Id = typeItem_Id;
            this.Location_Id = location_Id;
            this.Condition_Id = condition_Id;
        }

        public void Update(int id, string name_Item, string merk, string description, string photo_Item, DateTimeOffset year_Procurement, int stock, double price, int typeItem_Id, int location_Id, int condition_Id)
        {
            this.Id = id;
            this.Name_Item = name_Item;
            this.Merk = merk;
            this.Description = description;
            this.Photo_Item = photo_Item;
            this.Year_Procurement = year_Procurement;
            this.Stock = stock;
            this.Price = price;
            this.TypeItem_Id = typeItem_Id;
            this.Location_Id = location_Id;
            this.Condition_Id = condition_Id;
        }

        public int Id { get; set; }
        public string Name_Item { get; set; }
        public string Merk { get; set; }
        public string Description { get; set; }
        public string Photo_Item { get; set; }
        public DateTimeOffset Year_Procurement { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public int TypeItem_Id { get; set; }
        public int Location_Id { get; set; }
        public int Condition_Id { get; set; }
    }
}
