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
    [Table("TB_T_Return")]
    public class Return : BaseModel
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date_Return { get; set; }
        public int? User_Id { get; set; }

        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        public Item Item { get; set; }

        [ForeignKey("TypeItem")]
        public int TypeItem_Id { get; set; }
        public TypeItem TypeItem { get; set; }

        [ForeignKey("Condition")]
        public int Condition_Id { get; set; }
        public Condition Condition { get; set; }

        public Return () { }

        public Return(ReturnVM ReturnVM)
        {
            this.Quantity = ReturnVM.Quantity;
            this.Description = ReturnVM.Description;
            this.Date_Return = ReturnVM.Date_Return;
            this.User_Id = User_Id;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, ReturnVM ReturnVM)
        {
            this.Quantity = ReturnVM.Quantity;
            this.Description = ReturnVM.Description;
            this.Date_Return = ReturnVM.Date_Return;
            this.User_Id = User_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
