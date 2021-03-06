using AdmissionSystem.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Services
{
    public interface IAdmissionRepo
    {
        void AddApplicant(Applicant Applicant);
        void AddParentInfo(int _ApplicantId, ParentInfo parentInfo);
        void AddEmergencyContact(int ApplicantId, EmergencyContact EmergencyContact);
        void AddDocument(int ApplicantId, Document Document);
        void AddAdmissionDetails(int ApplicantId, AdmissionDetails AdmissionDetails);
        void AddSibling(int applicantId, Sibling sibling);
        void AddMedicalDetails(int applicantId, MedicalHistory medicalHistory);
        void MakePayment(Payment payment);
        Applicant GetApplicant(int ApplicantId);
        IEnumerable<ParentInfo> GetParentsInfos(int ApplicantId);
        ParentInfo GetParentInfos(int ApplicantId, string Gender);
        IEnumerable<EmergencyContact> GetEmergencyContacts(int ApplicantId);
        AdmissionDetails GetAdmissionDetails(int ApplicantId);
        void UpdateApplicant(Applicant Applicant);
        void UpdateParentInfo(ParentInfo ParentInfo);
        MedicalHistory GetMedicalHistory(int applicantId, Guid MedicalHistoryId);
        Sibling GetSibling(int applicantId, Guid siblingId);
        IEnumerable<Sibling> GetSiblings(int applicantId);

        bool ApplicantExist(int _ApplicantId);




        void DeleteSibling(Sibling sibling);

        void UpdateSibling(Sibling sibling);
        void UpdateMedicalDetails(MedicalHistory medicalHistory);


        bool Save();



    }
}
