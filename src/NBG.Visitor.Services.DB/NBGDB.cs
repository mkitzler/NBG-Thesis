using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Storage;

namespace NBG.Visitor.Services.DB
{
    public static class NBGDB
    {
        private static int GetVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            using (var db = new VisitContext())
            {
                db.
            }
        }

        public static void AddVisitorWithVisit(string firstName, string lastName, string phoneNumber)
        {

        }
    }
}
