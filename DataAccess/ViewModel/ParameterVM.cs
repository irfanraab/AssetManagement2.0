using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
   public class ParameterVM
    {
        public ParameterVM() { }

        public ParameterVM(string name_Validation, string punishment)
        {
            this.Name_Validation = Name_Validation;
            this.Punishment = Punishment;
        }

        public int Id { get; set; }
        public string Name_Validation { get; set; }
        public string Punishment { get; set; }
    }
}
