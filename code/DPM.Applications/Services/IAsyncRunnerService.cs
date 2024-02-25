using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Services
{
    public interface IAsyncRunnerService
    {
        void Run<TService>(Func<TService, Task> func) where TService : class;

    }
}
