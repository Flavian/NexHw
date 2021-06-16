using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.BLL.SimpleJobFinder
{
    public class SimpelFinderVehicle : IVehicle
    {
        public IVehicle Vehicle { get; }

        public int ID
        {
            get
            {
                return Vehicle.ID;
            }
        }

        public List<string> JobTypes
        {
            get
            {
                return Vehicle.JobTypes;
            }
        }

        public string ActualJobType {
            get
            {
                return ActualJobTypeIndex >= JobTypes.Count ? JobTypes.Last(): JobTypes[ActualJobTypeIndex];
            }
        }

        public int ActualJobTypeIndex { get; private set; }

        public IJob Job{ get; private set;}

        /// <summary>
        /// Return True if the vehicle has unchecked job type
        /// </summary>
        public bool HasMoreJobType
        {
            get
            {
                return Vehicle.JobTypes.Count > ActualJobTypeIndex;
            }
        }

        public SimpelFinderVehicle(IVehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public void SetJob(IJob matchedJob)
        {
            Job = matchedJob;
        }

        public bool NextJob()
        {
            if (HasMoreJobType)
            {
                ActualJobTypeIndex++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Set vehicle to unmached
        /// </summary>
        public void Reset()
        {
            ActualJobTypeIndex = 0;
            Job = null;
        }
    }
}
