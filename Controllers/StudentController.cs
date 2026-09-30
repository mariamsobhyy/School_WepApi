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
    public class StudentController : ControllerBase
    {
        private readonly IStudent _customRepo;
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper, IStudent customRepo)
        {
            _mapper = mapper;
            _customRepo = customRepo;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var stud = _customRepo.IncludeClassRoom();

            var res = _mapper.Map<List<StudentDTO>>(stud);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stud = _customRepo.GetById(id);

            if (stud == null)
                return BadRequest("Student Not Found");

            var res = _mapper.Map<StudentDTO>(stud);

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO dto)
        {
            var student = _mapper.Map<Student>(dto);

            if (student == null)
                return BadRequest("Student Cannot Be Null");

            _customRepo.Add(student);
          //  _customRepo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(
            int id,
            UpdateStudentDTO dto)
        {
            var student = _customRepo.GetById(id);

            if (student == null)
                return NotFound("Student Not Found");

            _mapper.Map(dto, student);

            _customRepo.Update(student);
         //   _customRepo.Save();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = _customRepo.GetById(id);

            if (student == null)
                return NotFound("Student Not Found");

            _customRepo.Delete(student);
          //  _customRepo.Save();

            return NoContent();
        }
    }
}
