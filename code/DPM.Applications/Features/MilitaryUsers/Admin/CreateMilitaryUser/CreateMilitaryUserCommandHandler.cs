using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DPM.Applications.Features.MilitaryUsers.Admin.CreateMilitaryUser
{
    public class CreateMilitaryUserCommandHandler : IRequestHandler<CreateMilitaryUserCommand, CreateMilitaryUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;
        private readonly IEmailService _emailService;
        private readonly IRequestContextService _requestContextService;
        public CreateMilitaryUserCommandHandler(
            IUserRepository userRepository, 
            IMapper mapper, 
            IAuthenticationService authService, 
            IEmailService emailService,
            IRequestContextService requestContextService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
            _requestContextService = requestContextService;
        }

        public async Task<CreateMilitaryUserResponse> Handle(CreateMilitaryUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetAll().AnyAsync(u => u.Username == request.Username || u.Email == request.Email, cancellationToken))
            {
                throw new ConflictException(nameof(User));
            }

            var sub = await _authService.CreateUserAsync(request.Email, request.Username, request.Password);

            var user = _mapper.Map<User>(request);
            user.CognitoSub = sub;
            user.Role = Role.Military;
            user.RoleType = RoleType.User;

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CreateMilitaryUserResponse>(user);
            await _emailService.SendEmailAsync(
              new[] { request.Email },
              nameof(EmailType.InviteToJoinMilitary),
              new
              {
                  senderName = _requestContextService.User.FullName?.Split(' ')?[0] ?? _requestContextService.User.Email,
                  request.Username,
                  request.Password,
              });
            return response;
        }
    }
}