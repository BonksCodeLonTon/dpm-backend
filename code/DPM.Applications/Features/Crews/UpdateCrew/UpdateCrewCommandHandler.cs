using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Crews.UpdateCrew
{
    internal class UpdateCrewCommandHandler : IRequestHandler<UpdateCrewCommand, Crew>
    {
        private readonly ICrewRepository _crewRepository;
        private readonly IMapper _mapper;
        public UpdateCrewCommandHandler(ICrewRepository crewRepository, IMapper mapper)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;
        }

        public async Task<Crew> Handle(UpdateCrewCommand request, CancellationToken cancellationToken)
        {
            var crew = _crewRepository.GetById(request.Id, tracking: true)
                    ?? throw new NotFoundException(nameof(Crew));
            _mapper.Map(request, crew);
            await _crewRepository.SaveChangesAsync(cancellationToken);
            return crew;
        }
    }
}
