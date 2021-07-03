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
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly AppDbContext _context = new AppDbContext();

        public PatientsController(ILogger<PatientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _context.Patients.ToList();
        }

        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return _context.Patients.Find(id);
        }

        [HttpPost]
        public void Post([FromBody] Patient value)
        {
            int id = _context.Patients.Max(p => p.Id) + 1;

            Patient newPatient = new Patient
            {
                Id = id,
                Name = value.Name,
                Address = value.Address,
                HealthNumber = value.HealthNumber,
                DateOfBirth = value.DateOfBirth,
                PhoneNumber = value.PhoneNumber
            };

            _context.Patients.Add(newPatient);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patient value)
        {
            Patient p = _context.Patients.Where(p => p.Id == id)
                                       .FirstOrDefault();

            if (p != null)
            {
                p.Name = value.Name;
                p.HealthNumber = value.HealthNumber;
                p.DateOfBirth = value.DateOfBirth;
                p.Address = value.Address;
                p.PhoneNumber = value.PhoneNumber;

                _context.SaveChanges();
            }
        }



    }
}