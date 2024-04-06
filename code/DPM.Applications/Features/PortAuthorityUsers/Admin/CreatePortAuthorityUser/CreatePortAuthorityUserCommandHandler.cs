using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.CreatePortAuthorityUser
{
    internal class CreatePortAuthorityUserCommandHandler : IRequestHandler<CreatePortAuthorityUserCommand, CreatePortAuthorityUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;
        private readonly IEmailService _emailService;
        private readonly IRequestContextService _requestContextService;

        public CreatePortAuthorityUserCommandHandler(
            IUserRepository userRepository, 
            IMapper mapper, 
            IAuthenticationService authService, 
            IEmailService emailService,
            IRequestContextService requestContextService
        )           
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
            _requestContextService = requestContextService;
        }

        public async Task<CreatePortAuthorityUserResponse> Handle(CreatePortAuthorityUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetAll().AnyAsync(u => u.Username == request.Username || u.Email == request.Email, cancellationToken))
            {
                throw new ConflictException(nameof(User));
            }

            var sub = await _authService.CreateUserAsync(request.Email, request.Username, request.Password);

            var user = _mapper.Map<User>(request);
            user.CognitoSub = sub;
            user.Role = Role.PortAuthority;
            user.RoleType = RoleType.User;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CreatePortAuthorityUserResponse>(user);
            await _emailService.SendEmailAsync(
              new[] { request.Email },
              nameof(EmailType.InviteToJoinPortAuthority),
              new
              {
                  senderName = _requestContextService.User.FullName?.Split(' ')?[0] ?? _requestContextService.User.Email,
                  username = request.Username,
                  password = request.Password,
              });
            return response;
        }
    }
}
