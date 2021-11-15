using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    public enum VisitStatus
    {
        VISIT_ACTIVE,
        VISIT_PENDING,
        VISIT_OVER
    }
}
