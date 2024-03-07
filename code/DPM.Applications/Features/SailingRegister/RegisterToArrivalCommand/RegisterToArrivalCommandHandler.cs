using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.RegisterToArrivalCommand
{
    internal class RegisterToArrivalCommandHandler : IRequestHandler<RegisterToArrivalCommand, bool>
    {
        public Task<bool> Handle(RegisterToArrivalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
