using NexHw.Interfaces;
using System;

namespace NexHw.DAL
{
    class Job : IJob
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Job(int id, string type)
        {
            ID = id;
            Type = type;
        }        
    }
}
