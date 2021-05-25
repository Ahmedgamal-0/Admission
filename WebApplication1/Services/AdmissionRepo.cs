using AdmissionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Services
{
    public class AdmissionRepo:IAdmissionRepo
    {
        private AdmissionSystemDbContext _AdmissionSystemDbContext;
        public AdmissionRepo(AdmissionSystemDbContext admissionSystemDbContext)
        {
            _AdmissionSystemDbContext = admissionSystemDbContext;
        }
        public void AddApplicant(Applicant Applicant)
        {
            _AdmissionSystemDbContext.Applicant.Add(Applicant);
        }

        public void AddMedicalDetails(MedicalHistory medicalHistory)
        {
            _AdmissionSystemDbContext.MedicalHistory.Add(medicalHistory);
        }

        public void AddSibling(Sibling sibling)
        {
            _AdmissionSystemDbContext.Siblings.Add(sibling);
        }

        public void MakePayment(MedicalHistory medicalHistory)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_AdmissionSystemDbContext.SaveChanges() >= 0);
        }


    }
}
