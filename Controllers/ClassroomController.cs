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
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroom _repo;
        private readonly IMapper _mapper;

        public ClassroomController(IMapper mapper, IClassroom repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClassRooms()
        {
            var classRooms = _repo.GetAll();

            if (classRooms == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<List<ClassroomDTO>>(classRooms);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassRoomById(int id)
        {
            var classRoom = _repo.GetById(id);

            if (classRoom == null)
                return NotFound();

            var res = _mapper.Map<ClassroomDTO>(classRoom);

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassRoomsDTO dto)
        {
            var res = _mapper.Map<ClassRoom>(dto);

            if (res == null)
                return BadRequest("ClassRoom Cannot Be Null");

            _repo.Add(res);
          //  _repo.Save();

            return CreatedAtAction(
                nameof(GetClassRoomById),
                new { id = res.Id },
                res
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassRoom(int id, UpdateClassRoomsDTO dto)
        {
            var classRoom = _repo.GetById(id);

            if (classRoom == null)
                return NotFound("ClassRoom Not Found");

            _mapper.Map(dto, classRoom);

            _repo.Update(classRoom);
          //  _repo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(int id)
        {
            var classRoom = _repo.GetById(id);

            if (classRoom == null)
                return NotFound("ClassRoom Not Found");

            _repo.Delete(classRoom);
         //   _repo.Save();

            return NoContent();
        }

        [HttpGet("EndPoint3")]
        public IActionResult EndPoint3(int capacity)
        {
            var classRoom = _repo.EndPoint3(capacity);

            if (classRoom == null)
                return NotFound();

            var res = _mapper.Map<ClassroomDTO>(classRoom);

            return Ok(res);
        }

        [HttpGet("EndPoint5")]
        public IActionResult EndPoint5(string name)
        {
            var classes = _repo.EndPoint5(name);

            if (classes == null)
                return NotFound();

            var res = _mapper.Map<ClassroomDTO>(classes);

            return Ok(res);
        }

        [HttpGet("EndPoint8")]
        public IActionResult EndPoint8(int index)
        {
            var classes = _repo.EndPoint8(index);

            if (classes == null)
                return NotFound();

            var res = _mapper.Map<ClassroomDTO>(classes);

            return Ok(res);
        }

        [HttpGet("EndPoint10")]
        public IActionResult EndPoint10(int gradelevel, int capacity)
        {
            var classes = _repo.EndPoint10(gradelevel, capacity);

            return Ok(classes);
        }
    }
}
