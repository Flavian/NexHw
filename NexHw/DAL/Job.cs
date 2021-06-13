using NexHw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
