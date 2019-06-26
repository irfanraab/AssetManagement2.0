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
    [Table("TB_M_Item")]
    public class Item : BaseModel
    {
        public Item() { }

        public string Name_Item { get; set; }
        public string Merk { get; set; }
        public string Description { get; set; }
        public string Photo_Item { get; set; }
        public DateTimeOffset Year_Procurement { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        [ForeignKey("TypeItem")]
        public int TypeItem_Id { get; set; }
        public TypeItem TypeItem { get; set; }

        [ForeignKey("Location")]
        public int Location_Id { get; set; }
        public Location Location { get; set; }

        [ForeignKey("Condition")]
        public int Condition_Id { get; set; }
        public Condition Condition { get; set; }

        public Item (ItemVM itemVM)
        {
            this.Name_Item = itemVM.Name_Item;
            this.Merk = itemVM.Merk;
            this.Description = itemVM.Description;
            this.Photo_Item = itemVM.Photo_Item;
            this.Year_Procurement = itemVM.Year_Procurement;
            this.Stock = itemVM.Stock;
            this.Price = itemVM.Price;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, ItemVM itemVM)
        {
            this.Name_Item = itemVM.Name_Item;
            this.Merk = itemVM.Merk;
            this.Description = itemVM.Description;
            this.Photo_Item = itemVM.Photo_Item;
            this.Year_Procurement = itemVM.Year_Procurement;
            this.Stock = itemVM.Stock;
            this.Price = itemVM.Price;
            this.Condition_Id = itemVM.Condition_Id;
            this.TypeItem_Id = itemVM.TypeItem_Id;
            this.Location_Id = itemVM.Location_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
