using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Job
    {
        public string JobName { get; set; }
        public int DifficultyLevel { get; set; }

        public Job(string jobName, int level)
        {
            this.JobName = jobName;
            this.DifficultyLevel = level;
        }
    }
}
