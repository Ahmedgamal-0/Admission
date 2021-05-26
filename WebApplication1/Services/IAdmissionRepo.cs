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
        void AddParentInfo(int _ApplicantId, ParentInfo parentInfo);
        Applicant GetApplicant(int ApplicantId);
        bool ApplicantExist(int _ApplicantId);
        void AddEmergencyContact(int ApplicantId, EmergencyContact EmergencyContact);
        void AddDocument(int ApplicantId, Document Document);
        void AddAdmissionDetails(int ApplicantId, AdmissionDetails AdmissionDetails);
        bool Save();



    }
}
