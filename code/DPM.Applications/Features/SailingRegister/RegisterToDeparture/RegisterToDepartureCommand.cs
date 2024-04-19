using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister
{
    public class RegisterToDepartureCommand : IRequest<string>
    {
        public long ShipId { get; set; }
        public long PortId { get; set; }
        public string? Attachment { get; set; }
        public long CaptainId { get; set; }
        public virtual long[]? CrewIds { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime GuessTimeArrival { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
        public string? Note { get; set; }
        public bool IsStart { get; set; }

        public class RequestCommandValidator : AbstractValidator<DepartureRegistration>
        {
            public RequestCommandValidator()
            {
                RuleFor(x => x.ShipId).NotEmpty();
            }
        }

        public class RegisterToArrivalCommandProfile : Profile
        {
            public RegisterToArrivalCommandProfile()
            {
                CreateMap<RegisterToDepartureCommand, DepartureRegistration>();
            }
        }
    }
}