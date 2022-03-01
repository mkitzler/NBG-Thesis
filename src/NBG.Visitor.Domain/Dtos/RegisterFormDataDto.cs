namespace NBG.Visitor.Domain.Dtos
{
    public class RegisterFormDataDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        private string email = null;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }
        public string Company { get; set; }
        public string ContactPerson { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {PhoneNumber}, Email: {Email}, {Company}, {ContactPerson}";
        }
    }
}
