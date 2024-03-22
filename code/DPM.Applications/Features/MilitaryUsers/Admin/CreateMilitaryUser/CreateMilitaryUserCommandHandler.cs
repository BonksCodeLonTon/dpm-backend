using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.CreateMilitaryUser
{
    public class CreateMilitaryUserCommandHandler : IRequestHandler<CreateMilitaryUserCommand, CreateMilitaryUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;


        public CreateMilitaryUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<CreateMilitaryUserResponse> Handle(CreateMilitaryUserCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _userRepository
              .GetAll()
              .Any(u => u.Username == request.Username || u.Email == request.Email);

            if (isExisted)
            {
                throw new ConflictException(nameof(User));
            }

            var sub = await _authService.CreateUserAsync(request.Email, request.Username, request.Password);
            var user = _mapper.Map<CreateMilitaryUserCommand, User>(request);
            user.CognitoSub = sub;
            user.Role = Role.Military;
            user.RoleType = RoleType.User;
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            var response = new CreateMilitaryUserResponse { Id = user.Id };
            return response;
        }
    }
}
