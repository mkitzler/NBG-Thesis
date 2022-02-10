namespace NBG.Visitor.Domain.Dtos
{
    public class VisitorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
