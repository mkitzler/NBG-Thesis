using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBG.Visitor_Registration.Shared.Models;

namespace NBG.Visitor_Registration.Client.Services
{
    public interface IVisitorService
    {
        Task<List<Visitor>> GetVisitors();
    }
}
