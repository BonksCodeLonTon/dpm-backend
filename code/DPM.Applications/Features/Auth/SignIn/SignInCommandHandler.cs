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
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;
        public SignInCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _userRepository
              .GetAll()
              .Any(u => u.Username == request.Username);

            if (!isExisted)
            {
                throw new NotFoundException(nameof(User));
            }
            await _userRepository.SaveChangesAsync(cancellationToken);
            SignInResponse response = await _authService.SignInAsync(request.Username, request.Password);

            return response;
        }
    }
}
