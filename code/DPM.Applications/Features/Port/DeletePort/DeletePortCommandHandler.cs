using AutoMapper;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.Port.DeletePort
{
    internal class DeletePortCommandHandler : IRequestHandler<DeletePortCommand, bool>
    {
        private readonly IPortRepository _portRepository;
        public DeletePortCommandHandler(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }
        public async Task<bool> Handle(DeletePortCommand request, CancellationToken cancellationToken)
        {
            var port = _portRepository
                .GetAll(tracking: true)
                .FirstOrDefault(p => p.Id == request.Id);

            if (port == null)
            {
                return false;
            }
            _portRepository.Delete(port);
            await _portRepository.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
