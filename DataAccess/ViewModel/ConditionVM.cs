using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ConditionVM
    {
        public ConditionVM() { }

        public ConditionVM(string condition)
        {
            this.Condition = condition;
        }

        public int Id { get; set; }
        public string Condition { get; set; }
    }
}
