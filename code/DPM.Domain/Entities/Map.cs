using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class Map : BaseEntity, ISoftDeletableEntity
    {
        public long ShipId { get; set; }
        public Ship? Ship { get; set; }
        public List<long>? Position { get; set; }
        public bool IsDeleted { get => ((ISoftDeletableEntity)Ship).IsDeleted; set => ((ISoftDeletableEntity)Ship).IsDeleted = value; }
    }
}
