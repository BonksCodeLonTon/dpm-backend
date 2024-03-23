using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.UpdatePort
{
    public class UpdatePortCommand : IRequest<Domain.Entities.Port>
    {
        public long Id {  get; set; }
        public string? Name { get; set; }
    }
    public class UpdatePortCommandProfile : Profile
    {
        public UpdatePortCommandProfile()
        {
            CreateMap<UpdatePortCommand, Domain.Entities.Port>();
        }
    }

    public class UpdateTeamCommandValidator : AbstractValidator<UpdatePortCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().MaximumLength(64);
        }
    }
}
