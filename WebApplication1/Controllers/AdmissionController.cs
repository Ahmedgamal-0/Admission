using AdmissionSystem.Entities;
using AdmissionSystem.Models;
using AdmissionSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    [Route("api/AddApplicant")]
    public class AdmissionController : Controller
    {
        //private AdmissionSystemDbContext _admissionSystemDbContext;
        private IAdmissionRepo _AdmissionRepo;
        public AdmissionController(IAdmissionRepo AdmissionRepo)
        {
            _AdmissionRepo = AdmissionRepo;
        }

        [HttpPost]
        public IActionResult AddApplicant([FromBody] ApplicantForCreation ApplicantForCreation)
        {
            var final = Mapper.Map<Applicant>(ApplicantForCreation);
            _AdmissionRepo.AddApplicant(final);
            _AdmissionRepo.Save();

            return Ok();
        } 
        [HttpPost("{ApplicantId}/ParentInfo")]
        public IActionResult AddParentInfo(int ApplicantId,[FromBody] ParentInfoForCreation ParentInfoForCreation)
        {
            if (ParentInfoForCreation == null)
            {
                return BadRequest();
            }
            if (_AdmissionRepo.GetApplicant(ApplicantId) == null)
            {
                return NotFound();
            }
            var ParentInfo = Mapper.Map<ParentInfo>(ParentInfoForCreation);
            _AdmissionRepo.AddParentInfo(ApplicantId, ParentInfo);
            _AdmissionRepo.Save();
            return Ok();

        }
       

        [HttpPost("{ApplicantId}/EmergencyContact")]
        public IActionResult AddEmergencyContact(int ApplicantId, [FromBody] EmergencyContactForCreation EmergencyContactForCreation)
        {
            if (EmergencyContactForCreation == null)
            {
                return BadRequest();
            }
            if (_AdmissionRepo.GetApplicant(ApplicantId) == null)
            {
                return NotFound();
            }
            var EmergencyContact = Mapper.Map<EmergencyContact>(EmergencyContactForCreation);
            _AdmissionRepo.AddEmergencyContact(ApplicantId, EmergencyContact);
            _AdmissionRepo.Save();
            return Ok();
        }


      


        [HttpPost("AddSibling")]
        public IActionResult AddSibling(SiblingDto sibling)
        {
            if (sibling == null)
            {
                return BadRequest();
            }

            //HttpContext.Session.SetString("ApplicantId", "10");

            var siblingEntity = Mapper.Map<Sibling>(sibling);
            _AdmissionRepo.AddSibling(siblingEntity);

            if (!_AdmissionRepo.Save())
            {
                throw new Exception("failed to add an sibling");
            }

            return Ok();
            /*var siblingToReturn = Mapper.Map<SiblingDto>(siblingEntity);
            return CreatedAtRoute("getSibling", new { id = siblingToReturn.id }, siblingToReturn);
            */
        }

        [HttpPost("AddMedical")]
        public IActionResult AddMedicalDetails(MedicalHistoryDto medicalHistory)
        {
            if (medicalHistory == null)
            {
                return BadRequest();
            }

            var MedicalEntity = Mapper.Map<MedicalHistory>(medicalHistory);
            _AdmissionRepo.AddMedicalDetails(MedicalEntity);

            if (!_AdmissionRepo.Save())
            {
                throw new Exception("failed to add an sibling");
            }

            return Ok();
            /*var MedicalHistoryToReturn = Mapper.Map<MedicalHistoryDto>(MedicalEntity);
            return CreatedAtRoute("getMedicalHistory", new { id = MedicalHistoryToReturn.id }, MedicalHistoryToReturn);
            */

        }
    }
}