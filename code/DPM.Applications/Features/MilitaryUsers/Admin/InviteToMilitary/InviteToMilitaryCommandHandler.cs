using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.MilitaryUsers.Admin.InviteToMilitary
{
    public class InviteToMilitaryCommandHandler : IRequestHandler<InviteToMilitaryCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IRequestContextService _requestContextService;
        public InviteToMilitaryCommandHandler(
            IUserRepository userRepository,
            IJwtService jwtService,
            IEmailService emailService,
            IRequestContextService requestContextService
        )
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _emailService = emailService;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(InviteToMilitaryCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId, ReadConsistency.Cached)
              ?? throw new NotFoundException(nameof(User));
            if (user.Role == Role.Military)
            {
                throw new ConflictException(nameof(User));
            }
            var token = _jwtService.Encode(new[]
                {
                  new System.Security.Claims.Claim("userId", request.UserId.ToString()),
                  new System.Security.Claims.Claim("role", Role.Military.ToString())
                });
            await _emailService.SendEmailAsync(
                  new[] { user.Email },
                  nameof(EmailType.InviteToJoinMilitary),
                  new
                  {
                      senderName = _requestContextService.User.FullName?.Split(' ')?[0] ?? _requestContextService.User.Email,
                      token = $"{Constants.AppDomain}/Military/invite?token={token}",
                  });
            return true;
        }
    }
}
