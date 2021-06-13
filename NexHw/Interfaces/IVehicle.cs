using System.Collections.Generic;

namespace NexHw.Interfaces
{
    interface IVehicle
    {
        int ID { get; }
        List<string> JobTypes { get; }

    }
}
