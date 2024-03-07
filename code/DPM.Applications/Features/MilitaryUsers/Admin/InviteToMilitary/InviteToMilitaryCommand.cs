using MediatR;
using DPM.Applications.Services;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.Admin.InviteToMilitary
{
    public class InviteToMilitaryCommand : IRequest<bool>
    {
        public long UserId { get; set; }

    }
}
