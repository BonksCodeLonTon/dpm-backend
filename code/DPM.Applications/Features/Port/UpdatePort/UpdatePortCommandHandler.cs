using AutoMapper;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.UpdatePort
{
    public class UpdatePortCommandHandler : IRequestHandler<UpdatePortCommand, Domain.Entities.Port>
    {
        private readonly IPortRepository _portRepository;
        private readonly IMapper _mapper;
        public UpdatePortCommandHandler(IPortRepository portRepository, IMapper mapper)
        {
            _portRepository = portRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Port> Handle(UpdatePortCommand request, CancellationToken cancellationToken)
        {
            var port = _portRepository.GetById(request.Id, tracking: true)
                    ?? throw new NotFoundException(nameof(Domain.Entities.Port));
            _mapper.Map(request, port);
            await _portRepository.SaveChangesAsync(cancellationToken);
            return port;
        }
    }
}
