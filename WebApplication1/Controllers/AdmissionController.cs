using AdmissionSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    public class AdmissionController : Controller
    {
        private AdmissionSystemDbContext _admissionSystemDbContext;
        public AdmissionController(AdmissionSystemDbContext admissionSystemDbContext)
        {
            _admissionSystemDbContext = admissionSystemDbContext;
        }
        [Route("api/testDatabase")]
        public IActionResult test()
        {
            return Ok();
        }
    }
}
