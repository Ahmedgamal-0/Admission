using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Entities
{
    [Table("BankElahly")]
    public class BankElahly : Payment
    {
        public String BankCode { set; get; }
    }
}
