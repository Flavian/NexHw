using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.Interfaces
{
    public interface IResult
    {
        IVehicle Vehicle { get; }
        IJob Job { get; }
    }
}
