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
    public class SubjectController : ControllerBase
    {
        private readonly Isubject _customRepo;
        private readonly IMapper _mapper;

        public SubjectController(IMapper mapper, Isubject customRepo)
        {
            _mapper = mapper;
            _customRepo = customRepo;
        }

        [HttpGet]
        public IActionResult GetSubject()
        {
            var subjects = _customRepo.GetSubjectsWithTeachers();

            var res = _mapper.Map<List<SubjectDTO>>(subjects);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _customRepo.GetById(id);

            if (subject == null)
                return BadRequest("Subject Not Found");

            var res = _mapper.Map<SubjectDTO>(subject);

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDTO dto)
        {
            var subject = _mapper.Map<Subject>(dto);

            if (subject == null)
                return BadRequest("Subject Cannot Be Null");

            _customRepo.Add(subject);
          //  _customRepo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.Id },
                subject
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(
            int id,
            UpdateSubjectDTO dto)
        {
            var subject = _customRepo.GetById(id);

            if (subject == null)
                return NotFound("Subject Not Found");

            _mapper.Map(dto, subject);

            _customRepo.Update(subject);
           // _customRepo.Save();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _customRepo.GetById(id);

            if (subject == null)
                return NotFound("Subject Not Found");

            _customRepo.Delete(subject);
           // _customRepo.Save();

            return NoContent();
        }

        [HttpGet("EndPoint2")]
        public IActionResult EndPoint2(int id)
        {
            var subject = _customRepo.EndPoint2(id);

            if (subject == null)
                return NotFound();

            var res = _mapper.Map<SubjectDTO>(subject);

            return Ok(res);
        }

        [HttpGet("EndPoint7")]
        public IActionResult EndPoint7(int teacherid)
        {
            var subject = _customRepo.EndPoint7(teacherid);

            if (subject == null)
                return NotFound();

            var res = _mapper.Map<SubjectDTO>(subject);

            return Ok(res);
        }

        [HttpGet("EndPoint11")]
        public IActionResult EndPoint11(int id1, int id2, int id3)
        {
            var subject = _customRepo.EndPoint11(id1, id2, id3);

            return Ok(subject);
        }

        [HttpGet("EndPoint13")]
        public IActionResult EndPoint13(int teacherid)
        {
            var subject = _customRepo.EndPoint13(teacherid);

            return Ok(subject);
        }

        [HttpGet("EndPoint14")]
        public IActionResult EndPoint14(int departmentid)
        {
            var subject = _customRepo.EndPoint14(departmentid);

            return Ok(subject);
        }

        [HttpGet("EndPoint16")]
        public IActionResult EndPoint16()
        {
            var subject = _customRepo.EndPoint16();

            return Ok(subject);
        }
    }
}
