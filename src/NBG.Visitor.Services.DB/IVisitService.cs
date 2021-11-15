using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public interface IVisitService
    {
        Task<Storage.Models.Visitor> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber);
    }
}
