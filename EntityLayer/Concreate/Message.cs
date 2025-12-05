using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    [Table("Message")]
    public class Message
    {
        public int MessageID { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
