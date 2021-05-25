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
    [Route("api/testDatabase")]
    public class AdmissionController : Controller
    {
        //private AdmissionSystemDbContext _admissionSystemDbContext;
        private IAdmissionRepo _AdmissionRepo;
        public AdmissionController(IAdmissionRepo AdmissionRepo)
        {
            _AdmissionRepo = AdmissionRepo;
        }
        
        [HttpPost]
        public IActionResult test([FromBody] ApplicantForCreation ApplicantForCreation)
        {
            var final = Mapper.Map<Applicant>(ApplicantForCreation);
            _AdmissionRepo.AddApplicant(final);
            _AdmissionRepo.Save();
            
            return Ok();
        }

        [HttpPost("AddSibling")]
        public IActionResult AddSibling(SiblingDto sibling)
        {
            if(sibling == null)
            {
                return BadRequest();
            }

            //HttpContext.Session.SetString("ApplicantId", "10");

            var siblingEntity = Mapper.Map <Sibling>(sibling);
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
