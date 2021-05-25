using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionSystem.Services
{
    public interface IApplicantRepository 
    {
        IActionResult AddMedicalDetails();
        IActionResult AddSiblingDetails();
    }
}
