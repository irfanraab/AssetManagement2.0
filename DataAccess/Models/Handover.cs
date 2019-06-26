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
    [Table("TB_T_Handover")]
    public class Handover : BaseModel
    {
        public string Description { get; set; }
        public DateTimeOffset Date_Handover { get; set; }
        public int? User_Id { get; set; }
        public int? Divhead_Id { get; set; }

        [ForeignKey("TypeItem")]
        public int TypeItem_Id { get; set; }
        public TypeItem TypeItem { get; set; }

        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        public Item Item { get; set; }

        [ForeignKey("Loaning")]
        public int Loaning_Id { get; set; }
        public Loaning Loaning { get; set; }

        [ForeignKey("Return")]
        public int Return_Id { get; set; }
        public Return Return { get; set; }
        
        public Handover() { }
        
        public Handover(HandoverVM HandoverVM)
        {
            this.Description = HandoverVM.Description;
            this.Date_Handover = HandoverVM.Date_Handover;
            this.User_Id = HandoverVM.User_Id;
            this.Divhead_Id = HandoverVM.Divhead_Id;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, HandoverVM HandoverVM)
        {
            this.Description = HandoverVM.Description;
            this.Date_Handover = HandoverVM.Date_Handover;
            this.User_Id = HandoverVM.User_Id;
            this.Divhead_Id = HandoverVM.Divhead_Id;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
