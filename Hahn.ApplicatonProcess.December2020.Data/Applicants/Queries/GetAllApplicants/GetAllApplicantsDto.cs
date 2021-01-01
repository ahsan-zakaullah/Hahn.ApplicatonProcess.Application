using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Common.Mapping;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.Queries.GetAllApplicants
{
    public class GetAllApplicantsDto : IMapFrom<GetAllApplicantsResponse>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAllApplicantsResponse, GetAllApplicantsDto>();
        }
    }
}
