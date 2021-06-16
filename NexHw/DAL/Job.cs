using NexHw.Interfaces;
using System;

namespace NexHw.DAL
{
    public class Job : IJob
    {
        public int ID { get; }
        public string Type { get; }

        public Job(int id, string type)
        {
            ID = id;
            Type = type;
        }        
    }
}
