using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlydiem.Models
{
    
        [Table("HOSSINHS")]
        public class HOCSINH
        {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            this.LOPS = new HashSet<LOP>();
        }

        [Key]
            public String MaHS { get; set; }
            [AllowHtml]
            public String TenHS { get; set; }
            public string NamSinh { get; set; }
            public string GioiTinh { get; set; }
            public String QueQuan { get; set; }
            public String MaLop { get; set; }
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<LOP> LOPS { get; set; }


    }
}

