using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Entities
{
    public class Sibling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SibilingId { set; get; }
        public string Relationship { set; get; }
        public string SiblingName { set; get; }
        public int Age { set; get; }
        public string SchoolName { set; get; }

        [ForeignKey("ApplicantId")]
        public Applicant Applicant { set; get; }
        public int ApplicantId { set; get; }


    }
}
