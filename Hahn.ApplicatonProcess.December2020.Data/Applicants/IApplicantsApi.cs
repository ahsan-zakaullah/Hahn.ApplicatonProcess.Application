using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.Commands.CreateApplicant;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.Queries.GetAllApplicants;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants
{
    public interface IApplicantsApi
    {
        Task<IEnumerable<GetAllApplicantsResponse>> GetAllApplicants();
        Task<CreateApplicantResponse> CreateApplicant(CreateApplicantRequest request);
    }
}
