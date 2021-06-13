using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.Interfaces
{
    interface IVehicle
    {
        int ID { get; }
        List<string> JobTypes { get; }

    }
}
