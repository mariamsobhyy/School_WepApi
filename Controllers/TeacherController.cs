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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _customRepo;
        private readonly IMapper _mapper;

        public TeacherController(ITeacher customRepo , IMapper mapper)
        {
            _customRepo = customRepo;

            _mapper = mapper;
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            var t = _customRepo.GetTeachersWithDepartment();

            var res = _mapper.Map<List<TeacherDTO>>(t);

            return Ok(res);
        }


        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var teacher = _customRepo.GetById(id);

            if (teacher == null)
            {
                return NotFound("Not Found");
            }
              
            var res = _mapper.Map<TeacherDTO>(teacher);

            return Ok(teacher);
        }


        [HttpPost]

        public IActionResult Create (TeacherDTO teacherDTO)
        {


            var res = _mapper.Map<Teacher>(teacherDTO);

            _customRepo.Add(res);

            return CreatedAtAction(nameof(GetById), new
            {
                id = res.Id,res
            });
           
        }


        [HttpPut]


        public IActionResult Update (TeacherDTO teacherDTO , int id )
        {
            var teacher = _customRepo.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            var res = _mapper.Map(teacherDTO, teacher);

         
            return NoContent();
        }


        [HttpDelete]

        public IActionResult Delete (int id)
        {
            var teacher = _customRepo.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            _customRepo.Delete(teacher);

            return NoContent();
        }


        [HttpGet("Filter")]

        public IActionResult filter (int id , int salary)
        {
            var teachers = _customRepo.Filter(id, salary);

            if (teachers == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<List<TeacherDTO>>(teachers);

            return Ok(res);
        }

    }
}
