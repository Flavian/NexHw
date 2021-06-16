using System.Collections.Generic;

namespace NexHw.Interfaces
{
    public interface IVehicle
    {
        int ID { get; }
        List<string> JobTypes { get; }
    }
}
