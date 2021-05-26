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

       public  void AddParentInfo(int _ApplicantId,ParentInfo parentInfo)
        {
            var Applicant = GetApplicant(_ApplicantId);
            if ( Applicant != null)
            {
                Applicant.ParentInfo.Add(parentInfo);
            }
        }
        public Applicant GetApplicant(int _ApplicantId)
        {
            var Applicant = _AdmissionSystemDbContext.Applicant.FirstOrDefault(a => a.ApplicantId ==_ApplicantId);
            return Applicant;

        }
        public bool ApplicantExist(int _ApplicantId)
        {
            var Applicant= _AdmissionSystemDbContext.Applicant.Any(a => a.ApplicantId == _ApplicantId);
            return Applicant;
        }
        public void AddEmergencyContact(int ApplicantId,EmergencyContact EmergencyContact)
        {
            var Applicant = GetApplicant(ApplicantId);
            if (Applicant != null)
            {
                Applicant.EmergencyContact.Add(EmergencyContact);
            }
        }
        public void AddAdmissionDetails(int ApplicantId, AdmissionDetails AdmissionDetails)
        {
            var Applicant = GetApplicant(ApplicantId);
            if (Applicant != null)
            {
                Applicant.AdmissionDetails = AdmissionDetails;
            }
        }
        public void AddDocument(int ApplicantId, Document Document)
        {
            var Applicant = GetApplicant(ApplicantId);
            if (Applicant != null)
            {
                Applicant.Documents.Add(Document);
            }
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
