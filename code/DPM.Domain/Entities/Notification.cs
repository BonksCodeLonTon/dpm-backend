using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class Notification
    {
        public long UserId { get; set; }
        public string Key { get; set; } = default!;
        public JsonElement Data { get; set; } = default!;
        public bool IsRead { get; set; } = default!;
        public User? User { get; set; }
    }
}
