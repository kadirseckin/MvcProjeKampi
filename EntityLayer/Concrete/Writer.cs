using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50),DisplayName("Yazar adı")]
        public string WriterName { get; set; }

        [StringLength(50), DisplayName("Yazar soyadı")]
        public string WriterSurName { get; set; }

        [StringLength(200), DisplayName("Yazar fotoğraf")]
        public string WriterImage { get; set; }

        [StringLength(100), DisplayName("Yazar hakkında")]
        public string WriterAbout { get; set; }

        [StringLength(200), DisplayName("Yazar e-mail")]
        public string WriterMail { get; set; }

        [StringLength(200), DisplayName("Yazar şifre")]
        public string WriterPassword { get; set; }

        [StringLength(50), DisplayName("Yazar unvanı")]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }


        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
        

    }
}
