using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class ReturnVM
    {
        public ReturnVM(int quantity, string description, DateTimeOffset date_Return, int user_Id, int item_Id, int typeItem_Id, int condition_Id)
        {
            this.Quantity = quantity;
            this.Description = description;
            this.Date_Return = date_Return;
            this.User_Id = user_Id;
            this.Item_Id = item_Id;
            this.TypeItem_Id = typeItem_Id;
            this.Condition_Id = condition_Id;
        }

        public ReturnVM() { }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date_Return { get; set; }
        public int User_Id { get; set; }
        public int Item_Id { get; set; }
        public int TypeItem_Id { get; set; }
        public int Condition_Id { get; set; }
    }
}
