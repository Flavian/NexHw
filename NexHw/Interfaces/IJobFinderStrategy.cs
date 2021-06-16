using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJobFinderStrategy
{
    interface IJobFinderStrategy
    {
        List<IVehicle> Mathces { get; set; }
        void Match();
    }

    
}
