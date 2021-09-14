using NBG.Visitor_Registration.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NBG.Visitor_Registration.Client.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly HttpClient _httpClient;

        public VisitorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Visitor>> GetVisitors()
        {
            return await _httpClient.GetFromJsonAsync<List<Visitor>>("api/visitor");
        }
    }
}
