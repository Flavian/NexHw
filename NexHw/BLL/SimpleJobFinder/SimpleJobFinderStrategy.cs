using NexHw.DAL;
using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexHw.BLL.SimpleJobFinder
{
    public class SimpleJobFinderStrategy
    { 
        public List<SimpelFinderVehicle> Vehicles { get; }
        public List<SimpleFinderJob> Jobs { get; }

        public List<IResult> Result { get; }

        public SimpleJobFinderStrategy(List<IVehicle> vehicles, List<IJob> jobs)
        {
            Vehicles = new List<SimpelFinderVehicle>();
            Jobs = new List<SimpleFinderJob>();
            Result = new List<IResult>();

            Vehicles.AddRange(vehicles.Select(v => new SimpelFinderVehicle(v)));
            Jobs.AddRange(jobs.Select(j => new SimpleFinderJob(j)));         
        }

        public void Find()
        {
            if (Vehicles.Count == 0 || Jobs.Count == 0)
            {
                return;
            }

            int maxJobs = 0;
            int actualJobs = 0;
            var index = 0;
            do
            {
                //Console.WriteLine(index);
                var actualVehicle = Vehicles[index];
                var matchedJob = Jobs.FirstOrDefault(j => j.ActualVehicle == null && j.Type == actualVehicle.ActualJobType);
                if (matchedJob != null)
                {
                    actualVehicle.SetJob(matchedJob);
                    matchedJob.ActualVehicle = actualVehicle;
                    //mached a correct vehicle
                    actualJobs++;
                    if (actualJobs > maxJobs)
                    {
                        maxJobs = actualJobs;
                        Result.Clear();
                        Result.AddRange(Vehicles.Where(v => v.Job != null).Select(v=> new Result(v.Vehicle, v.Job)));
                    }
                    if (Result.Count == Jobs.Count)
                    {
                        //all job has vehicle
                        break;
                    }
                }

                // step back
                index++;
                if (index == Vehicles.Count)
                {
                    index = Vehicles.Count - 1; // index of last item
                    
                    while (index >= 0)
                    {
                        SimpleFinderJob job;
                        if (Vehicles[index].Job!= null && Vehicles[index].HasMoreJobType)
                        {
                            Vehicles[index].NextJob();
                            job = Vehicles[index].Job as SimpleFinderJob;
                            if (job != null) job.ActualVehicle = null;
                            break;
                        }
                          
                        job = Vehicles[index].Job as SimpleFinderJob;
                        if(job != null) job.ActualVehicle = null;
                        Vehicles[index].Reset();
                        index--;
                    }

                    if (index < 0)
                    {
                        //all combination was checked
                        break;
                    }

                }
            } while (true);
        }

    }
}
