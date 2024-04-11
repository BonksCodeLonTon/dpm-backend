using DPM.Applications.Features.Users.GetUsers;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.GetCaptainUsers
{
    internal class GetCaptainUsersQueryHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public GetCaptainUsersQueryHandler(IUserRepository userRepository, IRegisterArrivalRepository registerArrivalRepository, IRegisterDepartureRepository registerDepartureRepository)
        {
            _userRepository = userRepository;
            _registerArrivalRepository = registerArrivalRepository;
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<IQueryable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = _userRepository.GetAll(ReadConsistency.Eventual);

            var arrivalCaptainIds = await _registerArrivalRepository.GetAll(ReadConsistency.Eventual)
                .Where(x => x.CaptainId != null)
                .Select(x => x.CaptainId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var departureCaptainIds = await _registerDepartureRepository.GetAll(ReadConsistency.Eventual)
                .Where(x => x.CaptainId != null)
                .Select(x => x.CaptainId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var captainIds = arrivalCaptainIds.Concat(departureCaptainIds).Distinct().ToList();

            return allUsers.Where(u => captainIds.Contains(u.Id));
        }
    }
}