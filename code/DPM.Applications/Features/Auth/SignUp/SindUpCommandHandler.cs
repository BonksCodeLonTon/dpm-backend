using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Features.Auth.Register;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Auth.SignUp
{
    internal class SindUpCommandHandler : IRequestHandler<SignUpCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authService;


        public SindUpCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _userRepository
              .GetAll()
              .Any(u => u.Username == request.Username || u.Email == request.Email);

            if (isExisted)
            {
                throw new ConflictException(nameof(User));
            }
            await _userRepository.SaveChangesAsync(cancellationToken);
            string sub = await _authService.SignUpAsync(request.Email, request.Username, request.Password, request.PhoneNumber, request.FullName);
            return sub;
        }
    }
}
