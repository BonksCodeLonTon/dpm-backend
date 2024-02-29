using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Auth.ConfirmSignUp
{
    internal class ConfirmSignUpCommandHandler  : IRequestHandler<ConfirmSignUpCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;


        public ConfirmSignUpCommandHandler(IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<bool> Handle(ConfirmSignUpCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);
            bool result = await _authService.ConfirmSignUpAsync(request.Username, request.ConfirmationCode);
            var user = _mapper.Map<ConfirmSignUpCommand, User>(request);

            user.CognitoSub = request.Sub;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
