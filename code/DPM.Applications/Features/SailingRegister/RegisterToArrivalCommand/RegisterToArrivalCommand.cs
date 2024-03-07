using AutoMapper;
using DPM.Applications.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using FluentValidation;
using MediatR;
using System.Text.RegularExpressions;

namespace DPM.Applications.Features.SailingRegister.RegisterToArrivalCommand
{
    public class RegisterToArrivalCommand : IRequest<bool>
    {
        public long RegisterById { get; set; }
        public long ShipId { get; set; }
        public long PortId { get; set; }
        public long CaptainId { get; set; }
        public ApproveStatus ApproveStatus { get; set; } = ApproveStatus.None;
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public bool IsStart { get; set; }

        public class RequestCommandValidator : AbstractValidator<RegisterToArrivalCommand>
        {
            public RequestCommandValidator()
            {
                RuleFor(x => x.ShipId).NotEmpty();
                RuleFor(v => v.RegisterById).NotEmpty();


            }
        }

        public class RegisterToArrivalCommandProfile : Profile
        {
            public RegisterToArrivalCommandProfile()
            {
                CreateMap<RegisterToArrivalCommand, RegisterToArrival>();
            }
        }
    }
}
