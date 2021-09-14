using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBG.Visitor_Registration.Server.Repositories;
using NBG.Visitor_Registration.Shared.Models;
using NBG.Visitor_Registration.Server.Dtos;

namespace NBG.Visitor_Registration.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        //List<Visitor> _visitors = new List<Visitor>
        //{
        //    new Visitor { FirstName = "Herwig", LastName = "Macho", Email = "h.macho@htlkrems.at", PhoneNumber = "+43 676 5558899" },
        //    new Visitor { FirstName = "Markus", LastName = "Brunner", Email = "m.brunner@htlkrems.at", PhoneNumber = "0676 4455887" }
        //};

        //public async Task<IActionResult> GetVisitor()
        //{
        //    return Ok(_visitors);
        //}

        private readonly IDataRepository _visitorRepository;
        public VisitorController(IDataRepository dataRepository)
        {
            _visitorRepository = dataRepository;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Visitor>> GetVisitor(int id)
        //{
        //    var visitor = await _visitorRepository.Get(id);
        //    if (visitor == null)
        //        return NotFound();
        //    return Ok(visitor);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitor>>> GetVisitors()
        {
            var visitors = await _visitorRepository.GetAll();
            return Ok(visitors);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVisitor(CreateVisitorDto createVisitorDto)
        {
            Visitor visitor = new()
            {
                FirstName = createVisitorDto.FirstName,
                LastName = createVisitorDto.LastName,
                Email = createVisitorDto.Email,
                PhoneNumber = createVisitorDto.PhoneNumber,
                Company = createVisitorDto.Company
            };

            await _visitorRepository.Add(visitor);
            return Ok();
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteVisitor(int id)
        //{
        //    await _visitorRepository.Delete(id);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateVisitor(int id, UpdateVisitorDto updateVisitorDto)
        //{
        //    Visitor visitor = new()
        //    {
        //        FirstName = updateVisitorDto.FirstName,
        //        LastName = updateVisitorDto.LastName,
        //        Email = updateVisitorDto.Email,
        //        PhoneNumber = updateVisitorDto.PhoneNumber,
        //        Company = updateVisitorDto.Company
        //    };

        //    await _visitorRepository.Update(visitor);
        //    return Ok();
        //}
    }
}
