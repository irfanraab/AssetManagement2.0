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
    [Table("TB_M_Condition")]
    public class Condition : BaseModel
    {
        public Condition() { }

        public string Condition_Name { get; set; }

        public Condition(ConditionVM conditionVM)
        {
            this.Condition_Name = conditionVM.Condition_Name;
        }

        public void Update(int id, ConditionVM conditionVM)
        {
            this.Condition_Name = conditionVM.Condition_Name;
            
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
