using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.UpdateArrivalRegistrationById
{
    public class UpdateArrivalRegistrationByIdCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
        public string Attachment { get; set; }
    }
}
