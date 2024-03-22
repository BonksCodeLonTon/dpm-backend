using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Features.Auth.Register;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.Auth.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;


        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _userRepository
              .GetAll()
              .Any(u => u.Username == request.Username || u.Email == request.Email);

            if (isExisted)
            {
                throw new ConflictException(nameof(User));
            }

            var sub = await _authService.CreateUserAsync(request.Email, request.Username, request.Password);
            var user = _mapper.Map<RegisterCommand, User>(request);
            user.CognitoSub = sub;
            user.RoleType = Domain.Enums.RoleType.Admin;
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            var response = new RegisterResponse { Id = user.Id };
            return response;
        }
    }

}
