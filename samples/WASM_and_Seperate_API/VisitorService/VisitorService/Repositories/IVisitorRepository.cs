using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorService.Models;

namespace VisitorService.Repositories
{
    public interface IVisitorRepository
    {
        Task SaveChanges();
        Task<Visitor> Get(int id);
        Task<IEnumerable<Visitor>> GetAll();
        Task Add(Visitor visitor);
        Task Delete(int id);
        Task Update(int id, Visitor visitor);
    }
}
