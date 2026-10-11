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
       private readonly IUnitOfWork _unitOfWork;


       public StudentController(IUnitOfWork unitOfWork)
       {
            _unitOfWork = unitOfWork;
       }

        [HttpPost]

        public async Task<IActionResult> CreateStudent(StudentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Student data is required");
            }

            var student = new Student
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                Gender = dto.Gender,
                Phone = dto.Phone,
            };

            await _unitOfWork.Students.Add(student);

            await _unitOfWork.Save();

            var result = new ReadStudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Phone = student.Phone,
                BirthDate = student.BirthDate,
                Gender = student.Gender
            };

            return Ok(result);
        }







    
    }
}

