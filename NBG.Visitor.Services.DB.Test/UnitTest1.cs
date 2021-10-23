using NUnit.Framework;

namespace NBG.Visitor.Services.DB.Test
{
    public class Tests
    {
        private VisitRepository _repo = new();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestAddVisitor()
        {
            var visitor = new Storage.Models.Visitor() { FirstName = "Max", LastName = "Mustermann", PhoneNumber = "0664 0815" };
            _repo.AddVisitor(visitor).Wait();
            Assert.IsNotNull(visitor.Id);
        }
    }
}
