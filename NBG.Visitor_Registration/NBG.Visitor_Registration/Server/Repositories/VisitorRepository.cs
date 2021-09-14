using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor_Registration.Server.ModelContexts;
using NBG.Visitor_Registration.Shared.Models;

namespace NBG.Visitor_Registration.Server.Repositories
{
    public class VisitorRepository : IDataRepository
    {
        private readonly IDataContext _context;
        public VisitorRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Visitors.FindAsync(id);
            if (itemToDelete != null)
                throw new NullReferenceException();

            _context.Visitors.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Visitor> Get(int id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task<IEnumerable<Visitor>> GetAll()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task Update(Visitor visitor)
        {
            var itemToUpdate = await _context.Visitors.FindAsync(visitor.Id);
            if(itemToUpdate != null)
                throw new NullReferenceException();

            itemToUpdate.FirstName = visitor.FirstName;
            itemToUpdate.LastName = visitor.LastName;
            itemToUpdate.Email = visitor.Email;
            itemToUpdate.PhoneNumber = visitor.PhoneNumber;
            itemToUpdate.Company = visitor.Company;
            await _context.SaveChangesAsync();
        }
    }
}
