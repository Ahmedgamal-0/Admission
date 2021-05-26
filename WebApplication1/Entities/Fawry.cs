using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Entities
{
    [Table("Fawry")]
    public class Fawry : Payment
    {
        public String FawryCode { set; get; }
    }
}
