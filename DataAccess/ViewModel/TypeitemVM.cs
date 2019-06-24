using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class TypeItemVM
    {
        public TypeItemVM() { }

        public TypeItemVM(string name_TypeItem)
        {
            this.Name_TypeItem = name_TypeItem;
        }

        public void Update(int id, string name_TypeItem)
        {
            this.Id = id;
            this.Name_TypeItem = name_TypeItem;
        }

        public int Id { get; set; }
        public string Name_TypeItem { get; set; }

        
    }
}
