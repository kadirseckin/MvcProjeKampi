using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {       
        [Key]
        public int MessageID { get; set; }

        [StringLength(50), DisplayName("Gönderici mail")]
        public string SenderMail { get; set; }
        [StringLength(50), DisplayName("Alıcı mail")]
        public string ReceiverMail{ get; set; }

        [StringLength(100), DisplayName("Konu")]
        public string Subject { get; set; }

        [DisplayName("Mesaj içeriği")]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
