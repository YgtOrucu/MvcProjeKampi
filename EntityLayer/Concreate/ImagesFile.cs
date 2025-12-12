using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("ImageFiles")]
    public class ImagesFile
    {
        public int ImagesID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
