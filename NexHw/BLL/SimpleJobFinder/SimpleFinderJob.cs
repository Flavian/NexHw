using NexHw.DAL;
using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.BLL.SimpleJobFinder
{
    public class SimpleFinderJob : IJob
    {
        IJob _job;

        public int ID
        {
            get
            {
                return _job.ID;
            }
        }
        public string Type 
        {
            get
            {
                return _job.Type;
            }
        }
        public IVehicle ActualVehicle { get; set; }

        public SimpleFinderJob(IJob job)
        {
            _job = job;
        }
    }
}
