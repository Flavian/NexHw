using NexHw.Interfaces;
using System.Collections.Generic;

namespace NexHw.DAL
{
    public class Vehicle : IVehicle
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
