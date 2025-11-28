using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("About")]
    public class About
    {
        public int AboutID { get; set; }
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
