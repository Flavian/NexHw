using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.BLL.SimpleJobFinder
{
    class Result : IResult
    {
        public IVehicle Vehicle {get;}

        public IJob Job { get; }

        public Result(IVehicle vehicle, IJob job)
        {
            Vehicle = vehicle;
            Job = job;
        }

        public override string ToString()
        {
            return $"{Vehicle.ID} {Job.ID}";
        }
    }
}
