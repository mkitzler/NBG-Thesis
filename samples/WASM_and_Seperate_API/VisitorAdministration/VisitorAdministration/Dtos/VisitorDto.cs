using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VisitorAdministration.Dtos
{
    public class VisitorDto
    {
        [JsonPropertyName("id")]
        public long Id { get; set;  }
        [JsonPropertyName("firstname")]
        public string FirstName {  get; set; }
        [JsonPropertyName("lastname")]
        public string LastName {  get; set; }
        [JsonPropertyName("email")]
        public string Email {  get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber {  get; set; }
        [JsonPropertyName("company")]
        public string Company { get; set; }
    }
}
