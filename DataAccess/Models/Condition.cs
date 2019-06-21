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

        public string Conditon { get; set; }

        public Condition(ConditionVM conditionVM)
        {
            this.Conditon = conditionVM.Condition;
        }

        public void Update(int id, ConditionVM conditionVM)
        {
            this.Conditon = conditionVM.Condition;
            
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
