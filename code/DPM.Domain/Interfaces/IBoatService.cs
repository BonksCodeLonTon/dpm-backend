using DPM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Interfaces
{
    public interface IBoatService
    {
        IEnumerable<Ship> GetAllBoats();
        Ship GetBoatById(long id);
        Task AddBoat(Ship boat);
        Task UpdateBoat(Ship boat);
        Task DeleteBoat(long id);
    }
}
