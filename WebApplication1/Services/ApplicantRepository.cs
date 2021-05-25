using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmissionSystem.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionSystem.Services
{
    public class ApplicantRepository : IApplicantRepository
    {
        private AdmissionSystemDbContext _context;
        public ApplicantRepository (AdmissionSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult AddMedicalDetails()
        {
            throw new NotImplementedException();
        }

        public IActionResult AddSiblingDetails()
        {
            throw new NotImplementedException();
        }
    }
}
