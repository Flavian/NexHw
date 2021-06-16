using NexHw.BLL.SimpleJobFinder;
using NexHw.DAL;
using NexHw.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace NexHw
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<IVehicle> vehicles = new List<IVehicle> 
            //{ 
            //    new Vehicle(1, new List<string> { "A", "B" }),
            //    new Vehicle(2, new List<string> { "A" })
            //};

            //List<IJob> jobs = new List<IJob>
            //{
            //    new Job(1,"A"),
            //    new Job(2,"B")
            //};

            List<IVehicle> vehicles = new List<IVehicle>();
            List<IJob> jobs = new List<IJob>();

            using (var sr = new StreamReader("mediordev.txt"))
            {
                var vlengthString = sr.ReadLine();
                var vlength = int.Parse(vlengthString);
                for (int i = 0; i < vlength; i++)
                {
                    var str = sr.ReadLine();
                    var splitted = str.Split(' ');
                    int id = int.Parse(splitted[0]);

                    var jobTypes = new List<string>();
                    for (int j = 1; j < splitted.Length; j++)
                    {
                        jobTypes.Add(splitted[j]);
                    }

                    vehicles.Add(new Vehicle(id, jobTypes));
                }

                var jlengthString = sr.ReadLine();
                var jlength = int.Parse(jlengthString);
                for (int i = 0; i < vlength; i++)
                {
                    var str = sr.ReadLine();
                    var splitted = str.Split(' ');
                    int id = int.Parse(splitted[0]);

                    var jobType = splitted[1];

                    jobs.Add(new Job(id, jobType));
                }



            }

            var finder = new SimpleJobFinderStrategy(vehicles, jobs);
            finder.Find();
            var results = finder.Result;

            foreach (var result in results)
            {
                System.Console.WriteLine(result.ToString());
            }

        }
    }
}
