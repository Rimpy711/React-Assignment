using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoctorsOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntakeFormsController : ControllerBase
    {
        private readonly ILogger<IntakeFormsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public IntakeFormsController(ILogger<IntakeFormsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IntakeForm> Get()
        {
            return _context.IntakeForms.ToList();
        }

        [HttpPost]
        public void Post([FromBody] IntakeForm value)
        {    
            int id=1;
            if(_context.IntakeForms.ToList().Count !=0)
                 id = _context.IntakeForms.Max(f => f.Id) + 1;
            
            

            IntakeForm newIntake = new IntakeForm
            {
                Id = id,
                Ailment=value.Ailment,
                DoctorId=value.DoctorId,
                PatientId=value.PatientId 
            };

            _context.IntakeForms.Add(newIntake);
            _context.SaveChanges();
        }

       


    }
}