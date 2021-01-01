using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.Queries.GetAllApplicants
{
    public class GetAllApplicantsQuery : IRequest<IEnumerable<GetAllApplicantsDto>>
    {
        public class GetAllApplicantsQueryHandler : IRequestHandler<GetAllApplicantsQuery, IEnumerable<GetAllApplicantsDto>>
        {
            private readonly IApplicantsApi _applicantsApi;
            private readonly IMapper _mapper;

            public GetAllApplicantsQueryHandler(IApplicantsApi applicantsApi, IMapper mapper)
            {
                _applicantsApi = applicantsApi;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetAllApplicantsDto>> Handle(GetAllApplicantsQuery request, CancellationToken cancellationToken)
            {
                var applicants = await _applicantsApi.GetAllApplicants();
                return _mapper.Map<IEnumerable<GetAllApplicantsDto>>(applicants);
            }
        }
    }
}
