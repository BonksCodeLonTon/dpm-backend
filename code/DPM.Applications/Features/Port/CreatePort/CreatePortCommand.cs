using AutoMapper;
using FluentValidation;
using MediatR;

namespace DPM.Applications.Features.Port.CreatePort
{
    public class CreatePortCommand : IRequest<Domain.Entities.Port>
    {
        public string? Name { get; set; }
    }
    public class CreatePortCommandProfile : Profile
    {
        public CreatePortCommandProfile()
        {
            CreateMap<CreatePortCommand, Domain.Entities.Port>();
        }
    }
    public class CreateShipCommandValidator : AbstractValidator<CreatePortCommand>
    {
        public CreateShipCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
