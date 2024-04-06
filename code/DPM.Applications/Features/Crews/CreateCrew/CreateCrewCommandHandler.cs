using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Crews.CreateCrew
{
    internal class CreateCrewCommandHandler : IRequestHandler<CreateCrewCommand, Crew>
    {
        private readonly ICrewRepository _crewRepository;
        private readonly IMapper _mapper;
        public CreateCrewCommandHandler(ICrewRepository crewRepository, IMapper mapper)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;
        }
        public async Task<Crew> Handle(CreateCrewCommand request, CancellationToken cancellationToken)
        {
            var crew = _mapper.Map<Crew>(request);
            _crewRepository.Add(crew);
            await _crewRepository.SaveChangesAsync(cancellationToken);
            return crew;
        }

    }
}
