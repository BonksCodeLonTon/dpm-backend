using AutoMapper;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.Port.CreatePort
{
    public class CreatePortCommandHandler : IRequestHandler<CreatePortCommand, Domain.Entities.Port>
    {
        private readonly IPortRepository _portRepository;
        private readonly IMapper _mapper;
        public CreatePortCommandHandler(IPortRepository portRepository, IMapper mapper)
        {
            _portRepository = portRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Entities.Port> Handle(CreatePortCommand request, CancellationToken cancellationToken)
        {
            var port = _mapper.Map<Domain.Entities.Port>(request);
            _portRepository.Add(port);
            await _portRepository.SaveChangesAsync(cancellationToken);
            return port;
        }

    }
}
