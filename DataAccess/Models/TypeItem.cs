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
    [Table("TB_M_TypeItem")]
    public class TypeItem : BaseModel
    {
        public TypeItem() { }

        public string Name_TypeItem { get; set; }

        public TypeItem(TypeItemVM typeitemVM)
        {
            this.Name_TypeItem = typeitemVM.Name_TypeItem;
            this.CreateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Update(int id, TypeItemVM typeItemVM)
        {
            this.Name_TypeItem = typeItemVM.Name_TypeItem;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
