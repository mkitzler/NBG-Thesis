using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Domain;
using NBG.Visitor.Domain.Commands;
using NBG.Visitor.Domain.Dtos;
using NBG.Visitor.Services.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.REST
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _vs;

        public VisitController(IVisitService vs)
        {
            _vs = vs;
        }

        [HttpPost("ReadVisitorIfExists")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReadVisitorIfExists([FromBody] ReadVisitorCommand visitor)
        {
            VisitorDto ret = await _vs.ReadVisitorIfExists(visitor.FirstName, visitor.LastName, visitor.PhoneNumber);
            if (ret == null)
                return NotFound();
            else
                return Ok(ret);
        }

        [HttpPost("AddVisit")]
        public async Task<VisitDto> AddVisit([FromBody] AddVisitCommand visit)
        {
            return await _vs.AddVisit(visit.Start, visit.FirstName, visit.LastName, visit.PhoneNumber, visit.Email, visit.Company, visit.ContactPerson, visit.Status);
        }

        [HttpGet("ReadAllVisits")]
        public async Task<List<VisitDto>> ReadAllVisits()
        {
            return await _vs.ReadAllVisits();
        }

        [HttpDelete("{Id}")]
        public async Task RemoveVisit(int Id)
        {
            await _vs.RemoveVisit(Id);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVisit(int Id, [FromBody] UpdateVisitCommand visit)
        {
            VisitDto ret = await _vs.UpdateVisit(Id, visit.Start, visit.End, visit.Status, visit.ContactPerson, visit.Company, visit.FirstName, visit.LastName, visit.PhoneNumber, visit.Email);
            if (ret == null)
                return NotFound();
            else
                return Ok(ret);
        }

        [HttpPatch("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVisit(int Id, [FromBody] PatchVisitCommand changes)
        {
            VisitDto ret = await _vs.UpdateVisit(Id, changes);
            if (ret == null)
                return NotFound();
            else
                return Ok(ret);
        }

        [HttpGet("ReadRegisterFormDataByGuid/{guid}")]
        public async Task<RegisterFormDataDto> ReadRegisterFormDataByGuid(Guid guid)
        {
            return await _vs.ReadRegisterFormDataByGuid(guid);
        }

        [HttpGet("ReadVisitByGuid/{guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VisitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReadVisitByGuid(Guid guid)
        {
            VisitDto ret = await _vs.ReadVisitByGuid(guid);
            if (ret == null)
                return NotFound();
            else
                return Ok(ret);
        }

        [HttpDelete]
        public async Task RemoveOldVisits()
        {
            await _vs.RemoveOldVisits();
        }
    }
}
