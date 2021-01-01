using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommand : IRequest<CreateApplicantDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, CreateApplicantDto>
        {
            private readonly IApplicantsApi _applicantsApi;
            private readonly IMapper _mapper;

            public CreateApplicantCommandHandler(IApplicantsApi applicantsApi, IMapper mapper)
            {
                _applicantsApi = applicantsApi;
                _mapper = mapper;
            }

            public async Task<CreateApplicantDto> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
            {
                var response = await _applicantsApi.CreateApplicant(_mapper.Map<CreateApplicantRequest>(request));
                return _mapper.Map<CreateApplicantDto>(response);
            }
        }
    }
}
