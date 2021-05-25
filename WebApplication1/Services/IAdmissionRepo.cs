using AdmissionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Services
{
    public interface IAdmissionRepo
    {
        void AddApplicant(Applicant Applicant);
        bool Save();



    }
}
