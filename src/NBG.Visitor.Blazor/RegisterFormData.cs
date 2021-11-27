using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor
{
    public class RegisterFormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = null;
        public string Company { get; set; }
        public string ContactPerson { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {PhoneNumber}, Email: {Email}, {Company}, {ContactPerson}";
        }
    }
}
