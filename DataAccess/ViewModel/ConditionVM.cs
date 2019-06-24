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

        public ConditionVM(string condition_Name)
        {
            this.Condition_Name = condition_Name;
        }

        public void Update(int id, string condition_Name)
        {
            this.Id = id;
            this.Condition_Name = condition_Name;
        }

        public int Id { get; set; }
        public string Condition_Name { get; set; }
    }
}
