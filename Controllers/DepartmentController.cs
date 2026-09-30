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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _repo;
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper, IDepartment repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _repo.GetAll();

            if (departments == null)
                return NotFound();

            var result = _mapper.Map<List<DepartmentDTO>>(departments);

            return Ok(result);
        }

        [HttpGet("Search")]
        public IActionResult SearchByTeacherName(string fullName)
        {
            var department = _repo.SearchByTeacherName(fullName);

            if (department == null)
                return NotFound("Teacher Not Found");

            var result = _mapper.Map<DepartmentDTO>(department);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _repo.GetById(id);

            if (department == null)
                return NotFound("Department Not Found");

            var result = _mapper.Map<DepartmentDTO>(department);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDTO dto)
        {
            var department = _mapper.Map<Department>(dto);

            if (department == null)
                return BadRequest("Department Cannot Be Null");

            _repo.Add(department);
           // _repo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.Id },
                department
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(
            int id,
            UpdateDepartmentDTO dto)
        {
            var department = _repo.GetById(id);

            if (department == null)
                return NotFound("Department Not Found");

            _mapper.Map(dto, department);

            _repo.Update(department);
          //  _repo.Save();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var department = _repo.GetById(id);

            if (department == null)
                return NotFound("Department Not Found");

            _repo.Delete(department);
          //  _repo.Save();

            return NoContent();
        }
    }
}
