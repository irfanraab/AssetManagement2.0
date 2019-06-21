using Core.Base;
using DataAccess.ViewModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("TB_M_Employee")]
    public class Employee : BaseModel
    {
        public string Name_Admin { get; set; }
        public string Name_User { get; set; }
        public int User_Id { get; set; }
        public int Admin_Id { get; set; }
        public int Divhead_Id { get; set; }


        public Employee() { }

        public Employee(EmployeeVM employeeVM)
        {
            this.User_Id = User_Id;
            this.Admin_Id = Admin_Id;
            this.Divhead_Id = Divhead_Id;
            this.Name_Admin = Name_Admin;
            this.Name_User = Name_User;
        }

        public void Update(int id, EmployeeVM employeeVM)
        {
            this.User_Id = User_Id;
            this.Admin_Id = Admin_Id;
            this.Divhead_Id = Divhead_Id;
            this.Name_Admin = Name_Admin;
            this.Name_User = Name_User;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }

    }
}
