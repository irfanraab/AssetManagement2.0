using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
   public  class EmployeeVM
    {
        public EmployeeVM(int user_Id, int admin_Id, int divhead_Id)
        {
            this.User_Id = User_Id;
            this.Admin_Id = Admin_Id;
            this.Divhead_Id = Divhead_Id;
            this.Name_Admin = Name_Admin;
            this.Name_User = Name_User;
        }

        public void Update(int id, int user_Id, int admin_Id, int divhead_Id)
        {
            this.Id = id;
            this.User_Id = User_Id;
            this.Admin_Id = Admin_Id;
            this.Divhead_Id = Divhead_Id;
            this.Name_Admin = Name_Admin;
            this.Name_User = Name_User;
        }

        public EmployeeVM () { }

        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Admin_Id { get; set; }
        public int Divhead_Id { get; set; }
        public string Name_Admin { get; set; }
        public string Name_User { get; set; }
    }
}
