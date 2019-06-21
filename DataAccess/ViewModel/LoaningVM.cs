using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class LoaningVM
    {
        public LoaningVM() { }

        public LoaningVM(int user_Id, DateTimeOffset date_Loaning, DateTimeOffset date_Return, int quantity, int item_Id, int typeItem_Id)
        {
            this.User_Id = user_Id;
            this.Date_Loaning = date_Loaning;
            this.Date_Return = date_Return;
            this.Quantity = quantity;
            this.Item_Id = item_Id;
            this.TypeItem_Id = typeItem_Id;
        }

        public int Id { get; set; }
        public int User_Id { get; set; }
        public DateTimeOffset Date_Loaning { get; set; }
        public DateTimeOffset Date_Return { get; set; }
        public int Quantity { get; set; }

        public int Item_Id { get; set; }
        public int TypeItem_Id { get; set; }
    }
}
