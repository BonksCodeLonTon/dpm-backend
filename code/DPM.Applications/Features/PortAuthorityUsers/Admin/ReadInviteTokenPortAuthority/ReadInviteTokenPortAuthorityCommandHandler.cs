﻿using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.PortAuthorityUsers.Admin.ReadInviteTokenPortAuthority
{
    internal class ReadInviteTokenPortAuthorityCommandHandler : IRequestHandler<ReadInviteTokenPortAuthorityCommand, string>
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public ReadInviteTokenPortAuthorityCommandHandler(
          IJwtService jwtService,
          IUserRepository userRepository
            )
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }


        public async Task<string> Handle(ReadInviteTokenPortAuthorityCommand request, CancellationToken cancellationToken)
        {
            var claims = _jwtService.Decode(request.Token);
            long userId = long.Parse(claims.First(c => c.Type == "userId").Value);
            string role = claims.First(c => c.Type == "role").Value;
            var user = _userRepository.GetById(userId)
                          ?? throw new NotFoundException(nameof(User));
            user.Role = (Role)Enum.Parse(typeof(Role), role);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return Constants.AppDomain;
        }
    }
}
