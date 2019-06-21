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
    [Table("TB_M_Location")]
    public class Location : BaseModel
    {
        public Location() { }

        public string Name_Location { get; set; }
        public string Floor { get; set; }

        public Location(LocationVM locationVM)
        {
            this.Name_Location = locationVM.Name_Location;
            this.Floor = locationVM.Floor;
        }

        public void Update(int id, LocationVM locationVM)
        {
            this.Name_Location = locationVM.Name_Location;
            this.Floor = locationVM.Floor;
            this.UpdateDate = DateTimeOffset.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.ToLocalTime();
        }
    }
}
