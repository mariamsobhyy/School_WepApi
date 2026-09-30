using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_WepApi.DTOs;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _customrepo;
        private readonly IMapper _mapper;

        public EnrollmentController(IMapper mapper, IEnrollment customerRepo)
        {
            _mapper = mapper;
            _customrepo = customerRepo;
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var enrollments = _customrepo.GetEnrollmentsWithStudentAndSubject();

            if (enrollments == null)
                return BadRequest("The Enrollment is null");

            var res = _mapper.Map<List<EnrollmentDTO>>(enrollments);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = _customrepo.GetById(id);

            if (enrollment == null)
                return NotFound("Enrollment Not Found");

            var res = _mapper.Map<EnrollmentDTO>(enrollment);

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(CreateEnrollmentDTO dto)
        {
            var enrollment = _mapper.Map<Enrollment>(dto);

            if (enrollment == null)
                return BadRequest("Enrollment Cannot Be Null");

            _customrepo.Add(enrollment);
           // _customrepo.Save();

            return Ok(enrollment);
        }

        [HttpPut]
        public IActionResult UpdateEnrollment(int id, UpdateEnrollmentDTO dto)
        {
            var enrollment = _customrepo.GetById(id);

            if (enrollment == null)
                return NotFound("Enrollment Not Found");

            _mapper.Map(dto, enrollment);

            _customrepo.Update(enrollment);
          //  _customrepo.Save();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteEnrollment(int id)
        {
            var enrollment = _customrepo.GetById(id);

            if (enrollment == null)
                return NotFound("Enrollment Not Found");

            _customrepo.Delete(enrollment);
          //  _customrepo.Save();

            return NoContent();
        }

        [HttpGet("EndPoint6")]
        public IActionResult EndPoint6(int subjectid)
        {
            var enrollment = _customrepo.EndPoint6(subjectid);

            if (enrollment == null)
                return NotFound();

            var res = _mapper.Map<EnrollmentDTO>(enrollment);

            return Ok(res);
        }
    }
}
