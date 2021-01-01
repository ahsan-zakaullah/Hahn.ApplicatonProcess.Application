using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Common.Mapping;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantDto : IMapFrom<CreateApplicantResponse>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateApplicantResponse, CreateApplicantDto>();
        }
    }
}
