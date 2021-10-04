using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorService.Repositories;
using VisitorService.Dtos;
using AutoMapper;
using VisitorService.Models;

namespace VisitorService.Controllers
{
    [Route("api/[controller]")] //[controller] comes from Class Name [Visitor]Controller
    [ApiController]
    public class VisitorController : ControllerBase
    {

        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorRepository dataRepository, IMapper mapper)
        {
            _visitorRepository = dataRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetVisitor")]
        public async Task<ActionResult<ReadVisitorDto>> GetVisitor(int id)
        {
            Console.WriteLine("--> Getting Visitor...");
            var visitor = await _visitorRepository.Get(id);
            if (visitor == null)
                return NotFound();
            return Ok(visitor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadVisitorDto>>> GetVisitors()
        {
            Console.WriteLine("--> Getting Visitorssss...");
            var visitors = await _visitorRepository.GetAll();
            if (visitors == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<ReadVisitorDto>>(visitors));
        }

        [HttpPost]
        public async Task<ActionResult<ReadVisitorDto>> CreateVisitor(CreateVisitorDto createVisitorDto)
        {
            var visitorModel = _mapper.Map<Visitor>(createVisitorDto);
            await _visitorRepository.Add(visitorModel);
            await _visitorRepository.SaveChanges();

            var readVisitorDto = _mapper.Map<ReadVisitorDto>(visitorModel);
            return CreatedAtRoute(nameof(GetVisitor), new { Id = readVisitorDto.Id }, readVisitorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVisitor(int id, UpdateVisitorDto updateVisitorDto)
        {
            var visitorModel = _mapper.Map<Visitor>(updateVisitorDto);
            await _visitorRepository.Update(id, visitorModel);
            await _visitorRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVisitor(int id)
        {
            await _visitorRepository.Delete(id);
            await _visitorRepository.SaveChanges();
            return Ok("Visitor Deleted");
        }


    }
}
