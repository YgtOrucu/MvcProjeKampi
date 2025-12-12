using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Role")]
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleType { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
