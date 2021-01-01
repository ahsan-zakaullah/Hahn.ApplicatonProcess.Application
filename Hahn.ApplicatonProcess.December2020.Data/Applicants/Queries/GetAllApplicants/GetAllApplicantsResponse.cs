using System.Text.Json.Serialization;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.Queries.GetAllApplicants
{
    public class GetAllApplicantsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
