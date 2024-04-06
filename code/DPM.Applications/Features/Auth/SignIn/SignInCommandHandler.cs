using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.SignIn
{
    internal class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authService;
        public SignInCommandHandler(IUserRepository userRepository, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _userRepository
              .GetAll()
              .Any(u => u.Username == request.Username || u.Email == request.Username && !u.IsDisabled);
            if (!isExisted)
            {
                throw new NotFoundException(nameof(User));
            }

            SignInResponse response = await _authService.SignInAsync(request.Username, request.Password);

            await _userRepository.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
    