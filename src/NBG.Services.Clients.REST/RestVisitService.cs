using NBG.Visitor.Domain;
using NBG.Visitor.Domain.Commands;
using NBG.Visitor.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Clients.REST
{
    public class RestVisitService : IVisitService
    {
        private const string API_URL = "https://localhost:44323/api/Visit";
        private HttpClient _http = new HttpClient();

        public async Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<ReadVisitorCommand>($"{API_URL}/ReadVisitorIfExists", new() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber }).ConfigureAwait(false);
            if (resp.IsSuccessStatusCode)
                return await resp.Content.ReadFromJsonAsync<VisitorDto>().ConfigureAwait(false);
            else
                return null;
        }

        public async Task<VisitDto> AddVisit(DateTime? start, string firstName, string lastName, string phoneNumber, string email = null, string company = null, string contactPerson = null, VisitStatusDto status = VisitStatusDto.VISIT_ACTIVE)
        {
            HttpResponseMessage resp = await _http.PostAsJsonAsync<AddVisitCommand>($"{API_URL}/AddVisit", new() { Start = start, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email, Company = company, ContactPerson = contactPerson, Status = status }).ConfigureAwait(false);
            return await resp.Content.ReadFromJsonAsync<VisitDto>().ConfigureAwait(false);
        }

        public async Task<List<VisitDto>> ReadAllVisits()
        {
            return await _http.GetFromJsonAsync<List<VisitDto>>($"{API_URL}/ReadAllVisits").ConfigureAwait(false);
        }

        public async Task RemoveVisit(int Id)
        {
            await _http.DeleteAsync($"{API_URL}/RemoveVisit/{Id}").ConfigureAwait(false);
        }

        public async Task<VisitDto> UpdateVisit(int Id, DateTime? start, DateTime? end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            HttpResponseMessage resp = await _http.PutAsJsonAsync<UpdateVisitCommand>($"{API_URL}/UpdateVisit/{Id}", new() { Start = start, End = end, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email, Company = company, ContactPerson = contactPerson, Status = status }).ConfigureAwait(false);
            if (resp.IsSuccessStatusCode)
                return await resp.Content.ReadFromJsonAsync<VisitDto>().ConfigureAwait(false);
            else
                return null;
        }

        public async Task<VisitDto> UpdateVisit(int Id, PatchVisitCommand changes)
        {
            HttpResponseMessage resp = await _http.PatchAsync($"{API_URL}/UpdateVisit/{Id}", JsonContent.Create(changes)).ConfigureAwait(false);
            if (resp.IsSuccessStatusCode)
                return await resp.Content.ReadFromJsonAsync<VisitDto>().ConfigureAwait(false);
            else
                return null;
        }

        public async Task<RegisterFormDataDto> ReadRegisterFormDataByGuid(Guid guid)
        {
            return await _http.GetFromJsonAsync<RegisterFormDataDto>($"{API_URL}/ReadRegisterFormDataByGuid/{guid}").ConfigureAwait(false);
        }

        public async Task<VisitDto> ReadVisitByGuid(Guid guid)
        {
            HttpResponseMessage resp = await _http.GetAsync($"{API_URL}/ReadVisitByGuid/{guid}").ConfigureAwait(false);
            if (resp.IsSuccessStatusCode)
                return await resp.Content.ReadFromJsonAsync<VisitDto>().ConfigureAwait(false);
            else
                return null;
        }

        public async Task RemoveOldVisits()
        {
            await _http.DeleteAsync(API_URL);
        }

        public Task<VisitDto> ReadActiveVisits()
        {
            throw new NotImplementedException();
        }
    }
}
