using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Services.DB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public class VisitService : IVisitService
    {
        private VisitContext _context = new();

        IMapper mapper = (new AutoMapperConfiguration()).Configure().CreateMapper();

        public async Task<Storage.Models.Visitor> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            return await _context.Visitors.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
