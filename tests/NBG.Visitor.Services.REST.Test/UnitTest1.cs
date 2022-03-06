using NBG.Visitor.Domain.Commands;
using NBG.Visitor.Domain.Dtos;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.REST.Test
{
    public class Tests
    {
        private HttpClient http;

        [SetUp]
        public void Setup()
        {
            http = new HttpClient();
        }

        [Test]
        public async Task TestRead()
        {
            var visits = await http.GetFromJsonAsync<List<VisitDto>>("https://localhost:44339/api/Visit/ReadAllVisits");
            Assert.IsNotNull(visits);
            Assert.AreEqual(20, visits.Count);
        }

        [Test]
        public async Task TestPost()
        {
            var v = new AddVisitCommand();
            v.Start = DateTime.Now;
            v.FirstName = "Max";
            v.LastName = "Test";
            v.PhoneNumber = "0664";
            var resp = await http.PostAsJsonAsync<AddVisitCommand>("https://localhost:44339/api/Visit/AddVisit", v);
            var visit = resp.Content.ReadFromJsonAsync<VisitDto>();
            Assert.AreEqual(21, visit.Id);
        }

        [Test]
        public async Task TestPatch()
        {
            var resp = await http.PatchAsync("https://localhost:44339/api/Visit/21", JsonContent.Create<PatchVisitCommand>(new() { Status = VisitStatusDto.VISIT_OVER }));
            Assert.True(resp.IsSuccessStatusCode);
            VisitDto visit = await resp.Content.ReadFromJsonAsync<VisitDto>();
            Assert.IsNotNull(visit);
            Assert.AreEqual(VisitStatusDto.VISIT_OVER, visit.Status);
        }
    }
}