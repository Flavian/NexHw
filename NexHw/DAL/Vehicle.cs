using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.DAL
{
    class Vehicle : IVehicle
    {
        public int ID { get; }

        public List<string> JobTypes { get; }

        public Vehicle(int id, List<string> jobTypes)
        {
            ID = id;
            JobTypes = jobTypes;
        }
    }
}
